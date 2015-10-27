ALTER VIEW [dbo].[vwGetAllItems]
AS
SELECT DISTINCT 
					  dbo.Items.ID
					  , ISNULL(dbo.Product.IIN, '') + ' - ' + ISNULL(dbo.DosageForm.Form, '') + ' - ' + ISNULL(dbo.Items.Strength, '') AS FullItemName
					  , dbo.Product.IIN AS ItemName
					  , dbo.Product.ATC
					  , dbo.Items.Strength
					  , dbo.Items.ABC AS ABCID
					  , dbo.ABC.Value AS ABC
					  , dbo.VEN.Value AS VEN
					  , dbo.Items.VEN AS VENID
					  , dbo.Items.IsFree
					  , dbo.Items.IsDiscontinued
					  , dbo.Items.EDL
					  , dbo.Items.Refrigeratored
					  , dbo.Items.Pediatric
					  , dbo.Items.DosageFormID
					  , dbo.DosageForm.Form AS DosageForm
					  , dbo.Items.UnitID
					  , dbo.Unit.Unit
					  , dbo.Items.StockCode
					  , dbo.Items.IINID
					  , dbo.Items.IsInHospitalList
					  , dbo.Product.TypeID
					  , dbo.Type.Name
					  , dbo.Items.StockCodeDACA
					  , dbo.Items.Cost
					  , dbo.Items.Code
					  , dbo.Items.NeedExpiryBatch
					  , dbo.Items.StorageTypeID
					  , dbo.Items.NearExpiryTrigger
					  --, dbo.SubCategory.CategoryId
					  --, PC.SubCategoryID
FROM				  
					  dbo.Product 
					  JOIN dbo.Items ON dbo.Items.IINID = dbo.Product.ID 
					  INNER JOIN dbo.DosageForm  ON dbo.DosageForm.ID = dbo.Items.DosageFormID 
					  LEFT JOIN dbo.ABC ON  dbo.Items.ABC =dbo.ABC.ID 
					  LEFT JOIN dbo.VEN ON dbo.Items.VEN = dbo.VEN.ID 
					  INNER JOIN dbo.Unit ON dbo.Items.UnitID = dbo.Unit.ID 
					  INNER JOIN dbo.[Type] ON dbo.Product.TypeID = dbo.Type.ID 
					  --LEFT JOIN  (
						--			select ItemID,max(SubCategoryID) SubCategoryID from dbo.ProductsCategory Group By ItemID
						--		 ) as PC ON dbo.Items.ID = PC.ItemId 
					 -- LEFT JOIN dbo.SubCategory ON PC.SubCategoryID = dbo.SubCategory.ID
							AND (dbo.Product.TypeID = 1 or dbo.Product.TypeID = 7)

Union  
SELECT DISTINCT 
					  dbo.Items.ID
					  , ISNULL(dbo.Product.IIN, '') + ' - ' + ISNULL(dbo.Items.Strength, '') AS FullItemName
					  , dbo.Product.IIN AS ItemName
					  , dbo.Product.ATC
					  , dbo.Items.Strength
					  , dbo.Items.ABC AS ABCID
					  , null AS ABC
					  , null AS VEN
					  , dbo.Items.VEN AS VENID
					  , dbo.Items.IsFree
					  , dbo.Items.IsDiscontinued
					  , dbo.Items.EDL
					  , dbo.Items.Refrigeratored
					  , dbo.Items.Pediatric
					  , dbo.Items.DosageFormID
					  , null AS DosageForm
					  , dbo.Items.UnitID
					  , dbo.Unit.Unit
					  , dbo.Items.StockCode
					  , dbo.Items.IINID
					  , dbo.Items.IsInHospitalList
					  , dbo.Product.TypeID
					  , dbo.Type.Name
					  , dbo.Items.StockCodeDACA
					  , dbo.Items.Cost
					  , dbo.Items.Code
					  , dbo.Items.NeedExpiryBatch
					  , dbo.Items.StorageTypeID
					  , dbo.Items.NearExpiryTrigger
					 -- , dbo.SupplyCategory.ParentId as CategoryID 
					 -- , dbo.ItemSupplyCategory.CategoryID as SubCategoryID 
FROM        
					  dbo.Items   
					  JOIN dbo.Unit ON dbo.Items.UnitID = dbo.Unit.ID  
					  JOIN  dbo.Product ON dbo.Items.IINID = dbo.Product.ID 
					  inner JOIN  dbo.Type ON dbo.Product.TypeID = dbo.Type.ID 
					 -- LEFT JOIN  dbo.ItemSupplyCategory ON dbo.Items.ID = dbo.ItemSupplyCategory.ItemID 
					 -- LEFT JOIN dbo.SupplyCategory on dbo.ItemSupplyCategory.CategoryID = dbo.SupplyCategory.ID 
								and (dbo.Product.TypeID <> 1 and dbo.Product.TypeID <> 7)
