using Split_It.Models;
using Split_It.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Split_It.ViewHelpers
{
    public class MemberTemplateSelector : DataTemplateSelector 
    {
        public DataTemplate MemberItemTemplate { get; set; }
        public DataTemplate NewMemberItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var member = item as MemberViewModel;
            if (member.FromDB == 1)
                return MemberItemTemplate;
            else
                return NewMemberItemTemplate;
        } 
    }
}
