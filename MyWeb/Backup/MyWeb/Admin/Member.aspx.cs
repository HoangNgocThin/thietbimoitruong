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
	public partial class Member : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		private string Lang = "";
        static string Password = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			Lang = Global.GetLang();
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				BindGrid();
			}
		}

		private void BindGrid()
		{
			grdMember.DataSource = MemberService.Member_GetByAll();
			grdMember.DataBind();
			if (grdMember.PageCount <= 1)
			{
				grdMember.PagerStyle.Visible = false;
			}
		}

		private void LoadGroupMemberDropDownList()
		{
			ddlGroupMember.Items.Clear();
			ddlGroupMember.Items.Add(new ListItem("", ""));
			List<Data.GroupMember> list = GroupMemberService.GroupMember_GetByAll();
			for (int i = 0; i < list.Count; i++)
			{
				ddlGroupMember.Items.Add(new ListItem(list[i].Name, list[i].Id));
			}
			ddlGroupMember.DataBind();
		}

		protected void grdMember_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdMember.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdMember_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdMember.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdMember_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					List<Data.Member> listE = MemberService.Member_GetById(Id);
					txtName.Text = listE[0].Name;
                    txtEmail.Text = listE[0].Email;
					txtUsername.Text = listE[0].Username;
					txtPassword.Text = "";
                    Password = listE[0].Password;
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
					LoadGroupMemberDropDownList();
					ddlGroupMember.Text = listE[0].GroupMemberId;
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update [Member] set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					MemberService.Member_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			 ControlClass.ResetControlValues(pnUpdate);
			LoadGroupMemberDropDownList();
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdMember.Items.Count; i++)
			{
				item = grdMember.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						MemberService.Member_Delete(strId);
					}
				}
			}
			grdMember.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
				Data.Member obj = new Data.Member();
				obj.Id = Id;
				obj.Name = txtName.Text;
                obj.Email = txtEmail.Text;
				obj.Username = txtUsername.Text;
				obj.Active = chkActive.Checked ? "1" : "0";
                obj.GroupMemberId = ddlGroupMember.SelectedValue.Length > 0 ? ddlGroupMember.SelectedValue : "1";
				if (Insert == true){
                    obj.Password = txtPassword.Text;
                    MemberService.Member_Insert(obj);
				}
				else{
                    obj.Password = txtPassword.Text != "" ? StringClass.Encrypt(txtPassword.Text) : Password;
                    MemberService.Member_Update(obj);
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