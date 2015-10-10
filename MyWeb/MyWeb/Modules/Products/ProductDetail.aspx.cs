using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
namespace MyWeb.Modules.Products
{
    public partial class ProductDetail : BaseClass.BaseDefault
    {
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["id"] != null)
            {
                id = RouteData.Values["id"].ToString();
                LoadProductByID(RouteData.Values["id"].ToString());
            }
        }
        protected string Format_Price(string Price)
        {
            if (Price.Trim().Equals(""))
            {
                return "0";
            }
            Price = Price.Replace(".", "");
            Price = Price.Replace(",", "");
            string tmp = "";
            while (Price.Length > 3)
            {
                tmp = "." + Price.Substring(Price.Length - 3) + tmp;
                Price = Price.Substring(0, Price.Length - 3);
            }
            tmp = Price + tmp;
            return tmp;
        }
        private void LoadProduct(string cateid)
        {
            List<Data.Product> list = new List<Data.Product>();
            list = ProductService.Product_GetByTop("8", "ProductCategoryID="+cateid +" and Active=1", "ModifiedDate DESC");
            if (list.Count > 0)
            {
                string str = "";
               
                
                for (int i = 0; i < list.Count; i++)
                {
                    if ((i % 4) == 0)
                    {
                        str += "<div class='productRow'>";
                    }
                    str += "<div class='product'>";
                    str += "<div class='p_img'>";
                    str += "<a href='/Product/" + list[i].ID + "/" + list[i].Tag + ".html'>";
                    str += "<img  src='" + list[i].Image + "' />";
                    str += "</a>";
                    str += "</div>";
                    str += "<div class='p_name'>";
                    str += "<a href='/Product/" + list[i].ID + "/" + list[i].Tag + ".html'>" + list[i].Name + "</a>";
                    str += "</div>";
                    str += "<div class='p_price'>";
                    str += "Giá: " + Format_Price(list[i].SalePrice) + " VND";
                    str += "</div>";
                    str += "<div class='p_cart'>";
                    str += "<a class='p_cart_a' href='/ShoppingCart/"+list[i].ID+"/"+list[0].Tag+".html'>Đặt mua</a>";
                    str += "</div>";
                    str += "</div>";
                    if (((i+1) % 4) == 0 && i != 0)
                    {
                        str += "<div class='clear'></div>";
                        str += "</div>";
                    }
                    else
                    {
                        if (i == (list.Count - 1))
                        {
                            str += "<div class='clear'></div>";
                            str += "</div>";
                        }
                    }
                }
                ltrProduct.Text = str;

            }
        }

        private void LoadComment(string strLink) {
            ltrComment.Text = "<div class='fb-comments' data-href='"+strLink+"' data-width='800px' data-numposts='10' data-colorscheme='light'></div>";
        }
        private void LoadProductByID(string id)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            List<Data.Product> list = new List<Data.Product>();
            list = ProductService.Product_GetById(id);
            if (list.Count > 0)
            {
                List<Data.ProductCategory> listcate = new List<Data.ProductCategory>();
                listcate = ProductCategoryService.ProductCategory_GetById(list[0].ProductCategoryID);
                if (listcate.Count > 0)
                {
                    ltrNavigate.Text = "<ul class='breadcumb'><li><a href='/'>Trang chủ</a></li><li><a href='/ProductList/" + listcate[0].ID + "/" + listcate[0].Tag + ".html'>" + listcate[0].Name + "</a></li><li class='breadcumb_last' ><a>" + list[0].Name + "</a></li></ul>";
                }
                if (list[0].Title.Equals(""))
                {
                    AddMetaKeyWordTitleDescription(list[0].Name, list[0].MetaKeyword, list[0].Decription);
                }
                else
                {
                    AddMetaKeyWordTitleDescription(list[0].Title, list[0].MetaKeyword, list[0].Decription);
                }
                
                ltrLike.Text = "<div class='fb-like' data-href='" + url + "' data-width='70' data-layout='button' data-action='like' data-show-faces='false' data-share='false'></div>";
                ltrShare.Text = "<div class='fb-share-button' data-href='"+url+"' data-width='100px' data-type='button_count'></div>";
                ltrGoogle.Text = "<div class='g-plusone' data-size='medium' data-annotation='inline' data-width='300'></div>";
                ltrimg.Text = "<img src='" + list[0].Image + "'/>";
                lblTitle.Text = list[0].Name;
                lblProductcode.Text = "Mã sản phẩm: " + list[0].ProductCode;
                lblCreatedDate.Text = "Thời gian cập nhật: " + Common.DateTimeClass.ConvertDate(list[0].CreatedDate, "dd/MM/yyyy");
                lblUnit.Text = "Đơn vị tính: "+list[0].Unit;
                if (list[0].UnitPrice.Trim().Equals("0") || list[0].UnitPrice.Trim().Equals(""))
                    lblUnitPrice.Text = "Giá thị trường: Đang cập nhật";
                else
                    lblUnitPrice.Text = "Giá thị trường: "+"<span style='color:red !important'>" + Format_Price(list[0].UnitPrice) + " VND"+"</span>";
                if (list[0].SalePrice.Trim().Equals("0") || list[0].SalePrice.Trim().Equals(""))
                    lblSalePrice.Text = "Giá bán: Đang cập nhật";
                else
                    lblSalePrice.Text = "Giá bán: " + "<strong style='color: red !important;font-size:16px'>"+Format_Price(list[0].SalePrice) + " VND"+"</strong>";

                ltrDetail.Text = list[0].Detail;

                LoadProduct(list[0].ProductCategoryID);
                LoadComment(url);
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Session["productid"] = id;
            if (txtquantity.Text.Trim().Equals(""))
            {
                Session["quantity"] = "1";
            }
            else
            {
                Session["quantity"] = txtquantity.Text;
            }
            Response.Redirect("/ShoppingCart.html");
        }
    }
}