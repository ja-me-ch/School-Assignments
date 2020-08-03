using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Delegates
{
    public class Publisher
    {

        public delegate void PublishMessageDelegate(string message);

        public PublishMessageDelegate publishMessage = null;

        public void PublishMessage(string message)
        {
            if (publishMessage != null)
            {
                publishMessage.Invoke(message);
            }
            else
            {
                Trace.WriteLine("Delegate is empty.");
            }
            
        }

    }//end of Publisher class

}//end of namespace
