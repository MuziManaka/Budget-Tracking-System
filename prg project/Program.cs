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

        static bool IsValidAmount(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void AddIncome()
        {
            // Open an empty object
            Transactions NewIncome = new Transactions();
            bool validInput = false;
            decimal income = 0;
            do
            {
                // read user input
                Console.WriteLine("Enter Income");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Answer cannot be blank");
                    // check if user has filled in anything
                }
                else if (!(decimal.TryParse(input, out income)))
                {
                    Console.WriteLine("Cannot retrieve amount");
                }
                else if (!IsValidAmount(income))
                {
                    Console.WriteLine("Number cannot be negative or zero");
                }
                else
                    validInput = true;
            } while (validInput);
         
            Console.WriteLine($"Income of R{income} has been succefully saved ");
            NewIncome.Type = "Income";
            NewIncome.Category = "N/A";
            NewIncome.Amount = income;
            NewIncome.Date = DateTime.Now;
            NewIncome.Description = "Income";
            transactions.Add(NewIncome);

        }
        static void AddExpense()
        {
            Transactions NewExpense = new Transactions();
            bool validInput = false;
            decimal amount = 0;

            do
            {
                Console.WriteLine("Enter expense amount");
                string input = Console.ReadLine();
                if (!(decimal.TryParse(input, out amount)))
                    Console.WriteLine("amount cannot be retrieved");
                else if (!IsValidAmount(amount))
                    Console.WriteLine("Amount should be numeric and greater than 0");
                else
                    validInput = true; 

            }
            while (!validInput);

            NewExpense.Amount = amount;

            Console.WriteLine("Please enter category");
            Console.WriteLine("1. Rent");
            Console.WriteLine("2. Groceries");
            Console.WriteLine("3. Utilties");
            Console.WriteLine("4. Entertainment");
            Console.WriteLine("5. Transport");
            Console.WriteLine("6. WiFi");

            Console.WriteLine("Please enter category number");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Cannot retrieve amount");
                return;
            }
            switch (choice)
            {
                case 1:
                    NewExpense.Category = "Rent";
                    Console.WriteLine($"Expense of R{amount} is succefully saved under Rent");
                    break;
                case 2:
                    NewExpense.Category = "Groceries";
                    Console.WriteLine($"Expense of R{amount} is succefully saved under Groceries");
                    break;
                case 3:
                    NewExpense.Category = "Utilities";
                    Console.WriteLine($"Expense of R{amount} is succefully saved under Utilities");
                    break;
                case 4:
                    NewExpense.Category = "Entertainment";
                    Console.WriteLine($"Expense of R{amount} is succefully saved under Entertainment");
                    break;
                case 5:
                    NewExpense.Category = "Transport";
                    Console.WriteLine($"Expense of R{amount} is succefully saved under Transport");
                    break;
                case 6:
                    NewExpense.Category = "WiFi";
                    Console.WriteLine($"Expense of R{amount} is succefully saved under WiFi");
                    break;

                    // add an extra case for an other option then we will ask for a description of the expense
                    // do the check for the budgetLimit, after setting one for each category
            }
            NewExpense.Type = "Expense";
            NewExpense.Date = DateTime.Now;
            NewExpense.Description = "Expense";
            transactions.Add(NewExpense);

            // Get total spent in that category so far
            decimal totalInCategory = 0;
            foreach (Transactions t in transactions)
            {
                if (t.Category == NewExpense.Category)
                    totalInCategory += t.Amount;
            }

            // Add current expense to that total
            totalInCategory += amount;

            // Check against limit
            if (totalInCategory > budgetLimits[NewExpense.Category])
                Console.WriteLine($"Warning: {NewExpense.Category} budget exceeded!");
            else if (totalInCategory >= budgetLimits[NewExpense.Category] * 0.8m)
                Console.WriteLine($"Warning: {NewExpense.Category} budget almost exceeded!");// the 0.8m just means 80% of the amount basically the m is a parse for the decimal keyword because our amounts are decimal
        }
        static void viewHistory()
        {
            // simple and straight forward
            // check if there are any records first
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions avaible");
                return;
                //leave the option
            }
            Console.WriteLine("================Transactions History====================");
            foreach (Transactions t in transactions)
            {
                // please look at text file 1 it has the way we want it to be displayed please do that im, just doing the fundementals rn
                // you probably going to need a counter that keeps record of how many transactions are in the list
                // or you can use a for-loop
                Console.WriteLine($"Counter here! {t.Type} /t {t.Category} /t {t.Amount} /t {t.Date.ToString("yyyy/MM/dd")} /t {t.Description}");
            }
        }

        static void ShowHistory()
        {
            // this one was a bitchey one icl
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transaction available");
                return;
            }

            decimal totalIncome = 0;
            decimal totalExpense = 0;
            Dictionary<string, decimal> catergoryTotals = new Dictionary<string, decimal>();

            // loop through the list again
            foreach (Transactions t in transactions)
            {
                if (t.Type == "Income")
                {
                    totalIncome += t.Amount; 
                }
                else if (t.Type == "Expense")
                {
                    totalExpense += t.Amount;

                    if (catergoryTotals.ContainsKey(t.Category))// so its only logical to check if the dictionary has the category first before assigning it a value 
                    {
                        catergoryTotals[t.Category] += t.Amount; // if it exist ADD amount to it, wang tlhalohanya? 
                    }
                    else
                    {
                        catergoryTotals[t.Category] = t.Amount;
                    }
                }
            }
            decimal balance = totalIncome - totalExpense;

            // now to determin highest spending catergory, we will loop through our dictonary catergory totals
            string category = "";
            decimal amount = 0;

            foreach (var h in catergoryTotals)
            {
                if (h.Value > amount)
                {
                    category = h.Key;
                    amount = h.Value;
                }

            }

            /// please do the displays, luv yah for that
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
