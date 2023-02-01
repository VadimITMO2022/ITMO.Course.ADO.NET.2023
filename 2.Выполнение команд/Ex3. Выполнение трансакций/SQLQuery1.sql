USE Northwind;
DELETE FROM dbo.Products WHERE ProductName = 'Wrong color';
DELETE FROM dbo.Products WHERE ProductName = 'Wrong size';
SELECT * FROM dbo.Products;


