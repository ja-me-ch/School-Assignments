using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Assignment_2_WPF_Data_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        static ObservableCollection<BillItem> bill = new ObservableCollection<BillItem>();
        private double bill_subtotal;
        private double tax = 0.13;
        private double grand_total;
        public double Bill_Subtotal
        {
            get { return bill_subtotal; }
            set
            {
                if (bill_subtotal != value)
                {
                    bill_subtotal = value;
                    OnPropertyChanged("Bill_Subtotal");
                }//end of if
            }//end of set
        }//end of Bill_Subtotal

        public string Tax
        {
            get { return $"{tax * 100}%"; }
        }

        public double Grand_Total
        {
            get { return grand_total; }
            set
            {
                if (grand_total != value)
                {
                    grand_total = value;
                    OnPropertyChanged("Grand_Total");
                }
            }
        }
        

        public MainWindow()
        {
            InitializeComponent();
            cbx_Beverages.ItemsSource = Menu.GetBeverages();
            cbx_Appetizers.ItemsSource = Menu.GetAppetizers();
            cbx_MainCourses.ItemsSource = Menu.GetMainCourses();
            cbx_Desserts.ItemsSource = Menu.GetDesserts();
            txbl_subtotal.DataContext = this;
            txbl_tax.DataContext = this;
            txbl_total.DataContext = this;
            datagrid_Bill.ItemsSource = bill;



        }//end of MainWindow constructor

        private void btn_Add_Beverages_Click(object sender, RoutedEventArgs e)
        {
            if (cbx_Beverages.SelectedIndex == -1)
            {

            }
            else
            {
                MenuItem selectedMenuItem = (MenuItem)cbx_Beverages.SelectedItem;
                bool item_exists = false;
                foreach (BillItem billitem in bill)
                {
                    if (billitem.Name.Equals(selectedMenuItem.Name))
                    {
                        item_exists = true;
                        billitem.Quantity++;
                    }//end of if
                }//end of foreach
                if (item_exists == false)
                {
                    bill.Add(new BillItem
                    {
                        menuItem = (MenuItem)cbx_Beverages.SelectedItem,
                        Quantity = 1
                    });
                }//end of if
                CalculateSubtotal();
            }//end of else
            
        }

        private void btn_Remove_One_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;

            try
            {
                BillItem billItem = (BillItem)datagrid_Bill.SelectedItem;
                foreach (BillItem item in bill)
                {
                    if (billItem.Name == item.Name)
                    {

                        item.Quantity--;
                        if (item.Quantity == 0)
                        {
                            bill.RemoveAt(index);
                        }
                        CalculateSubtotal();
                    }//end of if
                    index++;
                }//end of foreach
            }//end of try
            catch (System.InvalidOperationException) { }
            catch (System.InvalidCastException) { }

        }

        private void btn_Remove_All_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            try
            {
                BillItem billItem = (BillItem)datagrid_Bill.SelectedItem;
                foreach (BillItem item in bill)
                {
                    if (billItem.Name == item.Name)
                    {
                        bill.RemoveAt(index);
                        CalculateSubtotal();
                    }
                    index++;
                }//end of foreach
            }//end of try
            catch (System.InvalidOperationException) { }
            catch (System.InvalidCastException) { }
        }//end of btn_Remove_All_Click

        private void btn_Add_One_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            try
            {
                BillItem billItem = (BillItem)datagrid_Bill.SelectedItem;
                foreach (BillItem item in bill)
                {
                    if (billItem.Name == item.Name)
                    {
                        item.Quantity++;
                    }//end of if
                    index++;
                }//end of foreach
                CalculateSubtotal();
            }//end of try
            catch (System.InvalidOperationException) { }
            catch (System.InvalidCastException) { }
        }

        private void btn_Add_Appetizers_Click(object sender, RoutedEventArgs e)
        {
            if (cbx_Appetizers.SelectedIndex == -1)
            {

            }
            else
            {
                MenuItem selectedMenuItem = (MenuItem)cbx_Appetizers.SelectedItem;
                bool item_exists = false;
                foreach (BillItem billitem in bill)
                {
                    if (billitem.Name.Equals(selectedMenuItem.Name))
                    {
                        item_exists = true;
                        billitem.Quantity++;
                    }//end of if
                }//end of foreach
                if (item_exists == false)
                {
                    bill.Add(new BillItem
                    {
                        menuItem = (MenuItem)cbx_Appetizers.SelectedItem,
                        Quantity = 1
                    });
                }//end of if
                CalculateSubtotal();
            }//end of else
            
        }

        private void btn_Add_MainCourses_Click(object sender, RoutedEventArgs e)
        {
            if (cbx_MainCourses.SelectedIndex == -1)
            {
                Trace.WriteLine("Selected Index is -1");
            }
            else
            {
                MenuItem selectedMenuItem = (MenuItem)cbx_MainCourses.SelectedItem;
                bool item_exists = false;
                foreach (BillItem billitem in bill)
                {
                    if (billitem.Name.Equals(selectedMenuItem.Name))
                    {
                        item_exists = true;
                        billitem.Quantity++;
                    }//end of if
                }//end of foreach
                if (item_exists == false)
                {
                    bill.Add(new BillItem
                    {
                        menuItem = (MenuItem)cbx_MainCourses.SelectedItem,
                        Quantity = 1
                    });
                }//end of if
                CalculateSubtotal();
            }//end of else
        }

        private void btn_Add_Desserts_Click(object sender, RoutedEventArgs e)
        {
            if (cbx_Desserts.SelectedIndex == -1)
            {

            }
            else
            {
                MenuItem selectedMenuItem = (MenuItem)cbx_Desserts.SelectedItem;
                bool item_exists = false;
                foreach (BillItem billitem in bill)
                {
                    if (billitem.Name.Equals(selectedMenuItem.Name))
                    {
                        item_exists = true;
                        billitem.Quantity++;
                    }//end of if
                }//end of foreach
                if (item_exists == false)
                {
                    bill.Add(new BillItem
                    {
                        menuItem = (MenuItem)cbx_Desserts.SelectedItem,
                        Quantity = 1
                    });
                }//end of if
                CalculateSubtotal();
            }//end of else
            
        }//end of btn_Add_Desserts_Click



        public void CalculateSubtotal()
        {
            double subtotal = 0;
            foreach (BillItem item in bill)
            {
                subtotal += item.Price * item.Quantity;
            }
            Bill_Subtotal = subtotal;
            Grand_Total = subtotal * tax + subtotal;

        }//end of CalculateSubtotal

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }//end of MainWindow : Window
}//end of namespace
