using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XML_Manipulation
{
    public partial class WriteToXml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loadXmlButtonId_Click(object sender, EventArgs e)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\MyCode\\CSharp\\PTS\\XML_manipulation\\XML_manipulation\\Currency.xml");

            //XmlElement root = xmlDoc.DocumentElement; gets the root element
            
            XmlNode parentNodeOfCubes = xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0];

            XmlNode CubeNewNode = xmlDoc.CreateElement("Cube");

            XmlAttribute currencyAttr = xmlDoc.CreateAttribute("currency");
            String currency = CurrencyTbId.Text;
            currencyAttr.Value = currency.Length == 0 ? "няма данни": currency;
            CubeNewNode.Attributes.Append(currencyAttr);

            XmlAttribute rateAttr = xmlDoc.CreateAttribute("rate");
            String rate = RateTbId.Text;
            rateAttr.Value = rate.Length == 0 ? "няма данни" : rate;
            CubeNewNode.Attributes.Append(rateAttr);

            parentNodeOfCubes.AppendChild(CubeNewNode);
            

            xmlDoc.Save("E:\\MyCode\\CSharp\\PTS\\XML_manipulation\\XML_manipulation\\Currency.xml");
            Response.Redirect("ReadXml.aspx?fromWriteToXml=1");
        }

    }
}