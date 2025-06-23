CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

INSERT INTO Departments VALUES
(1, 'Sales'),
(2, 'Engineering'),
(3, 'HR'),
(4, 'Marketing');
---------------------------
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    HireDate DATE,
    Salary DECIMAL(10, 2),
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

INSERT INTO Employees VALUES
(101, 'Alice', 'Johnson', 1, '2020-01-15', 60000),
(102, 'Bob', 'Smith', 2, '2019-03-12', 80000),
(103, 'Carol', 'Lee', 1, '2021-07-22', 55000),
(104, 'David', 'Brown', 3, '2018-11-01', 50000),
(105, 'Eva', 'Davis', 4, '2022-06-10', 62000);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Country VARCHAR(50)
);

INSERT INTO Customers VALUES
(201, 'Tom', 'Harris', 'tom@example.com', 'USA'),
(202, 'Sara', 'Miller', 'sara@example.com', 'UK'),
(203, 'Liam', 'Wilson', 'liam@example.com', 'Canada'),
(204, 'Nina', 'Garcia', 'nina@example.com', 'USA');

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2),
    InStock INT
);

INSERT INTO Products VALUES
(301, 'Laptop', 'Electronics', 1200.00, 10),
(302, 'Phone', 'Electronics', 800.00, 20),
(303, 'Desk Chair', 'Furniture', 150.00, 15),
(304, 'Monitor', 'Electronics', 300.00, 8),
(305, 'Notebook', 'Stationery', 5.00, 100);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    EmployeeID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO Orders VALUES
(401, 201, 101, '2023-01-10', 2000.00),
(402, 202, 103, '2023-02-15', 950.00),
(403, 203, 102, '2023-03-05', 300.00),
(404, 204, 105, '2023-04-20', 1600.00);


CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO OrderDetails VALUES
(501, 401, 301, 1, 1200.00),
(502, 401, 302, 1, 800.00),
(503, 402, 303, 2, 150.00),
(504, 402, 305, 10, 5.00),
(505, 403, 305, 20, 5.00),
(506, 404, 301, 1, 1200.00),
(507, 404, 304, 1, 300.00),
(508, 404, 305, 20, 5.00);

-----
select * from Departments;
select * from Employees;
Select * from Customers;
Select * from Products;
Select * from Orders;
select * from OrderDetails
--------------------------------
use Learning;
--Select all columns from the Employees table.

select * from Employees;

--Retrieve the FirstName and LastName of all customers.

select FirstName, LastName from Customers

--Find all products in the category 'Electronics'.

select * from Products where Category = 'Electronics';

--List employees hired after January 1, 2020.
SELECT GETDATE() AS CurrentDate;

select * from Employees where HireDate > '2020-01-01';

--Get all orders with a TotalAmount greater than 1000.
select * from Orders;
select * from Orders where TotalAmount > 1000;

--Find all products with InStock less than 10.

select * from Products where InStock < 10;


--List employees ordered by their Salary descending.

select * from Employees order by Salary desc;

--Get the top 3 most expensive products.

select top 3 * from Products order by Price desc;


--Show customers sorted alphabetically by LastName, then FirstName.

select * from Customers order by LastName , FirstName;


--Find employees from the Sales department with salary over 55,000.

  SELECT 
  e.EmployeeID,
  e.DepartmentID as DeparatMentId,
  e.FirstName,
  e.Salary,
  d.DepartmentName
  FROM Employees e
  JOIN Departments d ON e.DepartmentID = d.DepartmentID
  where Salary > 55000;

--Select all orders placed between '2023-01-01' and '2023-03-31'.

select * from Orders where OrderDate between '2023-01-01' and '2023-03-31';

--Find products that are either in category 'Furniture' or priced below 100.
select * from Products where Category = 'Furniture' or Price < 100;


---Group BY Question

--Count the total number of employees.

select COUNT(*) as EmployeeCount from Employees

--Calculate the average salary of employees in the Engineering department.

select AVG(salary) as Average from Employees where Employees.DepartmentID = (select DepartmentID from Departments where DepartmentName = 'Engineering');

