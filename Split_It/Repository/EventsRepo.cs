using Split_It.Models;
using Split_It.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Split_It.Repository
{
    public class EventRepo : Repo
    {
        public EventsViewModel getEvents()
        {
            var eventsViewModel = new EventsViewModel();

            dbDelegate(() =>
            {
                foreach (var item in db.Table<Event>())
                    eventsViewModel.Items.Add(item);
            });

            return eventsViewModel;
        }

        public object getEvent(string name)
        {
            Event eventObj = null;
            dbDelegate(() =>
            {
                eventObj = db.Table<Event>().FirstOrDefault(m => m.Name == name);
            });
            return eventObj;
        }

        public void addEvent(string name)
        {
            dbDelegate(() =>
            {
                db.Insert(new Event() { Name = name });
            });
        }
    }
}
