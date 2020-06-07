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
        public List<Category> Categories;
          
        public ExpenseEntryPage()
        {                       
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            selectCategory.ItemsSource = CategInfo.Categories; // for listview
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            var chosen = (Category)selectCategory.SelectedItem;

            var budgetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Budget.txt");

            decimal CurrentBudget = decimal.Parse(File.ReadAllText(budgetFile));
            decimal CurrentExpense = decimal.Parse(amount.Text);

            if (CurrentBudget - CurrentExpense >= 0)
            {
                CurrentBudget = CurrentBudget - CurrentExpense;
                File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Budget.txt"), CurrentBudget.ToString());

                if (string.IsNullOrWhiteSpace(expense.Filename))
                {
                    expense.Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.expense.txt");
                    File.WriteAllText(expense.Filename, $"{name.Text};{amount.Text};{expensedate.Date.ToShortDateString()};{chosen.Image}");
                }
                else
                {
                    File.WriteAllText(expense.Filename, $"{name.Text};{amount.Text};{expensedate.Date.ToShortDateString()};{chosen.Image}");
                }
            }

            else
            {
                await DisplayAlert("Warning", "Insufficient funds in the budget for this purchase", "OK");
            }         

            await Navigation.PopModalAsync();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
