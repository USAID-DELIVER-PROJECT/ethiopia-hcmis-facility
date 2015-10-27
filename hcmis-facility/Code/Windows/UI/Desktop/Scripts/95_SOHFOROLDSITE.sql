
CREATE PROCEDURE [dbo].[SOHForRRF]
	@storeid int,
	@month int,
	@year int,
	@days int
AS
BEGIN
	declare @tempdate varchar(20)
	
	declare @amcrange int
	declare @min int
	declare @max int
	declare @eop float

	select  @amcrange = AMCRange,@eop = EOP, @min = MIN, @max = MAX from GeneralInfo 
	
	declare @rangedate datetime
	declare @todate datetime
	declare @fromdate datetime
	
	
	select @tempdate = cast(@month as varchar) + '/' + cast(@days as varchar) + '/' + cast(@year as varchar) 
	select @todate = cast(@tempdate as datetime)
	select @fromdate = case
				when MONTH(@todate)<=10 then cast('11/1/' + (cast((@year - 1) as varchar) ) as datetime)
				else cast('11/1/' + (cast((@year) as varchar) ) as datetime)
				end	
	select @rangedate = dateadd(month,0-@amcrange,@todate)
				
	select t.*, [Status] = case 
		when t.SOH is null or t.SOH = 0  then 'Stock Out'  
		when t.SOH < t.EOP then 'Below EOP'  
		when t.SOH <  (t.EOP * 1.25) then 'Near EOP' 
		when t.SOH > t.[Max] and t.AMC > 0 then 'Over Stocked' 
		else 'Normal' 
		end,
		(t.SOH - (t.Expired)) as Dispatchable
	from
	(select 
		case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as EverReceived, 
		isnull(rd.Quantity,0) as Received, 
		isnull(rd.QuantityLeft,0) as QuantityLeft,
		isnull(id.Quantity,0) as Issued,
		isnull(id2.Quantity,0) as IssuedMonth,
		isnull(loss.Quantity,0) as Lost, 
		isnull(adj.Quantity,0) as Adjusted , 
		isnull(amc.Quantity,0) as AMC ,
		isnull(dos.Quantity,0) as DOS ,
		 ( isnull(bb.Quantity,0) + isnull(rd.Quantity,0) + isnull(adj.Quantity,0) - isnull(id.Quantity,0) - isnull(loss.Quantity,0)) as SOH, 
		 isnull(amc.Quantity * @min, 0) as Min, 
		 isnull(amc.Quantity * @max,0) as Max, 
		 isnull(amc.Quantity * @eop,0) as EOP,
		 isnull(ed.Quantity,0) as Expired,
		 ISNULL(nEx.Quantity,0) as NearExpiry , 
		 vw.ID, vw.DSItemID, vw.FullItemName,vw.StockCode, vw.Unit,vw.Name as Type,vw.TypeID, p.ID as ProgramID, p.Name as ProgramName 
		from vwGetAllItems vw left join ProgramProduct pp on vw.ID = pp.ItemID left join Programs p on pp.ProgramID = p.ID left join 
		(select ItemID , sum(Quantity) Quantity, sum(QuantityLeft) QuantityLeft from ReceiveDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as rd on rd.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from IssueDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as id on id.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from IssueDoc where StoreID = @storeid and (year(date) = @year and MONTH(date) = @month) group by ItemID ) as id2 on id2.ItemID = vw.ID 
		left join
		(select ItemID , sum(PhysicalInventory) Quantity from YearEnd where StoreID = @storeid and Year = Year(@fromdate)  group by ItemID ) as bb on bb.ItemID = vw.ID 
		left join
		(select ItemID , sum(QuantityLeft) Quantity from ReceiveDoc where StoreID = @storeid and ExpDate < GETDATE() group by ItemID ) as ed on ed.ItemID = vw.ID 
		left join
		(select ItemID , sum(QuantityLeft) Quantity from ReceiveDoc rd join vwGetAllItems v on rd.ItemID=v.ID where StoreID = @storeid and ExpDate between GETDATE() and DATEADD(day,v.NearExpiryTrigger,GETDATE()) group by ItemID ) as nEx on nEx.ItemID = vw.ID		
		left join
		(select Max(AmcWithDos) as Quantity,ar.ItemID from AmcReport ar where ar.StoreID=@storeid group by ItemID)as amc on amc.ItemID = vw.ID 
		left join
		(select Max(DaysOutOfStock) as Quantity,ar.ItemID from AmcReport ar where ar.StoreID=@storeid group by ItemID)as dos on dos.ItemID = vw.ID 
	     left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 1 group by ItemID ) as loss on loss.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 0 group by ItemID ) as adj on adj.ItemID = vw.ID 
		where vw.IsInHospitalList = 1) 
		t order by t.FullItemName
END



