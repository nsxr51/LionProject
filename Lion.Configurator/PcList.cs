using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lion.Configurator
{
    public class PcList
    {
        public List<Pc> Pcs;
        public PcList()
        {
            Pcs = new List<Pc>();
        }

        public void AddPc(string host, string username, string password)
        {
            Pcs.Add(new Pc(host, username, password));
        }

        public void LoadFromXmlFile(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pc>));
            Pcs = (List<Pc>)serializer.Deserialize(new StringReader(xml));
        }

        public string GetXmlFile()
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Pc>));
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, this.Pcs);
                    xml = sww.ToString(); // Your XML
                }
            }
            return xml;
        }
    }

    public class Pc
    {
        [XmlAttribute]
        public string Hostname;
        [XmlAttribute]
        public string UserName;
        [XmlAttribute]
        public string Password;

        public Pc()
        {
            
        }
        public Pc(string hostName, string userName, string password)
        {
            Hostname = hostName;
            UserName = userName;
            Password = password;
        }
    }
}
