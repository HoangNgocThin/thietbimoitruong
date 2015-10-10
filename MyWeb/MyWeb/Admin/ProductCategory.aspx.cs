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
    public partial class ProductCategory : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        static string Level = "";
        static string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                NumberClass.OnlyInputNumber(txtOrd);
                Lang = Session["Lang"].ToString();
                BindGrid();
            }
        }

        private void BindGrid()
        {
            List<Data.ProductCategory> list = new List<Data.ProductCategory>();
            list = ProductCategoryService.ProductCategory_GetByAll();
            list = list.OrderBy(x=>x.Level).ThenBy(x=>x.Ord).ToList();
            grdProductCategory.DataSource = list;
            grdProductCategory.DataBind();
            if (grdProductCategory.PageCount <= 1)
            {
                grdProductCategory.PagerStyle.Visible = false;
            }
        }

        protected void grdProductCategory_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdProductCategory.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdProductCategory_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdProductCategory.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdProductCategory_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "AddSub":
                    Level = strCA;
                    AddButton_Click(source, e);
                    break;
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.ProductCategory> listE = ProductCategoryService.ProductCategory_GetById(Id);
                    Level = listE[0].Level.Substring(0, listE[0].Level.Length - 5);
                    txtName.Text = listE[0].Name;
                    txtTitle.Text = listE[0].Title;
                    txtOrd.Text = listE[0].Ord;
                    txtDescription.Text = listE[0].Description;
                    txtMetaKeyword.Text = listE[0].MetaKeyword;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    chkIsDisplayInHome.Checked = listE[0].IsDisplayInHome == "1" || listE[0].IsDisplayInHome == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [ProductCategory] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    ProductCategoryService.ProductCategory_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdProductCategory.Items.Count; i++)
            {
                item = grdProductCategory.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ProductCategoryService.ProductCategory_Delete(strId);
                    }
                }
            }
            grdProductCategory.CurrentPageIndex = 0;
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
                Data.ProductCategory obj = new Data.ProductCategory();
                obj.ID = Id;
                obj.Name = txtName.Text;
                obj.Title = txtTitle.Text;
                obj.Tag = Common.StringClass.NameToTag(txtName.Text);
                obj.Level = Level + "00000";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Description = txtDescription.Text;
                obj.MetaKeyword = txtMetaKeyword.Text;
                obj.IsDisplayInHome = chkIsDisplayInHome.Checked ? "1" : "0";
                obj.Active = chkActive.Checked ? "1" : "0";
                if (Insert == true)
                {
                    ProductCategoryService.ProductCategory_Insert(obj);
                }
                else
                {
                    ProductCategoryService.ProductCategory_Update(obj);
                }
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;
                Level = "";
                Insert = false;
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
            Level = "";
            Insert = false;
        }
    }
}