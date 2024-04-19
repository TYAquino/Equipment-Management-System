using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareAnalysis.Models;

namespace SoftwareAnalysis
{
	public partial class Manage_Customer : ComponentBase
	{
		private CustomerDbAccessor CustomerDbAccessor = new CustomerDbAccessor();

		public List<Customer> customers = new List<Customer>();

		protected override void OnInitialized()
		{
			CustomerDbAccessor.CreateCustomerTable();

			customers = CustomerDbAccessor.GetCustomers();
		}

		public void Add(Customer customer)
		{
			int id = CustomerDbAccessor.AddCustomer(customer);

			// System.Diagnostics.Debug.WriteLine("ID is " + id);
			Customer newCustomer = new Customer(id, customer.FirstName, customer.LastName, customer.EmailAddress, customer.PhoneNumber, customer.Comment );
			customers.Add(newCustomer);
		}

		public void Delete(Customer customer)
		{
			customers.Remove(customer);
			CustomerDbAccessor.DeleteCustomer(customer.CustomerId);
		}
	}

}