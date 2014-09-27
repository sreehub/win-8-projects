using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Split_It.Repository
{
    public class Repo
    {
        private App app = Application.Current as App;
        
        protected SQLite.SQLiteConnection db; 

        protected void dbDelegate(Action action)
        {
            using (db = new SQLite.SQLiteConnection(app.dBPath))
            {
                action();
            }
        }
    }
}
