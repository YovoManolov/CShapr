using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoadXML_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\VII семестър\\ПРС\\settings.xml");

            //root
            XmlElement settingsRootEl = xmlDoc.DocumentElement;

            XmlNodeList nodes = xmlDoc.SelectNodes("/settings/database"); // You can also use XPath here
            foreach (XmlNode node in nodes)
            {
                String DBMSValue = node.Attributes["DBMS"].Value;
                if (DBMSValue.Equals("MySQL"))
                {
                    XmlNode newNode = xmlDoc.CreateElement("database");
                    newNode.InnerXml = node.InnerXml;

                    XmlNodeList xmlNodeListOfDatabaseChilds =  newNode.ChildNodes;
                    foreach(XmlNode dbChildNode in xmlNodeListOfDatabaseChilds)
                    {
                        if (dbChildNode.Name.Equals("database"))
                        {
                            dbChildNode.InnerText = "MySecondDB";
                           
                            break;
                        }
                    }

                    XmlAttribute newAttr = xmlDoc.CreateAttribute("DBMS");
                    String AttrValue = node.Attributes["DBMS"].Value;
                    newAttr.Value = AttrValue;

                    newNode.Attributes.Append(newAttr);
                    settingsRootEl.AppendChild(newNode);
                }
            }
           
            xmlDoc.Save("E:\\VII семестър\\ПРС\\settings2.xml");
        }
       
    }
}