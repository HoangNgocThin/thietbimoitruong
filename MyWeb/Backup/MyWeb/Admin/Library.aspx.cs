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
	public partial class Library : System.Web.UI.Page
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
				BindGrid();
			}
		}

		private void BindGrid()
		{
			grdLibrary.DataSource = LibraryService.Library_GetByAll(Lang);
			grdLibrary.DataBind();
			if (grdLibrary.PageCount <= 1)
			{
				grdLibrary.PagerStyle.Visible = false;
			}
		}

		private void LoadGroupLibraryDropDownList()
		{
			ddlGroupLibrary.Items.Clear();
			ddlGroupLibrary.Items.Add(new ListItem("", ""));
			List<Data.GroupLibrary> list = GroupLibraryService.GroupLibrary_GetByAll(Lang);
			for (int i = 0; i < list.Count; i++)
			{
				ddlGroupLibrary.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
			}
			ddlGroupLibrary.DataBind();
		}

		protected void grdLibrary_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdLibrary.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdLibrary_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdLibrary.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdLibrary_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					List<Data.Library> listE = LibraryService.Library_GetById(Id);
					txtName.Text = listE[0].Name;
					txtImage.Text = listE[0].Image;
					imgImage.ImageUrl = listE[0].Image.Length > 0 ? listE[0].Image : "";
					txtFile.Text = listE[0].File;
					fckInfo.Value = listE[0].Info;
					chkPriority.Checked = listE[0].Priority == "1" || listE[0].Priority == "True";
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
					LoadGroupLibraryDropDownList();
					ddlGroupLibrary.Text = listE[0].GroupLibraryId;
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update [Library] set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					LibraryService.Library_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			 ControlClass.ResetControlValues(pnUpdate);
			LoadGroupLibraryDropDownList();
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdLibrary.Items.Count; i++)
			{
				item = grdLibrary.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						LibraryService.Library_Delete(strId);
					}
				}
			}
			grdLibrary.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
				Data.Library obj = new Data.Library();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.Tag = Common.StringClass.NameToTag(txtName.Text);
				obj.Image = txtImage.Text;
				obj.File = txtFile.Text;
				obj.Info = fckInfo.Value;
				obj.Priority = chkPriority.Checked ? "1" : "0";
				obj.Active = chkActive.Checked ? "1" : "0";
				obj.Lang = Lang;
				obj.GroupLibraryId = ddlGroupLibrary.SelectedValue;
				if (Insert == true){
					LibraryService.Library_Insert(obj);
				}
				else{
					LibraryService.Library_Update(obj);
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