using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using MyWeb.Common;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Default language of page
        /// </summary>
        public static string LangDefault = "";
        public static CookieClass Cookie = new CookieClass();
        /// <summary>
        /// Extension of page file
        /// </summary>
        public static string FileExtension = "";  
        void RegisterRoutes(RouteCollection routes)
        {
            RouteTable.Routes.MapPageRoute("Content", "Content/{language}-{country}.aspx", "~/Modules/Content.aspx");

            //News routes
            RouteTable.Routes.MapPageRoute("News", "News.aspx", "~/Modules/News/NewsView.aspx");
            RouteTable.Routes.MapPageRoute("NewsDate", "News/{Subject}/{date}.aspx", "~/Modules/News/NewsView.aspx");
            RouteTable.Routes.MapPageRoute("NewsGroup", "News/{Subject}.aspx", "~/Modules/News/NewsView.aspx");
            //RouteTable.Routes.MapPageRoute("Newshome", "Newshome/{Subject}.aspx", "~/Modules/News/NewsView.aspx");
            //RouteTable.Routes.MapPageRoute("Newssearch", "Newssearch/{dk}.aspx", "~/Modules/News/NewsView.aspx");
            RouteTable.Routes.MapPageRoute("NewsDetail", "News/{Subject}/{Id}/{title}.aspx", "~/Modules/News/NewsDetail.aspx");
            RouteTable.Routes.MapPageRoute("NewsTab", "NewsTab/{Subject}.aspx", "~/Modules/News/NewsTab.aspx");
            RouteTable.Routes.MapPageRoute("RssNews", "RssNews.aspx", "~/Modules/Other/RssNews.aspx");

            //Product routes
            RouteTable.Routes.MapPageRoute("OrderSuccess", "OrderSuccess.aspx", "~/Modules/Products/OrderSuccess.aspx");
            RouteTable.Routes.MapPageRoute("ContactOrder", "ContactOrder.aspx", "~/Modules/Products/ContactOrder.aspx");
            RouteTable.Routes.MapPageRoute("ProductsOrder", "Order.aspx", "~/Modules/Products/Order.aspx");
            RouteTable.Routes.MapPageRoute("ProductsList", "Product.aspx", "~/Modules/Products/ProductList.aspx");
            RouteTable.Routes.MapPageRoute("ProductsListpage", "ProductList.aspx/page={currentpage}", "~/Modules/Products/ProductList.aspx");
            RouteTable.Routes.MapPageRoute("Products", "Products/{CateId}/{title}.aspx", "~/Modules/Products/ProductView.aspx");
            RouteTable.Routes.MapPageRoute("Productspage", "Products/{CateId}.aspx/page={currentpage}", "~/Modules/Products/ProductView.aspx");
            RouteTable.Routes.MapPageRoute("ProductsSaleOff", "products-sale-off.aspx", "~/Modules/Products/ProductSaleOff.aspx");
            RouteTable.Routes.MapPageRoute("ProductCart", "Shopcart/{ProId}/{Idsize}/{Idcolor}/{num}/{title}.aspx", "~/Modules/Products/Shopcard.aspx");
            RouteTable.Routes.MapPageRoute("ProductDetail", "Products/{CateId}/{Id}/{title}.aspx", "~/Modules/Products/ProductDetail.aspx");
            RouteTable.Routes.MapPageRoute("ProPay", "MethodPay/{title}.aspx", "~/Modules/Products/StepPay.aspx");
            RouteTable.Routes.MapPageRoute("ProRegister", "Shopregister/{title}.aspx", "~/Modules/Products/RegisterCustomer.aspx");
            RouteTable.Routes.MapPageRoute("Message", "Message/{title}.aspx", "~/Modules/Products/Messages.aspx");
            RouteTable.Routes.MapPageRoute("Activeaccount", "Active/{userid}/{title}.aspx", "~/Modules/Products/ActiveAccount.aspx");
            RouteTable.Routes.MapPageRoute("Help", "Help/{title}.aspx", "~/Modules/Products/Helpsize.aspx");

            //Document routes
            RouteTable.Routes.MapPageRoute("Document", "Document.aspx", "~/Modules/Document/DocumentType.aspx");
            RouteTable.Routes.MapPageRoute("DocumentType", "Document/{Subject}.aspx", "~/Modules/Document/DocumentType.aspx");
            RouteTable.Routes.MapPageRoute("DocumentDetail", "Document/{Subject}/{IdDoc}/{title}.aspx", "~/Modules/Document/DocumentDetail.aspx");

            //Account routes
            RouteTable.Routes.MapPageRoute("AccountLogon", "Account/Logon.aspx", "~/Modules/Account/Logon.aspx");
            RouteTable.Routes.MapPageRoute("AccountRegister", "Account/register.aspx", "~/Modules/Account/register.aspx");
            RouteTable.Routes.MapPageRoute("AccountFogotpass", "Account/fogotpass.aspx", "~/Modules/Account/fogotpass.aspx");
            //Search routes
            RouteTable.Routes.MapPageRoute("SearchNon", "searchResult.aspx", "~/Modules/Search/searchResult.aspx");
            RouteTable.Routes.MapPageRoute("SearchPrice", "searchprice.aspx", "~/Modules/Search/My_Search_By_Price.aspx");
            RouteTable.Routes.MapPageRoute("SearchPricepaging", "searchprice.aspx/page={currentpage}", "~/Modules/Search/My_Search_By_Price.aspx");
            RouteTable.Routes.MapPageRoute("Searchkeyword", "search.aspx", "~/Modules/Search/My_Search_Form.aspx");
            RouteTable.Routes.MapPageRoute("Searchkeywordpaging", "search.aspx/page={currentpage}", "~/Modules/Search/My_Search_Form.aspx");
            RouteTable.Routes.MapPageRoute("Search", "search.aspx", "~/Modules/Search/Search.aspx");
            RouteTable.Routes.MapPageRoute("SearchVD", "search/vandon.aspx", "~/Modules/search/vandon.aspx");
            RouteTable.Routes.MapPageRoute("SearchVDFull", "search/vandon/{Code}-{Id}.aspx", "~/Modules/search/vandon.aspx");
            RouteTable.Routes.MapPageRoute("SearchLB", "search/lichbay.aspx", "~/Modules/search/lichbay.aspx");
            RouteTable.Routes.MapPageRoute("SearchLBFull", "search/lichbay/{Date}/{Code}-{Type}.aspx", "~/Modules/search/lichbay.aspx");

            //Library routes
            RouteTable.Routes.MapPageRoute("GroupLibrary", "library.aspx", "~/Modules/Page/library.aspx");
            RouteTable.Routes.MapPageRoute("Library", "library/{Subject}.aspx", "~/Modules/Page/library.aspx");

            //Page routes
            RouteTable.Routes.MapPageRoute("Promotionpaging", "Promotion.aspx/page={currentpage}", "~/Modules/Products/Promotion.aspx");
            RouteTable.Routes.MapPageRoute("Promotion", "Promotion.aspx", "~/Modules/Products/Promotion.aspx");
            RouteTable.Routes.MapPageRoute("Default", "default.aspx", "~/Default.aspx");
            RouteTable.Routes.MapPageRoute("ListShop", "ListShop.aspx", "~/Modules/Page/ListShop.aspx");
            RouteTable.Routes.MapPageRoute("Thumb", "thumb.aspx", "~/Modules/Page/thumb.aspx");
            RouteTable.Routes.MapPageRoute("Contact", "contact.aspx", "~/Modules/Page/contact.aspx");
            RouteTable.Routes.MapPageRoute("PageDetail", "Page/{pageid}.aspx", "~/Modules/Page/AboutUs.aspx");
            RouteTable.Routes.MapPageRoute("Weather", "weather.aspx", "~/Modules/Other/weather.aspx");
            RouteTable.Routes.MapPageRoute("Exchange", "Exchange.aspx", "~/Modules/Other/Exchange.aspx");
            RouteTable.Routes.MapPageRoute("PageSupport", "Support.aspx", "~/Modules/Page/Support.aspx");
            RouteTable.Routes.MapPageRoute("Error", "Error.aspx", "~/Modules/Page/Error.aspx");
            RouteTable.Routes.MapPageRoute("Logout", "Logout.aspx", "~/Modules/Page/Logout.aspx");
            RouteTable.Routes.MapPageRoute("Logon", "Logon.aspx", "~/Modules/Page/Logon.aspx");
            RouteTable.Routes.MapPageRoute("Admin", "Admin.aspx", "~/Admin/Default.aspx");
            RouteTable.Routes.MapPageRoute("NoPage", "{NoPage}.aspx", "~/Default.aspx");
            //RouteTable.Routes.Add(
            //    "PageDetail",
            //    new Route("Page/{Id}.aspx",
            //    new PageRouteHandler("~/Modules/Page/PageDetail.aspx")));
            
        }

        void Application_Start(object sender, EventArgs e)
        {
            
                //LangDefault = LanguageService.Language_GetByDefault();
                LangDefault = "vi";
                //FileExtension = GlobalClass.GetAppSettingKey("FileExtension");
                RegisterRoutes(RouteTable.Routes);
            
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            if (Session["Lang"] == null)
            {
                Cookie.SetCookie("Lang", LangDefault);
                Session["Lang"] = LangDefault;
            }
        }

        void Session_End(object sender, EventArgs e)
        {
            if (Session["Lang"] == null)
            {
                Session["Lang"] = GetLang();
            }
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }
        public static string GetLang(){
            return StringClass.Check(Cookie.GetCookie("Lang")) ? Cookie.GetCookie("Lang") : "";
        }
        public static string GetLangAdm()
        {

            return StringClass.Check(Cookie.GetCookie("LangAdm")) ? Cookie.GetCookie("LangAdm") : "";

        }

    }
}
