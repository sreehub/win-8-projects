using Split_It.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_It.ViewModels
{
    public class MemberViewModel
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }         
        public double TotalExpense { get; set; }
        public Int16 FromDB { get; set; } 

        public MemberViewModel(double expense, Int16 fromDB = 1)
        {            
            this.TotalExpense = expense;
            this.FromDB = fromDB;
        }

        public MemberViewModel()
        {            
        }
    }

    public class MembersViewModel
    {
        public ObservableCollection<MemberViewModel> Members { get; set; }

        public MembersViewModel()
        {
            this.Members = new ObservableCollection<MemberViewModel>();
        }
    }
}
