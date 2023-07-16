# GeometryLibrary
Test task in the company

Task:

Write a C# library for external clients that can calculate the area of a circle based on its radius and the area of a triangle based on its three sides.

Additionally, the following criteria will be evaluated:
  1) Unit tests
  2) Ease of adding other shapes
  3) Calculation of the area without knowledge of the shape type at compile-time
  4) Checking if a triangle is right-angled

Question #2:
In the MS SQL Server database, there are products and categories.
A product can correspond to multiple categories, and a category can have multiple products.
Write an SQL query to select all pairs of "Product Name - Category Name". If a product has no categories, its name should still be displayed.

Answer.

SELECT P.Name AS ProductName, C.Name AS CategoryName
FROM Products P
LEFT JOIN ProductCategory PC ON P.ProductId = PC.ProductId
LEFT JOIN Categories C ON PC.CategoryId = C.CategoryId;
