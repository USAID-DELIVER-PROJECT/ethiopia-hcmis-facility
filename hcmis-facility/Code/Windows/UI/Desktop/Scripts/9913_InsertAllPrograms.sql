  SET IDENTITY_INSERT Programs ON
  INSERT INTO Programs (ID,Name,[Description],ParentID,ProgramCode)
  VALUES (1000,'All Programs','All Programs',11,null);
  SET IDENTITY_INSERT Programs OFF