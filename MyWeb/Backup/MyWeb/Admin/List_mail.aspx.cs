using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MyWeb.Admin
{
    public partial class List_mail : System.Web.UI.Page
    {
        static string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Session["Lang"].ToString();
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("List_mail.xml"));
            dt = ds.Tables[0];
            grdtbCUSTOMERS.DataSource = dt;
            grdtbCUSTOMERS.DataBind();
            if (grdtbCUSTOMERS.PageCount <= 1)
            {
                grdtbCUSTOMERS.PagerStyle.Visible = false;
            }
        }
        protected void grdtbCUSTOMERS_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdtbCUSTOMERS.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
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
                        string strId = item.Cells[1].Text;
                        //tbCUSTOMERSService.tbCUSTOMERS_Delete(strId);
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

    }
}