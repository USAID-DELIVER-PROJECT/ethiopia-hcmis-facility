INSERT INTO dbo.ProgramProduct
        ( ProgramID, ItemID ,UnitID )
(SELECT SubProgramID,ItemID ,UnitID 
FROM dbo.ReceiveDoc 
GROUP BY SubProgramID,ItemID ,UnitID)