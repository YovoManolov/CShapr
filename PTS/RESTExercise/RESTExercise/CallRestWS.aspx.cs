using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace RESTExercise
{
    public partial class CallRestWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void xmlContentButtonId_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://localhost:52984/Service1.svc/getResource");
            literalXmlContentId.Mode = LiteralMode.Encode;
            literalXmlContentId.Text = xmlDoc.InnerText;
        }

        protected void AddButtonId_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string serverpath = "http://localhost:52984/Service1.svc/";
            String id = AddIdTextBoxId.Text.Trim();
            String value = AddValueTextBoxId.Text.Trim();
            string data = "addResource?id=" + id + "&value=" + value;
            string url = serverpath + data;

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = 0;
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            literalXmlContentId.Mode = LiteralMode.PassThrough;
            literalXmlContentId.Text = reader.ReadToEnd();
            reader.Close();
            response.Close();
           
        }
        protected void UpdateButtonId_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string serverpath = "http://localhost:52984/Service1.svc/";
            String id = UpdateIdTextBoxId.Text.Trim();
            String value = UpdateValueTextBoxId.Text.Trim();
            string data;
            if (deleteFlagId.Checked)
            {
                data = "updateResource?id=" + id + "&value=" + value + "&isdel=true";
            }
            else
            {
                data = "updateResource?id=" + id + "&value=" + value;
            }
            
            string url = serverpath + data;

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = 0;
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            literalXmlContentId.Mode = LiteralMode.PassThrough;
            literalXmlContentId.Text = reader.ReadToEnd();
            reader.Close();
            response.Close();

        }
    }
}