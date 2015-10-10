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
	public partial class News : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		private string Lang = "";
        public static string ListName = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			Lang = Global.GetLang();
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                LoadFilterGroupNewsDropDownList();
                LoadFilterNewsAutocomplete();
                Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
				BindGrid();
			}
		}

		private void BindGrid()
		{
			grdNews.DataSource = NewsService.News_GetByAll(Lang);
			grdNews.DataBind();
			if (grdNews.PageCount <= 1)
			{
				grdNews.PagerStyle.Visible = false;
			}
		}

		private void LoadGroupNewsDropDownList()
		{
			ddlGroupNews.Items.Clear();
			ddlGroupNews.Items.Add(new ListItem("", ""));
			List<Data.GroupNews> list = GroupNewsService.GroupNews_GetByAll(Lang);
			for (int i = 0; i < list.Count; i++)
			{
				ddlGroupNews.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
			}
			ddlGroupNews.DataBind();
		}

        private void LoadFilterGroupNewsDropDownList()
        {
            ddlFilterGroupNews.Items.Clear();
            ddlFilterGroupNews.Items.Add(new ListItem(" -- Tất cả -- ", ""));
            List<Data.GroupNews> list = GroupNewsService.GroupNews_GetByAll(Lang);
            for (int i = 0; i < list.Count; i++)
            {
                ddlFilterGroupNews.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
            }
            ddlFilterGroupNews.DataBind();
        }

        private void LoadFilterNewsAutocomplete()
        {
            string strName = "";
            List<Data.News> list = NewsService.News_GetByAll(Lang);
            for (int i = 0; i < list.Count; i++)
            {
                strName += list[i].Name + "|";
            }
            ListName = Common.StringClass.Check(strName) && strName.Substring(strName.Length - 1).Contains("|") ? strName.Substring(0, strName.Length - 1) : strName;
        }

		protected void grdNews_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdNews.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdNews_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdNews.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdNews_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					List<Data.News> listE = NewsService.News_GetById(Id);
					txtName.Text = listE[0].Name;
					txtImage.Text = listE[0].Image;
					imgImage.ImageUrl = listE[0].Image.Length > 0 ? listE[0].Image : "";
					txtContent.Text = listE[0].Content;
					fckDetail.Value = listE[0].Detail;
					txtDate.Text = DateTimeClass.ConvertDateTime(listE[0].Date);
					txtTitle.Text = listE[0].Title;
					txtDescription.Text = listE[0].Description;
					txtKeyword.Text = listE[0].Keyword;
					chkPriority.Checked = listE[0].Priority == "1" || listE[0].Priority == "True";
					chkIndex.Checked = listE[0].Index == "1" || listE[0].Index == "True";
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
					LoadGroupNewsDropDownList();
					ddlGroupNews.Text = listE[0].GroupNewsId;
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update News set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					NewsService.News_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			 ControlClass.ResetControlValues(pnUpdate);
			LoadGroupNewsDropDownList();
			txtDate.Text = DateTimeClass.ConvertDateTime(DateTime.Now, "dd/MM/yyyy hh:mm:ss tt");
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdNews.Items.Count; i++)
			{
				item = grdNews.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						NewsService.News_Delete(strId);
					}
				}
			}
			grdNews.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
				Data.News obj = new Data.News();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.Tag = Common.StringClass.NameToTag(txtName.Text);
				obj.Image = txtImage.Text;
				obj.Content = txtContent.Text;
				obj.Detail = fckDetail.Value;
				obj.Date = DateTimeClass.ConvertDateTime(txtDate.Text, "MM/dd/yyyy HH:mm:ss");
				obj.Title = txtTitle.Text;
				obj.Description = txtDescription.Text;
				obj.Keyword = txtKeyword.Text;
				obj.Priority = chkPriority.Checked ? "1" : "0";
				obj.Index = chkIndex.Checked ? "1" : "0";
				obj.Active = chkActive.Checked ? "1" : "0";
				obj.Lang = Lang;
				obj.GroupNewsId = ddlGroupNews.SelectedValue;
				if (Insert == true){
					NewsService.News_Insert(obj);
				}
				else{
					NewsService.News_Update(obj);
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

        protected void Filter_Click(object sender, EventArgs e)
        {
            string strWhere = " 1=1 ";
            if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
            {
                strWhere += " and GroupNewsId = '" + ddlFilterGroupNews.SelectedValue + "' ";
            }
            if (Common.StringClass.Check(txtFilterName.Text))
            {
                strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
            }
            if (Common.StringClass.Check(txtFilterDateF.Text) && Common.StringClass.Check(txtFilterDateT.Text) == false)
            {
                txtFilterDateT.Text = txtFilterDateF.Text;
            }
            if (Common.StringClass.Check(txtFilterDateF.Text) == false && Common.StringClass.Check(txtFilterDateT.Text))
            {
                txtFilterDateF.Text = txtFilterDateT.Text;
            }
            if (Common.StringClass.Check(txtFilterDateF.Text) && Common.StringClass.Check(txtFilterDateT.Text))
            {
                strWhere += " and convert(nvarchar(10), Date, 21) between '" + Common.DateTimeClass.ConvertDate(txtFilterDateF.Text, "yyyy-MM-dd") + "' and '" + Common.DateTimeClass.ConvertDate(txtFilterDateT.Text, "yyyy-MM-dd") + "' ";
            }
            if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
            {
                strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
            }
            grdNews.DataSource = NewsService.News_GetByTop("", strWhere, "Date desc, Id desc");
            grdNews.DataBind();
            if (grdNews.PageCount <= 1)
            {
                grdNews.PagerStyle.Visible = false;
            }
        }

        protected void UnFilter_Click(object sender, EventArgs e)
        {
             ControlClass.ResetControlValues(pnUpdate);
            LoadFilterGroupNewsDropDownList();
            LoadFilterNewsAutocomplete();
            Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
            BindGrid();
        }
	}
}