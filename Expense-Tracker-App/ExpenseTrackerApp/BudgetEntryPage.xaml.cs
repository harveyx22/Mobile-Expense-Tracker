using ExpenseTrackerApp.Model;
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
    public partial class BudgetEntryPage : ContentPage
    {
        public BudgetEntryPage()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //Open (or overwrite) budget text file with new budget value
            string currentBudget = budgetEntry.Text;
            var budgetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Budget.txt");
            File.WriteAllText(budgetFile, currentBudget, result);
            
            // Delete all expenses upon setting new budget
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expense.txt");
            foreach (var filename in files)
            {

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }

            await Navigation.PopModalAsync();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}