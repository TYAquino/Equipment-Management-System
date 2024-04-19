namespace SoftwareAnalysis.Models
{
	public class Equipment
	{
		public int EquipmentId { get; set; }
		public int CategoryId { get; set; }
		public string EquipmentName { get; set; }
		public string EquipmentDescription { get; set; }
		public int DailyRate { get; set; }
		public Equipment()
		{

		}
		public Equipment(int equipmentId, int categoryId, string equipmentName, string equipmentDescription, int dailyRate)
		{
			EquipmentId = equipmentId;
			CategoryId = categoryId;
			EquipmentName = equipmentName;
			EquipmentDescription = equipmentDescription;
			DailyRate = dailyRate;
		}
	}
}
