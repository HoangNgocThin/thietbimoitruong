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
    public partial class Company : System.Web.UI.Page
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
            grdCompany.DataSource = CompanyService.Company_GetByAll();
            grdCompany.DataBind();
            if (grdCompany.PageCount <= 1)
            {
                grdCompany.PagerStyle.Visible = false;
            }
            else
            {
                grdCompany.PagerStyle.Visible = true;
            }
        }

        private void LoadProvinceDropDownList()
		{
			ddlProvince.Items.Clear();
			ddlProvince.Items.Add(new ListItem("==chọn tỉnh thành==", ""));
			List<Data.Province> list = ProvinceService.Province_GetByAll();
			for (int i = 0; i < list.Count; i++)
			{
				ddlProvince.Items.Add(new ListItem(list[i].Name, list[i].Id));
			}
			ddlProvince.DataBind();
		}

        protected void grdCompany_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdCompany.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdCompany_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdCompany.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdCompany_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.Company> listE = CompanyService.Company_GetById(Id);
                    //txtid.Text = listE[0].id;
                    txtName.Text = listE[0].Name;
                    txtAddress.Text = listE[0].Address;
                    txtPhoneNumber.Text = listE[0].PhoneNumber;
                    txtFax.Text = listE[0].Fax;
                    LoadProvinceDropDownList();
                    ddlProvince.Text = listE[0].ProvinceId;
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Delete":
                    CompanyService.Company_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            LoadProvinceDropDownList();
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdCompany.Items.Count; i++)
            {
                item = grdCompany.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        CompanyService.Company_Delete(strId);
                    }
                }
            }
            grdCompany.CurrentPageIndex = 0;
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
                Data.Company obj = new Data.Company();
                obj.id = Id;
                obj.Name = txtName.Text;
                obj.Address = txtAddress.Text;
                obj.PhoneNumber = txtPhoneNumber.Text;
                obj.Fax = txtFax.Text;
                obj.ProvinceId = ddlProvince.SelectedValue;
                if (Insert == true)
                {
                    CompanyService.Company_Insert(obj);
                }
                else
                {
                    CompanyService.Company_Update(obj);
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