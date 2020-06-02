using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ExpenseTrackerApp.Model
{
    public class Budget
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
