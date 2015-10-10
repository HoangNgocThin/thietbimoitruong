using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Controls
{
    public partial class uc_phanloaisanpham : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadControl();
                if (Session["CapacityID"] != null)
                {
                    rdCapacity.SelectedValue = Session["CapacityID"].ToString();
                }
                if (Session["BranchID"] != null)
                {
                    rdBranch.SelectedValue = Session["BranchID"].ToString();
                }
            }
        }

        private void LoadControl()
        {
            List<Branch> listbranch = new List<Branch>();
            listbranch = BranchService.Branch_GetByAll();
            if (listbranch.Count > 0)
            {
                ListItem obj = null;
                obj = new ListItem("Tất cả", "0");
                obj.Selected = true;
                rdBranch.Items.Add(obj);
                for (int i = 0; i < listbranch.Count; i++)
                {
                    obj = new ListItem(listbranch[i].Name, listbranch[i].Id);
                    rdBranch.Items.Add(obj);
                }
            }
            List<Capacity> listCapacity = new List<Capacity>();
            listCapacity = CapacityService.Capacity_GetByAll();
            if (listCapacity.Count > 0)
            {
                ListItem obj = null;
                obj = new ListItem("Tất cả", "0");
                obj.Selected = true;
                rdCapacity.Items.Add(obj);
                for (int i = 0; i < listCapacity.Count; i++)
                {
                    obj = new ListItem(listCapacity[i].Name, listCapacity[i].Id);
                    rdCapacity.Items.Add(obj);
                }
            }
        }

        protected void rdBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["BranchID"] = rdBranch.SelectedValue;
            Response.Redirect("/ProductList.html");
        }

        protected void rdCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CapacityID"] = rdCapacity.SelectedValue;
            Response.Redirect("/ProductList.html");
        }
    }
}