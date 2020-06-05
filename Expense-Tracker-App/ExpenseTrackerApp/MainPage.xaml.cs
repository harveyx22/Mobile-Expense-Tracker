using ExpenseTrackerApp.Model;
using ExpenseTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //protected override void OnAppearing()
        //{
        //    var expenses = new List<Expense>();
        //    var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expense.txt");

        //    foreach (var filename in files)
        //    {
        //        var note = new Expense
        //        {
        //            // TO DO
        //        };
        //        expenses.Add(Expense);
        //    }

        //    listView.ItemsSource = expenses.OrderBy(n => n.Date);
        //}


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

            await Navigation.PushModalAsync(new BudgetEntryPage
            {
                BindingContext = new Budget()
            });
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
        void OnSaveButtonCliked(object sender, EventArgs e);
        {
           Double Budget = Double.TryParse();
           Double Expense = Double.TryParse();
           result.Text = (Budget - Expense).ToString(); 
        }
    }
}
