using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExpenseTrackerApp.Model
{
	class CategoryData
	{
		public List<Category> CategoriesList { get; set; }

		public CategoryData(List<Category> CategoryList)
		{
			CategoriesList = CategoryList;
		}
	}
}
