using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prg_project.Enums;
using prg_project.Models;

namespace prg_project.Services
{
    internal class BudgetService
    {
        public List<Budget> budgets = new List<Budget>();
        public List<Transaction> transactions = new List<Transaction>();

        public void AddBudgets(Budget budget)
        {
            if (budget.Limit < 0)
            {
                throw new ArgumentException("Budget limit cannot be negative.");
            }
            if (budget.AmountSpent < 0)
            {
                throw new ArgumentException("Amount spent cannot be negative.");
            }
            budgets.Add(budget);
        }
        public void SetBudget(Budget budget, Category category, decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Budget limit cannot be negative.");
            }
            var budgetcategory = budgets.FirstOrDefault(b => b.Category == category);
            if (budgetcategory != null)
            {
                budgetcategory.Limit = amount;
            }
            else
            {
                string budgetId = "BG" + Guid.NewGuid().ToString();

                budgets.Add(new Budget(budgetId, category, amount, 0));
            }


        }
        public Budget GetBudgetLimit(Budget budget)
        {
            var filter = budgets.FirstOrDefault(b => b.Category == budget.Category);
            if (filter == null)
            {
                throw new ArgumentException("No budget found");
            }
            return filter;
        }

        public decimal GetRemaingBalance(Category category)
        {
            var budget = budgets.FirstOrDefault(b => b.Category == category);
            if (budget == null)
            {
                throw new ArgumentException("The is not budget under this category");
            }
         
            var spent = transactions.Where(t => t.Type == TransactionType.Expense && t.Category == category).Sum(t => t.Amount);
            decimal remainingBalance = budget.Limit - spent;
            return remainingBalance;
           
        }

        public void RemovBudget(Category category)
        { 
            var budgettoremove = budgets.FirstOrDefault(b => b.Category == category);
            if (budgettoremove != null)
            {
                budgets.Remove(budgettoremove);
            }
            else
            {
                throw new ArgumentException("Budget for the specified category does not exist.");
            }
        }
    }
}
 
