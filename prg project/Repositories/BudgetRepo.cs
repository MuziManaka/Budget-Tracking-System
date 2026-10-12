using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using prg_project.Models;
using prg_project.Enums;
using System.Configuration;

namespace prg_project.Repositories
{
    public class BudgetRepo
    {
        private readonly string connectionstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        // ========================= ADDING DAATA =============================================
        public void AddBudget(Budget budget)
        {
            //1. sql statemenet
            string sql =
                @"INSERT INTO BudgetsT
                    (BudgetID, UserID, CategoryID, BugdetLimit)
                   VALUES
                    (@BudgetId, @User, @CategoryId, @Limit)";

            // create a connection object that will use the connection string to access the db
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                // that conn goes with a command ankere you want to add data, so create a command object that will handle the connetion and the sql statement
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    // now write the data in the db
                    comm.Parameters.AddWithValue("@BudgetId", budget.BudgetId);
                    comm.Parameters.AddWithValue("@User", budget.User);
                    comm.Parameters.AddWithValue("@Category", budget.Category);
                    comm.Parameters.AddWithValue("@Limit", budget.Limit);
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
            }
        }

        // ======================= GETTING OR READING DATA ==================================
        /*
         oaky logic yamo esimple, nahana nkare oya spaza, wo vaya leng? plastic ankere. then thats your list pakage yago tsentsa dilo

         */

        public List<Budget> AllBudgets()
        {
            List<Budget> budgets = new List<Budget>();
            //sql statement always
            string sql =
                @"SELECT *
                  FROM BudgetsT
                ";

            // are tome, since re interacter le database re thloka connection
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                // after okreya connection betsa commander hore atlo era merko
                using (SqlCommand comm = new SqlCommand(sql,conn))
                {
                    /*
                     bynong eba different ye he, pile bula connection beause without conekt ahona merko, sho after mo wo berekisa silo sesingwe byana
                     basi betsa Sqlreader, deman oya ko databasing fetsa ocollect'a di detail, mara according to command e omo feleng yona wang hlalohyna
                     */
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        // okay nou shashalaza o fitle, mara he doesn't know what to do yet, so rao botsa
                        // retlore eya ko db and fetch eaxh line for me, mos wa etsi hore ke "while loop dydang"
                        while(reader.Read())
                        {
                            // remember our prevoius analogy ya spaza le plastic, yah? sho. so lets go shopping 
                            Budget budget = new Budget
                                (
                                    reader["BudgetId"].ToString(),
                                    (User)reader["User"],
                                    (Category)reader["Category"],
                                    Convert.ToDecimal(reader["Limit"])
                                );
                            // tsentsa kamo hare ha plastic
                            budgets.Add(budget);
                        }
                    }
                }
            }
            return budgets;
        }
    }
}
