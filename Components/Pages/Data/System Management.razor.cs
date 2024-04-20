using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareAnalysis.Models;

namespace SoftwareAnalysis
{
	public partial class Manage_Category : ComponentBase
	{
		private CategoryDbAccessor CategoryDbAccessor = new CategoryDbAccessor();

		public List<Category> categories = new List<Category>();

		public string errorMessage;

		protected override void OnInitialized()
		{
			try
			{
				CategoryDbAccessor.CreateCategoryTable();

				categories = CategoryDbAccessor.GetCategories();
			}
			catch (Exception ex)
			{
				errorMessage = $"Error Occured: {ex.Message}";
			}
		}

		public void Add(Category category)
		{
			try
			{
				int id = CategoryDbAccessor.AddCategory(category);

				// System.Diagnostics.Debug.WriteLine("ID is " + id);
				Category newCategory = new Category(id, category.CategoryName);
				categories.Add(newCategory);
			}
			catch (Exception ex)
			{
				errorMessage = $"Error Occured: {ex.Message}";
			}
			
		}

		public void Delete(Category category)
		{
			try
			{
				categories.Remove(category);
				CategoryDbAccessor.DeleteCategory(category.CategoryId);
			}
			catch (Exception ex)
			{
				errorMessage = $"Error Occured: {ex.Message}";
				categories.Add(category);
			}
		}
	}

	
}