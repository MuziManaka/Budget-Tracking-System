using prg_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg_project.Services
{
    internal class SavingsService
    {
        public List<SavingsGoal> savingsGoals = new List<SavingsGoal>();
        public void CreateGoal(SavingsGoal goal)
        {
            if (goal != null)
            { 
                string goalId = $"SG -{ Guid.NewGuid().ToString()}";
                savingsGoals.Add(goal);
            }
            else
            {
                throw new ArgumentNullException(nameof(goal));
            }
        }

        public void AddMoney(string id, decimal amount)
        {
            var goal = savingsGoals.FirstOrDefault(g => g.GoalId == id);
            if (goal == null)
            {
                throw new ArgumentException("No goal exist");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Some money should be entered");
            }
            goal.CurrentAmount += amount;
        }

       public void RemoveSavingsGoal(string id)
        {
            var goal = savingsGoals.FirstOrDefault(g => g.GoalId == id);
            if (goal == null)
            {
                throw new ArgumentException("No goal exist");
            }
            savingsGoals.Remove(goal);
        }
    }
}
