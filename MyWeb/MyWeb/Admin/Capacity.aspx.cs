using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admin
{
    public partial class Capacity : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
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
            grdCapacity.DataSource = CapacityService.Capacity_GetByAll();
            grdCapacity.DataBind();
            if (grdCapacity.PageCount <= 1)
            {
                grdCapacity.PagerStyle.Visible = false;
            }
        }

        protected void grdCapacity_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdCapacity.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdCapacity_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdCapacity.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdCapacity_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.Capacity> listE = CapacityService.Capacity_GetById(Id);
                    txtName.Text = listE[0].Name;
                    txtOrd.Text = listE[0].Ord;
                    txtCreatedDate.Text = DateTimeClass.ConvertDateTime(listE[0].CreatedDate);
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    txtTitle.Text = listE[0].Title;
                    txtDescription.Text = listE[0].Description;
                    txtMetaKeyword.Text = listE[0].MetaKeyword;
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [Capacity] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    CapacityService.Capacity_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            txtCreatedDate.Text = DateTimeClass.ConvertDateTime(DateTime.Now, "dd/MM/yyyy hh:mm:ss tt");
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdCapacity.Items.Count; i++)
            {
                item = grdCapacity.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        CapacityService.Capacity_Delete(strId);
                    }
                }
            }
            grdCapacity.CurrentPageIndex = 0;
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
                Data.Capacity obj = new Data.Capacity();
                obj.Id = Id;
                obj.Name = txtName.Text;
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.CreatedDate = DateTimeClass.ConvertDateTime(txtCreatedDate.Text, "MM/dd/yyyy HH:mm:ss");
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.Title = txtTitle.Text;
                obj.Description = txtDescription.Text;
                obj.MetaKeyword = txtMetaKeyword.Text;
                if (Insert == true)
                {
                    CapacityService.Capacity_Insert(obj);
                }
                else
                {
                    CapacityService.Capacity_Update(obj);
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
    }
}