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
         void OnSetBudgetClicked(object sender, EventArgs e)
        {
            var budget = (Budget)BindingContext;

            if (string.IsNullOrWhiteSpace(budget.Filename))
            {
                // Set Budget 
                var filename = Path.Combine(MainPage.FolderPath, $"{Path.GetRandomFileName()}.budgetes.txt");
                File.WriteAllText(filename, budget.Text);
            }
            else
            {
                // Budget Is Set
                File.WriteAllText(budget.Filename, budget.Text);
            }
        }