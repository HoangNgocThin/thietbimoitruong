using System;
using System.Collections.Generic;
using System.Linq;
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
        private string Lang = "vi";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Lang = Global.GetLang();
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                BindGrid();
            }
            
        }
        protected string loadlocation(string location)
        { 
            string str="";
            if(location.Trim().Equals("0"))
            {
                str = "Miền bắc";
            }
            else if (location.Trim().Equals("1"))
            {
                str = "Miền nam";
            }
            return str;
        }
        private void BindGrid()
        {
            grdConfig.DataSource = ConfigService.Config_GetByAll(Lang);
            grdConfig.DataBind();
            if (grdConfig.PageCount <= 1)
            {
                grdConfig.PagerStyle.Visible = false;
            }
            else
            {
                grdConfig.PagerStyle.Visible = true;  
            }
        }
        private void loadDDLLocation()
        {
            DDLLocation.Items.Clear();
            DDLLocation.Items.Add(new ListItem("==chọn khu vực==",""));
            DDLLocation.Items.Add(new ListItem("Khu vực phía bắc","0"));
            DDLLocation.Items.Add(new ListItem("Khu vực phía nam","1"));
            DDLLocation.DataBind();
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
                    txtMail_Smtp.Text = listE[0].Mail_Smtp;
                    txtMail_Port.Text = listE[0].Mail_Port;
                    txtMail_Info.Text = listE[0].Mail_Info;
                    txtMail_Noreply.Text = listE[0].Mail_Noreply;
                    txtMail_Password.Text = listE[0].Mail_Password;
                    txtPlaceHead.Text = listE[0].PlaceHead;
                    //txtPlaceBody.Text = listE[0].PlaceBody;
                    fckPlaceBody.Value = listE[0].PlaceBody;
                    txtGoogleId.Text = listE[0].GoogleId;
                    fckContact.Value = listE[0].Contact;
                    fckDeliveryTerms.Value = listE[0].DeliveryTerms;
                    fckPaymentTerms.Value = listE[0].PaymentTerms;
                    fckCopyright.Value = listE[0].Copyright;
                    txtFreeShipping.Text = listE[0].FreeShipping;
                    txtTitle.Text = listE[0].Title;
                    txtDescription.Text = listE[0].Description;
                    txtKeyword.Text = listE[0].Keyword;
                    loadDDLLocation();
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
             ControlClass.ResetControlValues(pnUpdate);
            pnView.Visible = false;
            loadDDLLocation();
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
                obj.Mail_Smtp = txtMail_Smtp.Text;
                obj.Mail_Port = txtMail_Port.Text;
                obj.Mail_Info = txtMail_Info.Text;
                obj.Mail_Noreply = txtMail_Noreply.Text;
                obj.Mail_Password = txtMail_Password.Text;
                obj.PlaceHead = txtPlaceHead.Text;
                //obj.PlaceBody = txtPlaceBody.Text;
                obj.PlaceBody = fckPlaceBody.Value;
                obj.GoogleId = txtGoogleId.Text;
                obj.Contact = fckContact.Value;
                obj.DeliveryTerms = fckDeliveryTerms.Value;
                obj.PaymentTerms = fckPaymentTerms.Value;
                obj.FreeShipping = txtFreeShipping.Text;
                obj.Copyright = fckCopyright.Value;
                obj.Title = txtTitle.Text;
                obj.Description = txtDescription.Text;
                obj.Keyword = txtKeyword.Text;
                obj.Lang = Lang;
                obj.Helpsize = this.fckhelp_size.Value.ToString();
                obj.Location = DDLLocation.SelectedValue.ToString();
                if (Insert == true)
                {
                    ConfigService.Config_Insert(obj);
                }
                else
                {
                    ConfigService.Config_Update(obj);
                }
                //BindGrid();
                //pnView.Visible = true;
                //pnUpdate.Visible = false;
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