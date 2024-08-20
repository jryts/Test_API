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
4. Add all necessary class files to match with the db table schema were inside this folder /Domain/Entities
   Pizza.cs, Pizza_Type.cs, Order.cs and Order_Detail.cs
6. Install the microsoft.entityframeworkcore.tool and microsoft.entityframeworkcore.sqlserver libraries from Nuget
7. Add TestDbContext.cs for our data context
8. Make sure the db connection string was setup inside AppSettings.json
   ![image](https://github.com/user-attachments/assets/4be03591-7adb-467a-91f2-7114796bb25f)

10. from Visual Studio Package Manager Console run the "add-migration" command to create table based the created class files inside /Domain/Entities
11. from Visual Studio Package Manager Console run the "update-database" command and refresh your SQL Server Management Studio.
12. Check the newly create database name Pizza_Place_Sales
    ![image](https://github.com/user-attachments/assets/a46a3268-9d51-42ae-a905-8328908a23e9)

14. after updating your database add these line of codes in program.cs to import csv data into your database tables    
16. try to run the program and use swagger to test the api endpoints.

