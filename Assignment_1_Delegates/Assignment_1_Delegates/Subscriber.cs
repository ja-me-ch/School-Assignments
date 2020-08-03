using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Delegates
{
    public class Subscriber
    {
        private String email;
        public String Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                }
            }
        }//end of Email property

        private String mobile;
        public String Mobile
        {
            get { return mobile; }
            set
            {
                if (value != mobile)
                {
                    mobile = value;
                }
            }
        }//end of Mobile property

        private bool emailNotif;
        public bool EmailNotif
        {
            get { return emailNotif; }
            set
            {
                if (value != emailNotif)
                {
                    emailNotif = value;
                }
            }
        }

        private bool mobileNotif;
        public bool MobileNotif
        {
            get { return mobileNotif; }
            set
            {
                if (value != mobileNotif)
                {
                    mobileNotif = value;
                }
            }
        }

        public void SendEmail(string message)
        {
            Trace.WriteLine($"The message: ''{message}'' has been sent to {email}.");
        }

        public void SendMobile(string message)
        {
            Trace.WriteLine($"The message: ''{message}'' has been sent to {mobile}.");
        }

        public void Subscribe (Publisher pub)
        {
            if (EmailNotif == true)
            {
                pub.publishMessage += SendEmail;
                Trace.WriteLine($"{Email} is now subscribed.");
            }
            if (MobileNotif == true)
            {
                pub.publishMessage += SendMobile;
                Trace.WriteLine($"{Mobile} is now subscribed.");
            }
        }

        public void Unsubscribe (Publisher pub)
        {
            if (EmailNotif == false)
            {
                pub.publishMessage -= SendEmail;
                Trace.WriteLine($"{Email} is now unsubscribed.");
            }
            if (MobileNotif == false)
            {
                pub.publishMessage -= SendMobile;
                Trace.WriteLine($"{Mobile} is now unsubscribed.");
            }
        }

    }//end of class
}//end of namespace
