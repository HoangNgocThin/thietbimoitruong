using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace MyWeb.Modules.Other
{
    public partial class RssNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader("http://dantri.com.vn/skphapluat.rss");
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                rptRss.DataSource = ds.Tables["item"];
                rptRss.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                reader.Close();
            }

            //XDocument feedXml = XDocument.Load("http://vnexpress.net/RSS/GL/trang-chu.rss");
            //var feeds = from feed in feedXml.Descendants("item")
            //    select new
            //    {
            //        title = feed.Element("title").Value,
            //        description = feed.Element("description").Value,
            //        link = feed.Element("link").Value,
            //        pubDate = feed.Element("pubDate").Value
            //    };
            //rptRss.DataSource = feeds.Take(feeds.Count());
            //rptRss.DataBind();
        }
    }
}