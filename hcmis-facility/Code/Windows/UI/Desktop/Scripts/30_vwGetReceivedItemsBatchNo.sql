ALTER VIEW [dbo].[vwGetReceivedItemsByBatch]
AS
SELECT     TOP (100) PERCENT ISNULL(dbo.Product.IIN, '') + ' - ' + ISNULL(dbo.DosageForm.Form, '') + ' - ' + ISNULL(dbo.Items.Strength, '') AS FullItemName, 
                      dbo.Product.IIN AS ItemName, dbo.Product.ATC, dbo.Items.Strength, dbo.Items.ABC AS ABCID, dbo.ABC.Value AS ABC, dbo.VEN.Value AS VEN, 
                      dbo.Items.VEN AS VENID, dbo.Items.IsFree, dbo.Items.IsDiscontinued, dbo.Items.EDL, dbo.Items.Refrigeratored, dbo.Items.Pediatric, dbo.Items.DosageFormID, 
                      dbo.DosageForm.Form AS DosageForm, dbo.Items.UnitID, dbo.Unit.Unit, dbo.Items.StockCode, dbo.Items.IINID, dbo.Items.IsInHospitalList, dbo.ReceiveDoc.BatchNo, 
                      dbo.ReceiveDoc.Quantity, dbo.ReceiveDoc.Date, dbo.ReceiveDoc.ExpDate, dbo.ReceiveDoc.Out, dbo.ReceiveDoc.StoreID, dbo.ReceiveDoc.RefNo, 
                      dbo.ReceiveDoc.Cost, dbo.ReceiveDoc.QuantityLeft, dbo.Product.TypeID, dbo.Type.Name, dbo.Items.StockCodeDACA, dbo.Items.Code, dbo.Items.NeedExpiryBatch, 
                      dbo.ReceiveDoc.EurDate, dbo.ReceiveDoc.QtyPerPack, dbo.ReceiveDoc.NoOfPack, dbo.ReceiveDoc.ID AS ReceiveID, dbo.ProductsCategory.SubCategoryID, 
                      dbo.Items.ID, dbo.SubCategory.CategoryId, dbo.SubCategory.SubCategoryName, dbo.SubCategory.SubCategoryCode, dbo.Category.CategoryName, 
                      dbo.Category.CategoryCode, dbo.DisposalReasons.Reason, dbo.Disposal.ReasonId
FROM         dbo.SubCategory INNER JOIN
                      dbo.ProductsCategory ON dbo.SubCategory.ID = dbo.ProductsCategory.SubCategoryID INNER JOIN
                      dbo.DosageForm INNER JOIN
                      dbo.ABC RIGHT OUTER JOIN
                      dbo.Items ON dbo.ABC.ID = dbo.Items.ABC LEFT OUTER JOIN
                      dbo.VEN ON dbo.Items.VEN = dbo.VEN.ID ON dbo.DosageForm.ID = dbo.Items.DosageFormID INNER JOIN
                      dbo.Unit ON dbo.Items.UnitID = dbo.Unit.ID INNER JOIN
                      dbo.Product ON dbo.Items.IINID = dbo.Product.ID INNER JOIN
                      dbo.ReceiveDoc ON dbo.Items.ID = dbo.ReceiveDoc.ItemID INNER JOIN
                      dbo.Type ON dbo.Product.TypeID = dbo.Type.ID ON dbo.ProductsCategory.ItemId = dbo.Items.ID INNER JOIN
                      dbo.Category ON dbo.SubCategory.CategoryId = dbo.Category.ID INNER JOIN
                      dbo.Disposal ON dbo.Items.ID = dbo.Disposal.ItemID INNER JOIN
                      dbo.DisposalReasons ON dbo.Disposal.ReasonId = dbo.DisposalReasons.ID