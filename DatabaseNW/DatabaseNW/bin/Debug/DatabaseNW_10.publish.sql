﻿/*
Deployment script for DatabaseNW

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DatabaseNW"
:setvar DefaultFilePrefix "DatabaseNW"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering Table [dbo].[Categories]...';


GO
ALTER TABLE [dbo].[Categories]
    ADD [CategoryLongName] NCHAR (10) NULL;


GO
PRINT N'Refreshing View [dbo].[Alphabetical list of products]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[Alphabetical list of products]';


GO
PRINT N'Refreshing View [dbo].[Product Sales for 1997]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[Product Sales for 1997]';


GO
PRINT N'Refreshing View [dbo].[Products by Category]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[Products by Category]';


GO
PRINT N'Refreshing View [dbo].[Sales by Category]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[Sales by Category]';


GO
PRINT N'Refreshing View [dbo].[Category Sales for 1997]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[Category Sales for 1997]';


GO
PRINT N'Refreshing Procedure [dbo].[SalesByCategory]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[SalesByCategory]';


GO
PRINT N'Update complete.';


GO
