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
	public partial class GroupSupport : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		private string Lang = "vi";
        SqlDataProvider sql = new SqlDataProvider();
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
			grdGroupSupport.DataSource = GroupSupportService.GroupSupport_GetByAll(Lang);
			grdGroupSupport.DataBind();
            if (grdGroupSupport.PageCount <= 1)
            {
                grdGroupSupport.PagerStyle.Visible = false;
            }
            else
            {
                grdGroupSupport.PagerStyle.Visible = true;
            }
		}

		protected void grdGroupSupport_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdGroupSupport.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdGroupSupport_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdGroupSupport.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdGroupSupport_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					List<Data.GroupSupport> listE = GroupSupportService.GroupSupport_GetById(Id);
					txtName.Text = listE[0].Name;
					txtOrd.Text = listE[0].Ord;
 
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";

					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [GroupSupport] set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					GroupSupportService.GroupSupport_Delete(strCA);
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
			for (int i = 0; i < grdGroupSupport.Items.Count; i++)
			{
				item = grdGroupSupport.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						GroupSupportService.GroupSupport_Delete(strId);
					}
				}
			}
			grdGroupSupport.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
				Data.GroupSupport obj = new Data.GroupSupport();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
				obj.Active = chkActive.Checked ? "1" : "0";
				obj.Lang = Lang;
               
				if (Insert == true){
					GroupSupportService.GroupSupport_Insert(obj);
				}
				else{
					GroupSupportService.GroupSupport_Update(obj);
				}
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
				Insert = false;
			}
		}
        //void loadddlkhuvuc()
        //{
        //    ddlkhuvuc.Items.Clear();
        //    ddlkhuvuc.Items.Add(new ListItem("==chọn khu vực==",""));
        //    ddlkhuvuc.Items.Add(new ListItem("Khu vực miền bắc", "0"));
        //    ddlkhuvuc.Items.Add(new ListItem("Khu vực miền nam", "1"));
        //    ddlkhuvuc.DataBind();
        //}
		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			Insert = false;
		}
	}
}