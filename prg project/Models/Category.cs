using prg_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg_project.Enums
{
    internal class Category
    {
        public string CategoryID { get; set; }
        public User UserId { get; set; }
        public string CategoryName { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public bool IsAcitive;

        public Category(string id, User userid, string name, TransactionType type, string description)
        {
            CategoryID = id;
            UserId = userid;
            Type = type;
            Description = description;
            IsAcitive = true;
        }
    }

}
