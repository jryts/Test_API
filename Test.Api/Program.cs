using CsvHelper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using System.Reflection;
using Test.Api.Data;

var builder = WebApplication.CreateBuilder(args);

//get the connection string from appsettings.json
var conString = builder.Configuration.GetConnectionString("DbConnection");

//must run Add-Migration first and update-Database before running the api program else will encounter error
#region Import Data from CSV file
//initialize ImportData class to get the current directory
ImportData importData = new(conString);
//import csv data if some table(s) have no data
if (importData.HasEmptyData())
{
	//clean up data before importing
	importData.CleanData();
	//import pizzas data from csv file and save into pizzas table
	importData.SaveBulkData();
}
#endregion

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add db context here
builder.Services.AddDbContext<TestDbContext>(x =>
{
	x.UseSqlServer(conString);
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
