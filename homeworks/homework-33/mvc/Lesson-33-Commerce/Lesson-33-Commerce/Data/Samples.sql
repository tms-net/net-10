-- DDL - Data Definition Language
-- Shema == Structured Data

CREATE TABLE Products (
    Id int NOT NULL,
	[Name] nvarchar(max),
	Price decimal, -- money
	UpdateDate time
);

-- Primary Key (PK)
  -- 1. Constraint - unique per table
  -- 2. Faster storage structure
  -- 3. Can be used for data CONSISTENCY (define RELATIONS)

-- Foreign Key (FK)
  -- 1. Define constraints for data CONSISTENCY (define RELATIONS)
  -- 2. Faster JOINS

ALTER TABLE Products
ADD PRIMARY KEY (Id);

ALTER TABLE Products
ADD CategoryId int;

CREATE TABLE Categories (
    Id int NOT NULL PRIMARY KEY,
	[Name] nvarchar(max)
);

ALTER TABLE Orders
ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id);

ALTER TABLE Products
ADD CONSTRAINT FK_ProductsCategory
FOREIGN KEY (CategoryId) REFERENCES Categories(Id);

-- Нормализация данных

-- Нормальные формы данных

--       1             ->             6
-- есть избыточность         минимальная избыточность

-- DML - Data Manipulation Language

-- CRUD - create, read, update, delete

-- 1. Query data - read data
-- 2. Change (update, create, delete)


-- RELATIONAL

-- TABLE ~ Множество

-- 1. Read 
-- SELECT TOP 1 * FROM [Products]
SELECT * FROM [Products]
-- SELECT COUNT(*) as [Count] FROM [Products]
-- SELECT MAX(Price) as [Count] FROM [Products]

  -- 1.1 filter .Where()
     -- WHERE [Name] = 'Adidas Shirt' -- Name == "Nike Sneakers"
	 -- WHERE Price >= 100
	 -- WHERE CategoryId = NULL -- != DB NULL НЕВЕРНО
	 -- WHERE CategoryId is NULL
     
  -- 1.2 .Take(10)
  -- TOP 10

  -- 1.3 aggregate .Count() / .Max()

  -- 1.4 group .GroupBy() -> Key, IEnumerable  
HAVING Count([Id]) > 1

  -- 1.5 order .OrderBy() / .OderByDescending()
ORDER BY Price DESC


-- 2. Create
INSERT INTO [Products] (Id, [Name], Price, UpdateDate, CategoryId)
VALUES (1, 'Nike Sneakers', 100.0, '2023-09-18', NULL);

INSERT INTO [Products] (Id, [Name], Price, UpdateDate, CategoryId)
VALUES (2, 'Adidas Shirt', 150.0, GETDATE(), NULL);

INSERT INTO [Products] (Id, [Name], Price, UpdateDate, CategoryId)
VALUES (3, 'Nike Shoes', 100.0, GETDATE(), NULL);

-- 3. Update
UPDATE [Products]
SET UpdateDate = GETDATE()
WHERE [Name] = 'Nike Sneakers'

-- 4. Delete
DELETE FROM [Products]
WHERE [Name] = 'Nike Sneakers'


-- SELECT GETDATE();

SELECT * FROM  [Products]

SELECT TOP 3 Price, Count([Id]) as [Count] FROM [Products]
-- WHERE
GROUP BY Price
HAVING Count([Id]) > 1
ORDER BY [Count]

-- Shoes - 100
-- Shirts - 200

-- JOIN 

-- Count() aggregation -> table to value
-- Group() aggregation -> table to table column

-- JOIN -> объединение -> tables to table

INSERT INTO [dbo].[Categories]
VALUES (1, 'Shoes')

INSERT INTO [dbo].[Categories]
VALUES (2, 'Shirts')

SELECT * FROM [Categories]
SELECT * FROM [Products]

SELECT * FROM [Products]
INNER JOIN [Categories] ON [Categories].Id = [Products].CategoryId

SELECT * FROM [Products]
LEFT JOIN [Categories] ON [Categories].Id = [Products].CategoryId

SELECT * FROM [Products]
FULL OUTER JOIN [Categories] ON [Categories].Id = [Products].CategoryId

SELECT * FROM [Products]
LEFT JOIN [Categories] ON [Categories].Id = [Products].CategoryId
WHERE [Categories].Id is NULL

-- INNER / OUTER
-- FULL OUTER

UPDATE [Products]
SET CategoryId = 1
WHERE Id = 3

DELETE FROM  [dbo].[Categories]
 -- Error
 -- Cascade behavior (delete)
 -- NULL

SELECT * FROM [dbo].[Categories]

-- One to Many Relationship





