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
            selectCategory.ItemsSource = CategInfo.Categories; // for listview
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