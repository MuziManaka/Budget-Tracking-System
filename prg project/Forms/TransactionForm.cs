using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prg_project.Models;
using System.Windows.Forms;

namespace prg_project.Forms
{
    public partial class TransactionForm : Form
    {
        public TransactionForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delte this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    transactionBindingSource.RemoveCurrent();
            }
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            transactionBindingSource.Add(new Transaction(
                "1",
                Enums.TransactionType.Expense,
                new Category("CAT001", new User("User001", "User", "pass", "muai@gmailcom", DateTime.Today),"Food", Enums.TransactionType.Expense,"...."),
                750,
                DateTime.Today,
                "....") 
            );
        }
    }
}
