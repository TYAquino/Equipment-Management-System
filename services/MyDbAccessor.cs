using Dapper;
using SoftwareAnalysis;
using MySqlConnector;

namespace SoftwareAnalysis
{
	public class MyDbAccessor
	{
		protected MySqlConnection connection;

		public MyDbAccessor()
		{
			//string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
			//string dbUser = Environment.GetEnvironmentVariable("DB_USER");
			//string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

			var builder = new MySqlConnectionStringBuilder
			{
				Server = "localhost",
				UserID = "root",
				Password = "password",
				Database = "village-rentals",
			};
			connection = new MySqlConnection(builder.ConnectionString);
		}
	}
}