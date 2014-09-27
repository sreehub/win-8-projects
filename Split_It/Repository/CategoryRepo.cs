using Split_It.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_It.Repository
{
    public class CategoryRepo : Repo
    {
        public object getExpensesByCategory(int eventID)
        {
            return null;
        }

        public void addCategory(string categoryName)
        {
            dbDelegate(() =>
            {
                db.Insert(new Category { Name = categoryName });
            });
        }
    }
}
