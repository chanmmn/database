USE [test]
GO
/****** Object:  StoredProcedure [dbo].[Customers_Cursor1]    Script Date: 16/3/2022 11:40:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Customers_Cursor1]
AS
BEGIN
      SET NOCOUNT ON;
 
      --DECLARE THE VARIABLES FOR HOLDING DATA.
      DECLARE @CustomerId INT
             ,@Name VARCHAR(100)
             ,@Country VARCHAR(100)
 
      --DECLARE AND SET COUNTER.
      DECLARE @Counter INT
      SET @Counter = 1
 
      --DECLARE THE CURSOR FOR A QUERY.
      DECLARE PrintCustomers CURSOR READ_ONLY
      FOR
      SELECT CustomerId, Name, Country
      FROM Customers
 
      --OPEN CURSOR.
      OPEN PrintCustomers
 
      --FETCH THE RECORD INTO THE VARIABLES.
      FETCH NEXT FROM PrintCustomers INTO
      @CustomerId, @Name, @Country
 
      --LOOP UNTIL RECORDS ARE AVAILABLE.
      WHILE @@FETCH_STATUS = 0
      BEGIN
             --IF @Counter = 1
             --BEGIN
             --           PRINT 'CustomerID' + CHAR(9) + 'Name' + CHAR(9) + CHAR(9) + CHAR(9) + 'Country'
             --           PRINT '------------------------------------'
             --END
 
             ----PRINT CURRENT RECORD.
             --PRINT CAST(@CustomerId AS VARCHAR(10)) + CHAR(9) + CHAR(9) + CHAR(9) + @Name + CHAR(9) + @Country
    
             ----INCREMENT COUNTER.
             --SET @Counter = @Counter + 1
			SELECT  @CustomerId, @Name, @Country
             ----FETCH THE NEXT RECORD INTO THE VARIABLES.
             FETCH NEXT FROM PrintCustomers INTO
             @CustomerId, @Name, @Country
			 
      END
 
      --CLOSE THE CURSOR.
      CLOSE PrintCustomers
      DEALLOCATE PrintCustomers
END
