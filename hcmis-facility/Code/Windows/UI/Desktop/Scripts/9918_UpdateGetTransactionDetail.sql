ALTER PROCEDURE [dbo].[GetTransactionDetails]
	  @storeid int,
	  @todate datetime,
	  @fromdate datetime
AS
BEGIN
select t.*
	from
	(select 
		case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as Received, 
		isnull(rd.Quantity,0) as ReceivedQty, 
		isnull(rd.Price,0) as ReceivedPrice, 
		isnull(rd.QuantityLeft,0) as QuantityLeft, 
		isnull(rd.price1,0) as QuantityLeftPrice, 
		isnull(id.Quantity,0) as IssuedQty, 
		isnull(id.Price,0) as IssuedPrice,
		vw.ID, vw.FullItemName,vw.StockCode, 
		vw.Unit,vw.Name ,vw.TypeID as TypeID
		from vwGetAllItems vw  left join 
		(select ItemID , sum(Quantity) Quantity, sum(QuantityLeft) QuantityLeft, SUM(Quantity * Cost) Price ,Sum(QuantityLeft*Cost) price1 
		from ReceiveDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as rd on rd.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity, SUM(Quantity * Cost) Price 
		from IssueDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as id on id.ItemID = vw.ID 
		where vw.IsInHospitalList = 1) t order by t.FullItemName
END


