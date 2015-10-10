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
        static string Lang = "";
        string dtPostedDate=DateTime.Now.ToLongTimeString();
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
            grdNews.DataSource = NewsService.News_GetByAll();
            grdNews.DataBind();
            if (grdNews.PageCount <= 1)
            {
                grdNews.PagerStyle.Visible = false;
            }
        }

        private void LoadNewsCategoryDropDownList()
		{
			ddlNewsCategory.Items.Clear();
			ddlNewsCategory.Items.Add(new ListItem("", ""));
			List<Data.NewsCategory> list = NewsCategoryService.NewsCategory_GetByAll();
			for (int i = 0; i < list.Count; i++)
			{
				ddlNewsCategory.Items.Add(new ListItem(list[i].Name, list[i].Id));
			}
			ddlNewsCategory.DataBind();
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
                    fckContent.Value = listE[0].Content;
                    fckDetail.Value = listE[0].Detail;
                    txtTitle.Text = listE[0].Title;
                    txtDescription.Text = listE[0].Description;
                    txtKeyword.Text = listE[0].Keyword;
                    chkPriority.Checked = listE[0].Priority == "1" || listE[0].Priority == "True";
                    chkIndex.Checked = listE[0].Index == "1" || listE[0].Index == "True";
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    chkIsHotNews.Checked = listE[0].IsHotNews == "1" || listE[0].IsHotNews == "True";
                    dtPostedDate = listE[0].PostedDate;
                    LoadNewsCategoryDropDownList();
                    ddlNewsCategory.Text = listE[0].NewsCategoryID;
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [News] set Active=" + strA + "  Where Id='" + strCA + "'");
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
            ControlClass.ResetControlValues(this);
            LoadNewsCategoryDropDownList();
            
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
            if (Page.IsValid)
            {
                Data.News obj = new Data.News();
                obj.Id = Id;
                obj.Name = txtName.Text;
                obj.Tag = Common.StringClass.NameToTag(txtName.Text);
                obj.Image = txtImage.Text;
                obj.Content = fckContent.Value;
                obj.Detail = fckDetail.Value;
                obj.Title = txtTitle.Text;
                obj.Description = txtDescription.Text;
                obj.Keyword = txtKeyword.Text;
                obj.Priority = chkPriority.Checked ? "1" : "0";
                obj.Index = chkIndex.Checked ? "1" : "0";
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.IsHotNews = chkIsHotNews.Checked ? "1" : "0";
                obj.NewsCategoryID = ddlNewsCategory.SelectedValue;
                obj.PostedDate = DateTimeClass.ConvertDateTime(dtPostedDate, "MM/dd/yyyy HH:mm:ss");
                if (Insert == true)
                {
                   
                    NewsService.News_Insert(obj);
                }
                else
                {
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Trim().Equals(""))
            {
                grdNews.DataSource = NewsService.News_GetByTop("", "Name like N'%"+txtSearch.Text+"%'", "");
                grdNews.DataBind();
                if (grdNews.PageCount <= 1)
                {
                    grdNews.PagerStyle.Visible = false;
                }
            }
        }
    }
}