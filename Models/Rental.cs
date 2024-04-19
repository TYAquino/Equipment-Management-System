namespace SoftwareAnalysis.Models
{
	public class Rental
	{
		public int RentalId { get; set; }
		public DateOnly RentalStartDate { get; set; }
		public DateOnly RentalEndDate { get; set; }
		public int RentalPrice { get; set; }
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public int PhoneNumber { get; set; }
		public int EquipmentId { get; set; }
		public int CategoryId { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public string EquipmentName { get; set; }

		public Rental() 
		{

		}
		public Rental(int rentalId, DateOnly rentalStartDate, DateOnly rentalEndDate, int rentalPrice, int customerId, string firstName, string lastName, string emailAddress, int phoneNumber, int equipmendId, int categoryId, string description, int quantity, string equipmentName)
		{
			RentalId = rentalId;
			RentalStartDate = rentalStartDate;
			RentalEndDate = rentalEndDate;
			RentalPrice = rentalPrice;
			CustomerId = customerId;
			FirstName = firstName;
			LastName = lastName;
			EmailAddress = emailAddress;
			PhoneNumber = phoneNumber;
			EquipmentId = equipmendId;
			CategoryId = categoryId;
			Description = description;
			Quantity = quantity;
			EquipmentName = equipmentName;
				
		}
	}
}
