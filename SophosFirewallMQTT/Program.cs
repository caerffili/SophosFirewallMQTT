using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SophosAPILib;
using MQTTLib;

namespace SophosFirewallMQTT
{
    class Program
    {
        static void Main(string[] args)
        {
            //SophosAPI c = new SophosAPI("https://10.20.0.8:4444/");
            //c.Get_SDWANPolicyRouteStatus();

            //c.Get_FirewallRule();

            MQTT ml = new MQTT();

            ml.Publish_Application_Message();

            Console.ReadKey();
        }
    }
}
