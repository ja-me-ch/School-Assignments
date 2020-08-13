using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_WPF_Data_Binding
{
    class BillItem :  INotifyPropertyChanged
    {
        private MenuItem _menuItem;
        public MenuItem menuItem 
        {
            get { return _menuItem; }
            set 
            { 
                _menuItem = value;
            }
        }

        private int _quantity;
        public int Quantity {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    Subtotal = _quantity * Price;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        public string Name 
        { 
            get { return _menuItem.Name; }
        }

        public double Price
        {
            get { return _menuItem.Price; }
        }

        private double _subtotal;
        public double Subtotal
        {
            get { return (menuItem.Price * Quantity); }
            set
            {
                if (_subtotal != value)
                {
                    _subtotal = _quantity * Price;
                    OnPropertyChanged("Subtotal");
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
