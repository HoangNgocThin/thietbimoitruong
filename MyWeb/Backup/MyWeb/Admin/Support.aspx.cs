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
	public partial class Support : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		private string Lang = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			Lang = Global.GetLang();
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				NumberClass.OnlyInputNumber(txtOrd);
				BindGrid();
			}
		}

		private void BindGrid()
		{
			grdSupport.DataSource = SupportService.Support_GetByAll(Lang);
			grdSupport.DataBind();
            if (grdSupport.PageCount <= 1)
            {
                grdSupport.PagerStyle.Visible = false;
            }
            else
            {
                grdSupport.PagerStyle.Visible = true;
            }
		}

		private void LoadGroupSupportDropDownList()
		{
			ddlGroupSupport.Items.Clear();
			ddlGroupSupport.Items.Add(new ListItem("", ""));
			List<Data.GroupSupport> list = GroupSupportService.GroupSupport_GetByAll(Lang);
			for (int i = 0; i < list.Count; i++)
			{
				ddlGroupSupport.Items.Add(new ListItem(list[i].Name, list[i].Id));
			}
			ddlGroupSupport.DataBind();
		}

		protected void grdSupport_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdSupport.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdSupport_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdSupport.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdSupport_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					List<Data.Support> listE = SupportService.Support_GetById(Id);
					txtName.Text = listE[0].Name;
					txtTel.Text = listE[0].Tel;
                    PageHelper.LoadDropDownListSupportType(ddlType);
                    ddlType.Text = listE[0].Type;
					txtNick.Text = listE[0].Nick;
					txtOrd.Text = listE[0].Ord;
                    loadddlkhuvuc();
                    ddlkhuvuc.SelectedValue = listE[0].Location;
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
					LoadGroupSupportDropDownList();
					ddlGroupSupport.Text = listE[0].GroupSupportId;
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update Support set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					SupportService.Support_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			 ControlClass.ResetControlValues(pnUpdate);
			LoadGroupSupportDropDownList();
            loadddlkhuvuc();
            PageHelper.LoadDropDownListSupportType(ddlType);
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdSupport.Items.Count; i++)
			{
				item = grdSupport.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						SupportService.Support_Delete(strId);
					}
				}
			}
			grdSupport.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
				Data.Support obj = new Data.Support();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.Tel = txtTel.Text;
                obj.Type = ddlType.SelectedValue;
				obj.Nick = txtNick.Text;
				obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
				obj.Active = chkActive.Checked ? "1" : "0";
				obj.Lang = Lang;
                obj.Location = ddlkhuvuc.SelectedValue;
				obj.GroupSupportId = ddlGroupSupport.SelectedValue;
				if (Insert == true){
					SupportService.Support_Insert(obj);
				}
				else{
					SupportService.Support_Update(obj);
				}
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
				Insert = false;
			}
		}
        void loadddlkhuvuc()
        {
            ddlkhuvuc.Items.Clear();
            ddlkhuvuc.Items.Add(new ListItem("==chọn khu vực==", ""));
            ddlkhuvuc.Items.Add(new ListItem("Khu vực miền bắc", "0"));
            ddlkhuvuc.Items.Add(new ListItem("Khu vực miền nam", "1"));
            ddlkhuvuc.DataBind();
        }
        protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			Insert = false;
		}
	}
}