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

		public string errorMessage;

		protected override void OnInitialized()
		{
			try
			{
				CustomerDbAccessor.CreateCustomerTable();

				customers = CustomerDbAccessor.GetCustomers();
			}
			catch (Exception ex)
			{
				errorMessage = $"Error Occured: {ex.Message}";
			}

		}

		public void Add(Customer customer)
		{
			try
			{
				int id = CustomerDbAccessor.AddCustomer(customer);

				// System.Diagnostics.Debug.WriteLine("ID is " + id);
				Customer newCustomer = new Customer(id, customer.FirstName, customer.LastName, customer.EmailAddress, customer.PhoneNumber, customer.Comment);
				customers.Add(newCustomer);
			}
			catch (Exception ex)
			{
				errorMessage = $"Error Occured: {ex.Message}";
			}
		}

		public void Delete(Customer customer)
		{
			try
			{
				customers.Remove(customer);
				CustomerDbAccessor.DeleteCustomer(customer.CustomerId);
			}
			catch (Exception ex)
			{
				errorMessage = $"Error Occured: {ex.Message}";
				customers.Add(customer);
			}
			
		}
	}

}