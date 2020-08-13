using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace Assignment_2_WPF_Data_Binding
{
    static class Menu
    {
        private static ObservableCollection<MenuItem> beverages = new ObservableCollection<MenuItem>();
        

        private static ObservableCollection<MenuItem> appetizers = new ObservableCollection<MenuItem>();
        private static ObservableCollection<MenuItem> main_courses = new ObservableCollection<MenuItem>();
        private static ObservableCollection<MenuItem> desserts = new ObservableCollection<MenuItem>();

        public static ObservableCollection<MenuItem> GetBeverages()
        {
            if (beverages.Count == 0)
            {
                beverages.Add(new MenuItem("Soda", 1.95, FoodCategory.Beverage));
                beverages.Add(new MenuItem("Tea", 1.50, FoodCategory.Beverage));
                beverages.Add(new MenuItem("Coffee", 1.25, FoodCategory.Beverage));
                beverages.Add(new MenuItem("Mineral Water", 2.95, FoodCategory.Beverage));
                beverages.Add(new MenuItem("Juice", 2.50, FoodCategory.Beverage));
                beverages.Add(new MenuItem("Milk", 1.50, FoodCategory.Beverage));
            }
            return beverages;
        }

        public static ObservableCollection<MenuItem> GetAppetizers()
        {
            if (appetizers.Count == 0)
            {
                appetizers.Add(new MenuItem("Buffalo Wings", 5.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Buffalo Fingers", 6.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Potato Skins", 8.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Nachos", 8.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Mushroom Caps", 10.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Shrimp Cocktail", 12.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Chips and Salsa", 6.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Buffalo Wings", 5.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Buffalo Fingers", 6.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Potato Skins", 8.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Nachos", 8.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Mushroom Caps", 10.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Shrimp Cocktail", 12.99, FoodCategory.Appetizer));
                appetizers.Add(new MenuItem("Chips and Salsa", 6.99, FoodCategory.Appetizer));
            }
            return appetizers;
        }

        public static ObservableCollection<MenuItem> GetMainCourses()
        {
            if (main_courses.Count == 0)
            {
                main_courses.Add(new MenuItem("Seafood Alfredo", 15.99, FoodCategory.Main_Course));
                main_courses.Add(new MenuItem("Chicken Picatta", 13.99, FoodCategory.Main_Course));
                main_courses.Add(new MenuItem("Turkey Club", 11.99, FoodCategory.Main_Course));
                main_courses.Add(new MenuItem("Lobster Pie", 19.99, FoodCategory.Main_Course));
                main_courses.Add(new MenuItem("Prime Rib", 13.99, FoodCategory.Main_Course));
                main_courses.Add(new MenuItem("Shrimp Scampi", 14.99, FoodCategory.Main_Course));
                main_courses.Add(new MenuItem("Turkey Dinner", 18.99, FoodCategory.Main_Course));
                main_courses.Add(new MenuItem("Stuffed Chicken", 17.99, FoodCategory.Main_Course));
            }
            return main_courses;
        }

        public static ObservableCollection<MenuItem> GetDesserts()
        {
            if (desserts.Count == 0)
            {
                desserts.Add(new MenuItem("Apple Pie", 5.99, FoodCategory.Dessert));
                desserts.Add(new MenuItem("Sundae", 3.99, FoodCategory.Dessert));
                desserts.Add(new MenuItem("Carrot Cake", 5.99, FoodCategory.Dessert));
                desserts.Add(new MenuItem("Cheese Cake", 4.99, FoodCategory.Dessert));
                desserts.Add(new MenuItem("Apple Crisp", 5.99, FoodCategory.Dessert));
            }
            return desserts;
        }

    }//end of class

}//end of namespace
