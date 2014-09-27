using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_It.Models
{
    public class Expense 
    {
       [SQLite.AutoIncrement, SQLite.PrimaryKey]
        public int ID { get; set; }
        public int EventID { get; set; }
        public int MemberID { get; set; }
        public int CategoryID { get; set; }
        public string Comments { get; set; }
        public double Amount { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
