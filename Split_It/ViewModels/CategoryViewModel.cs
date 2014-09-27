using Split_It.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_It.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; private set; }
        public double TotalExpense { get; private set; }

        public CategoryViewModel(Category category, double totalExpense)
        {
            this.Category = category;
            this.TotalExpense = totalExpense;
        }
    }

    public class CategoriesViewModel
    {
        public ObservableCollection<CategoryViewModel> Categories { get; private set; }

        public CategoriesViewModel()
        {
            this.Categories = new ObservableCollection<CategoryViewModel>();
        }
    }
}
