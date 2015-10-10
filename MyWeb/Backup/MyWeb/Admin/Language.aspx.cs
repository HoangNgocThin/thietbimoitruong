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
	public partial class Language : System.Web.UI.Page
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
			grdLanguage.DataSource = LanguageService.Language_GetByAll();
			grdLanguage.DataBind();
			if (grdLanguage.PageCount <= 1)
			{
				grdLanguage.PagerStyle.Visible = false;
			}
		}

		protected void grdLanguage_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdLanguage.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdLanguage_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdLanguage.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdLanguage_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					List<Data.Language> listE = LanguageService.Language_GetById(Id);
					txtName.Text = listE[0].Name;
					txtFolder.Text = listE[0].Folder;
					chkDefault.Checked = listE[0].Default == "1" || listE[0].Default == "True";
					txtImage.Text = listE[0].Image;
					imgImage.ImageUrl = listE[0].Image.Length > 0 ? listE[0].Image : "";
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update Language set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					LanguageService.Language_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			 ControlClass.ResetControlValues(pnUpdate);
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdLanguage.Items.Count; i++)
			{
				item = grdLanguage.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						LanguageService.Language_Delete(strId);
					}
				}
			}
			grdLanguage.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
				Data.Language obj = new Data.Language();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.Folder = txtFolder.Text;
				obj.Default = chkDefault.Checked ? "1" : "0";
				obj.Image = txtImage.Text;
				obj.Active = chkActive.Checked ? "1" : "0";
				if (Insert == true){
					LanguageService.Language_Insert(obj);
				}
				else{
					LanguageService.Language_Update(obj);
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