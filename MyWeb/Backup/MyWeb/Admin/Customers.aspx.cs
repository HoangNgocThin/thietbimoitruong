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
    public partial class Customers : System.Web.UI.Page
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
            grdtbCUSTOMERS.DataSource = tbCUSTOMERSService.tbCUSTOMERS_GetByAll();
            grdtbCUSTOMERS.DataBind();
            if (grdtbCUSTOMERS.PageCount <= 1)
            {
                grdtbCUSTOMERS.PagerStyle.Visible = false;
            }
            else
            {
                grdtbCUSTOMERS.PagerStyle.Visible = true;
            }
        }

        protected void grdtbCUSTOMERS_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdtbCUSTOMERS.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdtbCUSTOMERS_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdtbCUSTOMERS.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdtbCUSTOMERS_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.tbCUSTOMERS> listE = tbCUSTOMERSService.tbCUSTOMERS_GetById(Id);
                    txtvpassword.Text = listE[0].vpassword;
                    txtvcusname.Text = listE[0].vcusname;
                    txtdbirthday.Text = listE[0].dbirthday;
                    txtvprovince.Text = listE[0].vprovince;
                    txtvaddress.Text = listE[0].vaddress;
                    txtvmobile.Text = listE[0].vmobile;
                    txtvemail.Text = listE[0].vemail;
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Delete":
                    try
                    {
                        tbCUSTOMERSService.tbCUSTOMERS_Delete(strCA);
                    }
                    catch
                    {
                        Common.WebMsgBox.Show("Khách hàng đã từng mua hàng không thể xóa");
                        return;
                    }
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
            for (int i = 0; i < grdtbCUSTOMERS.Items.Count; i++)
            {
                item = grdtbCUSTOMERS.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        try
                        {
                            string strId = item.Cells[1].Text;
                            tbCUSTOMERSService.tbCUSTOMERS_Delete(strId);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            grdtbCUSTOMERS.CurrentPageIndex = 0;
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
                Data.tbCUSTOMERS obj = new Data.tbCUSTOMERS();
                obj.iusid = Id;
                obj.vusername = "KH" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Millisecond.ToString();       
                obj.vpassword = txtvpassword.Text;
                obj.vcusname = txtvcusname.Text;
                obj.dbirthday = txtdbirthday.Text;
                obj.vprovince = txtvprovince.Text;
                obj.vaddress = txtvaddress.Text;
                obj.vphone = txtvmobile.Text;
                obj.vmobile = txtvmobile.Text;
                obj.vemail = txtvemail.Text;
                obj.dcreatedate = DateTime.Now.ToShortDateString();
                obj.istatus = "0";
                if (Insert == true)
                {
                    tbCUSTOMERSService.tbCUSTOMERS_Insert(obj);
                }
                else
                {
                    tbCUSTOMERSService.tbCUSTOMERS_Update(obj);
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