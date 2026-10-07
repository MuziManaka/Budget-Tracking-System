 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prg_project.Enums;
namespace prg_project.Models
{
    internal class Budget
    {
        public string BudgetId { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }   // "Rent", "Groceries", etc.
        public decimal Limit { get; set; }     // e.g. 1500.00
        public decimal AmountSpent { get; set; } // e.g. 500.00
        public decimal RemainingAmount { get => Limit - AmountSpent; } // e.g. 1000.00
        public decimal PercentageUsed { get => (AmountSpent / Limit) * 100; } // e.g. 33.33

        public Budget(string budgetId, User user, Category category, decimal limit, decimal amountSpent)// decimal remainingAmount, decimal percentageUsed)
        {
            BudgetId = budgetId;
            User.UserId = user.UserId;
            Category = category;
            Limit = limit;
            AmountSpent = amountSpent;
           // RemainingAmount = remainingAmount;
           // PercentageUsed = percentageUsed;
        }

    }
}
