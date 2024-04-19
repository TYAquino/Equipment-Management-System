using Dapper;
using SoftwareAnalysis;
using MySqlConnector;
using SoftwareAnalysis.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftwareAnalysis
{
	public class CustomerDbAccessor : MyDbAccessor
	{
		public void CreateCustomerTable()
		{
			connection.Open();

			string sql = "CREATE TABLE IF NOT EXISTS customers (CustomerId INT(10) PRIMARY KEY, FirstName VARCHAR(255), LastName VARCHAR(255), PhoneNumber INT(20), EmailAddress VARCHAR(255), Comment VARCHAR(255))";

			connection.Execute(sql);

			connection.Close();
		}
		public List<Customer> GetCustomers()
		{
			connection.Open();

			string sql = "SELECT * FROM customers";

			var customers = connection.Query<Customer>(sql);

			connection.Close();

			return customers.ToList();
		}
		public int AddCustomer(Customer customer)
		{
			connection.Open();

			string sql = "INSERT INTO customers (FirstName, LastName, PhoneNumber, EmailAddress, Comment) VALUES (@FirstName, @LastName, @PhoneNumber, @EmailAddress, @Comment)";

			connection.Execute(sql, customer);

			string sql2 = "SELECT CustomerId FROM customers ORDER BY CustomerId DESC LIMIT 1";

			var data = connection.QueryFirstOrDefault<Customer>(sql2);

			connection.Close();

			if (null != data)
			{
				return data.CustomerId;
			}
			return 0;
		}

		public void DeleteCustomer(int customerId)
		{
			connection.Open();

			string sql = "DELETE FROM customers WHERE CustomerId = @CustomerId";

			connection.Execute(sql, new { CustomerId = customerId });

			connection.Close();
		}
	}
}