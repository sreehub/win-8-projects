using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_It.Models
{
    public class Event
    {
       [SQLite.AutoIncrement, SQLite.PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
