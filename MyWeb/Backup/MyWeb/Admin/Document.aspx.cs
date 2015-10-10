using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admin
{
	public partial class Document : System.Web.UI.Page
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
			grdDocument.DataSource = DocumentService.Document_GetByAll(Lang);
			grdDocument.DataBind();
			if (grdDocument.PageCount <= 1)
			{
				grdDocument.PagerStyle.Visible = false;
			}
		}

		private void LoadDocumentTypeDropDownList()
		{
			ddlDocumentType.Items.Clear();
			ddlDocumentType.Items.Add(new ListItem("", ""));
			List<Data.DocumentType> list = DocumentTypeService.DocumentType_GetByAll(Lang);
			for (int i = 0; i < list.Count; i++)
			{
				ddlDocumentType.Items.Add(new ListItem(list[i].Name, list[i].Id));
			}
			ddlDocumentType.DataBind();
		}

        private void LoadMemberDropDownList() 
        {
            string[] myArr = new string[] { "-1,EveryOne", "0,Member user" };
            Common.PageHelper.LoadDropDownList(ddlMember, myArr, true);
        }

		protected void grdDocument_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdDocument.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdDocument_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdDocument.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdDocument_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					List<Data.Document> listE = DocumentService.Document_GetById(Id);
					txtCode.Text = listE[0].Code;
					txtName.Text = listE[0].Name;
					txtCreateDate.Text = DateTimeClass.ConvertDate(listE[0].CreateDate);
					txtEffectiveDate.Text = DateTimeClass.ConvertDate(listE[0].EffectiveDate);
					fckInfo.Value = listE[0].Info;
					txtFile.Text = listE[0].File;
					chkPriority.Checked = listE[0].Priority == "1" || listE[0].Priority == "True";
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
					LoadDocumentTypeDropDownList();
                    LoadMemberDropDownList();
					ddlDocumentType.Text = listE[0].TypeId;
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update Document set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					DocumentService.Document_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			 ControlClass.ResetControlValues(pnUpdate);
			LoadDocumentTypeDropDownList();
            LoadMemberDropDownList();
            LoadMember2List();
			txtCreateDate.Text = DateTimeClass.ConvertDate(DateTime.Now);
			txtEffectiveDate.Text = DateTimeClass.ConvertDate(DateTime.Now);
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdDocument.Items.Count; i++)
			{
				item = grdDocument.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						DocumentService.Document_Delete(strId);
					}
				}
			}
			grdDocument.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
				Data.Document obj = new Data.Document();
				obj.Id = Id;
				obj.Code = txtCode.Text;
				obj.Name = txtName.Text;
				obj.CreateDate = DateTimeClass.ConvertDateTime(txtCreateDate.Text, "MM/dd/yyyy");
				obj.EffectiveDate = DateTimeClass.ConvertDateTime(txtEffectiveDate.Text, "MM/dd/yyyy");
				obj.Info = fckInfo.Value;
				obj.File = txtFile.Text;
				obj.Priority = chkPriority.Checked ? "1" : "0";
				obj.Active = chkActive.Checked ? "1" : "0";
				obj.Lang = Lang;
				obj.TypeId = ddlDocumentType.SelectedValue;
				if (Insert == true){
					DocumentService.Document_Insert(obj);
				}
				else{
					DocumentService.Document_Update(obj);
				}
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
				Insert = false;
			}
		}

        protected void LoadMember2List() 
        {
            List<Data.Member> list = MemberService.Member_GetByAll();
            lstMemberSelect.DataSource =list;
            lstMemberSelect.DataTextField = "Name";
            lstMemberSelect.DataValueField = "Id";
            lstMemberSelect.DataBind();
        }

		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			Insert = false;
		}
	}
}