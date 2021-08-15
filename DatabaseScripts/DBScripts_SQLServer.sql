-- Create DB
create database GridForm
-- Creating a Form table
Create table dbo.Form
(
  FormId int identity(1,1) PRIMARY KEY,
  FormName varchar(100)
)

-- Creating a data table
Create table dbo.FormData
(
  FormDataId int identity(1,1) PRIMARY KEY,
  FormId int NOT NULL ,
  FormItem VARCHAR(MAX)  
);

-- Test data
/*
Insert into  dbo.Form values ('MyForm1')
Insert into  dbo.Form values ('MyForm2')
Insert into  dbo.Form values ('MyForm3')

Insert into dbo.FormData values
(1,'Test1~Test1~Test1~Test1~Test1')

--Insert into dbo.FormData values
Insert into dbo.FormData values
(2,'Test1~Test1~Test1~Test1~Test1')

Insert into dbo.FormData values
(2,'Test2~Test2~Test2~Test2~Test2')


Insert into dbo.FormData values
(3,'Test4~~Test4~Test4~Test4')

*/