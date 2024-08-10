SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO northwindrepl.dbo.Products 
(ProductId, ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
SELECT ProductId + 80, ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued
FROM northwind.dbo.Products;
SET IDENTITY_INSERT [dbo].[Products] OFF