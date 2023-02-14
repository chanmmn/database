USE [Northwind]
GO

/****** Object:  StoredProcedure [dbo].[uspCountOrders]    Script Date: 13/2/2023 11:39:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspCountOrders] 
	-- Add the parameters for the stored procedure here
	@orderid As int,
	@count As Int Output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @count = COUNT(OrderID) FROM [Order Details] WHERE OrderID = @orderid
END
GO


