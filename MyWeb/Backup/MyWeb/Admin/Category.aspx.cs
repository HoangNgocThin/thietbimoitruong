using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admin
{
    public partial class Category1 : System.Web.UI.Page
    {
        static bool Insert = false;
        static string Level = "";
        static string Lang = "";
        public static string ListName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                NumberClass.OnlyInputNumber(txtOrd);
                Lang = Session["Lang"].ToString();
                LoadFilterNewsAutocomplete();
                Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
                Common.PageHelper.LoadDropDownListFilterActive(drlNhomtrangchu);
                Common.PageHelper.LoadDropDownListFilterActive(drlNhomuutien);
                BindGrid();
            }
        }

        private void BindGrid()
        {
            bool flag = false;
            string strWhere = " 1=1 ";
            if (Common.StringClass.Check(txtFilterName.Text))
            {
                strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
            }
            if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
            {
                strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
            }
            if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
            {
                strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
            }
            if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
            {
                strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
            }
            if (!txtFilterName.Text.Trim().Equals("") || !ddlFilterActive.SelectedValue.Equals("") || !drlNhomuutien.SelectedValue.Equals(""))
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            if (flag == false)
            {
                grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Level");
                grdCategory.DataBind();
            }
            else
            {
                grdCategory.DataSource = CategoryService.Category_GetByAll(Lang);
                grdCategory.DataBind();
            }
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdCategory.Items.Count; i++)
            {
                item = grdCategory.Items[i];
                TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                NumberClass.OnlyInputNumber(stxtOrd);
            }
            if (grdCategory.PageCount <= 1)
            {
                grdCategory.PagerStyle.Visible = false;
            }
            else
            {
                grdCategory.PagerStyle.Visible = true;
            }
        }

        protected void grdCategory_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdCategory.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdCategory_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdCategory.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdCategory_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            string strWhere = " 1=1 ";
            DataGridItem item = default(DataGridItem);
            switch (e.CommandName)
            {
                case "AddSub":
                    Level = strCA;
                    AddButton_Click(source, e);
                    break;
                case "Edit":
                    Insert = false;
                    txtId.Value = strCA;
                    List<Data.Category> listE = CategoryService.Category_GetById(strCA);
                    Level = listE[0].Level.Substring(0, listE[0].Level.Length - 5);
                    txtName.Text = listE[0].Name;
                    fckContent.Value = listE[0].Content;
                    chkPriority.Checked = listE[0].Priority == "1" || listE[0].Priority == "True";
                    chkIndex.Checked = listE[0].Index == "1" || listE[0].Index == "True";
                    txtImage.Text = listE[0].Image;
                    imgImage.ImageUrl = listE[0].Image.Length > 0 ? listE[0].Image : "";
                    txtTitle.Text = listE[0].Title;
                    txtDescription.Text = listE[0].Description;
                    txtKeyword.Text = listE[0].Keyword;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    txtOrd.Text = listE[0].Ord;
                     txtImage2.Text = listE[0].Image2;
                    imgImage2.ImageUrl = listE[0].Image2.Length > 0 ? listE[0].Image2 : "";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [Category] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    List<Data.Product> list = new List<Product>();
                    list = ProductService.Product_GetByCatelogy(strCA);
                    if (list.Count > 0)
                    {
                        Common.WebMsgBox.Show("Không thể xóa nhóm sản phẩm đang có dữ liệu!");
                        return;
                    }
                    else
                    {
                        CategoryService.Category_Delete(strCA);
                    }
                    BindGrid();
                    break;
                #region[Sort Name asc]
                case "ascname":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Name");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Name desc]
                case "descname":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Name desc");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Priority asc]
                case "ascpriority":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Priority");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Priority desc]
                case "descpriority":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Priority desc");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Index asc]
                case "ascindex":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "[Index]");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Index desc]
                case "descindex":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "[Index] desc");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Active asc]
                case "ascactive":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Active");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Active desc]
                case "descactive":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Active desc");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Ord asc]
                case "ascord":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Ord");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Ord desc]
                case "descord":
                    if (Common.StringClass.Check(txtFilterName.Text))
                    {
                        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
                    }
                    if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
                    {
                        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
                    {
                        strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
                    }
                    if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
                    {
                        strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
                    }
                    grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Ord desc");
                    grdCategory.DataBind();
                    for (int i = 0; i < grdCategory.Items.Count; i++)
                    {
                        item = grdCategory.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                    }
                    if (grdCategory.PageCount <= 1)
                    {
                        grdCategory.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
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
                for (int i = 0; i < grdCategory.Items.Count; i++)
                {
                    item = grdCategory.Items[i];
                    if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                    {
                        //TextBox txtOrd = ((TextBox)item.FindControl("ChkSelect"));
                        if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                        {
                            string strId = item.Cells[1].Text;
                            List<Data.Product> list = new List<Product>();
                            list = ProductService.Product_GetByCatelogy(strId);
                            if (list.Count > 0)
                            {
                                Common.WebMsgBox.Show("Không thể xóa nhóm sản phẩm đang có dữ liệu!");
                                return;
                            }
                            else
                            {
                                CategoryService.Category_Delete(strId);
                            }
                        }
                    }
                }
            
            grdCategory.CurrentPageIndex = 0;
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
                Data.Category obj = new Data.Category();
                obj.Id = txtId.Value;
                obj.Tag = Common.StringClass.NameToTag(txtName.Text);
                obj.Name = txtName.Text;
                obj.Content = fckContent.Value;
                obj.Level = Level + "00000";
                obj.Priority = chkPriority.Checked ? "1" : "0";
                obj.Index = chkIndex.Checked ? "1" : "0";
                obj.Image = txtImage.Text;
                obj.Title = txtTitle.Text;
                obj.Description = txtDescription.Text;
                obj.Keyword = txtKeyword.Text;
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Lang = Lang;
                obj.Image2 = txtImage2.Text;
                if (Insert == true)
                {
                    CategoryService.Category_Insert(obj);
                }
                else
                {
                    CategoryService.Category_Update(obj);
                }
                Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
                Common.PageHelper.LoadDropDownListFilterActive(drlNhomtrangchu);
                Common.PageHelper.LoadDropDownListFilterActive(drlNhomuutien);
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;
                Level = "";
                Insert = false;
            }
        }

        private void LoadFilterNewsAutocomplete()
        {
            string strName = "";
            List<Data.Category> list = CategoryService.Category_GetByAll(Lang);
            for (int i = 0; i < list.Count; i++)
            {
                strName += list[i].Name + "|";
            }
            ListName = Common.StringClass.Check(strName) && strName.Substring(strName.Length - 1).Contains("|") ? strName.Substring(0, strName.Length - 1) : strName;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
            Level = "";
            Insert = false;
        }

        protected void Filter_Click(object sender, EventArgs e)
        {
            string strWhere = " 1=1 ";
            if (Common.StringClass.Check(txtFilterName.Text))
            {
                strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
            }
            if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
            {
                strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
            }
            if (Common.StringClass.Check(drlNhomtrangchu.SelectedValue))
            {
                strWhere += " and [Index] = '" + drlNhomtrangchu.SelectedValue + "' ";
            }
            if (Common.StringClass.Check(drlNhomuutien.SelectedValue))
            {
                strWhere += " and Priority = '" + drlNhomuutien.SelectedValue + "' ";
            }
            grdCategory.CurrentPageIndex = 0;
            grdCategory.DataSource = CategoryService.Category_GetByTop("", strWhere, "Level");
            grdCategory.DataBind();
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdCategory.Items.Count; i++)
            {
                item = grdCategory.Items[i];
                TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                NumberClass.OnlyInputNumber(stxtOrd);
            }
            if (grdCategory.PageCount <= 1)
            {
                grdCategory.PagerStyle.Visible = false;
            }
            else
            {
                grdCategory.PagerStyle.Visible = true;
            }
        }

        protected void UnFilter_Click(object sender, EventArgs e)
        {
             ControlClass.ResetControlValues(pnUpdate);
            LoadFilterNewsAutocomplete();
            Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
            Common.PageHelper.LoadDropDownListFilterActive(drlNhomtrangchu);
            Common.PageHelper.LoadDropDownListFilterActive(drlNhomuutien);
            BindGrid();
        }

        protected void lbtUpdateOrd_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdCategory.Items.Count; i++)
            {
                item = grdCategory.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                    NumberClass.OnlyInputNumber(stxtOrd);
                    if (stxtOrd.Text != "" && stxtOrd.Text!="0")
                    {
                        string strId = item.Cells[1].Text;
                        Data.Category obj = new Data.Category();
                        obj.Id = strId;
                        obj.Ord = stxtOrd.Text;
                        CategoryService.Category_Update_Ord(obj);
                    }
                }
            }
            BindGrid();
        }

        protected void lbtUpdateOrdBottom_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdCategory.Items.Count; i++)
            {
                item = grdCategory.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                    NumberClass.OnlyInputNumber(stxtOrd);
                    if (stxtOrd.Text != "" && stxtOrd.Text != "0")
                    {
                        string strId = item.Cells[1].Text;
                        Data.Category obj = new Data.Category();
                        obj.Id = strId;
                        obj.Ord = stxtOrd.Text;
                        CategoryService.Category_Update_Ord(obj);
                    }
                }
            }
            BindGrid();
        }
    }
}