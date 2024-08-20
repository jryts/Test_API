using CsvHelper;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace Test.Api.Data
{
	public class ImportData
	{
		private readonly string _dirPath;
		private readonly string? _conString;
		public ImportData(string conString)
		{
			_dirPath = Directory.GetCurrentDirectory() + "\\Migrations\\pizza_data\\"; //. AppDomain.CurrentDomain.BaseDirectory;
			_conString = conString;
		}

		//get the CSV file and save data into table
		public void SaveBulkData()
		{
			FileInfo[] files = GetCSVFiles();
			if (files.Length == 0) { return; }

			using (var con = new SqlConnection(_conString))
			{
				con.Open();
				foreach (FileInfo file in files)
				{
					using (var reader = new StreamReader(_dirPath + file.Name))
					{
						using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
						{
							// Do any configuration to `CsvReader` before creating CsvDataReader.
							using (var dr = new CsvDataReader(csv))
							using (var bcp = new SqlBulkCopy(con))
							{
								bcp.DestinationTableName = file.Name.Replace(file.Extension, "");

								bcp.WriteToServer(dr);
							}
							reader.Close();
						}
					}
				}
			}
		}
		//get all csv files from _dirPath
		public FileInfo[] GetCSVFiles()
		{
			//get Folder info from _dirPath value
			DirectoryInfo dir = new DirectoryInfo(_dirPath); 
			//Getting all csv files inside the folder
			FileInfo[] Files = dir.GetFiles("*.csv"); 
			return Files;
		}
		//delete all data from the tables
		public void CleanData()
		{
			FileInfo[] files = GetCSVFiles();
			if (files.Length == 0) { return; }
			using (var con = new SqlConnection(_conString))
			{
				con.Open();
				foreach (FileInfo file in files)
				{
					string csvFileName = file.Name.Replace(file.Extension, "");
					using var cmd = new SqlCommand("delete from " + csvFileName, con);
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void DropTables()
		{

		}
		
		public bool HasEmptyData()
		{ 
			bool retValue = false;
			FileInfo[] files = GetCSVFiles();
			using (var con = new SqlConnection(_conString))
			{
				con.Open();
				foreach (FileInfo file in files)
				{
					string csvFileName = file.Name.Replace(file.Extension, "");
					using var cmd = new SqlCommand("select count(*) from " + csvFileName, con);
					var obj = cmd.ExecuteScalar();
					int results = Convert.ToInt32(obj);
					if(results == 0)
					{
						retValue = true;
					}
				}
			}
	
			return retValue;
		}
	}
}
