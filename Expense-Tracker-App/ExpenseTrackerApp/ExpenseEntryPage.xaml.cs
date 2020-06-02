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
        public ExpenseEntryPage()
        {
            InitializeComponent();
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
                File.WriteAllText(expense.Filename, $"{name.Text};{amount.Text};{expensedate.Date};{category.SelectedItem}");
            }

            await Navigation.PopModalAsync();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}