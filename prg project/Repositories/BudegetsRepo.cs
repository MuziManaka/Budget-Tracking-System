using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using System.Data.SqlClient;

namespace prg_project.Repositories
{
    public class BudegetsRepo
    {
        private readonly string connectionstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        //============ Creating A budget and saving it to the db====================

        public void AddTransaction(Budget budget)
        {
            // sql statement
            string sql =
               @" INSERT INTO BudgetsT
                (BudgetID, UserID,Category,BudgetLimit)
                VALUES
                (@BudgetId, @UserId, @Category, @Limit)";
            
            using (SqlConnection conn =  new SqlConnection(connectionstring))
            {
                using (SqlCommand comm = new SqlCommand(conn, sql))
                {
                    command.Parameter.AddWithValue()
                }
            }

               
        }
    }
}
