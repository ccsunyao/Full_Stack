/*Answer following questions
1.	What is a result set?
	A result set is a set of records, including not only the data itself, but also metadata like column names, types and sizes.

2.	What is the difference between Union and Union All?
	(1) Union will automatically clean up duplications, while Union All will not.
	(2) Union will sort the result by the order of first column by default, while Union will remain the original sequence by default. 

3.	What are the other Set Operators SQL Server has?
	UNION, UNION ALL, INTERSECT, EXCEPT, MINUS

4.	What is the difference between Union and Join?
	Join combine data into new columns; Union combine data into new rows.
	
	Union is used to combine multiple queries into a single query with all the records of queries and the same column forms. (Vertically)
	Join is used to combine data from multiple queries with the column names of all queries. The number of rows depends on the kinds of joins and the queries. (Horizontally)

5.	What is the difference between INNER JOIN and FULL JOIN?
	Inner join returns only the matching rows between both the tables, non matching rows are eliminated;
	Full Join returns all rows from both the tables (left & right tables), including non-matching rows from both the tables.

6.	What is difference between left join and right join
	Left join  returns all the rows from the LEFT table and matching records between both the tables.
	Full Join returns all rows from both the tables (left & right tables), including non-matching rows from both the tables.

7.	What is cross join?
	Cross join returns every combination of rows from two tables

8.	What is the difference between WHERE clause and HAVING clause?
	(1) WHERE clause is processed before GROUP BY clause while HAVING clause is executed after groups are created.
	(2) If used in GROUP BY, You can refer any column from a table in WHERE clause but you can only use columns which are not grouped or aggregated in HAVING.
    	(3) You can use an aggregate function to filter rows with HAVING clause isstead of WHERE clause
    	(4) WHERE will use Index and HAVING will not, so WHERE has a better performance

9.	Can there be multiple group by columns?
	yes
*/

/*
Write queries for following scenarios
1.	How many products can you find in the Production.Product table?
*/
USE AdventureWorks2017
SELECT COUNT(1)
FROM Production.Product
GO

/*
2.	Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
*/
USE AdventureWorks2017
SELECT COUNT(1)
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GO

/*
3.	How many Products reside in each SubCategory? Write a query to display the results with the following titles.
ProductSubcategoryID CountedProducts
-------------------- ---------------
*/
USE AdventureWorks2017
SELECT ProductSubcategoryID, COUNT(1) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID;
GO

/*
4.	How many products that do not have a product subcategory. 
*/
USE AdventureWorks2017
SELECT COUNT(1)
FROM Production.Product
WHERE ProductSubcategoryID IS NULL
GO

/*
5.	Write a query to list the summary of products quantity in the Production.ProductInventory table.
*/
USE AdventureWorks2017
SELECT SUM(Quantity)
FROM  Production.ProductInventory
GROUP BY ProductID
GO

/*
6.	 Write a query to list the summary of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
              ProductID    TheSum
-----------        ----------
*/
USE AdventureWorks2017
SELECT ProductID, SUM(Quantity)
FROM  Production.ProductInventory
WHERE LocationID = 40 
GROUP BY ProductID
HAVING SUM(Quantity) < 100
GO

/*
7.	Write a query to list the summary of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
Shelf      ProductID    TheSum
---------- -----------        -----------
*/
USE AdventureWorks2017 
SELECT Shelf, ProductID,  SUM(Quantity) AS Qty
FROM  Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID, Shelf
HAVING SUM(Quantity) < 100
GO

/*
8.	Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
*/
USE AdventureWorks2017 
SELECT ProductID, AVG(Quantity) 
FROM  Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID
GO

/*
9.	Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
ProductID   Shelf      TheAvg
----------- ---------- -----------
*/
USE AdventureWorks2017 
SELECT ProductID, Shelf, AVG(Quantity) AS Avg_Qty
FROM  Production.ProductInventory
GROUP BY ProductID, Shelf
GO

/*
10.	Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
ProductID   Shelf      TheAvg
----------- ---------- -----------
*/
USE AdventureWorks2017 
SELECT ProductID, Shelf, AVG(Quantity) AS Avg_Qty
FROM  Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY ProductID, Shelf
GO

/*
11.	List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
Color           	Class 	TheCount   	 AvgPrice
--------------	- ----- 	----------- 	---------------------
Joins:
*/
USE AdventureWorks2017 
SELECT Color, Class, COUNT(1) AS TheCount, AVG(ListPrice) AS Avg_LP
FROM  Production.Product
WHERE Color IS NOT NULL AND  Class IS NOT NULL
GROUP BY Color, Class
GO

/*
12.	  Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following. 

Country                        Province
---------                          ----------------------
*/
USE AdventureWorks2017 
SELECT c.Name AS Country, s.Name AS Province
FROM  person. CountryRegion AS c
INNER JOIN person. StateProvince AS s
ON c.CountryRegionCode = s.CountryRegionCode
GO

/*
13.	Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

Country                        Province
---------                          ----------------------
*/
USE AdventureWorks2017 
SELECT c.Name AS Country, s.Name Province
FROM  person. CountryRegion AS c
INNER JOIN person. StateProvince AS s
ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name IN ('Germany', 'Canada')
GO

/*
        Using Northwnd Database: (Use aliases for all the Joins)
14.	List all Products that has been sold at least once in last 25 years.
*/

USE Northwind 
SELECT DISTINCT p.ProductName AS Product 
FROM Products AS p
INNER JOIN [Order Details] AS od
ON p.ProductID = od.ProductID
GO

