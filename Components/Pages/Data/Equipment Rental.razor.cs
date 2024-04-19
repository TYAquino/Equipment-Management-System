using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareAnalysis.Models;

namespace SoftwareAnalysis
{
	public partial class Manage_Rental : ComponentBase
	{
		private RentalDbAccessor RentalDbAccessor = new RentalDbAccessor();

		public List<Rental> rentals = new List<Rental>();

		protected override void OnInitialized()
		{
			RentalDbAccessor.CreateRentalTable();

			rentals = RentalDbAccessor.GetRentals();
		}

		public void Add(Rental rental)
		{
			int id = RentalDbAccessor.AddRental(rental);

			Rental newRental = new Rental(id, rental.RentalStartDate, rental.RentalEndDate, rental.RentalPrice, rental.CustomerId, rental.FirstName, rental.LastName, rental.EmailAddress, rental.PhoneNumber, rental.EquipmentId, rental.CategoryId, rental.Description, rental.Quantity, rental.EquipmentName);
			rentals.Add(newRental);
		}

		public void Delete(Rental rental)
		{
			rentals.Remove(rental);
			RentalDbAccessor.DeleteRental(rental.RentalId);
		}
	}

}