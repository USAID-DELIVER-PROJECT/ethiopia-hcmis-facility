
/****** Object:  StoredProcedure [dbo].[GetTransactionDetails]    Script Date: 10/29/2011 13:31:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTransactionDetails]
	-- Add the parameters for the stored procedure here
	  @storeid int,
	  @todate datetime,
	  @fromdate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	select t.*
	from
	(select 
		case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as Received, 
		isnull(rd.Quantity,0) as ReceivedQty, isnull(rd.Price,0) as ReceivedPrice, isnull(rd.QuantityLeft,0) as QuantityLeft, 
		isnull(id.Quantity,0) as IssuedQty, isnull(id.Price,0) as IssuedPrice,
		vw.ID, vw.FullItemName,vw.StockCode, vw.Unit,vw.Name as Type, p.ID as ProgramID, p.Name as ProgramName 
		from vwGetAllItems vw left join ProgramProduct pp on vw.ID = pp.ItemID left join Programs p on pp.ProgramID = p.ID left join 
		(select ItemID , sum(Quantity) Quantity, sum(QuantityLeft) QuantityLeft, SUM(Quantity * Cost) Price from ReceiveDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as rd on rd.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity, SUM(Quantity * Cost) Price from IssueDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as id on id.ItemID = vw.ID 
		
		where vw.IsInHospitalList = 1) t order by t.FullItemName
END

GO


