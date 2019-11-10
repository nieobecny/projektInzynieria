using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ATM
{
    public class ClientDB
    {
        private static CultureInfo culture;

        public static List<Client> getList()
        {
            

            XDocument xdoc = XDocument.Load("data.xml");
            List<Client> clients = (from xml in xdoc.Elements("Clients").Elements("Client")
                select new Client
                {
                    accountNumber = Int32.Parse(xml.Element("accountNumber").Value),
                    accountBalance = Convert.ToDouble((xml.Element("accountBalance").Value),CultureInfo.InvariantCulture),
                    pin = Int32.Parse(xml.Element("pin").Value)

                }).ToList();

            Console.WriteLine(clients.Count);
            

            return clients;
        }

        public static void SaveList(List<Client> clients)
        {
            
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Clients";
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Client>),xRoot);
            TextWriter filestream = new StreamWriter("data.xml");
            serialiser.Serialize(filestream , clients);
            filestream.Close();
        }
    
    }
}