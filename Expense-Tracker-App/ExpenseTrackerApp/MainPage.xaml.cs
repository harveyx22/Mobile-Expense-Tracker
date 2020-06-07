using ExpenseTrackerApp.Model;
using ExpenseTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseTrackerApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            

            // Check if budget text file exists and populate list view with expenses if it does.
            var budgetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Budget.txt");
            if (File.Exists(budgetFile))
            {
                var budget = decimal.Parse(File.ReadAllText(budgetFile));
                string formattedBudget = string.Format("${0:F2}", budget);
                budgetDisplay.Text = formattedBudget;

                var expenses = new List<Expense>();
                var expenseFiles = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expense.txt");

                foreach (var filename in expenseFiles)
                {
                    var expenseText = File.ReadAllText(filename).Split(';');

                    var expense = new Expense
                    {
                        Name = expenseText[0].Trim(),
                        Amount = decimal.Parse(expenseText[1]),
                        EntryDate = File.GetCreationTime(filename),
                        ExpenseDate = expenseText[2],
                        Filename = expenseText[3]
                    };
                    expenses.Add(expense);
                }
                listView.ItemsSource = expenses.OrderBy(n => n.EntryDate);
            }

            // If budget text file does not exist - send user to budget entry page. 
            else
            {
                await Navigation.PushModalAsync(new BudgetEntryPage
                {
                    BindingContext = new Budget { }
                });
            }            
        }

        private async void OnNewBudgetClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BudgetEntryPage { });            
        }

        private async void OnNewExpenseClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseEntryPage
            { 
                BindingContext = new Expense()
            });
        }


        //The below button clicked method is for test purposes and can be deleted along with the "Delete Budget" in the future
       // private void OnDeleteBudgetClicked(object sender, EventArgs e)
      //  {
      //      var budgetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Budget.txt");
      //      File.Delete(budgetFile);            
      ///  }
    }
}
