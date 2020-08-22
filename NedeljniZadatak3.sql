

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
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'tblPersonRecipe')
drop table tblPersonRecipe
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'tblIngredientRecipe')
drop table tblIngredientRecipe

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
IngredientName nvarchar(50)

)

 

CREATE TABLE tblPersonRecipe (
   
	PersonID int FOREIGN KEY REFERENCES tblPerson(PersonID),
	RecipeID int FOREIGN KEY REFERENCES tblRecipe(RecipeID)  ,
	primary key(PersonID,RecipeID)
);

CREATE TABLE tblIngredientRecipe (
   
	IngredientID int FOREIGN KEY REFERENCES tblIngredients(IngredientID),
	RecipeID int FOREIGN KEY REFERENCES tblRecipe(RecipeID)  ,
	primary key(IngredientID,RecipeID)
);

 GO
CREATE VIEW vwRecipe 
AS

SELECT   dbo.tblRecipe.RecipeID ,dbo.tblRecipe.RecipeName,
         dbo.tblRecipe.RecipeType ,dbo.tblRecipe.IntendedFor,
		 dbo.tblRecipe.Description ,dbo.tblRecipe.DateCreated ,        
		 dbo.tblPerson.PersonID,dbo.tblPerson.FirstName,
         dbo.tblPerson.LastName,dbo.tblPerson.Username
		 
FROM            dbo.tblRecipe INNER JOIN
            dbo.tblPerson ON dbo.tblRecipe.Author = dbo.tblPerson.PersonID  
			 
           
GO

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

select * from tblRecipe;
select * from tblIngredientRecipe;
select * from tblPersonRecipe;