select AVG(e.Salary),d.DepartmentName  from Employees e 
join Departments d on e.DepartmentID =  d.DepartmentID
where DepartmentName = 'Engineering'
group by DepartmentName  

--Find the total number of orders placed by each customer.

select * from Orders o 
join Customers c on o.CustomerID = c.CustomerID
join  OrderDetails od on od.OrderID =  o.OrderID
group by od.OrderID 
----
select c.CustomerID, SUM(od.Quantity) as TotalQuantity from Orders o 
join Customers c on o.CustomerID = c.CustomerID
join  OrderDetails od on od.OrderID =  o.OrderID
group by od.OrderID ,c.CustomerID

--Show the total sales (sum of TotalAmount) by each employee.


select SUM(o.TotalAmount) as totalAmount, e.EmployeeID from Employees e 
join Orders o on
e.EmployeeID =  o.EmployeeID
join OrderDetails od on 
od.OrderID = o.OrderID
group by e.EmployeeID

--Find the number of products available in each category.

select  COUNT(p.category) as ProductCategory from Products p group by p.Category

--List departments with more than 1 employee.

select d.DepartmentName , COUNT(e.EmployeeID) as EmpCount from Departments d 
join Employees e on
e.DepartmentID = d.DepartmentID
group by d.DepartmentName having COUNT(e.EmployeeID) >1;

--Find customers who have placed more than 1 order.
WITH cte AS (
    SELECT 
        o.OrderID, 
        COUNT(o.OrderID) AS OrderCount
    FROM Customers c 
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN OrderDetails od ON od.OrderID = o.OrderID
    GROUP BY o.OrderID
    HAVING COUNT(o.OrderID) > 1
)
select * from Customers c
join cte on cte.OrderID = c.CustomerID

--Show products where the total quantity sold (from OrderDetails) is greater than 20.
with cte as(
select p.ProductID  as productId from Products p
join OrderDetails od on p.ProductID = od.ProductID 
group by p.ProductID having SUM(od.Quantity) > 20 )

select * from Products p 
join cte on p.ProductID = cte.productId

WITH cte AS (
    SELECT p.ProductID AS productId
    FROM Products p
    JOIN OrderDetails od ON p.ProductID = od.ProductID 
    GROUP BY p.ProductID 
    HAVING SUM(od.Quantity) > 20
)

-----JOINs
--List all employees with their department names.

select e.*,d.DepartmentName
	from Employees e
	join Departments d on e.DepartmentID = d.DepartmentID

--Show all orders with the customer’s full name and the employee’s full name who handled the order.

select  CONCAT(c.FirstName , c.LastName) as CustomerFullName,
	CONCAT(e.FirstName,e.LastName) as EmpFullName,
	c.CustomerID,o.OrderID
	from Customers c
	join Orders o on o.CustomerID = c.CustomerID 
	join Employees e on e.EmployeeID = o.EmployeeID
select * from Products;

select * from OrderDetails;



select * from Departments

select * from Customers

select * from Orders

select * from Employees


SELECT c.CustomerID, COUNT(o.OrderID) AS OrderCount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID;

--Show Each Employee with Average Department Salary

select e.EmployeeID,d.DepartmentID,e.FirstName,e.Salary, avg(e.Salary) as AvgSalary from Employees e
join Departments d on d.DepartmentID = e.DepartmentID
group by d.DepartmentID, e.FirstName, e.Salary ,e.EmployeeID order by AVG(e.EmployeeID) 

SELECT 
    e.EmployeeID,
    e.FirstName,
    e.Salary,
    (SELECT AVG(Salary)
     FROM Employees
     WHERE DepartmentID = e.DepartmentID) AS DepartmentAverage
FROM Employees e;

select avg(e.Salary) as AvgSalary from Employees e
join Departments d on d.DepartmentID = e.DepartmentID
group by d.DepartmentID

--Find employees who handled orders for customers from the USA.

select * from Employees e

join Orders o on o.EmployeeID = e.EmployeeID
join Customers c on c.CustomerID = o.CustomerID
where c.Country ='USA'


select * from Products