using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Linq;

namespace MyWeb.Admin
{
    public partial class Product : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        static string Lang = "";
        string createdDate = DateTime.Now.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                Lang = Session["Lang"].ToString();
                LoadProductCategoryDropDownList();
                BindGrid();
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

        private void BindGrid()
        {
            grdProduct.DataSource = ProductService.Product_GetByAll().OrderByDescending(x=>x.ModifiedDate).ToList();
            grdProduct.DataBind();
            if (grdProduct.PageCount <= 1)
            {
                grdProduct.PagerStyle.Visible = false;
            }
        }


        private void LoadProductCategoryDropDownList()
        {
            ddlProductCategory.Items.Clear();
            ddlProductCategory.Items.Add(new ListItem("", ""));
            List<Data.ProductCategory> list = ProductCategoryService.ProductCategory_GetByAll();
            for (int i = 0; i < list.Count; i++)
            {
                ddlProductCategory.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].ID));
            }
            ddlProductCategory.DataBind();

            ddlProductCategorySearch.Items.Clear();
            ddlProductCategorySearch.Items.Add(new ListItem("Tất cả", "0"));
            List<Data.ProductCategory> listSearch = ProductCategoryService.ProductCategory_GetByAll();
            for (int i = 0; i < list.Count; i++)
            {
                ddlProductCategorySearch.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].ID));
            }
            ddlProductCategorySearch.DataBind();
        }

        protected void grdProduct_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
            {
                if (itemType == ListItemType.Header)
                {
                    object checkBox = e.Item.FindControl("chkSelectAll");
                    if ((checkBox != null))
                    {
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
                    }
                }
                else
                {
                    string tableRowId = grdProduct.ClientID + "_row" + e.Item.ItemIndex.ToString();
                    e.Item.Attributes.Add("id", tableRowId);
                    object checkBox = e.Item.FindControl("chkSelect");
                    if ((checkBox != null))
                    {
                        e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                        e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex.ToString() + ")");
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex.ToString() + ")");
                    }
                }
            }
        }

        protected void grdProduct_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdProduct.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdProduct_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.Product> listE = ProductService.Product_GetById(Id);
                    txtName.Text = listE[0].Name;
                    txtTitle.Text = listE[0].Title;
                    fckContent.Value = listE[0].Content;
                    txtUnit.Text = listE[0].Unit;
                    txtDecription.Text = listE[0].Decription;
                    txtMetaKeyword.Text = listE[0].MetaKeyword;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    txtSalePrice.Text = NumberClass.ConvertNumber(listE[0].SalePrice);
                    txtImage.Text = listE[0].Image;
                    imgImage.ImageUrl = listE[0].Image.Length > 0 ? listE[0].Image : "";
                    txtImage1.Text = listE[0].Image1;
                    imgImage1.ImageUrl = listE[0].Image1.Length > 0 ? listE[0].Image1 : "";
                    txtImage2.Text = listE[0].Image2;
                    imgImage2.ImageUrl = listE[0].Image2.Length > 0 ? listE[0].Image2 : "";
                    txtImage3.Text = listE[0].Image3;
                    imgImage3.ImageUrl = listE[0].Image3.Length > 0 ? listE[0].Image3 : "";
                    txtImage4.Text = listE[0].Image4;
                    imgImage4.ImageUrl = listE[0].Image4.Length > 0 ? listE[0].Image4 : "";
                    txtImage5.Text = listE[0].Image5;
                    imgImage5.ImageUrl = listE[0].Image5.Length > 0 ? listE[0].Image5 : "";
                    fckDetail.Value = listE[0].Detail;
                    txtProductCode.Text = listE[0].ProductCode;
                    createdDate = listE[0].CreatedDate;
                    txtUnitPrice.Text = NumberClass.ConvertNumber(listE[0].UnitPrice);
                    LoadProductCategoryDropDownList();
                    ddlProductCategory.Text = listE[0].ProductCategoryID;
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [Product] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    ProductService.Product_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            LoadProductCategoryDropDownList();
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdProduct.Items.Count; i++)
            {
                item = grdProduct.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ProductService.Product_Delete(strId);
                    }
                }
            }
            grdProduct.CurrentPageIndex = 0;
            BindGrid();
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.Product obj = new Data.Product();
                obj.ID = Id;
                obj.Name = txtName.Text;
                obj.Title = txtTitle.Text;
                obj.Tag = Common.StringClass.NameToTag(txtName.Text);
                obj.Content = fckContent.Value;
               
                obj.Ord = "0";
                obj.Decription = txtDecription.Text;
                obj.MetaKeyword = txtMetaKeyword.Text;
                obj.Active = chkActive.Checked ? "1" : "0";
                string saleprice = txtSalePrice.Text;
                if (saleprice.Trim().Equals(""))
                    saleprice = "0";
               
                string unitPrice = txtUnitPrice.Text;
                if (unitPrice.Trim().Equals(""))
                    unitPrice = "0";
                obj.SalePrice = saleprice;
                obj.UnitPrice = unitPrice;
                obj.Image = txtImage.Text;
                obj.Unit = txtUnit.Text;
                obj.Priority = "1";
                obj.Image1 = txtImage1.Text;
                obj.Image2 = txtImage2.Text;
                obj.Image3 = txtImage3.Text;
                obj.Image4 = txtImage4.Text;
                obj.Image5 = txtImage5.Text;
                obj.Detail = fckDetail.Value;

                obj.ProductCode = txtProductCode.Text;
              
                obj.BranchID = "0";
               
                obj.CapacityID = "0";

                obj.ProductCategoryID = ddlProductCategory.SelectedValue;
                if (Insert == true)
                {
                    obj.CreatedDate = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy HH:mm:ss");
                    obj.ModifiedDate = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy HH:mm:ss");
                    ProductService.Product_Insert(obj);
                }
                else
                {
                    obj.ModifiedDate = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy HH:mm:ss");
                    ProductService.Product_Update(obj);
                }
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;
                Insert = false;
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
            Insert = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string where = "";
            if(ddlProductCategorySearch.SelectedValue !=null){
                if(!ddlProductCategorySearch.SelectedValue.Trim().Equals("0")){
                    where += "ProductCategoryID ="+ddlProductCategorySearch.SelectedValue.ToString()+ " and";
                }
            }
            if (!txtSearch.Text.Trim().Equals(""))
            {
                where += " Name like N'%" + txtSearch.Text + "%'";
            }
            if(!where.Trim().Equals("") && where.EndsWith("and")==true){
                where = where.Substring(0, where.LastIndexOf("and"));
            }

                grdProduct.DataSource = ProductService.Product_GetByTop("", where, "");
                grdProduct.DataBind();
                if (grdProduct.PageCount <= 1)
                {
                    grdProduct.PagerStyle.Visible = false;
                }

        }
    }
}