/*
15.	List top 5 locations (Zip Code) where the products sold most.
*/
USE Northwind 
SELECT TOP 5 ShipPostalCode AS [Zip Code], SUM(Quantity) AS qty
FROM Orders AS o
INNER JOIN [Order Details] AS od
ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY qty DESC
GO

/*
16.	List top 5 locations (Zip Code) where the products sold most in last 20 years.
*/
USE Northwind 
SELECT TOP 5 ShipPostalCode AS [Zip Code], SUM(Quantity) AS qty
FROM Orders AS o
INNER JOIN [Order Details] AS od
ON o.OrderID = od.OrderID
WHERE o.OrderDate > '2000-01-01'
GROUP BY o.ShipPostalCode
ORDER BY qty DESC
GO

/*
17.	 List all city names and number of customers in that city.     
*/
USE Northwind 
SELECT City, Count(1) AS Num_Ctm
FROM Customers
GROUP BY City
GO

/*
18.	List city names which have more than 10 customers, and number of customers in that city 
*/
USE Northwind 
SELECT City, Count(1) AS Num_Ctm
FROM Customers
GROUP BY City
HAVING Count(1) > 10
GO

/*
19.	List the names of customers who placed orders after 1/1/98 with order date.
*/
USE Northwind 
SELECT DISTINCT c.ContactName AS names
FROM Customers AS c
INNER JOIN Orders AS o
ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'
GO

/*
20.	List the names of all customers with most recent order dates 
*/
USE Northwind 
SELECT c.ContactName AS names, MAX(o.OrderDate)
FROM Customers AS c
INNER JOIN Orders AS o
ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName
GO

/*
21.	Display the names of all customers  along with the  count of products they bought 
*/
USE Northwind 
SELECT c.ContactName AS names, SUM(Quantity) AS CNT
FROM Customers AS c
INNER JOIN Orders AS o
ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] AS od
ON o.OrderID = od.OrderID
GROUP BY c.ContactName
GO

/*
22.	Display the customer ids who bought more than 100 Products with count of products.
*/
USE Northwind 
SELECT c.CustomerID AS names
FROM Customers AS c
INNER JOIN Orders AS o
ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] AS od
ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING SUM(Quantity) > 100
GO

/*
23.	List all of the possible ways that suppliers can ship their products. Display the results as below
Supplier Company Name   	Shipping Company Name
---------------------------------            ----------------------------------
*/
USE Northwind 
SELECT sp.CompanyName AS [Supplier Company Name], sh.CompanyName AS [Shipping Company Name]
FROM Products p
INNER JOIN Suppliers sp
ON p.SupplierID = sp.SupplierID
INNER JOIN [Order Details] od
ON p.ProductID = od.ProductID
INNER JOIN OrderS o
ON o.OrderID = od.OrderID
INNER JOIN Shippers sh
ON o.ShipVia = sh.ShipperID
ORDER  by sp.CompanyName
GO

/*
24.	Display the products order each day. Show Order date and Product Name.
*/
USE Northwind 
SELECT o.OrderDate, p.ProductName
FROM Orders o
INNER JOIN [Order Details] od
ON o.OrderID = od.OrderID
INNER JOIN Products p
ON od.ProductID = p.ProductID
GROUP BY o.OrderDate, p.ProductName
ORDER BY o.OrderDate
GO

/*
25.	Displays pairs of employees who have the same job title.
*/
USE Northwind 
SELECT a.LastName +' '+ a.FirstName, b.LastName +' '+ b.FirstName
FROM Employees a
INNER JOIN Employees b
ON a.ReportsTo = b.ReportsTo
WHERE a.LastName <> b.LastName AND a.FirstName <> b.FirstName 
GO

-- remove the duplicated data
USE Northwind 
SELECT DISTINCT CASE WHEN a.LastName +' '+ a.FirstName > b.LastName +' '+ b.FirstName THEN a.LastName +' '+ a.FirstName ELSE b.LastName +' '+ b.FirstName END,
	            CASE WHEN a.LastName +' '+ a.FirstName > b.LastName +' '+ b.FirstName THEN b.LastName +' '+ b.FirstName ELSE a.LastName +' '+ a.FirstName END
FROM Employees a
INNER JOIN Employees b
ON a.ReportsTo = b.ReportsTo
WHERE a.LastName <> b.LastName AND a.FirstName <> b.FirstName 
GO

/*
26.	Display all the Managers who have more than 2 employees reporting to them.
*/
USE Northwind 
SELECT a.LastName +' '+ a.FirstName AS Managers
FROM Employees a
INNER JOIN Employees b
ON a.EmployeeID = b.ReportsTo
GROUP BY a.LastName +' '+ a.FirstName
HAVING COUNT(b.ReportsTo) > 2
GO

/*
27.	Display the customers and suppliers by city. The results should have the following columns
City 
Name 
Contact Name,
Type (Customer or Supplier)
*/
USE Northwind 
SELECT City, CompanyName AS [Name], ContactName, 'Customer' AS Type
FROM Customers
UNION
SELECT City, CompanyName AS NAME, ContactName, 'Supplier' AS Type
FROM Suppliers
GO

/*
 28. Have two tables T1 and T2
F1.T1	F2.T2
1	2
2	3
3	4

Please write a query to inner join these two tables and write down the result of this query.
*/
-- RESULT SET: F1.T1  F2.T2
--		2      2
--		3      3

/*
 29. Based on above two table, Please write a query to left outer join these two tables and write down the result of this query.
*/
-- RESULT SET: F1.T1  F2.T2
--		1      Null
--	        2      2
--	        3      3
