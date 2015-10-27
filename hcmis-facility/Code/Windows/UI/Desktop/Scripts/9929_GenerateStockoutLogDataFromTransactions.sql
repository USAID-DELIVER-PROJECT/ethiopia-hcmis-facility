truncate table StockoutLog

declare @storeId int, @itemId int, @recieveDocId varchar, @lastRecieveDate date, @lastIssueDate date, 
	@quantityRecieved int, @issuedQuantity int, @quantityLeft int;

declare stockoutLog_cursor cursor for 
WITH ItemTransaction (StoreID, ItemID, RecievDocID, LastRecieveDate, LastIssueDate)
AS
(
	select StoreId, ItemID, RecievDocID, 
		(select MAX(EurDate) from ReceiveDoc rd where rd.ID = id.RecievDocID) LastRecieveDate, 
		MAX(EurDate) LastIssueDate
	from IssueDoc id
	group by StoreId, ItemID, RecievDocID
)
select StoreID, ItemID, LastRecieveDate, MAX(LastIssueDate) LastIssueDate
from ItemTransaction it
where it.LastIssueDate is not null
group by StoreId, ItemID, LastRecieveDate
order by StoreId, ItemID, LastRecieveDate, LastIssueDate

open stockoutLog_cursor

fetch next from stockoutLog_cursor
into @storeId, @itemId, @lastRecieveDate, @lastIssueDate

WHILE @@FETCH_STATUS = 0
BEGIN
    --declare @innerStoreId int, @innerItemId int, @innerStartDate date;
	declare @stockoutLogId int;
	declare checkExistance_cursor cursor for
	select isnull(id, 0) from StockoutLog 
	where StoreID = @storeId and ItemID = @itemId and EndDate is null

	open checkExistance_cursor
	fetch next from checkExistance_cursor
	into @stockoutLogId

	if @@FETCH_STATUS = 0
	begin
		if (@lastRecieveDate > @lastIssueDate)
		begin
			update stockoutLog set enddate = + cast(@lastRecieveDate as nvarchar) where Id = @stockoutLogId;
		end
		else
		begin
			update stockoutLog set enddate = StartDate where Id = @stockoutLogId;
		end
		insert into stockoutLog(storeid, itemid, startdate) values(@storeId, @itemId, @lastIssueDate);
	end
	else
		begin
			insert into stockoutLog(storeid, itemid, startdate) values(@storeId, @itemId, @lastIssueDate);
		end

	CLOSE checkExistance_cursor;
	DEALLOCATE checkExistance_cursor;
    
    -- Get the next transaction.
	fetch next from stockoutLog_cursor
	into @storeId, @itemId, @lastRecieveDate, @lastIssueDate
END 
CLOSE stockoutLog_cursor;
DEALLOCATE stockoutLog_cursor;

--truncate table stockoutLog
--select * from stockoutLog