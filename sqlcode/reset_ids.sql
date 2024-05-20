DECLARE @TableName NVARCHAR(128)
DECLARE @Command NVARCHAR(300)

DECLARE ResetSeeder CURSOR FOR
SELECT OBJECT_SCHEMA_NAME([object_id])+'.'+name AS TableName
FROM sys.tables
WHERE OBJECTPROPERTY([object_id],'TableHasIdentity') = 1
OPEN ResetSeeder

FETCH NEXT FROM ResetSeeder INTO @TableName
WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT @Command = 'DBCC CHECKIDENT (''' + @TableName + ''', RESEED, 0)'
    EXEC sp_executesql @Command
    FETCH NEXT FROM ResetSeeder INTO @TableName
END

CLOSE ResetSeeder
DEALLOCATE ResetSeeder