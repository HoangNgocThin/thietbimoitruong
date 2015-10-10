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
            RouteTable.Routes.MapPageRoute("PageDefault", "Index.html", "~/Default.aspx");
            RouteTable.Routes.MapPageRoute("Order", "ShoppingCart.html", "~/Modules/Products/ShoppingCart.aspx");
            RouteTable.Routes.MapPageRoute("OrderRequest", "ShoppingCart/{id}/{tag}.html", "~/Modules/Products/ShoppingCart.aspx");
            RouteTable.Routes.MapPageRoute("OrderContact", "ContactOrder.html", "~/Modules/Products/ContactOrder.aspx");
            RouteTable.Routes.MapPageRoute("OrderSuccess", "OrderNotify.html", "~/Modules/Products/OrderSuccess.aspx");

            RouteTable.Routes.MapPageRoute("ProductDetail", "Product/{id}/{tag}.html", "~/Modules/Products/ProductDetail.aspx");

            RouteTable.Routes.MapPageRoute("ProductList", "ProductList.html", "~/Modules/Products/ProductList.aspx");
            RouteTable.Routes.MapPageRoute("ProductListPaging", "ProductList/page{currentPage}.html", "~/Modules/Products/ProductList.aspx");
            
            RouteTable.Routes.MapPageRoute("ProductCategory", "ProductList/{Id}/{Tag}.html", "~/Modules/Products/ProductByCategory.aspx");
            RouteTable.Routes.MapPageRoute("ProductCategoryPaging", "ProductList/{Id}/{Tag}/page{currentPage}.html", "~/Modules/Products/ProductByCategory.aspx");

            RouteTable.Routes.MapPageRoute("ProductSearch", "ProductSearch.html", "~/Modules/Products/ProductBySearch.aspx");
            RouteTable.Routes.MapPageRoute("ProductSearchPaging", "ProductSearch/page{currentPage}.html", "~/Modules/Products/ProductBySearch.aspx");

            RouteTable.Routes.MapPageRoute("ProductListSearch", "ProductList/{id}/{tag}.html", "~/Modules/Products/ProductList.aspx");
            RouteTable.Routes.MapPageRoute("ProductListSearchPaging", "ProductList/{id}/{tag}/page{currentPage}.html", "~/Modules/Products/ProductList.aspx");

            RouteTable.Routes.MapPageRoute("NewsList", "NewsList.html", "~/Modules/News/NewsList.aspx");
            RouteTable.Routes.MapPageRoute("NewsListPaging", "NewsList/page{currentpage}.html", "~/Modules/News/NewsList.aspx");
            RouteTable.Routes.MapPageRoute("NewsDetail", "News/{Id}/{tag}.html", "~/Modules/News/NewsDetail.aspx");

            RouteTable.Routes.MapPageRoute("Error", "Error.aspx", "~/Modules/Page/Error.aspx");
            RouteTable.Routes.MapPageRoute("Logout", "Logout.aspx", "~/Modules/Page/Logout.aspx");
            RouteTable.Routes.MapPageRoute("Logon", "Logon.aspx", "~/Modules/Page/Logon.aspx");
            RouteTable.Routes.MapPageRoute("Admin", "Admin.aspx", "~/Admin/Default.aspx");
            RouteTable.Routes.MapPageRoute("PageDetail", "page/{page}/{tag}.html", "~/Modules/Page/PageDetail.aspx");
            RouteTable.Routes.MapPageRoute("PageDetailhtm", "page/{page}/{tag}.htm", "~/Modules/Page/PageDetail.aspx");
         
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
