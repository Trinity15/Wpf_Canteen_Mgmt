using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessMgmt
{
    public class MenuItems
    {

        public DateTime PreparedDate { get; set; } = DateTime.Now;
        public uint MealType { get; set; } = 0;
        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd'/'MM'/'yyyy");
        public ObservableCollection<Dish> Dish { get; set; } = new ObservableCollection<Dish>();

    }

    public class Dish
    {
        public bool Veg { get; set; } = false;
        public string DishName { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

    }
}
