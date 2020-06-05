using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTrackerApp.Models
{
    public class GUIbudget
    {
        // This class is for testing GUI functionality
        // Not to be used in final version of the app
        public double Budget { get; set; }

        public GUIbudget()
        {
            this.Budget = 500.0;
        }
    }
}
