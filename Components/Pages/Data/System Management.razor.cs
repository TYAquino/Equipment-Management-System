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

		protected override void OnInitialized()
		{
			CategoryDbAccessor.CreateCategoryTable();

			categories = CategoryDbAccessor.GetCategories();
		}

		public void Add(Category category)
		{
			int id = CategoryDbAccessor.AddCategory(category);

			// System.Diagnostics.Debug.WriteLine("ID is " + id);
			Category newCategory = new Category(id, category.CategoryName);
			categories.Add(newCategory);
		}

		public void Delete(Category category)
		{
			categories.Remove(category);
			CategoryDbAccessor.DeleteCategory(category.CategoryId);
		}
	}

	
}