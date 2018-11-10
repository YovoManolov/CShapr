using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class HelloWorldClientPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient mySvc = new
                ServiceReference1.WebService1SoapClient();
            Label1.Text = mySvc.HelloWorld();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(tbA.Text);
            int b = Convert.ToInt32(tbB.Text);
            ServiceReference1.WebService1SoapClient mySvc = new
               ServiceReference1.WebService1SoapClient();
            addLabel.Text = mySvc.Add(a,b).ToString();
        }

        protected void ctf_Click(object sender, EventArgs e)
        {
            double cel = Convert.ToDouble(ctfParamGrad.Text);
            ServiceReference1.WebService1SoapClient mySvc = new
               ServiceReference1.WebService1SoapClient();
            ctfResult.Text = mySvc.CelsiusToFahrenheit(cel).ToString();
        }

        protected void ftc_Click(object sender, EventArgs e)
        {
            double far = Convert.ToDouble(ftcParamGrad.Text);
            ServiceReference1.WebService1SoapClient mySvc = new
               ServiceReference1.WebService1SoapClient();
            ftcResult.Text = mySvc.FahrenheitToCelsius(far).ToString();
        }
    }
}