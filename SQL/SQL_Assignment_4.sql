-----------------------  Assignment Day4 ¨CSQL:  Comprehensive practice ------------------------------
/*Answer following questions
1.	What is View? What are the benefits of using views?
	A view is a virtual table based on the result-set of an SQL statement. A view contains rows and columns, just like a real table.

2.	Can data be modified through views?
	Yes, but there are some restrictions as below:
	(1) update, insert, or delete operations that refer to a computed column or a built-in function in a view are not allowed.
	(2) update, insert, or delete operations that refer to a view that includes aggregates or row aggregates are not allowed.
	(3) insert, delete, and update operations that refer to a distinct view are not allowed.
	(4) insert statements are not allowed unless all NOT NULL columns in the underlying tables or views are included in the view through which you are inserting new rows. Adaptive Server has no way to supply values for NOT NULL columns in the underlying objects.
	(5) If a view has a with check option clause, all rows inserted or updated through the view (or through any derived views) must satisfy the view¡¯s selection criteria.
	(6) delete statements are not allowed on multitable views.
	(7) insert statements are not allowed on multitable views created with the with check option clause.
	(8) update statements are allowed on multitable views where with check option is used. The update fails if any of the affected columns appears in the where clause, in an expression that includes columns from more than one table.
	(9) insert and update statements are not allowed on multitable distinct views.
	(10) update statements cannot specify a value for an IDENTITY column. The table owner, database owner, or a system administrator can insert an explicit value into an IDENTITY column after setting identity_insert on for the column¡¯s base table.
	(11) If you insert or update a row through a multitable view, all affected columns must belong to the same base table.
	(12) writetext is not allowed on the text and image columns in a view.

3.	What is stored procedure and what are the benefits of using it?
	A stored procedure is a prepared SQL code that you can save, so the code can be reused over and over again.
	Benefits: (1) Reusability; (2) Improve Performance; (3) Speed: One run, multiple uses, unless recompile (4) Security

4.	What is the difference between view and stored procedure?
	A Stored Procedure:
		Accepts input and output parameters
		Can NOT be used as building block in a larger query
		Can contain several statements, DML, DDL, loops, IF ELSE, etc.
		Can perform modifications to one or several tables
		Can NOT be used as the target of an INSERT, UPDATE or DELETE statement.
	A View:
		Does NOT accept parameters
		Can be used as building block in a larger query
		Can contain only one single SELECT query
		Can NOT perform modifications to any table
		But can (sometimes) be used as the target of an INSERT, UPDATE or DELETE statement.

5.	What is the difference between stored procedure and functions?
	(1) The function must return a value but in Stored Procedure it is optional. Even a procedure can return zero or n values.
	(2)	Functions can have only input parameters for it whereas Procedures can have input or output parameters.
	(3)	Functions can be called from Procedure whereas Procedures cannot be called from a Function.
	(4) The function must return a value but in Stored Procedure it is optional. Even a procedure can return zero or n values.
	(5) Functions can have only input parameters for it whereas Procedures can have input or output parameters.
	(6) Functions can be called from Procedure whereas Procedures cannot be called from a Function.
	(7) Functions that return tables can be treated as another rowset. This can be used in JOINs with other tables.

6.	Can stored procedure return multiple result sets?
	Yes, use out parameters

7.	Can stored procedure be executed as part of SELECT Statement? Why?
	No, bcz it's an option for a stored procedure to return  or not return values
	
8.	What is Trigger? What types of Triggers are there?
	A trigger is a stored procedure in database which automatically invokes whenever a special event in the database occurs.
	Types: DML Trigger, DDL Trigger, Loggon Trigger

9.	What are the scenarios to use Triggers?
	For example, a trigger can be invoked when a row is inserted into a specified table or when certain table columns are being updated.

10.	What is the difference between Trigger and Stored Procedure?
	A trigger is a kind of special stored procedure in database which automatically invokes whenever a special event in the database occurs.
*/

/*
Write queries for following scenarios
Use Northwind database. All questions are based on assumptions described by the Database Diagram sent to you yesterday. 
When inserting, make up info if necessary. Write query for each step. Do not use IDE. BE CAREFUL WHEN DELETING DATA OR DROPPING TABLE.
*/
/*1.	Lock tables Region, Territories, EmployeeTerritories and Employees. 
Insert following information into the database. In case of an error, no changes should be made to DB.
a.	A new region called ¡°Middle Earth¡±;
b.	A new territory called ¡°Gondor¡±, belongs to region ¡°Middle Earth¡±;
c.	A new employee ¡°Aragorn King¡± who's territory is ¡°Gondor¡±.*/
--a--
INSERT INTO Region VALUES(5,'Middle Earth')
--b--
INSERT INTO Territories VALUES(99999, 'Gondor', 5)
--c--
INSERT INTO Employees(LastName, FirstName) VALUES('Aragorn', 'King')
INSERT INTO EmployeeTerritories VALUES(10, 99999)

