using Split_It.Models;
using Split_It.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_It.Repository
{
    public class MemberRepo : Repo
    {
        public MembersViewModel getMembers(int eventID)
        {
            var membersViewModel = new MembersViewModel();

            dbDelegate(() =>
            {
                var result = db.Query<MemberViewModel>(String.Format(@"SELECT 
                                                        Member.ID, Member.EventID, Member.Name, Member.PhoneNumber
                                                        , SUM(Expense.Amount) AS TotalExpense
                                                        , 1 AS FromDB
                                                        FROM 
                                                            Member 
                                                        LEFT JOIN 
                                                            Expense 
                                                        ON
                                                            Member.EventID = Expense.EventID 
                                                        AND 
                                                            Member.ID = Expense.MemberID    
                                                        WHERE 
                                                            Member.EventID =  {0}
                                                        GROUP BY Member.ID, Member.EventID, Member.Name, Member.PhoneNumber ", eventID));

                foreach (var member in result)
                    membersViewModel.Members.Add(member);

                membersViewModel.Members.Add(new MemberViewModel() { FromDB = 0 , Name = "Add new member"});
            });

            return membersViewModel;
        }

        public void addMember(int eventID, string name, string phoneNumber)
        {
            dbDelegate(() =>
            {
                db.Insert(new Member { Name = name, PhoneNumber = phoneNumber });
            });
        }

        public object getMember(string name)
        {
            return null;
        }
    }
}
