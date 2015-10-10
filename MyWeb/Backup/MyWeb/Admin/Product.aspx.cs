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
    public partial class Product1 : System.Web.UI.Page
    {
        static bool Insert = false;
        static string Lang = "";
        public static string ListName = "";
        public static string ListCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                NumberClass.OnlyInputNumber(txtOrd);
                Lang = Session["Lang"].ToString();
                LoadFilterGroupNewsDropDownList();
                LoadFilterNewsNameAutocomplete();
                LoadFilterNewsCodeAutocomplete();
                Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
                ViewCategory();
                BindGrid();
               
            }
        }

        #region[ViewCatId]
        void ViewCategory()
        {
            drlCatIdAdd.Items.Clear();
            drlCatIdAdd.Items.Add(new ListItem("===Chọn nhóm===","0"));
            List<Data.Category> list = CategoryService.Category_GetByAll(Lang);
            for (int i = 0; i < list.Count; i++)
            {
                drlCatIdAdd.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
            }
            drlCatIdAdd.DataBind();
            list.Clear();
            list = null;
        }
        #endregion

        private void BindGrid()
        {
            bool flag = false;
            string strWhere = " 1=1 ";
            if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
            {
                strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
            }
            else if (Common.StringClass.Check(txtFilterName.Text))
            {
                strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
            }
            else if (Common.StringClass.Check(txtFilterCode.Text))
            {
                strWhere += " and Codepro like N'%" + txtFilterCode.Text + "%' ";
            }
            else if (Common.StringClass.Check(txtFilterDateF.Text) && Common.StringClass.Check(txtFilterDateT.Text) == false)
            {
                txtFilterDateT.Text = txtFilterDateF.Text;
            }
            else if (Common.StringClass.Check(txtFilterDateF.Text) == false && Common.StringClass.Check(txtFilterDateT.Text))
            {
                txtFilterDateF.Text = txtFilterDateT.Text;
            }
            else if (Common.StringClass.Check(txtFilterDateF.Text) && Common.StringClass.Check(txtFilterDateT.Text))
            {
                strWhere += " and convert(nvarchar(10), Date, 21) between '" + Common.DateTimeClass.ConvertDate(txtFilterDateF.Text, "yyyy-MM-dd") + "' and '" + Common.DateTimeClass.ConvertDate(txtFilterDateT.Text, "yyyy-MM-dd") + "' ";
            }
            else if (Common.StringClass.Check(ddlFilterActive.SelectedValue))
            {
                strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "' ";
            }
            if (!ddlFilterGroupNews.SelectedValue.Equals("") || !txtFilterName.Text.Trim().Equals("") || !txtFilterCode.Text.Trim().Equals("") || !ddlFilterActive.SelectedValue.Equals(""))
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            if (flag == true)
            {
                grdProduct.DataSource = ProductService.Product_GetByAll(Lang);
                grdProduct.DataBind();
            }
            else
            {
                grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Date desc, Id desc");
                grdProduct.DataBind();
            }
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdProduct.Items.Count; i++)
            {
                item = grdProduct.Items[i];
                TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                NumberClass.OnlyInputNumber(stxtOrd);
                NumberClass.OnlyInputNumber(stxtGia);
            }
            if (grdProduct.PageCount <= 1)
            {
                grdProduct.PagerStyle.Visible = false;
            }
            else
            {
                grdProduct.PagerStyle.Visible = true;
            }
        }
        private void Bin_Brands()
        {
            
            List<Data.Brands> list = BrandsService.Brands_GetByAll(Lang);
            this.chkbrands.DataSource = list;
            this.chkbrands.DataTextField = "Name";
            this.chkbrands.DataValueField = "Id";
            this.chkbrands.DataBind();
            list.Clear();
            list = null;
        }
        private void Bin_Size()
        {
            this.chklistSizes.DataSource = SizesService.Sizes_GetByAll(Lang);
            this.chklistSizes.DataTextField = "Name";
            this.chklistSizes.DataValueField = "Id";
            this.chklistSizes.DataBind();
            if (this.chklistSizes.Items.Count > 0)
            {
                for (int i = 0; i < this.chklistSizes.Items.Count; i++)
                {
                    this.chklistSizes.Items[i].Selected = false;
                }
            }
        }
        private void Bin_Color()
        {
            this.chklistColors.DataSource = ColorsService.Colors_GetByAll(Lang);
            this.chklistColors.DataTextField = "Name";
            this.chklistColors.DataValueField = "Id";
            this.chklistColors.DataBind();
            if (this.chklistColors.Items.Count > 0)
            {
                for (int i = 0; i < this.chklistColors.Items.Count; i++)
                {
                    this.chklistColors.Items[i].Selected = false;
                }
            }
        }
        private void LoadFilterGroupNewsDropDownList()
        {
            ddlFilterGroupNews.Items.Clear();
            ddlFilterGroupNews.Items.Add(new ListItem(" -- Tất cả -- ", ""));
            List<Data.Category> list = CategoryService.Category_GetByAll(Lang);
            for (int i = 0; i < list.Count; i++)
            {
                ddlFilterGroupNews.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
            }
            ddlFilterGroupNews.DataBind();
        }

        private void LoadFilterNewsNameAutocomplete()
        {
            string strName = "";
            List<Data.Product> list = ProductService.Product_GetByAll(Lang);
            for (int i = 0; i < list.Count; i++)
            {
                strName += list[i].Name + "|";
            }
            ListName = Common.StringClass.Check(strName) && strName.Substring(strName.Length - 1).Contains("|") ? strName.Substring(0, strName.Length - 1) : strName;
        }

        private void LoadFilterNewsCodeAutocomplete()
        {
            string strCode = "";
            List<Data.Product> list = ProductService.Product_GetByAll(Lang);
            for (int i = 0; i < list.Count; i++)
            {
                strCode += list[i].Codepro + "|";
            }
            ListCode = Common.StringClass.Check(strCode) && strCode.Substring(strCode.Length - 1).Contains("|") ? strCode.Substring(0, strCode.Length - 1) : strCode;
        }

        protected void grdProduct_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdProduct.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdProduct_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdProduct.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdProduct_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            
            string strCA = e.CommandArgument.ToString();
            string strWhere = " 1=1 ";
            Bin_Brands();
            Bin_Size();
            Bin_Color();
            DataGridItem item = default(DataGridItem);
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    txtId.Value = strCA;
                    ViewCategory();
                    List<Data.Product> listE = ProductService.Product_GetById(strCA);
                    txtName.Text = listE[0].Name;
                    fckContent.Value = listE[0].Content;
                    fckDetail.Value = listE[0].Detail;
                    chkPriority.Checked = listE[0].Priority == "1" || listE[0].Priority == "True";
                    chkIndex.Checked = listE[0].Index == "1" || listE[0].Index == "True";
                    txtPrice.Text = NumberClass.ConvertNumber(listE[0].Price);
                    txtImage.Text = listE[0].Image;
                    imgImage.ImageUrl = listE[0].Image.Length > 0 ? listE[0].Image : "";
                    txtDate.Text = DateTimeClass.ConvertDateTime(listE[0].Date);
                    txtTitle.Text = listE[0].Title;
                    txtDescription.Text = listE[0].Description;
                    txtKeyword.Text = listE[0].Keyword;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    txtOrd.Text = listE[0].Ord;
                    drlCatIdAdd.SelectedValue = listE[0].CatId;
                    txtPricecu.Text = listE[0].PiceOld;
					txtImage1.Text = listE[0].Image1;
					imgImage1.ImageUrl = listE[0].Image1.Length > 0 ? listE[0].Image1 : "";
					txtImage2.Text = listE[0].Image2;
					imgImage2.ImageUrl = listE[0].Image2.Length > 0 ? listE[0].Image2 : "";
					txtImage3.Text = listE[0].Image3;
					imgImage3.ImageUrl = listE[0].Image3.Length > 0 ? listE[0].Image3 : "";
					txtImage4.Text = listE[0].Image4;
					imgImage4.ImageUrl = listE[0].Image4.Length > 0 ? listE[0].Image4 : "";
					txtImage5.Text = listE[0].Image5;
					imgImage5.ImageUrl = listE[0].Image5.Length > 0 ? listE[0].Image5 : "";
                    for (int i = 0; i < this.chkbrands.Items.Count; i++)
                    {
                        if (chkbrands.Items[i].Value.ToString().Equals(listE[0].BrandId.ToString()))
                        {
                            chkbrands.Items[i].Selected = true;
                            break;
                        }
                    }

                    List<Data.ProSize> listprosize = ProSizeService.ProSize_GetById(strCA);
                    if (listprosize.Count > 0)
                    {
                        
                        for (int i = 0; i < listprosize.Count; i++)
                        {
                            for(int j=0;j<this.chklistSizes.Items.Count;j++)
                            {
                                if (this.chklistSizes.Items[j].Value == listprosize[i].SizeId)
                                {
                                    this.chklistSizes.Items[j].Selected = true;
                                    break;
                                }
                               
                            }
                        }
                    }
                    List<Data.ProColor> listprocolor = ProColorService.ProColor_GetById(strCA);
                    if (listprocolor.Count > 0)
                    {
                        
                        for (int i = 0; i < listprocolor.Count; i++)
                        {
                            for(int j=0;j<this.chklistColors.Items.Count;j++)
                            {
                                if (this.chklistColors.Items[j].Value == listprocolor[i].ColorId)
                                {
                                    this.chklistColors.Items[j].Selected = true;
                                    break;
                                }
                                //else if(this.chklistColors.Items[j].Selected==false)
                                //    this.chklistColors.Items[j].Selected = false;
                            }
                        }
                    }
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [Product] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    ProductService.Product_Delete(strCA);
                    BindGrid();
                    break;
                #region[Sort Name asc]
                case "ascName":
                    if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
                    {
                        strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
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
                    grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Name");
                    grdProduct.DataBind();
                    for (int i = 0; i < grdProduct.Items.Count; i++)
                    {
                        item = grdProduct.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                        NumberClass.OnlyInputNumber(stxtGia);
                    }
                    if (grdProduct.PageCount <= 1)
                    {
                        grdProduct.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Name desc]
                case "descName":
                    if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
                    {
                        strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
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
                    grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Name desc");
                    grdProduct.DataBind();
                    for (int i = 0; i < grdProduct.Items.Count; i++)
                    {
                        item = grdProduct.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                        NumberClass.OnlyInputNumber(stxtGia);
                    }
                    if (grdProduct.PageCount <= 1)
                    {
                        grdProduct.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Date asc]
                case "ascDate":
                    if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
                    {
                        strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
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
                    grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Date");
                    grdProduct.DataBind();
                    for (int i = 0; i < grdProduct.Items.Count; i++)
                    {
                        item = grdProduct.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                        NumberClass.OnlyInputNumber(stxtGia);
                    }
                    if (grdProduct.PageCount <= 1)
                    {
                        grdProduct.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Date desc]
                case "descDate":
                    if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
                    {
                        strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
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
                    grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Date desc");
                    grdProduct.DataBind();
                    for (int i = 0; i < grdProduct.Items.Count; i++)
                    {
                        item = grdProduct.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                        NumberClass.OnlyInputNumber(stxtGia);
                    }
                    if (grdProduct.PageCount <= 1)
                    {
                        grdProduct.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Price asc]
                case "ascPrice":
                    if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
                    {
                        strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
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
                    grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Price");
                    grdProduct.DataBind();
                    for (int i = 0; i < grdProduct.Items.Count; i++)
                    {
                        item = grdProduct.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                        NumberClass.OnlyInputNumber(stxtGia);
                    }
                    if (grdProduct.PageCount <= 1)
                    {
                        grdProduct.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Price desc]
                case "descPrice":
                    if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
                    {
                        strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
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
                    grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Price desc");
                    grdProduct.DataBind();
                    for (int i = 0; i < grdProduct.Items.Count; i++)
                    {
                        item = grdProduct.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                        NumberClass.OnlyInputNumber(stxtGia);
                    }
                    if (grdProduct.PageCount <= 1)
                    {
                        grdProduct.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Ord asc]
                case "ascOrd":
                    if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
                    {
                        strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
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
                    grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Ord");
                    grdProduct.DataBind();
                    for (int i = 0; i < grdProduct.Items.Count; i++)
                    {
                        item = grdProduct.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                        NumberClass.OnlyInputNumber(stxtGia);
                    }
                    if (grdProduct.PageCount <= 1)
                    {
                        grdProduct.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
                #region[Sort Ord desc]
                case "descOrd":
                    if (Common.StringClass.Check(ddlFilterGroupNews.SelectedValue))
                    {
                        strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
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
                    grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Ord desc");
                    grdProduct.DataBind();
                    for (int i = 0; i < grdProduct.Items.Count; i++)
                    {
                        item = grdProduct.Items[i];
                        TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                        TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                        NumberClass.OnlyInputNumber(stxtOrd);
                        NumberClass.OnlyInputNumber(stxtGia);
                    }
                    if (grdProduct.PageCount <= 1)
                    {
                        grdProduct.PagerStyle.Visible = false;
                    }
                    break;
                #endregion
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
             ControlClass.ResetControlValues(pnUpdate);
            txtDate.Text = DateTimeClass.ConvertDateTime(DateTime.Now, "dd/MM/yyyy hh:mm:ss tt");
            Bin_Brands();
            pnView.Visible = false;
            ViewCategory();
            Bin_Brands();
            Bin_Size();
            Bin_Color();
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdProduct.Items.Count; i++)
            {
                item = grdProduct.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ProductService.Product_Delete(strId);
                    }
                }
            }
            grdProduct.CurrentPageIndex = 0;
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
                string catTag = "";
                string sPrice = NumberClass.ConvertNumber(txtPrice.Text, "en-US");
                string sPrice2 = NumberClass.ConvertNumber(txtPricecu.Text, "en-US");
                List<Category> list = CategoryService.Category_GetById(drlCatIdAdd.SelectedValue);
                catTag = list[0].Tag;
                list.Clear();
                list = null;
                Data.Product obj = new Data.Product();
                obj.Id = txtId.Value;
                obj.Tag = Common.StringClass.NameToTag(txtName.Text);
                obj.Name = txtName.Text;
                obj.Content = fckContent.Value;
                obj.Detail = fckDetail.Value;
                obj.Priority = chkPriority.Checked ? "1" : "0";
                obj.Index = chkIndex.Checked ? "1" : "0";
                obj.Price = sPrice.Replace(".", "");
                obj.Image = txtImage.Text;
                obj.Date = DateTimeClass.ConvertDateTime(txtDate.Text, "MM/dd/yyyy HH:mm:ss");
                obj.CatId = drlCatIdAdd.SelectedValue;
                obj.CatTag = catTag;
                obj.Title = txtTitle.Text;
                obj.Description = txtDescription.Text;
                obj.Keyword = txtKeyword.Text;
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Lang = Lang;
                obj.PiceOld = sPrice2.Replace(".", "");
                obj.Image1 = txtImage1.Text;
                obj.Image2 = txtImage2.Text;
                obj.Image3 = txtImage3.Text;
                obj.Image4 = txtImage4.Text;
                obj.Image5 = txtImage5.Text;
                obj.BrandId = this.chkbrands.SelectedValue.ToString();
                obj.Codepro = this.txtCode.Text.Trim();
                if (Insert == true)
                {
                    if (ProductService.Product_Insert(obj))
                    {
                        List<Product> listsp = ProductService.Product_GetByTop("1", "", "Id desc");
                        Data.ProSize objsize = new Data.ProSize();
                        for (int i = 0; i < this.chklistSizes.Items.Count; i++)
                        {
                            if (this.chklistSizes.Items[i].Selected == true)
                            {
                                objsize.ProId = listsp[0].Id;
                                objsize.SizeId = this.chklistSizes.Items[i].Value.ToString();
                                ProSizeService.ProSize_Insert(objsize);
                            }
                        }
                        Data.ProColor objprocolor = new Data.ProColor();
                        for (int i = 0; i < this.chklistColors.Items.Count; i++)
                        {
                            if (this.chklistColors.Items[i].Selected == true)
                            {
                                objprocolor.ProId = listsp[0].Id;
                                objprocolor.ColorId = this.chklistColors.Items[i].Value.ToString();
                                ProColorService.ProColor_Insert(objprocolor);
                            }
                        }
                    }
                }
                else
                {
                    if (ProductService.Product_Update(obj))
                    {
                        ProSizeService.ProSize_Delete(obj.Id);
                        ProColorService.ProColor_Delete(obj.Id);
                        Data.ProSize objsize = new Data.ProSize();
                        for (int i = 0; i < this.chklistSizes.Items.Count; i++)
                        {
                            if (this.chklistSizes.Items[i].Selected == true)
                            {
                                objsize.ProId = obj.Id;
                                objsize.SizeId = this.chklistSizes.Items[i].Value.ToString();
                                ProSizeService.ProSize_Insert(objsize);
                            }
                        }
                        Data.ProColor objprocolor = new Data.ProColor();
                        for (int i = 0; i < this.chklistColors.Items.Count; i++)
                        {
                            if (this.chklistColors.Items[i].Selected == true)
                            {
                                objprocolor.ProId = obj.Id;
                                objprocolor.ColorId = this.chklistColors.Items[i].Value.ToString();
                                ProColorService.ProColor_Insert(objprocolor);
                            }
                        }
                    }
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
                strWhere += " and CatId = '" + ddlFilterGroupNews.SelectedValue + "' ";
            }
            if (Common.StringClass.Check(txtFilterName.Text))
            {
                strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
            }
            if (Common.StringClass.Check(txtFilterCode.Text))
            {
                strWhere += " and Codepro like N'%" + txtFilterCode.Text + "%' ";
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
            grdProduct.CurrentPageIndex = 0;
            grdProduct.DataSource = ProductService.Product_GetByTop("", strWhere, "Date desc, Id desc");
            grdProduct.DataBind();
            if (grdProduct.PageCount <= 1)
            {
                grdProduct.PagerStyle.Visible = false;
            }
        }

        protected void UnFilter_Click(object sender, EventArgs e)
        {
             ControlClass.ResetControlValues(pnUpdate);
            LoadFilterGroupNewsDropDownList();
            LoadFilterNewsNameAutocomplete();
            LoadFilterNewsCodeAutocomplete();
            Common.PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
            BindGrid();
        }

        protected void lbtUpdateprice_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdProduct.Items.Count; i++)
            {
                item = grdProduct.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                    TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                    NumberClass.OnlyInputNumber(stxtOrd);
                    NumberClass.OnlyInputNumber(stxtGia);
                    if (stxtOrd.Text != "" && stxtOrd.Text != "0")
                    {
                        string strId = item.Cells[1].Text;
                        ProductService.Product_Update_Ord(stxtOrd.Text, stxtGia.Text, strId);
                    }
                }
            }
            BindGrid();
        }

        protected void lbtUpdatepricebottom_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdProduct.Items.Count; i++)
            {
                item = grdProduct.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    TextBox stxtOrd = ((TextBox)item.FindControl("txtOrd"));
                    TextBox stxtGia = ((TextBox)item.FindControl("txtGia"));
                    NumberClass.OnlyInputNumber(stxtOrd);
                    NumberClass.OnlyInputNumber(stxtGia);
                    if (stxtOrd.Text != "" && stxtOrd.Text != "0")
                    {
                        string strId = item.Cells[1].Text;
                        ProductService.Product_Update_Ord(stxtOrd.Text, stxtGia.Text, strId);
                    }
                }
            }
            BindGrid();
        }

    }
}