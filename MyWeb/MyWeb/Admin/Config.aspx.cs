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
    public partial class Config : System.Web.UI.Page
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
                Lang = Session["Lang"].ToString();
                BindGrid();
            }
        }

        private void BindGrid()
        {
            grdConfig.DataSource = ConfigService.Config_GetByAll();
            grdConfig.DataBind();
            if (grdConfig.PageCount <= 1)
            {
                grdConfig.PagerStyle.Visible = false;
            }
        }

        protected void grdConfig_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdConfig.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdConfig_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdConfig.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdConfig_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.Config> listE = ConfigService.Config_GetById(Id);
                    txtBanner.Text = listE[0].Banner;
                    imgBanner.ImageUrl = listE[0].Banner.Length > 0 ? listE[0].Banner : "";
                    fckFooter.Value = listE[0].Footer;
                    txtPageTitle.Text = listE[0].PageTitle;
                    txtDescription.Text = listE[0].Description;
                    txtMetaKeyword.Text = listE[0].MetaKeyword;
                    txtModifiedDate.Text = DateTimeClass.ConvertDateTime(listE[0].ModifiedDate);
                    chkIsApply.Checked = listE[0].IsApply == "1" || listE[0].IsApply == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Delete":
                    ConfigService.Config_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            txtModifiedDate.Text = DateTimeClass.ConvertDateTime(DateTime.Now, "dd/MM/yyyy hh:mm:ss tt");
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdConfig.Items.Count; i++)
            {
                item = grdConfig.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ConfigService.Config_Delete(strId);
                    }
                }
            }
            grdConfig.CurrentPageIndex = 0;
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
                Data.Config obj = new Data.Config();
                obj.Id = Id;
                obj.SendGmail = "satthepthangngoc@gmail.com";
                obj.Password = "abc";
                obj.ReceiveGmail = "satthepthangngoc@gmail.com";
                obj.Banner = txtBanner.Text;
                obj.Footer = fckFooter.Value;
                obj.PageTitle = txtPageTitle.Text;
                obj.Description = txtDescription.Text;
                obj.MetaKeyword = txtMetaKeyword.Text;
                obj.ModifiedDate = DateTimeClass.ConvertDateTime(txtModifiedDate.Text, "MM/dd/yyyy HH:mm:ss");
                obj.IsApply = chkIsApply.Checked ? "1" : "0";
                if (Insert == true)
                {
                    ConfigService.Config_Insert(obj);
                }
                else
                {
                    ConfigService.Config_Update(obj);
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