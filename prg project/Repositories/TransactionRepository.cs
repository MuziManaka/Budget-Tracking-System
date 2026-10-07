using Microsoft.SqlServer;
using prg_project.Enums;
using prg_project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg_project.Repositories
{
    public class TransactionRepository
    {
        private readonly string connectionstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        //===============================Creating a transaction and saving it to the db====================
        public void AddTransaction(Transaction transaction)
        {
            //1. Sql statement
            string sql =
                @"INSERT INTO TransactionT
                   (TransactionID,UserID, Category, TransactionType, Amount, TransactioinDate, Description)
                  VALUES
                   (@TransactionID, @User, @Category, @Type, @Amount, @Date, @Description)";
            
            //2. retrieve the connection or create an object that will use the connnetion string
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //3. command is what communicates with the sever to link these two types of variables
                using (SqlCommand command = new SqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@TransactionID", transaction.TransactionID);
                    command.Parameters.AddWithValue("@User", transaction.User);
                    command.Parameters.AddWithValue("@Category", transaction.Category);
                    command.Parameters.AddWithValue("@Type", transaction.Type);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@Date", transaction.Date);
                    command.Parameters.AddWithValue("@Description", transaction.Description);
                    //4. Open the connection so work can be don
                    // 5. Use "ExecuteNonQuery when changing data"
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        //=======Get or Read ==========================

        public List<Transaction> GetAllTransactions()
        {
            //1. Create a library where you can stor all these transactions
            List<Transaction> transactions = new List<Transaction>();

            //2. Sql statement
            string sql =
                @"SELECT *
                  FROM Transactions";
            
            //3. Establish Connection
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    //4. Open the connection
                    conn.Open();
                    //5. Create an instance of a reader that will go through each row in the list and save it to the db
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                       //6. read each row
                       while(reader.Read())
                        {
                            //7. create a new transaction
                            Transaction transaction = new Transaction
                                (
                                    reader["TransactionID"].ToString(),
                                    (User)reader["UserID"],
                                    (TransactionType)reader["TransactionType"],
                                    (Category)reader["Category"],
                                    Convert.ToDecimal(reader["Amount"]),
                                    Convert.ToDateTime(reader["TransactionDate"]),
                                    reader["Description"].ToString()
                                );
                            // add trans to list
                            transactions.Add(transaction);

                        }
                       
                    }
                }
            }
            return transactions;
        }

        public List<Transaction> GetTransactionsByTransID(string transid)
        {
            List<Transaction> transactions = new List<Transaction>();

            //2. sql stat
            string sql =
                    @"SELECT *
                      FROM Transactions
                      WHERE TransactionID = @TransactionID
                      ORDER BY TransactionDate ASC
                        ";
            //3. Connection
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                //4. Command
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    //5. since we are searching using the transID we have to addthevalue before opening
                    comm.Parameters.AddWithValue("@Transaction", transid);
                    conn.Open();

                    //Execute the Sql Statement
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        //6. read each row
                        while (reader.Read())
                        {
                            //7. create a new transaction
                            Transaction transaction = new Transaction
                                (
                                    reader["TransactionID"].ToString(),
                                    (User)reader["UserID"],
                                    (TransactionType)reader["TransactionType"],
                                    (Category)reader["Category"],
                                    Convert.ToDecimal(reader["Amount"]),
                                    Convert.ToDateTime(reader["TransactionDate"]),
                                    reader["Description"].ToString()
                                );
                            // add trans to list
                            transactions.Add(transaction);

                        }
                    }
                }
            }
            return transactions;
        }

        public List<Transaction> GetTransactionsByCategory(string category)
        {
            List<Transaction> transactions = new List<Transaction>();

            //2. sql stat
            string sql =
                    @"SELECT *
                      FROM Transactions
                      WHERE Category = @Category
                      ORDER BY TransactionDate ASC
                        ";
            //3. Connection
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                //4. Command
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    //5. since we are searching using the transID we have to addthevalue before opening
                    comm.Parameters.AddWithValue("@Category", category);
                    conn.Open();

                    //Execute the Sql Statement
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        //6. read each row
                        while (reader.Read())
                        {
                            //7. create a new transaction
                            Transaction transaction = new Transaction
                                (
                                    reader["TransactionID"].ToString(),
                                    (User)reader["UserID"],
                                    (TransactionType)reader["TransactionType"],
                                    (Category)reader["Category"],
                                    Convert.ToDecimal(reader["Amount"]),
                                    Convert.ToDateTime(reader["TransactionDate"]),
                                    reader["Description"].ToString()
                                );
                            // add trans to list
                            transactions.Add(transaction);

                        }
                    }
                }
            }
            return transactions;
        }

        public List<Transaction> GetTransactionsByTransType(string type)
        {
            List<Transaction> transactions = new List<Transaction>();

            //2. sql stat
            string sql =
                    @"SELECT *
                      FROM Transactions
                      WHERE TransactionType = @Type
                      ORDER BY TransactionDate ASC
                        ";
            //3. Connection
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                //4. Command
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    //5. since we are searching using the transID we have to addthevalue before opening
                    comm.Parameters.AddWithValue("@Type", type);
                    conn.Open();

                    //Execute the Sql Statement
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        //6. read each row
                        while (reader.Read())
                        {
                            //7. create a new transaction
                            Transaction transaction = new Transaction
                                (
                                    reader["TransactionID"].ToString(),
                                    (User)reader["UserID"],
                                    (TransactionType)reader["TransactionType"],
                                    (Category)reader["Category"],
                                    Convert.ToDecimal(reader["Amount"]),
                                    Convert.ToDateTime(reader["TransactionDate"]),
                                    reader["Description"].ToString()
                                );
                            // add trans to list
                            transactions.Add(transaction);

                        }
                    }
                }
            }
            return transactions;
        }

        //=============== Update or Edit =======================

        public void UpdateTransaction(string transid, Transaction transaction)
        {
            // sql stat
            string sql =
                @"UPDATE Transactions
                  SET Category = @Category,
                      TransactionType = @Type
                      Amount = @Amount
                      TransactionDate = @Date
                      Description = @Description
                  WHERE TransactionID = @transid";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //3. command is what communicates with the sever to link these two types of variables
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Category", transaction.Category);
                    command.Parameters.AddWithValue("@Type", transaction.Type);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@Date", transaction.Date);
                    command.Parameters.AddWithValue("@Description", transaction.Description);
                    //4. Open the connection so work can be don
                    // 5. Use "ExecuteNonQuery when changing data"
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
