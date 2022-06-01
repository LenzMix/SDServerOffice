using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerOffice
{
    public static class FileManager
    {
        public static databaseConnector ReadFiles()
        {
            if (!System.IO.File.Exists(@"Database.xml"))
            {
                SaveFile(null);
                return null;
            }
            string users = File.ReadAllText(@"Database.xml");

            var xmlSerializer = new XmlSerializer(typeof(databaseConnector));
            var stringReader = new StringReader(users);
            databaseConnector userCollection = (databaseConnector)xmlSerializer.Deserialize(stringReader);
            return userCollection;
        }

        private static void SaveFile(databaseConnector connector)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(databaseConnector));
            StringWriter stringWriter = new StringWriter();
            if (connector == null) 
                xmlSerializer.Serialize(stringWriter, new databaseConnector
                {
                    databaseIP = "",
                    databasePort = "",
                    databaseUser = "",
                    databasePassword = "",
                    databaseName = "",
                    databaseTable = "",
                });
            else 
                xmlSerializer.Serialize(stringWriter, connector);
            string userstring = stringWriter.ToString();
            FileStream stream = null;
            if (!File.Exists(@"Database.xml"))
            {
                //File.Delete(@"InfoUsers.xml");
                stream = File.Create(@"Database.xml");
                stream.Close();
            }
            File.WriteAllText(@"Database.xml", userstring);
            if (stream != null) stream.Close();
            stream = null;
        }
    }

    [Serializable]
    public class databaseConnector
    {
        [XmlElement("IP")]
        public string databaseIP;
        [XmlElement("Port")]
        public string databasePort;
        [XmlElement("User")]
        public string databaseUser;
        [XmlElement("Password")]
        public string databasePassword;
        [XmlElement("Name")]
        public string databaseName;
        [XmlElement("Table")]
        public string databaseTable;
    }
}
