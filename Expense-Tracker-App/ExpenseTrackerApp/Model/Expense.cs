using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace ExpenseTrackerApp.Models
{
    public class Expense
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public string ExpenseDate { get; set; }

        public DateTime EntryDate { get; set; }

        // public int ExpenseId { get; set; }

        public string Filename { get; set; }

        // public int EntryCount = 0;
    }
}
