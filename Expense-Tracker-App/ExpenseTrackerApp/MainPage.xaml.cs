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

        protected override void OnAppearing()
        {
            var expenses = new List<Expense>();
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expense.txt");

            foreach (var filename in files)
            {
                var expenseText = File.ReadAllText(filename).Split(';');

                var expense = new Expense
                {
                    Name = expenseText[0].Trim(),
                    Amount = decimal.Parse(expenseText[1]),
                    EntryDate = File.GetCreationTime(filename)
                };
                expenses.Add(expense);
            }
            listView.ItemsSource = expenses.OrderBy(n => n.EntryDate);
        }


        // An expense edit page is something we can look into in the future. 
        private void OnExpenseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();

            /*await Navigation.PushModalAsync(new ExpenseEditPage
            {
                BindingContext = (Expense)e.SelectedItem
            });*/
        }

        private void OnNewBudgetClicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            /*await Navigation.PushModalAsync(new BudgetEntryPage
            {
                BindingContext = new Budget { }
            });*/

            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expense.txt");

            foreach (var filename in files)
            {

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }
        }

        private async void OnNewExpenseClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseEntryPage
            { 
                BindingContext = new Expense()
            });


            /*await Navigation.PushModalAsync(new ExpenseEntryPage
            {
                BindingContext = new Expense { }
            });*/
        }
        void OnSaveButtonCliked(object sender, EventArgs e)
        {
           Double Budget = Double.TryParse();
           Double Expense = Double.TryParse();
           result.Text = (Budget - Expense).ToString(); 
        }
    }
}
