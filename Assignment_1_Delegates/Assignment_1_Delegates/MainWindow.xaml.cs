using System;
using System.Collections.Generic;
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

namespace Assignment_1_Delegates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SubscriberList subscriberList = new SubscriberList();
        private Publisher publisher = new Publisher();

        public MainWindow()
        {
            InitializeComponent();
            


        }//end of MainWindow method

        private void btn_ManageSubscription_Click(object sender, RoutedEventArgs e)
        {
            ManageSubscriptionWindow window = new ManageSubscriptionWindow(subscriberList, publisher, this);
            window.Show();
            this.Hide();

        }

        private void btn_PublishNotification_Click(object sender, RoutedEventArgs e)
        {
            PublishNotificationWindow window = new PublishNotificationWindow(publisher, this);
            window.Show();
            this.Hide();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }//end of partial class MainWindow : Window

}//end of namespace Assignment_1_Delegates