/*2.	Change territory ¡°Gondor¡± to ¡°Arnor¡±.*/
UPDATE Territories
SET TerritoryDescription = 'Arnor'
WHERE TerritoryDescription = 'Gondor'

/*3.	Delete Region ¡°Middle Earth¡±. (tip: remove referenced data first) (Caution: do not forget WHERE or you will delete everything.) In case of an error, no changes should be made to DB. 
Unlock the tables mentioned in question 1.*/
DELETE FROM EmployeeTerritories
WHERE TerritoryID = '99999'

DELETE FROM Territories
WHERE TerritoryDescription = 'Arnor'

DELETE FROM Region
WHERE RegionDescription = 'Middle Earth'

SELECT * FROM Region
select * from Territories order by TerritoryID
SELECT * FROM EmployeeTerritories
SELECT * FROM Employees

USE Northwind
SELECT * FROM Products
SELECT * FROM [Order Details]
go
/*4.	Create a view named ¡°view_product_order_[your_last_name]¡±, list all products and total ordered quantity for that product.*/
CREATE VIEW view_product_order_sun 
AS
SELECT p.ProductID, SUM(od.Quantity) Qty
FROM Products p
INNER JOIN [Order Details] od
ON p.ProductID = od.ProductID
GROUP BY p.ProductID;
GO

/*5.	Create a stored procedure ¡°sp_product_order_quantity_[your_last_name]¡± that accept product id as an input and total quantities of order as output parameter.*/
CREATE PROCEDURE sp_product_order_quantity_sun (
	@ProductID INT,  
    @Total_Quantity INT OUTPUT
) AS 
BEGIN 
	SELECT * FROM Products;
END;

/*6.	Create a stored procedure ¡°sp_product_order_city_[your_last_name]¡± that accept product name as an input and top 5
cities that ordered most that product combined with the total quantity of that product ordered from that city as output.*/
CREATE PROCEDURE sp_product_order_city_sun (
	@ProductName VARCHAR,  
    @Top5_City VARCHAR OUTPUT,
	@City_Qty INT OUTPUT
) AS 
BEGIN 
	SELECT TOP 5 @Top5_City, @City_Qty
	FROM Products p
	INNER JOIN [Order Details] od
	ON p.ProductID = od.ProductID
	INNER JOIN Orders o
	ON od.OrderID = o.OrderID
	INNER JOIN Customers c
	ON o.CustomerID =  c.CustomerID
	WHERE p.ProductName = @ProductName
	GROUP BY c.City
	ORDER BY COUNT(o.OrderID) DESC;
END;

/*7.Lock tables Region, Territories, EmployeeTerritories and Employees. Create a stored procedure ¡°sp_move_employees_[your_last_name]¡± 
that automatically find all employees in territory ¡°Tory¡±; if more than 0 found, insert a new territory ¡°Stevens Point¡± of 
region ¡°North¡± to the database, and then move those employees to ¡°Stevens Point¡±.*/
CREATE PROCEDURE sp_move_employees_sun () AS 
BEGIN 
	DECLARE @CNT INT;
	@CNT = (SELECT COUNT(1)
	FROM Employees e
	INNER JOIN EmployeeTerritories et
	ON e.EmployeeID = et.EmployeeID
	INNER JOIN Territories t
	ON et.TerritoryID = t.TerritoryID
	WHERE t.TerritoryDescription = 'Tory');

	IF(@CNT > 0)
		INSERT INTO Territories VALUES(99999, 'Stevens Point', 3)
		UPDATE Territories 
		SET TerritoryDescription = 'Stevens Point'
		WHERE TerritoryDescription = 'Tory'
	END
END

/*8.	Create a trigger that when there are more than 100 employees in territory ¡°Stevens Point¡±, move them back to Troy. 
(After test your code,) remove the trigger. Move those employees back to ¡°Troy¡±, if any. Unlock the tables.*/
CREATE TRIGGER tr_territory ON Territories
    AFTER INSERT 
    AS
    BEGIN
      UPDATE Territories
      SET TerritoryDescription = 'Tory'
	  WHERE TerritoryDescription = 'Stevens Point' 
	  HAVING COUNT(TerritoryDescription) > 100
	END
