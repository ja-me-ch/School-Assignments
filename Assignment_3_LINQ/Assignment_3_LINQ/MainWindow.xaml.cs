using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
Q1.	List the names of the countries in alphabetical order
Q2.	List the names of the countries in descending order of number of resources
Q3.	List the names of the countries that shares a border with Argentina
Q4.	List the names of the countries that has more than 10,000,000 population
Q5.	List the country with highest population
Q6.	List all the religion in south America in dictionary order
 */

namespace Assignment_3_LINQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txbl_TextArea.Text = "Sample Text";
        }

        public void SetText(string text)
        {
            txbl_TextArea.Text = "";
            txbl_TextArea.Text = text;
        }

        private void Q1_Click(object sender, RoutedEventArgs e)
        {

            var alphabeticalList = from items in Country.GetCountries()
                                   orderby items.Name
                                   select items.Name;

            string text = "";
            foreach (var item in alphabeticalList)
            {
                text = text + item + "\n";
            }
            SetText(text);
        }//end of Q1_Click

        private void Q2_Click(object sender, RoutedEventArgs e)
        {
            var countries_descending_order_by_resources = from items in Country.GetCountries()
                                                          orderby items.Resources.Count descending
                                                          select new
                                                          {
                                                              Country = items.Name,
                                                              ResourceCount = items.Resources.Count
                                                          };

            string text = "";
            foreach(var item in countries_descending_order_by_resources)
            {
                text = $"{text}{item.Country} : {item.ResourceCount}\n";
                //text = text + item + "\n";
            }

            SetText(text);
        }

        private void Q3_Click(object sender, RoutedEventArgs e)
        {
            var countries_share_border_argentina = from items in Country.GetCountries()
                                                   where items.Borders.Contains("Argentina")
                                                   orderby items.Name
                                                   select new
                                                   {
                                                       Country = items.Name,
                                                   };

            string text = "";
            foreach (var item in countries_share_border_argentina)
            {

                text = $"{text}{item.Country}\n";
            }

            SetText(text);

        }

        private void Q4_Click(object sender, RoutedEventArgs e)
        {
            var countries_with_pop_over_10mil = from item in Country.GetCountries()
                                                where item.Population > 10000000
                                                orderby item.Population descending
                                                select new
                                                {
                                                    Country = item.Name,
                                                    Population = item.Population
                                                };

            string text = "";
            foreach (var item in countries_with_pop_over_10mil)
            {

                text = $"{text}{item.Country} : {item.Population}\n";
            }

            SetText(text);

        }

        private void Q5_Click(object sender, RoutedEventArgs e)
        {
            var country_highest_population = (from item in Country.GetCountries()
                                              orderby item.Population descending
                                              select new
                                              {
                                                  Country = item.Name,
                                                  Population = item.Population
                                              }).Take(1);

            string text = "";

            foreach (var item in country_highest_population)
            {
                text += $"{item.Country} : {item.Population}";
            }

            SetText(text);
        }//end of Q5_Click

        private void Q6_Click(object sender, RoutedEventArgs e)
        {

            var all_religion_in_sa_ascending = (from country in Country.GetCountries()
                                                from religion in country.Religions
                                                orderby religion
                                                select religion).Distinct();

            string text = "";

            foreach (var religion in all_religion_in_sa_ascending)
            {
                text = $"{text}{religion}\n";
            }

            SetText(text);


        }//end of Q6_Click
    }//end of partial class MainWindow : Window
}//end of namespace
