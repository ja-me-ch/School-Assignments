using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Delegates
{
    public class SubscriberList
    {
        private List<Subscriber> subscribers = new List<Subscriber>();
        public List<Subscriber> Subscribers
        {
            get { return subscribers; }
        }

        public void AddSubscriber(Subscriber subscriber, Publisher publisher)
        {
            string email = subscriber.Email;
            string mobile = subscriber.Mobile;

            bool emailNotif = subscriber.EmailNotif;
            bool mobileNotif = subscriber.MobileNotif;

            bool emailCheck = CheckDuplicateEmail(email);
            bool mobileCheck = CheckDuplicateMobile(mobile);

            if (emailCheck == true && mobileCheck == true)
            {
                subscribers.Add(subscriber);
                Trace.WriteLine($"Subscriber Added: [{email}][{mobile}]");
            }
            else
            {
                foreach (var sub in Subscribers)
                {
                    if (email == sub.Email && mobile == sub.Mobile)
                    {
                        Trace.WriteLine($"Email: {email} and {mobile} found.");
                        Trace.WriteLine($"Email Notification: {sub.EmailNotif.ToString()}");
                        Trace.WriteLine($"Mobile Notification: {sub.MobileNotif.ToString()}");
                        sub.EmailNotif = emailNotif;
                        sub.MobileNotif = mobileNotif;
                        Trace.WriteLine($"{email} is set to {emailNotif.ToString()}.");
                        Trace.WriteLine($"{mobile} is set to {mobileNotif.ToString()}.");
                    }//end of if
                }//end of foreach
            }//end of else

            subscriber.Subscribe(publisher);
            subscriber.Unsubscribe(publisher);

        }//end of AddSubscriber method

        public bool CheckDuplicateEmail(string email)
        { 
            foreach (var sub in Subscribers)
            {
                if (email == sub.Email)
                {
                    Trace.WriteLine("This email is already registered.");
                    return false;
                }
            }//end of foreach
            return true;
        }//end of CheckDuplicateEmail method

        public bool CheckDuplicateMobile(string mobile)
        {
            foreach (var sub in Subscribers)
            {
                if (mobile == sub.Mobile)
                {
                    Trace.WriteLine("This mobile is already registered.");
                    return false;
                }
            }//end of foreach
            return true;
        }//end of CheckDuplicateEmail method

    }//end of SubscriberList class

}//end of namespace
