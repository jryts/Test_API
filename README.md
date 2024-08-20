# Test_API
Test requirement for 24 hour code challenge by 

# Requirements
Language is using C#.Net
Framework is using Entity Framework core 6
Data Storage is using SQL Server Express

# Data Source
Download csv file from https://www.kaggle.com/datasets/mysarahmadbhat/pizza-place-sales
1. pizzas.csv
2. pizza_types.csv
3. orders.csv
4. order_details.csv

# How this API work
1. First Clone or download code files.
2. Configure SQL Server
3. Open project in Visual Studio
4. Make sure all necessary class files to match with the db table schema were inside this folder /Domain/Entities
   Pizza.cs, Pizza_Type.cs, Order.cs and Order_Detail.cs
6. Install the microsoft.entityframeworkcore.tool and microsoft.entityframeworkcore.sqlserver libraries from Nuget
7. Make sure the db connection string was setup inside AppSettings.json
8. from Visual Studio Package Manager Console run the "add-migration" command to create table based the created class files inside /Domain/Entities
9. from Visual Studio Package Manager Console run the "update-database" command to refresh your SQL Server Management
10. after updating your database try to run the program to import csv files and save into your database
11. Use swagger to test the api endpoints

