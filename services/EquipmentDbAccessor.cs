using Dapper;
using System;
using SoftwareAnalysis;
using MySqlConnector;
using SoftwareAnalysis.Models;

namespace SoftwareAnalysis
{
	public class EquipmentDbAccessor : MyDbAccessor
	{
		public void CreateEquipmentTable()
		{
			connection.Open();

			string sql = "CREATE TABLE IF NOT EXISTS equipments (EquipmentId INT(10) PRIMARY KEY, CategoryId INT(10), EquipmentName VARCHAR(255), EquipmentDescription VARCHAR(255), DailyRate INT(10))";

			connection.Execute(sql);

			connection.Close();
		}
		public List<Equipment> GetEquipments()
		{
			connection.Open();

			string sql = "SELECT * FROM equipments";

			var equipments = connection.Query<Equipment>(sql);

			connection.Close();

			return equipments.ToList();
		}

        public int AddEquipment(Equipment equipment)
        {
            connection.Open();

            string sql = "INSERT INTO equipments (CategoryId, EquipmentName, EquipmentDescription, DailyRate) VALUES (@CategoryId, @EquipmentName, @EquipmentDescription, @DailyRate)";

            connection.Execute(sql, equipment);

            string sql2 = "SELECT EquipmentId FROM equipments ORDER BY EquipmentId DESC LIMIT 1";

            var data = connection.QueryFirstOrDefault<Equipment>(sql2);

            connection.Close();

            if (null != data)
            {
                return data.EquipmentId;
            }
            return 0;
        }

        public void DeleteEquipment(int equipmentId)
        {
            connection.Open();

            string sql = "DELETE FROM equipments WHERE EquipmentId = @EquipmentId";

            connection.Execute(sql, new { EquipmentId = equipmentId });

            connection.Close();
        }
    }
}