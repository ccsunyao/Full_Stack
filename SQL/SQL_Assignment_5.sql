---  Assignment Day 5¨CSQL:  Comprehensive practice ---
/*Answer following questions
1.	What is an object in SQL?
	A database object is any defined object in a database that is used to store or reference data.

2.	What is Index? What are the advantages and disadvantages of using Indexes?
	Index is a physical structure contains pointers to the data.
	Advantages:
	(1) Their use in queries usually results in much better performance.
	(2) They make it possible to quickly retrieve (fetch) data.
	(3) They can be used for sorting. A post-fetch-sort operation can be eliminated.
	(4) Unique indexes guarantee uniquely identifiable records in the database.
	Disadvantages:
	(1) They decrease performance on inserts, updates, and deletes.
	(2) They take up space (this increases with the number of fields used and the length of the fields).
	(3) Some databases will monocase values in fields that are indexed.

3.	What are the types of Indexes?
	Clustered Index and Non Clustered Index
4.	Does SQL Server automatically create indexes when a table is created? If yes, under which constraints?
	Yes, primary key

5.	Can a table have multiple clustered index? Why?
	No, a table can only have one clustered index, because the data rows themselves can be stored in only one order.

6.	Can an index be created on multiple columns? Is yes, is the order of columns matter?
	Yes, the order matters

7.	Can indexes be created on views?
	Yes, indexed view

8.	What is normalization? What are the steps (normal forms) to achieve normalization?
	Database Normalization is a process of organizing data to minimize redundancy (data duplication), which in turn ensures data consistency. 
	Normalization has a series of steps called ¡°Forms¡±, the more steps you take the more normalized your tables are.

	First Normal Form: 
		Data in each column should be atomic, no multiples values separated by comma.
		The table does not contain any repeating column group
		Identify each record using primary key.
	Second Normal Form: 
		The table must meet all the conditions of 1NF
		Move redundant data to separate table
		Create relationships between these tables using foreign keys
	Third Normal Form: 
		Table must meet all the conditions of 1NF and 2nd.
		Does not contain columns that are not fully dependent on primary key.

9.	What is denormalization and under which scenarios can it be preferable?
	Denormalization is a database optimization technique in which we add redundant data to one or more tables. 
	Join table, and some tables are pretty large

10.	How do you achieve Data Integrity in SQL Server?
	Physical integrity, Logical integrity, Entity integrity, Referential integrity, Domain integrity, User-defined integrity

11.	What are the different kinds of constraint do SQL Server have?
	Primary Key, Foriegn Key, Not Null, Check, Default, Unique

12.	What is the difference between Primary Key and Unique Key?
	Primary Key = Unique + Not Null

13.	What is foreign key?
	A foreign key (FK) is a column or combination of columns that is used to establish and enforce a link between the data in two tables. 
	You can create a foreign key by defining a FOREIGN KEY constraint when you create or modify a table. 

14.	Can a table have multiple foreign keys?
	Yes

15.	Does a foreign key have to be unique? Can it be null?
	Not have to be unique, and yest it can be null

16.	Can we create indexes on Table Variables or Temporary Tables?
	yes

17.	What is Transaction? What types of transaction levels are there in SQL Server?
	Transactions by definition are a logical unit of work  Transaction is a single recoverable unit of work that executes either: Completely or Not at all
	Read Uncommitted (Lowest level), Read Committed, Repeatable Read, Serializable (Highest Level), Snapshot Isolation
*/

/*Write queries for following scenarios
1.	Write an sql statement that will display the name of each customer and the sum of order totals placed by that customer during the year 2002
 Create table customer(cust_id int,  iname varchar (50)) create table order(order_id int,cust_id int,amount money,order_date smalldatetime) */
 CREATE TABLE Customer 
 ( 
	cust_id int Primary Key,
	iname varchar (50) NOT NULL)

CREATE TABLE [Order] 
(
	order_id int Primary Key,
	cust_id int,
	amount money,
	order_date smalldatetime)

SELECT c.iname, SUM(o.amount)
FROM [Order] o
INNER JOIN Customer c
ON o.cust_id = c.cust_id
WHERE YEAR(o.order_date) =  '2002'
GROUP BY c.iname

/*2.  The following table is used to store information about company¡¯s personnel:
Create table person (id int, firstname varchar(100), lastname varchar(100)) write a query that returns all employees whose last names  start with ¡°A¡±. */
Create table Person 
(
	id int, 
	firstname varchar(100), 
	lastname varchar(100)) 

SELECT * FROM Person
WHERE lastname LIKE 'A%'

DROP TABLE Customer 
DROP TABLE [Order] 
DROP TABLE Person
/*3.  The information about company¡¯s personnel is stored in the following table:
Create table person(person_id int primary key, manager_id int null, name varchar(100)not null) The filed managed_id contains the person_id of the employee¡¯s manager.
Please write a query that would return the names of all top managers(an employee who does not have  a manger, and the number of people that report directly to this manager. */
Create table Person
(	person_id int primary key, 
	manager_id int null, 
	name varchar(100)not null)

SELECT b.[name], a.[name]
FROM Person a
INNER JOIN Person b
ON a.manager_id = b.person_id
WHERE b.manager_id IS NULL


/*4.  List all events that can cause a trigger to be executed. 
	DML: INSERT, DELETE, UPDATE
	DDL: CREATE, ALTER
	LOGON: Logon/Logoff, errors
*/

/*5. Generate a destination schema in 3rd Normal Form.  Include all necessary fact, join, and dictionary tables, and all Primary and Foreign Key relationships.  The following assumptions can be made:
a. Each Company can have one or more Divisions.
b. Each record in the Company table represents a unique combination 
c. Physical locations are associated with Divisions.
d. Some Company Divisions are collocated at the same physical of Company Name and Division Name.
e. Contacts can be associated with one or more divisions and the address, but are differentiated by suite/mail drop records.status of each association should be separately maintained and audited. */
