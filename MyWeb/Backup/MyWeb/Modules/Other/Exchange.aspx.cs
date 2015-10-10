using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
//using System.Xml.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.Other
{
    public partial class Exchange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strReturn = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("http://www.vietcombank.com.vn/ExchangeRates/ExrateXML.aspx");
            XmlNodeList elements = doc.SelectNodes("//ExrateList/Exrate");
            foreach (XmlElement element in elements)
            {
                string CurrencyCode = element.GetAttribute("CurrencyCode").ToUpper();
                if (CurrencyCode.Contains("AUD") || CurrencyCode.Contains("EUR") || CurrencyCode.Contains("HKD") || CurrencyCode.Contains("JPY") || CurrencyCode.Contains("GBP") || CurrencyCode.Contains("USD"))
                {
                    string Buy = element.GetAttribute("Buy").ToUpper();
                    string Transfer = element.GetAttribute("Transfer").ToUpper();
                    string Sell = element.GetAttribute("Sell").ToUpper();
                    strReturn += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", CurrencyCode, FormatCurrency(Buy), FormatCurrency(Transfer), FormatCurrency(Sell));
                }
            }
            ltrCurrency.Text = strReturn;
        }
        private string FormatCurrency(string Currency)
        {
            return Currency == "0" ? "-" : String.Format("{0:0,0.00}", Convert.ToDouble(Currency));
        }
    }
}