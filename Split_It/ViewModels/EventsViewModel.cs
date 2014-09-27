using Split_It.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Split_It.ViewModels
{
    public class EventsViewModel
    {
        public ObservableCollection<Event> Items { get; set; }

        public EventsViewModel()
        {
            this.Items = new ObservableCollection<Event>();
        }
    }

}
