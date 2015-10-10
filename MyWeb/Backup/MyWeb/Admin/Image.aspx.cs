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
    public partial class Image : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		static string Level = "";
		static string Lang = "";
        string UserId = "";
        string Admins = "";
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Request.Cookies["Id"] != null)
            {
                UserId = Request.Cookies["Id"].Value;
            }
            if (Request.Cookies["Admin"] != null)
            {
                Admins = Request.Cookies["Admin"].Value;
            }
			if (!IsPostBack)
			{
				lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				NumberClass.OnlyInputNumber(txtOrd);
				Lang = Session["lang"].ToString();
                LoadGroupNewsDropDownList();
				BindGrid();
			}
		}

        #region[ViewGroupImage]
        private void LoadGroupNewsDropDownList()
        {
            drlNhomanh.Items.Clear();
            drlChuyenmuc.Items.Clear();
            drlNhomanh.Items.Add(new ListItem("===Chọn nhóm===", "0"));
            drlChuyenmuc.Items.Add(new ListItem("===Chọn nhóm===", "0"));
            List<Data.GroupImage> list = new List<Data.GroupImage>();
            if (Admins == "1")
            {
                list = GroupImageService.GroupImage_GetByAll(Lang);
            }
            else
            {
                if (UserId.Length > 0)
                {
                    list = Business.GroupImageService.GroupImage_GetByTop("100", "Id in(select GroupImageId from PerLibrary where UserId=" + UserId + ")", "Level");
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                drlNhomanh.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
                drlChuyenmuc.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
            }
            drlNhomanh.DataBind();
        }
        #endregion

        private void BindGrid()
		{
            if (Admins == "1")
            {
                if (drlChuyenmuc.SelectedValue == "0")
                {
                    grdGroupNews.DataSource = Business.ImageService.Image_GetByAll(Lang);
                    grdGroupNews.DataBind();
                    if (grdGroupNews.PageCount <= 1)
                    {
                        grdGroupNews.PagerStyle.Visible = false;
                    }
                }
                else
                {
                    grdGroupNews.DataSource = ImageService.Image_GetByTop("100000", "GroupImageId=" + drlChuyenmuc.SelectedValue + "", "Id desc");
                    grdGroupNews.DataBind();
                    if (grdGroupNews.PageCount <= 1)
                    {
                        grdGroupNews.PagerStyle.Visible = false;
                    }
                }
            }
            else
            {
                grdGroupNews.DataSource = ImageService.Image_GetByTop("100000", "GroupImageId=" + drlChuyenmuc.SelectedValue + "", "Id desc");
                grdGroupNews.DataBind();
                if (grdGroupNews.PageCount <= 1)
                {
                    grdGroupNews.PagerStyle.Visible = false;
                }
            }
		}

		protected void grdGroupNews_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdGroupNews.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdGroupNews_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdGroupNews.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdGroupNews_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "AddSub":
					Level = strCA;
					AddButton_Click(source, e);
					break;
				case "Edit":
					Insert = false;
					Id = strCA;
                    LoadGroupNewsDropDownList();
					List<Data.Image> listE = Business.ImageService.Image_GetById(Id);
					txtName.Text = listE[0].Name;
                    txtFile.Text = listE[0].File;
					imgImage.ImageUrl = listE[0].File.Length > 0 ? listE[0].File : "";
					txtTitle.Text = listE[0].Title;
					txtDescription.Text = listE[0].Description;
					txtKeyword.Text = listE[0].Keyword;
					txtOrd.Text = listE[0].Ord;
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    //chkIndex.Checked = listE[0].Index == "1" || listE[0].Index == "True";
                    drlNhomanh.SelectedValue = listE[0].GroupImageId;
                    rbtUutien.SelectedValue = listE[0].Index;
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update Image set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					Business.ImageService.Image_Delete(strCA);
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
            LoadGroupNewsDropDownList();
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdGroupNews.Items.Count; i++)
			{
				item = grdGroupNews.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						Business.ImageService.Image_Delete(strId);
					}
				}
			}
			grdGroupNews.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
                Data.Image obj = new Data.Image();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.Tag = Common.StringClass.NameToTag(txtName.Text);
				obj.Title = txtTitle.Text;
				obj.Description = txtDescription.Text;
				obj.Keyword = txtKeyword.Text;
				obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
				obj.Active = chkActive.Checked ? "1" : "0";
				obj.Lang = Lang;
                obj.Index = rbtUutien.SelectedValue;
                obj.GroupImageId = drlNhomanh.SelectedValue;
                obj.File = txtFile.Text;
				if (Insert == true){
					Business.ImageService.Image_Insert(obj);
				}
				else{
                    Business.ImageService.Image_Update(obj);
				}
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
				Level= "";
				Insert = false;
			}
		}

		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			Level= "";
			Insert = false;
		}

        protected void drlChuyenmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
	}
}