using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg_project.Models
{
    internal class SavingsGoal
    {
        public string GoalId { get; set; }
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal PercentageCompleted { get => (CurrentAmount / TargetAmount) * 100; } 
        public bool IsCompleted { get => CurrentAmount >= TargetAmount; }

        public SavingsGoal(string goalId, string goalName, decimal targetAmount, decimal currentAmount)
        {
            GoalId = goalId;
            GoalName = goalName;
            TargetAmount = targetAmount;
            CurrentAmount = currentAmount;
        }
    }
}
