

using Microsoft.EntityFrameworkCore;
using System.Data;
using Test.Api.Data;

var builder = WebApplication.CreateBuilder(args);

//get the connection string from appsettings.json
var conString = builder.Configuration.GetConnectionString("DbConnection");

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

/*
 ** MUST COMMENT OUT THIS IMPORT DATA CODES WHEN RUN THE MIGRATION **
//must run Add-Migration first then update-Database before uncomment the codes below else will encounter database error
#region Import Data from CSV file
//initialize ImportData class to get the current directory
ImportData importData = new(conString);
//import csv data if some table(s) have no data
if (importData.HasEmptyData())
{
	//clean tables before importing
	importData.CleanData();
	//import pizzas data from csv file and save into pizzas table
	importData.SaveBulkData();
}
#endregion
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	//optimize swagger UI performance to load huge data reponse from api
	app.UseSwaggerUI(config =>
	{
		config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
		{
			["activated"] = false
		};
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
