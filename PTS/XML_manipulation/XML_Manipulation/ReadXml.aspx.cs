using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XML_Manipulation
{
    public partial class ReadXml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["fromWriteToXml"] != null)
            {
                loadXmlFromFile();
            }
        }

        protected void loadXmlButtonId_Click(object sender, EventArgs e)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            xmlDoc.Save("E:\\MyCode\\CSharp\\PTS\\XML_manipulation\\XML_manipulation\\Currency.xml");

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Currency", typeof(string)));
            dt.Columns.Add(new DataColumn("Rate", typeof(string)));

            DataRow dr = null;
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            {
                dr = dt.NewRow();
                dr["Currency"] = xmlNode.Attributes["currency"].Value;
                dr["Rate"] = xmlNode.Attributes["rate"].Value;
                dt.Rows.Add(dr);
            }

            gridViewCurrencyId.DataSource = dt;
            gridViewCurrencyId.DataBind();

        }

        protected void AddDataButtonId_Click(object sender, EventArgs e)
        {
            Response.Redirect("WriteToXml.aspx");
        }

        protected void loadXmlFromFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\MyCode\\CSharp\\PTS\\XML_manipulation\\XML_manipulation\\Currency.xml");

            DataTable dt = new DataTable();
       
            dt.Columns.Add(new DataColumn("Currency", typeof(string)));
            dt.Columns.Add(new DataColumn("Rate", typeof(string)));
            
            DataRow dr = null;
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            {
                dr = dt.NewRow();
                dr["Currency"] = xmlNode.Attributes["currency"].Value;
                dr["Rate"] = xmlNode.Attributes["rate"].Value;
                dt.Rows.Add(dr);
            }

            gridViewCurrencyId.DataSource = dt;
            gridViewCurrencyId.DataBind();
        }
    }
}