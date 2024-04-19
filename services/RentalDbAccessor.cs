using Dapper;
using SoftwareAnalysis;
using MySqlConnector;
using SoftwareAnalysis.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftwareAnalysis
{
    public class RentalDbAccessor : MyDbAccessor
    {
        public void CreateRentalTable()
        {
            connection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS rentals (RentalId INT(10) PRIMARY KEY, CustomerId INT(10), FirstName VARCHAR(255), LastName VARCHAR(255), PhoneNumber VARCHAR(255), EmailAddress VARCHAR(255), EquipmentId INT(10), EquipmentName VARCHAR(255), Description VARCHAR(255), RentalStartDate DATE, RentalEndDate DATE, Quantity INT(20), RentalPrice INT(255))";

            connection.Execute(sql);

            connection.Close();
        }
		public List<Rental> GetRentals()
		{
			connection.Open();

			string sql = "SELECT * FROM rentals";

			var rentals = connection.Query<Rental>(sql);

			connection.Close();

			return rentals.ToList();
		}

		public int AddRental(Rental rental)
        {
            connection.Open();

            string sql = "INSERT INTO rentals (CustomerId, EquipmentId, EquipmentName, Description, RentalStartDate, RentalEndDate, Quantity, RentalPrice) VALUES (@CustomerId, @EquipmentId, @EquipmentName, @Description, @RentalStartDate, @RentalEndDate, @Quantity, @RentalPrice)";

            connection.Execute(sql, rental);

			string sql2 = "SELECT RentalId FROM rentals ORDER BY RentalId DESC LIMIT 1";

			var data = connection.QueryFirstOrDefault<Rental>(sql2);

			connection.Close();

			if (null != data)
			{
				return data.RentalId;
			}
			return 0;

		}
        public void DeleteRental(int rentalId)
        {
            connection.Open();

            string sql = "DELETE FROM rentals WHERE RentalId = @RentalId";

            connection.Execute(sql, new { RentalId = rentalId });

            connection.Close();
        }
    }
}