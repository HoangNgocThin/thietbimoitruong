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
	public partial class EmailRegisters : System.Web.UI.Page
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
			grdEmailRegisters.DataSource = EmailRegistersService.EmailRegisters_GetByAll();
			grdEmailRegisters.DataBind();
			if (grdEmailRegisters.PageCount <= 1)
			{
				grdEmailRegisters.PagerStyle.Visible = false;
			}
		}

		protected void grdEmailRegisters_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdEmailRegisters.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdEmailRegisters_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdEmailRegisters.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdEmailRegisters_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					List<Data.EmailRegisters> listE = EmailRegistersService.EmailRegisters_GetById(Id);
					txtEmail.Text = listE[0].Email;
					txtCreatedate.Text = listE[0].Createdate;
					txtStatus.Text = listE[0].Status;
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Delete":
					EmailRegistersService.EmailRegisters_Delete(strCA);
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
			for (int i = 0; i < grdEmailRegisters.Items.Count; i++)
			{
				item = grdEmailRegisters.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						EmailRegistersService.EmailRegisters_Delete(strId);
					}
				}
			}
			grdEmailRegisters.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
				Data.EmailRegisters obj = new Data.EmailRegisters();
				obj.Id = Id;
				obj.Email = txtEmail.Text;
				obj.Createdate = txtCreatedate.Text;
				obj.Status = txtStatus.Text;
				if (Insert == true){
					EmailRegistersService.EmailRegisters_Insert(obj);
				}
				else{
					EmailRegistersService.EmailRegisters_Update(obj);
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