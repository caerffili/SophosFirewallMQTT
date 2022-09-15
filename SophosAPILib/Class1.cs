using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SophosAPILib
{

    public class FirewallRuleDef
    {
        public String Name;
        public String Status;
    }
    public class SDWANPolicyRouteStatusDef
    {
        public String SDWANPolicyRouteName;
        public String Status;
    }

    public class LoginDef
    {
        public String status;
    }

    public class Response
    {
        public LoginDef Login;

        [XmlElement(ElementName = "SDWANPolicyRouteStatus")]
        public List<SDWANPolicyRouteStatusDef> SDWANPolicyRouteStatuses { get; set; }


        [XmlElement(ElementName = "FirewallRule")]
        public List<FirewallRuleDef> FirewallRules { get; set; }
        
    }

    public class SophosAPI
    {
        private RestClientOptions options;
        private RestClient client;


        public SophosAPI(String BaseUrl)
        {
            options = new RestClientOptions(BaseUrl)
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };

            client = new RestClient(options);
        }

        public void Get_SDWANPolicyRouteStatus()
        {
            RestRequest request = new RestRequest("webconsole/APIController", Method.Get);

            request.AddParameter("reqxml", "<Request><Login><Username>API%20Admin</Username><Password>uZlEuFgq@wIClPgK9oLrg</Password></Login><Get><SDWANPolicyRouteStatus><SDWANPolicyRouteName>Lenovo Desktop</SDWANPolicyRouteName></SDWANPolicyRouteStatus></Get></Request>", false);

            var response = client.Execute(request);


            XmlSerializer ser;
            ser = new XmlSerializer(typeof(Response));
            StringReader stringReader;
            stringReader = new StringReader(response.Content);
            XmlTextReader xmlReader;
            xmlReader = new XmlTextReader(stringReader);
            object obj;
            obj = ser.Deserialize(xmlReader);
            xmlReader.Close();
            stringReader.Close();

            Console.WriteLine(response.Content);
        }

        public void Get_FirewallRule()
        {
            RestRequest request = new RestRequest("webconsole/APIController", Method.Get);

            request.AddParameter("reqxml", "<Request><Login><Username>API%20Admin</Username><Password>uZlEuFgq@wIClPgK9oLrg</Password></Login><Get><FirewallRule></FirewallRule></Get></Request>", false);

            var response = client.Execute(request);


            XmlSerializer ser;
            ser = new XmlSerializer(typeof(Response));
            StringReader stringReader;
            stringReader = new StringReader(response.Content);
            XmlTextReader xmlReader;
            xmlReader = new XmlTextReader(stringReader);
            object obj;
            obj = ser.Deserialize(xmlReader);
            xmlReader.Close();
            stringReader.Close();

            Console.WriteLine(response.Content);
        }
    }
}
