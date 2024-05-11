DECLARE @TableName NVARCHAR(255)
DECLARE @SQL NVARCHAR(MAX)

-- Declare a cursor to loop through all table names
DECLARE TableCursor CURSOR FOR
SELECT name
FROM sys.tables

-- Open the cursor
OPEN TableCursor

-- Fetch the first table name from the cursor
FETCH NEXT FROM TableCursor INTO @TableName

-- Start looping through tables
WHILE @@FETCH_STATUS = 0
BEGIN
    -- Build the dynamic SQL statement
    SET @SQL = 'SELECT * FROM ' + QUOTENAME(@TableName)
    
    -- Execute the dynamic SQL
    EXEC sp_executesql @SQL
    
    -- Fetch the next table name
    FETCH NEXT FROM TableCursor INTO @TableName
END

-- Close and deallocate the cursor
CLOSE TableCursor
DEALLOCATE TableCursor
