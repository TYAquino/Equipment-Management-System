namespace SoftwareAnalysis.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public int PhoneNumber { get; set; }
		public string Comment { get; set; }

		public Customer()
		{

		}

		public Customer(int customerId, string firstName, string lastName, string emailAddress, int phoneNumber, string comment)
		{
			CustomerId = customerId;
			FirstName = firstName;
			LastName = lastName;
			EmailAddress = emailAddress;
			PhoneNumber = phoneNumber;
			Comment = comment;
		}
	}
}
