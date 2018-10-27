using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace RESTExercise
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public string AddIt(int num1, int num2)
        {
            return Convert.ToString(num1 + num2);

        }

        public String getResource()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\MyCode\\CSharp\\PTS\\RESTExercise\\RESTExercise\\test.xml");

            String innerXml = xmlDoc.InnerXml;
            return innerXml;
        }

        public string addResource(string id, string value){
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\MyCode\\CSharp\\PTS\\RESTExercise\\RESTExercise\\test.xml");

            //XmlElement root = xmlDoc.DocumentElement; gets the root element

            XmlNode root = xmlDoc.DocumentElement;
            XmlNode newRecord = xmlDoc.CreateElement("record");

            XmlAttribute recordIdAttr = xmlDoc.CreateAttribute("id");
            if (id.Length == 0)
            {
                recordIdAttr.Value = (getLastAttrId(xmlDoc)+1).ToString();
            }
            else
            {

                recordIdAttr.Value = id;
            }
                

            newRecord.Attributes.Append(recordIdAttr);
            newRecord.InnerText = value;

            root.AppendChild(newRecord);

            String innerXml = xmlDoc.InnerXml;
            xmlDoc.Save("E:\\MyCode\\CSharp\\PTS\\RESTExercise\\RESTExercise\\test.xml");
            return innerXml;
        }

        private int getLastAttrId(XmlDocument xmlDoc)
        {
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList records = xmlDoc.SelectNodes("/root/record");
            int recordsCount = records.Count;
            XmlNode record = records[recordsCount-1];
            String attributeIdValue = record.Attributes["id"].Value;
           
            return Convert.ToInt32(attributeIdValue.Trim());
        }

        public string updateResource(string id, string value, bool isdel)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\MyCode\\CSharp\\PTS\\RESTExercise\\RESTExercise\\test.xml");

            //root
            XmlElement root = xmlDoc.DocumentElement;

            XmlNodeList records = xmlDoc.SelectNodes("/root/record"); // You can also use XPath here
            foreach (XmlNode record in records)
            {
                String idVaue = record.Attributes["id"].Value;
                if (idVaue.Trim().Equals(id))
                {
                    if (isdel)
                    {
                        record.ParentNode.RemoveChild(record);
                    }
                    else
                    {
                        record.InnerText = value;
                    }
                   
                }
            }
            String innerXml = xmlDoc.InnerXml;
            xmlDoc.Save("E:\\MyCode\\CSharp\\PTS\\RESTExercise\\RESTExercise\\test.xml");
            return innerXml;
        }
    }
}
