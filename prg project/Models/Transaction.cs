using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prg_project.Enums;

namespace prg_project.Models
{
    public class Transaction
    {
        private decimal _amount;
        public string TransactionID { get; set; }  
        public User User { get; set; }
        public TransactionType Type { get; set; }       // "Income" or "Expense"
        public Category Category { get; set; }   // "Rent", "Groceries", etc.
        public decimal Amount 
        {
            get => _amount;
            set
            { 
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Amount cannot be negative.");
                else
                    _amount = value;
            }
        }     // e.g. 1500.00
        public DateTime Date { get; set; }       // e.g. "2026-05-17"
        public string Description { get; set; } // optional note

        public Transaction(string id,User user, TransactionType type, Category category, decimal amount, DateTime date, string description)
        {
            TransactionID = id;
            User.UserId = user.UserId;
            Type = type;
            Category.CategoryName = category.CategoryName;
            Amount = amount;
            Date = date;
            Description = description;
        }

    }
}
