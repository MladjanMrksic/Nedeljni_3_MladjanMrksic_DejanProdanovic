IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CookbookDatabase')
CREATE DATABASE CookbookDatabase
GO

USE CookbookDatabase
GO

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'tblIngredients')
drop table tblIngredients
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'tblShoppingList')
drop table tblShoppingList
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'tblRecipe')
drop table tblRecipe
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'tblPerson')
drop table tblPerson

CREATE TABLE tblPerson
(
PersonID int primary key identity(1,1),
FirstName nvarchar(50),
LastName nvarchar(50),
Username nvarchar(50) unique,
Password nvarchar(50),
)

CREATE TABLE tblRecipe 
(
RecipeID int primary key identity(1,1),
RecipeName nvarchar(50),
RecipeType nvarchar(20),
IntendedFor int,
Author int FOREIGN KEY REFERENCES tblPerson(PersonID),
Description nvarchar(150),
DateCreated date
)

CREATE TABLE tblIngredients
(
IngredientID int primary key identity (1,1),
IngredientName nvarchar(50),
Ammount int,
Recipe int FOREIGN KEY REFERENCES tblRecipe(RecipeID),
)

CREATE TABLE tblShoppingList
(
IngredientID int primary key identity (1,1),
IngredientName nvarchar(50),
Ammount int,
Owned bit default(0),
Recipe int FOREIGN KEY REFERENCES tblRecipe(RecipeID),
Person int FOREIGN KEY REFERENCES tblPerson(PersonID)
)

USE CookbookDatabase
GO

INSERT INTO tblIngredients (IngredientName) VALUES ('Milk')
INSERT INTO tblIngredients (IngredientName) VALUES ('Salt')
INSERT INTO tblIngredients (IngredientName) VALUES ('Sugar')
INSERT INTO tblIngredients (IngredientName) VALUES ('Tomato')
INSERT INTO tblIngredients (IngredientName) VALUES ('Mayonnaise')
INSERT INTO tblIngredients (IngredientName) VALUES ('Mushroom')
INSERT INTO tblIngredients (IngredientName) VALUES ('Ketchup')
INSERT INTO tblIngredients (IngredientName) VALUES ('Cheese')
INSERT INTO tblIngredients (IngredientName) VALUES ('Egg')
INSERT INTO tblIngredients (IngredientName) VALUES ('Ham')
INSERT INTO tblIngredients (IngredientName) VALUES ('Flour')
