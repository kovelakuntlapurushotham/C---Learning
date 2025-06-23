-- Create the table
CREATE TABLE EmployeeSales (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50),
    Department VARCHAR(50),
    Sales INT
);

-- Insert sample data
INSERT INTO EmployeeSales (EmployeeID, EmployeeName, Department, Sales) VALUES
(1, 'Alice', 'Electronics', 300),
(2, 'Bob', 'Electronics', 400),
(3, 'Charlie', 'Electronics', 400),
(4, 'David', 'Furniture', 250),
(5, 'Eva', 'Electronics', 300),
(6, 'Frank', 'Furniture', 250),
(7, 'Grace', 'Furniture', 400),
(8, 'Helen', 'Furniture', 300),
(9, 'Ian', 'Electronics', 250),
(10, 'Jane', 'Furniture', 300);

select * from EmployeeSales;

WITH cte1 AS (
    SELECT COUNT(*) as county FROM EmployeeSales where Department = 'Electronics'
)
SELECT cte1.county
FROM cte1;


with cte as(
select *,
Dense_Rank() over (order by Sales desc)as topMax 
from EmployeeSales where Sales< ( select MAX(sales) as TopSale from EmployeeSales))
select * from cte where cte.topMax = 2

Select 
	EmployeeSales.EmployeeName,
	EmployeeSales.Sales,
RANK() over (order by sales desc) As Rank,
Dense_Rank() Over( order by sales Desc) as Dense_Rank
from  EmployeeSales;

SELECT 
    Department,
    EmployeeName,
    Sales,
    RANK() OVER (PARTITION BY Department ORDER BY Sales DESC) AS RankDept,
    DENSE_RANK() OVER (PARTITION BY Department ORDER BY Sales DESC) AS DenseRankDept,
    ROW_NUMBER() OVER (PARTITION BY Department ORDER BY Sales DESC) AS RowNumDept
FROM EmployeeSales;

 SELECT *,
           RANK() OVER (PARTITION BY Department ORDER BY Sales DESC) AS RankDept
    FROM EmployeeSales

	WITH RankedSales AS (
    SELECT *,
           RANK() OVER (PARTITION BY Department ORDER BY Sales DESC) AS RankDept
    FROM EmployeeSales
)
select top 1  Sales from EmployeeSales
order by sales desc

select EmployeeSales.Sales, COUNT(*) as CountOfSales
from
EmployeeSales group by EmployeeSales.Sales having  COUNT(*) >3