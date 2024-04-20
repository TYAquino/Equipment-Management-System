using Dapper;
using SoftwareAnalysis;
using MySqlConnector;

using SoftwareAnalysis.Models;

namespace SoftwareAnalysis
{
	public class CategoryDbAccessor : MyDbAccessor
	{
		public void CreateCategoryTable()
		{
			connection.Open();

			string sql = "CREATE TABLE IF NOT EXISTS category (CategoryId INT(10) PRIMARY KEY, CategoryName VARCHAR(50))";

			connection.Execute(sql);

			connection.Close();
		}

		public List<Category> GetCategories()
		{
			connection.Open();

			string sql = "SELECT * FROM category";

			var categories = connection.Query<Category>(sql);

			connection.Close();

			return categories.ToList();
		}

		public int AddCategory(Category category)
		{
			connection.Open();

			string sql = "INSERT INTO category (CategoryName) VALUES (@CategoryName)";

			connection.Execute(sql, category);

			//var data = connection.Query("SELECT LAST_INSERT_ID()");
			string sql2 = "SELECT CategoryId FROM category ORDER BY CategoryId DESC LIMIT 1";

			var data = connection.QueryFirstOrDefault<Category>(sql2);

			connection.Close();

			if (null != data)
			{
				return data.CategoryId;
			}
			return 0;
		}

		//public void UpdateCategory(Category category)
		//{
		//	connection.Open();

		//	string sql = "UPDATE category SET CategoryName = @CategoryName, WHERE CategoryId = @CategoryId";

		//	connection.Execute(sql, category);

		//	connection.Close();
		//}

		public void DeleteCategory(int categoryId)
		{
			connection.Open();

			string sql = "DELETE FROM category WHERE CategoryId = @CategoryId";

			connection.Execute(sql, new { CategoryId = categoryId });

			connection.Close();
		}
	}
}
