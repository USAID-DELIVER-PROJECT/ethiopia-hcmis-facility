CREATE PROCEDURE [dbo].[GetConsumptionTrendByMonth] 
	-- Add the parameters for the stored procedure here
	@year int, 
	@storeid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @todate datetime
	declare @fromdate datetime
	declare @tempdate datetime
	declare @pyr int
	
	select @tempdate =  cast('10/30/' + cast(@year as varchar) as datetime)
	select @todate = cast(@tempdate as datetime)
	select @fromdate = cast('11/1/' + (cast((@year - 1) as varchar)) as datetime)
	select @pyr = @year - 1


    -- Insert statements for procedure here
select PivTable.ItemId, isnull([11],0) as [11],isnull([12],0) as [12] , isnull([1],0) as [1],isnull([2],0) as [2],isnull([3],0) as [3],isnull([4],0) as [4],isnull([5],0) as [5],
	isnull([6],0) as [6], isnull([7],0) as [7],isnull([8],0) as [8],isnull([9],0) as [9],isnull([10],0) as [10], storeId,
	case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as EverReceived,
	( isnull(bb.Quantity,0) + isnull(rd.Quantity,0) + isnull(adj.Quantity,0) - isnull(id.Quantity,0) - isnull(loss.Quantity,0)) as SOH, vw.*
from vwGetAllItems vw left outer join(
select ItemId, MONTH(DATE)as mon, StoreId, Quantity
from IssueDoc where StoreId = @StoreId and ((YEAR(Date) = @Year and MONTH(Date) != 11 and MONTH(Date) != 12) or (YEAR(Date) = @pyr and (MONTH(Date) = 11 )) or (YEAR(Date) = @pyr and MONTH(Date) = 12) )) as IssDoc
pivot (
Sum(Quantity) for mon in ([11],[12],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10])
) as pivTable on ItemID = vw.ID
left join 
		(select ItemID , sum(Quantity) Quantity, sum(QuantityLeft) QuantityLeft from ReceiveDoc 
		where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as rd on rd.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from IssueDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as id on id.ItemID = vw.ID 
		left join
		(select ItemID , sum(PhysicalInventory) Quantity from YearEnd where StoreID = @storeid and Year = Year(@fromdate)  group by ItemID ) as bb on bb.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 1 group by ItemID ) as loss on loss.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 0 group by ItemID ) as adj on adj.ItemID = vw.ID 
where vw.IsInHospitalList = 1 
order by vw.FullItemName
END

Go
