using ExpenseTrackerApp.Model;
using ExpenseTrackerApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTrackerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseEntryPage : ContentPage
    {
        public ExpenseEntryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var categoriesList = new List<Category>();

            categoriesList.Add(new Category { Name = "Clothes", Image = "clothes.png" });
            categoriesList.Add(new Category { Name = "Dining", Image = "dining.png" });
            categoriesList.Add(new Category { Name = "Fuel", Image = "fuel.png" });
            categoriesList.Add(new Category { Name = "Entertainment", Image = "entertainment.png" });
            categoriesList.Add(new Category { Name = "Gifts", Image = "gifts.png" });
            categoriesList.Add(new Category { Name = "Savings", Image = "savings.png" });
            categoriesList.Add(new Category { Name = "Medical", Image = "medical.png" });
            categoriesList.Add(new Category { Name = "Kids", Image = "kids.png" });
            categoriesList.Add(new Category { Name = "Groceries", Image = "groceries.png" });
            categoriesList.Add(new Category { Name = "Debt", Image = "debt.png" });
            categoriesList.Add(new Category { Name = "Travel", Image = "travel.png" });
            categoriesList.Add(new Category { Name = "Housing", Image = "housing.png" });

            // category.ItemsSource = categoriesList.OrderBy(c => c.Name).ToList(); // for picker
            
            selectCategory.ItemsSource = categoriesList.OrderBy(c => c.Name).ToList(); // for listview
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            var chosen = (Category)selectCategory.SelectedItem;
            var filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                $"{Path.GetRandomFileName()}.expense.txt");

            if (string.IsNullOrWhiteSpace(expense.Filename))
            {
                File.WriteAllText(filename, $"{name.Text}, {amount.Text}, {expensedate.Date}, {chosen.Name}");
            }
            else
            {
                File.WriteAllText(filename, $"{name.Text}, {amount.Text}, {expensedate.Date}, {chosen.Name}");
            }

            await Navigation.PopModalAsync();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}