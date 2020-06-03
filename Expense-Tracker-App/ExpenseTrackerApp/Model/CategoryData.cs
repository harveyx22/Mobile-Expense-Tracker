using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExpenseTrackerApp.Model
{
	class CategoryData
	{
		public List<Category> Categories { get; set; }

		public CategoryData()
		{
			List<Category> categoriesList = new List<Category>();

			categoriesList.Add(new Category { Name = "House", IconFilepath = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Assets/Categories/house.png") });
			categoriesList.Add(new Category { Name = "Pet", IconFilepath = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Assets/Categories/pet.png") });
			categoriesList.Add(new Category { Name = "Savings", IconFilepath = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Assets/Categories/savings.png") });

			Categories = categoriesList.OrderBy(c => c.Name).ToList();
		}
	}
}
