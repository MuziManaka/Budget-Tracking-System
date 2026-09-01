using prg_project.Enums;
using prg_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg_project.Services
{
    internal class TransactionService
    {
        public List<Transaction> transactions = new List<Transaction>();
        static bool IsValidAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }
            else
            {
                return true;
            }
        }
        static bool isValidDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                throw new ArgumentException("Date cannot be in the future.");
            }
            else
            {
                return true;
            }
        }
 
        public void AddTransaction(Transaction transaction )
        {
           
                if (!IsValidAmount(transaction.Amount))
                {
                    throw new ArgumentException("Amount must be greater than zero.");
                }
                if (!isValidDate(transaction.Date))
                {
                    throw new ArgumentException("Date cannot be in the future.");
                }
                if (string.IsNullOrEmpty(transaction.ID))
                {
                    throw new ArgumentException("ID cannot be null or empty.");
                }
                transactions.Add(transaction);  
        }
        public Transaction SearchTransactionById(string id)
        {
            return transactions.FirstOrDefault(t => t.ID == id);
        }

        public void RemoveTransaction(string id)
        {
            var transaction = SearchTransactionById(id);
            if (transaction != null)
            {
                transactions.Remove(transaction);
            }
            else
            {
                throw new ArgumentException("Transaction not found.");
            }
        }
        public List<Transaction> GetTransactions()
        {
            return transactions;
        }   

        public decimal GetTotalIncome()
        {
            return transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);
        }

        public decimal GetTotalExpense()
        {
            return transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);
        }

    }
}
