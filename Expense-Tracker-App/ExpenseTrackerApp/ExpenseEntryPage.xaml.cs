using ExpenseTrackerApp.Model;
using ExpenseTrackerApp.Models;
using System;
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
        public List<Category> Categories;
          
        public ExpenseEntryPage()
        {                       
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Categories = new List<Category>();
            Categories.Add(new Category { IconFilepath = "Assets/Icons/animals.png", Name = "House" });
            Categories.Add(new Category { IconFilepath = "Assets/Icons/cartoon.png", Name = "Pet" });
            Categories.Add(new Category { IconFilepath = "Assets/Icons/taunt.png", Name = "Savings" });

            category.BindingContext = new CategoryData(Categories);
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if(string.IsNullOrWhiteSpace(expense.Filename))
            {
                // create and save expense
                var filename = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"{Path.GetRandomFileName()}.expense.txt");
                File.WriteAllText(filename, $"{name.Text};{amount.Text};{expensedate.Date};{category.SelectedItem}");
            }
            else
            {
                File.WriteAllText(expense.Filename, $"{name.Text};{amount.Text};{String.Format("{0:d}", expensedate.Date)};{category.SelectedItem}");
            }

            await Navigation.PopModalAsync();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}