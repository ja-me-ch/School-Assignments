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
using System.Windows.Shapes;

namespace Assignment_1_Delegates
{
    /// <summary>
    /// Interaction logic for ManageSubscriptionWindow.xaml
    /// </summary>
    public partial class ManageSubscriptionWindow : Window
    {
        private SubscriberList subscriberList = new SubscriberList();
        private Publisher publisher = new Publisher();
        private MainWindow mainWindow = new MainWindow();
        
        public ManageSubscriptionWindow(SubscriberList subscriberList, Publisher publisher, MainWindow mainWindow)
        {
            this.subscriberList = subscriberList;
            this.publisher = publisher;
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void btn_SaveNotificationSettings_Click(object sender, RoutedEventArgs e)
        {
            Subscriber sub = new Subscriber
            {
                Email = txbx_Email.Text,
                EmailNotif = (bool)chbx_EmailNotif.IsChecked,
                Mobile = txbx_Mobile.Text,
                MobileNotif = (bool)chbx_MobileNotif.IsChecked
            };

            if (txbx_Email.Text != null || txbx_Email.Text != "")
            {
                subscriberList.AddSubscriber(sub, publisher);
            }
            else
            {
                Trace.Write("Email field cannot be empty.");
            }
        }//end of btn_Subscribe_Click

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();
        }
    }//end of partial class ManageSubscriptionWindow : Window
}//end of namespace
