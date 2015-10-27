CREATE VIEW [dbo].[vwGetReceivedItems]
AS
SELECT        dbo.ReceiveDoc.ID, dbo.ReceiveDoc.BatchNo, dbo.ReceiveDoc.ItemID, dbo.ReceiveDoc.SupplierID, dbo.ReceiveDoc.Quantity, dbo.ReceiveDoc.Date, 
                         dbo.ReceiveDoc.ExpDate, dbo.ReceiveDoc.Out, dbo.ReceiveDoc.ReceivedStatus, dbo.ReceiveDoc.ReceivedBy, dbo.ReceiveDoc.Remark, dbo.ReceiveDoc.StoreID, 
                         dbo.ReceiveDoc.LocalBatchNo, dbo.ReceiveDoc.RefNo, dbo.ReceiveDoc.Cost, dbo.ReceiveDoc.IsApproved, dbo.ReceiveDoc.ManufacturerId, 
                         dbo.ReceiveDoc.QuantityLeft, dbo.ReceiveDoc.NoOfPack, dbo.ReceiveDoc.QtyPerPack, dbo.ReceiveDoc.EurDate, dbo.ReceiveDoc.BoxLevel, 
                         dbo.ReceiveDoc.SubProgramID, dbo.vwGetAllItems.TypeID, dbo.vwGetAllItems.FullItemName, dbo.vwGetAllItems.Name AS TypeName, 
                         dbo.vwGetAllItems.StockCode
FROM            dbo.ReceiveDoc INNER JOIN
                         dbo.vwGetAllItems ON dbo.ReceiveDoc.ItemID = dbo.vwGetAllItems.ID