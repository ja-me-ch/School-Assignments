using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_WPF_Data_Binding
{
    class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public FoodCategory Category { get; set; }

        public string NameAndCost
        {
            get
            {
                return $"{Name} {Price}";
            }
        }

        public MenuItem(string name, double cost, FoodCategory category)
        {
            Name = name;
            Price = cost;
            Category = category;
        }

    }
}
