IF EXISTS (SELECT * 
  FROM sys.foreign_keys 
   WHERE object_id = OBJECT_ID(N'dbo.FK_ReceivingUnits_Woreda')
   AND parent_object_id = OBJECT_ID(N'dbo.ReceivingUnits')
)
  ALTER TABLE [dbo].[ReceivingUnits] DROP CONSTRAINT [FK_ReceivingUnits_Woreda]