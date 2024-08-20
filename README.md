# Test_API
Test requirement for 24 hour code challenge by 

# Requirements
Language is using C#.Net
Framework is using Entity Framework core 6
Data Storage is using SQL Server Express

# Data Source
Download csv file from https://www.kaggle.com/datasets/mysarahmadbhat/pizza-place-sales
pizzas.csv
pizza_types.csv
orders.csv
order_details.csv

# How this API work
1. First Clone or download code files.
2. Configure SQL Server
3. Open project in Visual Studio
4. Make sure all necessary class files were inside this folder /Domain/Entities
5. Install the microsoft.entityframeworkcore.tool and microsoft.entityframeworkcore.sqlserver libraries from Nuget
6. Make sure the db connection string was setup inside AppSettings.json
7. from Visual Studio Package Manager Console run the "add-migration" command to create table based the created class files inside /Domain/Entities
8. from Visual Studio Package Manager Console run the "update-database" command to refresh your SQL Server Management
9. after updating your database try to run the program to import csv files and save into your database
10. Use swagger to test the api endpoints

