using ExpenseTrackerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTrackerApp.Models
{
    public static class CategInfo
    {
        public static List<Category> Categories = new List<Category>
        {
            new Category { Name = "Clothes", Image = "clothes.png" },
            new Category { Name = "Dining", Image = "dining.png" },
            new Category { Name = "Fuel", Image = "fuel.png" },
            new Category { Name = "Entertainment", Image = "entertainment.png" },
            new Category { Name = "Gifts", Image = "gifts.png" },
            new Category { Name = "Savings", Image = "savings.png" },
            new Category { Name = "Medical", Image = "medical.png" },
            new Category { Name = "Kids", Image = "kids.png" },
            new Category { Name = "Groceries", Image = "groceries.png" },
            new Category { Name = "Debt", Image = "debt.png" },
            new Category { Name = "Travel", Image = "travel.png" },
            new Category { Name = "Housing", Image = "housing.png" }
        }.OrderBy(c => c.Name).ToList();
    }
}
