declare @ItemsXML xml ='<DisposalReasons>
  <DisposalReason>
    <ID>1</ID>
    <Reason>Expired</Reason>
    <Description>Expiry date</Description>
  </DisposalReason>
  <DisposalReason>
    <ID>2</ID>
    <Reason>Damaged</Reason>
  </DisposalReason>
  <DisposalReason>
    <ID>3</ID>
    <Reason>Low Quality</Reason>
  </DisposalReason>
  <DisposalReason>
    <ID>4</ID>
    <Reason>Lost</Reason>
  </DisposalReason>
  <DisposalReason>
    <ID>5</ID>
    <Reason>Found</Reason>
  </DisposalReason>
  <DisposalReason>
    <ID>6</ID>
    <Reason>Returned</Reason>
  </DisposalReason>
  <DisposalReason>
    <ID>7</ID>
    <Reason>Data Entry Error</Reason>
  </DisposalReason>
  <DisposalReason>
    <ID>8</ID>
    <Reason>Inventory</Reason>
  </DisposalReason>
  <DisposalReason>
    <ID>9</ID>
    <Reason>Transfer</Reason>
    <Description>Transfer to Other Health Facility</Description>
  </DisposalReason>
</DisposalReasons>'

SET IDENTITY_INSERT DisposalReasons ON
;merge DisposalReasons as T
using
(
select T.N.value('ID[1]', 'int') as ID,
T.N.value('Reason[1]', 'nvarchar(200)') as Reason,
T.N.value('Description[1]', 'nvarchar(2000)') as [Description]
from @ItemsXML.nodes('/DisposalReasons/DisposalReason') T(N)
) as S
on T.ID = S.ID

when matched then
update set Reason = S.Reason,[Description]=S.[Description]
when not matched then
insert (ID, Reason,[Description]) values (S.ID, S.Reason, S.[Description])
;
SET IDENTITY_INSERT DisposalReasons OFF