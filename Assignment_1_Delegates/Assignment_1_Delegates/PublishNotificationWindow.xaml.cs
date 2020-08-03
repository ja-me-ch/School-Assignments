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
    /// Interaction logic for PublishNotificationWindow.xaml
    /// </summary>
    public partial class PublishNotificationWindow : Window
    {
        MainWindow window = new MainWindow();
        Publisher pub = new Publisher();

        public PublishNotificationWindow(Publisher publisher, MainWindow window)
        {
            this.pub = publisher;
            this.window = window;
            InitializeComponent();
        }//end of constructor

        private void btn_Publish_Click(object sender, RoutedEventArgs e)
        {
            if (txbx_NotificationContent.Text != null || txbx_NotificationContent.Text != "")
            {
                pub.PublishMessage(txbx_NotificationContent.Text);
            }
            else
            {
                Trace.WriteLine("Content cannot be empty.");
            }
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            window.Show();
            this.Close();
        }
    }//end of partial class PublishNotificationWindow : Window

}//end of namespace
