--- Database Design Practice ---
/*1.	Design a Database for a company to Manage all its projects. 
•	Company has diverse offices in several countries, which manage and co-ordinate the project of that country.
•	Head office has a unique name, city, country, address, phone number and name of the director.
•	Every head office manages a set of projects with Project code, title, project starting and end date, assigned budget and name of the person in-charge. 
	One project is formed by the set of operations that can affect to several cities.
•	We want to know what actions are realized in each city storing its name, country and number of inhabitants.*/
CREATE DATABASE CompanyManage 
GO
USE CompanyManage
CREATE TABLE Office (
	OfficeName		VARCHAR(50) Unique,
	City			VARCHAR(50), 
	Country			VARCHAR(50), 
	[Address]		VARCHAR(50), 
	PhoneNumber		VARCHAR(20),
	Director		VARCHAR(50),
) 
CREATE TABLE Project (
	ProjectCode		INT Primary Key, 
	Title			VARCHAR(50), 
	StartDate		DATETIME,
	EndDate			DATETIME, 
	AssignedBudget	MONEY,
	PersonInCharge	VARCHAR(50),
	OfficeName		VARCHAR(50)
	FOREIGN KEY (OfficeName) REFERENCES Office(OfficeName)
)
CREATE TABLE Operation (
	ActionID			INT, 
	ActionName			VARCHAR(50),
	City				VARCHAR(50),
	Country				VARCHAR(50),
	NumOfInhabitants	INT,
	ProjectID		INT,
	FOREIGN KEY (ProjectID) REFERENCES Project(ProjectCode)
)
GO

/*2.	Design a database for a lending company which manages lending among people (p2p lending)

•	Lenders that lending money are registered with an Id, name and available amount of money for the financial operations. 
•	Borrowers are identified by their id and the company registers their name and a risk value depending on their personal situation.
•	When borrowers apply for a loan, a new loan code, the total amount, the refund deadline, the interest rate and its purpose are stored in database. 
•	Lenders choose the amount they want to invest in each loan. A lender can contribute with different partial amounts to several loans. */
CREATE DATABASE LendingCompany 
GO
USE LendingCompany
CREATE TABLE Lender (
	LID			INT PRIMARY KEY,
	LName		VARCHAR(50),
	AvaMoney	Money
)
CREATE TABLE Borrower (
	BID			INT PRIMARY KEY,
	BName		VARCHAR(50),
	RishValue	MONEY
)
CREATE TABLE Load (
	LoanCode		INT,
	TotalValue		MONEY,
	Refund_Deadline	DATETIME,
	Rate			FLOAT,
	Purpose			VARCHAR(500),
	BorrowerID		INT,
	FOREIGN KEY (BorrowerID) REFERENCES Borrower(BID)
)
CREATE TABLE Business (
	BusinessCode	INT,
	LoanCode		INT,
	LenderID		INT,
	BorrowID		INT,
	lendAmount		INT
)
GO

/*3.Design a database to maintain the menu of a restaurant.
•	Each course has its name, a short description, photo and final price.
•	Each course has categories characterized by their names, short description, name of the employee in-charge of them.
•	Besides the courses some recipes are stored. They are formed by the name of their ingredients, the required amount, 
	units of measurements and the current amount in the store. */
CREATE DATABASE Restaurant 
GO
CREATE TABLE Category (
	CategoryName		VARCHAR(20) PRIMARY KEY,
	[Description]		VARCHAR(50),
	EmployeeInCharge	VARCHAR(20) NOT NULL
)
CREATE TABLE Course (
	CourseName		VARCHAR(20),
	[Description]	VARCHAR(50),
	Photo			VARCHAR(100),
	Price			MONEY,
	CategoryName	VARCHAR(20),
	FOREIGN KEY (CategoryName) REFERENCES Category(CategoryName)
)
CREATE TABLE Recipe (
	Ingredient		VARCHAR(20),
	RequiredAmount	FLOAT,
	Unit			FLOAT,
	CourseName		VARCHAR(20),
	AmountInStore	FLOAT
)
GO