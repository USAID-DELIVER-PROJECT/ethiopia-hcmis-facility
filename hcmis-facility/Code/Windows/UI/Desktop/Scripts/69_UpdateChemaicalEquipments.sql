Update Items 
Set NeedExpiryBatch = 0
where ID in (
Select i.ID from Items i join Product p on i.IINID = p.ID where p.TypeID = 9
)