GO

/*
9.	Create 2 new tables ¡°people_your_last_name¡± ¡°city_your_last_name¡±. City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}.
People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 
Remove city of Seattle. If there was anyone from Seattle, put them into a new city ¡°Madison¡±. Create a view ¡°Packers_your_name¡± lists all people from Green Bay.
If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.*/
CREATE TABLE people_your_last_name (Id INT, City VARCHAR(50))
CREATE TABLE city_your_last_name (Id INT, Name VARCHAR(50), City INT)
GO
INSERT INTO people_your_last_name VALUES (1, 'Seattle'), (2, 'Green Bay')
INSERT INTO city_your_last_name VALUES (1, 'Aaron Rodgers', 1), (2, 'Russell Wilson', 1), (3, 'Jody Nelson', 2)
GO
UPDATE people_your_last_name SET City = 'Madiso' WHERE City = 'Seattle'
GO

CREATE VIEW Packers_your_name
AS
SELECT c.Name
FROM city_your_last_name c
INNER JOIN people_your_last_name p
ON c.City = p.Id
WHERE p.City = 'Green Bay'
GO
SELECT * FROM Packers_your_name;

DROP TABLE people_your_last_name;
DROP TABLE city_your_last_name;
DROP VIEW Packers_your_name;
GO

/*10.	 Create a stored procedure ¡°sp_birthday_employees_[you_last_name]¡± that creates a new table ¡°birthday_employees_your_last_name¡± and fill it with all employees 
that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.*/
CREATE PROCEDURE sp_birthday_employees_sun
AS 
BEGIN 
	CREATE TABLE birthday_employees_sun (LastName VARCHAR(50), FirstName  VARCHAR(50))
	INSERT INTO birthday_employees_sun (LastName, FirstName)
	SELECT LastName, FirstName
	FROM Employees 
	WHERE  MONTH(BirthDate) = 2
END;
GO
EXEC sp_birthday_employees_sun
GO
DROP TABLE birthday_employees_sun
GO

/*11.	Create a stored procedure named ¡°sp_your_last_name_1¡± that returns all cites that have at least 2 customers who have bought no or only one kind of product. 
Create a stored procedure named ¡°sp_your_last_name_2¡± that returns the same but using a different approach. (sub-query and no-sub-query). */
CREATE PROCEDURE sp_sun_1
AS 
BEGIN 
	SELECT c.City
	FROM Customers c
	INNER JOIN 
	(SELECT c.CustomerID FROM Customers c 
	INNER JOIN Orders o
	ON c.CustomerID = o.CustomerID
	GROUP BY c.CustomerID
	HAVING COUNT(1) > 1) AS t
	ON c.CustomerID = t.CustomerID
	GROUP BY c.City
	HAVING COUNT(1) > 1
END;
GO

CREATE PROCEDURE sp_sun_2
AS 
BEGIN 
	WITH CTE_Temp
	AS 
	(SELECT c.CustomerID FROM Customers c 
	INNER JOIN Orders o
	ON c.CustomerID = o.CustomerID
	GROUP BY c.CustomerID
	HAVING COUNT(1) > 1)

	SELECT c.City
	FROM Customers c
	INNER JOIN CTE_Temp ct
	ON c.CustomerID = ct.CustomerID
	GROUP BY c.City
	HAVING COUNT(1) > 1
END;
GO

/*  12.	How do you make sure two tables have the same data? */
SELECT * FROM TABLE1
EXCEPT 
SELECT * FROM TABLE2

SELECT * FROM TABLE1
UNION
SELECT * FROM TABLE2

/*14.
First Name	Last Name	Middle Name
John	Green	
Mike	White	M
Output should be
Full Name
John Green
Mike White M.
Note: There is a dot after M when you output. */

SELECT CONCAT(First_Name, Last_Nmae, Middle_Name + '.')

/*15.
Student	Marks	Sex
Ci	70	F
Bob	80	M
Li	90	F
Mi	95	M
Find the top marks of Female students.
If there are to students have the max score, only output one.*/

SELECT TOP 1 * 
FROM Student_Mark
WHERE SEX = 'F'
ORDER BY Marks DESC

/*16.
Student	Marks	Sex
Li	90	F
Ci	70	F
Mi	95	M
Bob	80	M
How do you out put this? */

SELECT * FROM Student_Mark
ORDER BY Sex, Marks