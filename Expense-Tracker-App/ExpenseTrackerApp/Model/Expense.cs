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

        public DateTime ExpenseDate { get; set; }

        public DateTime EntryDate { get; set; }

        public int ExpenseId { get; set; }

        public string Filename { get; set; }

        public int EntryCount = 0;

        //public Expense(string name, decimal amount, DateTime expenseDate, ExpenseCategory category)
        //{
        //    this.ExpenseId = EntryCount++;
       //     this.Name = name;
        //    this.Amount = amount;
        //    this.ExpenseDate = expenseDate;
        //    this.Category = category;
       // }
    }
}
