using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg_project
{
    internal class Program
    {
       static Dictionary<string, decimal> budgetLimits = new Dictionary<string, decimal>();
        // Example: budgetLimits["Groceries"] = 500.00;
        static void SetBudgetLimit()
        {
            Console.WriteLine("Set budget Limit:");
            string[] catergories = { "Rent", "Groceries", "Utilities", "Entertainment", "Transport", "Wifi" };
           

            foreach (string category in catergories)
            {
                decimal limit = 0;
                bool validInput = false;
                do
                {
                    Console.WriteLine("Enter Limit amount:");
                    if (!decimal.TryParse(Console.ReadLine(), out limit))
                        Console.WriteLine("cannot retrive amount");
                    else if (!IsValidAmount(limit))
                        Console.WriteLine("Amount should be numeric and greater thn 0");
                    else
                        validInput = true;
                }
                while (!validInput);

                budgetLimits[category] = limit;
            }


            Console.WriteLine("Budget Limit saved succesfully");
        }
        // Please do the updateBudgetLimit, thank you
       static Dictionary<string, double> savingsGoals = new Dictionary<string, double>();
       static List<Transactions> transactions = new List<Transactions>();
        static List<string> goalNames = new List<string>();
        static List<decimal> goalTargets = new List<decimal>();
        static List<decimal> goalCurrentAmount = new List<decimal>();
    
        enum Menu
        {
          SetBudgetLimit =1,
          AddIncome,
          AddExpense,
          ViewTransactionHistory,
          ViewBudgetSummary,
          SplitSharedExpense,
          // updateBudgetLimit
          SVSavingindGoal,
          Exit
        }
        static void DisplayMenu()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("STUDENT BUDGET TRACKER");
            Console.WriteLine("=========================================");
            Console.WriteLine(" ");
            Console.WriteLine("Welcome! Please select an option:");
            Console.WriteLine("");
            Console.WriteLine("Add Income");
            Console.WriteLine("Add Expense");
            Console.WriteLine("3. View Transaction History");
            Console.WriteLine("4. View Budget Summary");
            Console.WriteLine("5. Split Shared Expense");
            Console.WriteLine("6. Set Budget Limit");
            Console.WriteLine("7. Set/View Savings Goal");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Please enter option");
        }

  

      

        // Can you please do the expense splitter, its not complicated

        static void AddSavingsGoal()
        {
            bool validInput = false;
            decimal target = 0;

            Console.WriteLine("Enter savings goal name (e.g. Vacation, New Phone):");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Goal name cannot be blank");
                return;
            }

            do
            {
                Console.WriteLine("Enter target amount:");
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out target))
                    Console.WriteLine("Please enter a valid number");
                else if (!IsValidAmount(target))
                    Console.WriteLine("Target must be greater than 0");
                else
                    validInput = true;

            } while (!validInput);

            goalNames.Add(name);
            goalTargets.Add(target);
            goalCurrentAmount.Add(0); // starts at 0

            Console.WriteLine($"Savings goal '{name}' of R{target} created!");
        }


        static void AddToSavingsGoal()
        {
            if (goalNames.Count == 0)
            {
                Console.WriteLine("No savings goals found, create one first.");
                return;
            }

            // show all goals
            Console.WriteLine("--- Your Savings Goals ---");
            for (int i = 0; i < goalNames.Count; i++)
            {
                decimal progress = (goalCurrentAmount[i] / goalTargets[i]) * 100;
                Console.WriteLine($"{i + 1}. {goalNames[i]} | R{goalCurrentAmount[i]} / R{goalTargets[i]} | {progress:F1}% complete");
            }

            // pick a goal
            Console.WriteLine("Enter goal number to add money to:");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > goalNames.Count)
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            int index = choice - 1; // lists start at 0, menu starts at 1

            // add money
            bool validInput = false;
            decimal amount = 0;

            do
            {
                Console.WriteLine($"Enter amount to add to '{goalNames[index]}':");
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out amount))
                    Console.WriteLine("Please enter a valid number");
                else if (!IsValidAmount(amount))
                    Console.WriteLine("Amount must be greater than 0");
                else
                    validInput = true;

            } while (!validInput);

            goalCurrentAmount[index] += amount;

            decimal newProgress = (goalCurrentAmount[index] / goalTargets[index]) * 100;

            if (newProgress >= 100)
                Console.WriteLine($"Congratulations! You have reached your '{goalNames[index]}' goal!");
            else
                Console.WriteLine($"R{amount} added! Progress: {newProgress:F1}% complete");
        }
        static void Main(string[] args)
        {
            //call set budget limit
            // then you can continue with the norm

        }

   
        
    }
}
