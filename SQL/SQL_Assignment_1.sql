/*
1.	Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, with no filter. 
*/
USE AdventureWorks2017
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
GO

/*
2.	Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are 0 for the column ListPrice
*/
USE AdventureWorks2017
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE ListPrice = 0
GO

/*
3.	Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are rows that are NULL for the Color column.
*/
USE AdventureWorks2017
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NULL
GO

/*
4.	Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the Color column.
*/
USE AdventureWorks2017
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL
GO

/*
5.	Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the column Color, and the column ListPrice has a value greater than zero.
*/
USE AdventureWorks2017
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0
GO

/*
6.	Generate a report that concatenates the columns Name and Color from the Production.Product table by excluding the rows that are null for color.
*/
USE AdventureWorks2017
SELECT CONCAT(Name, Color) AS Concatenates
FROM Production.Product
WHERE Color IS NOT NULL
GO

/*
7.	Write a query that generates the following result set  from Production.Product:
Name And Color
--------------------------------------------------
NAME: LL Crankarm  --  COLOR: Black
NAME: ML Crankarm  --  COLOR: Black
NAME: HL Crankarm  --  COLOR: Black
NAME: Chainring Bolts  --  COLOR: Silver
NAME: Chainring Nut  --  COLOR: Silver
NAME: Chainring  --  COLOR: Black
¡­¡­¡­
*/
USE AdventureWorks2017
SELECT Name, Color
FROM Production.Product
WHERE (Name LIKE '%Crankarm' OR Name LIKE 'Chainring%') AND (COLOR = 'Black' OR COLOR = 'Silver')
ORDER BY ProductID 
GO

/*
8.	Write a query to retrieve the to the columns ProductID and Name from the Production.Product table filtered by ProductID from 400 to 500
*/
USE AdventureWorks2017
SELECT ProductID, Name 
FROM Production.Product
WHERE ProductID BETWEEN 400 AND 500
GO

/*
9.	Write a query to retrieve the to the columns  ProductID, Name and color from the Production.Product table restricted to the colors black and blue
*/
USE AdventureWorks2017
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color IN ('Black','Blue')
GO

/*
10.	Write a query to generate a report on products that begins with the letter S. 
*/
USE AdventureWorks2017
SELECT *
FROM Production.Product
WHERE Name LIKE 'S%';
GO

/*
11.	Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. 
 
Name                                               ListPrice
-------------------------------------------------- -----------
Seat Lug                                           0,00
Seat Post                                          0,00
Seat Stays                                         0,00
Seat Tube                                          0,00
Short-Sleeve Classic Jersey, L                     53,99
Short-Sleeve Classic Jersey, M                     53,99
*/ 
USE AdventureWorks2017
SELECT top 6 Name, ListPrice 
FROM Production.Product
WHERE (Name LIKE 'Short-Sleeve Classic Jersey, %' OR Name LIKE 'Seat %')
ORDER BY Name
GO

/*
12.	 Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. The products name should start with either 'A' or 'S'
 
Name                                               ListPrice
-------------------------------------------------- ----------
Adjustable Race                                    0,00
All-Purpose Bike Stand                             159,00
AWC Logo Cap                                       8,99
Seat Lug                                           0,00
Seat Post                                          0,00
               ¡­¡­¡­
*/
USE AdventureWorks2017
SELECT Name, ListPrice 
FROM Production.Product
WHERE Name LIKE '[AS]%'
ORDER BY Name
GO

/*
13.	Write a query so you retrieve rows that have a Name that begins with the letters SPO, but is then not followed by the letter K. After this zero or more letters can exists. Order the result set by the Name column.
*/
USE AdventureWorks2017
SELECT Name, ListPrice 
FROM Production.Product
WHERE Name LIKE 'SPO[^K]%'
ORDER BY Name
GO

/*
14.	Write a query that retrieves unique colors from the table Production.Product. Order the results  in descending  manner
*/
USE AdventureWorks2017
SELECT DISTINCT Color
FROM Production.Product
ORDER BY Color DESC
GO

/*
15.	Write a query that retrieves the unique combination of columns ProductSubcategoryID and Color from the Production.Product table. Format and sort so the result set accordingly to the following. We do not want any rows that are NULL.in any of the two columns in the result.
*/
USE AdventureWorks2017
SELECT DISTINCT ProductSubcategoryID, Color
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL AND Color IS NOT NULL
GO

/*
16.	Something is ¡°wrong¡± with the WHERE clause in the following query. 
We do not want any Red or Black products from any SubCategory than those with the value of 1 in column ProductSubCategoryID, unless they cost between 1000 and 2000.
 
Note:
The LEFT() function will be covered in a forthcoming module.

 
SELECT ProductSubCategoryID
      , LEFT([Name],35) AS [Name]
      , Color, ListPrice 
FROM Production.Product
WHERE Color IN ('Red','Black') 
      OR ListPrice BETWEEN 1000 AND 2000 
      AND ProductSubCategoryID = 1
ORDER BY ProductID
 */ 

USE AdventureWorks2017
SELECT ProductSubCategoryID
      , LEFT([Name],35) AS [Name]
      , Color, ListPrice 
FROM Production.Product
EXCEPT
SELECT ProductSubCategoryID
      , LEFT([Name],35) AS [Name]
      , Color, ListPrice 
FROM Production.Product
WHERE Color IN ('Red','Black') 
AND ProductSubCategoryID = 1
AND ListPrice NOT BETWEEN 1000 AND 2000
GO

/*
17.	Write the query in the editor and execute it. Take a look at the result set and then adjust the query so it delivers the following result set.
 
 
ProductSubCategoryID Name                                Color           ListPrice
-------------------- ----------------------------------- --------------- ---------
14                   HL Road Frame - Black, 58           Black           1431,50
14                   HL Road Frame - Red, 58             Red             1431,50
14                   HL Road Frame - Red, 62             Red             1431,50
14                   HL Road Frame - Red, 44             Red             1431,50
14                   HL Road Frame - Red, 48             Red             1431,50
14                   HL Road Frame - Red, 52             Red             1431,50
14                   HL Road Frame - Red, 56             Red             1431,50
12                   HL Mountain Frame - Silver, 42      Silver          1364,50
12                   HL Mountain Frame - Silver, 44      Silver          1364,50
12                   HL Mountain Frame - Silver, 48      Silver          1364,50
                                    ......
2                    Road-350-W Yellow, 44               Yellow          1700,99
2                    Road-350-W Yellow, 48               Yellow          1700,99
1                    Mountain-500 Black, 40              Black           539,99
1                    Mountain-500 Black, 42              Black           539,99
1                    Mountain-500 Black, 44              Black           539,99
1                    Mountain-500 Black, 48              Black           539,99
1                    Mountain-500 Black, 52              Black           539,99

*/

USE AdventureWorks2017
SELECT ProductSubCategoryID, Name, Color, ListPrice
FROM Production.Product
WHERE (Name LIKE 'HL Road Frame - Red%' 
OR NAME = 'HL Road Frame - Black, 58'
OR Name LIKE 'HL Mountain Frame - Silver, %'
OR Name LIKE 'Road-350-W Yellow, %'
OR Name LIKE 'Mountain-500 Black, %')
AND Color IN ('Red', 'Silver', 'Yellow', 'Black')
ORDER BY ProductSubCategoryID DESC
GO