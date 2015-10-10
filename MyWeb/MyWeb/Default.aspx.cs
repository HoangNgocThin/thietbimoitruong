using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;

namespace MyWeb
{
    public partial class Default : BaseClass.BaseDefault
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Data.Config> list = new List<Data.Config>();
            list = ConfigService.Config_GetByTop("1", "IsApply=1", "");
            if (list.Count > 0)
            {
                AddMetaKeyWordTitleDescription(list[0].PageTitle, list[0].MetaKeyword, list[0].Description);
            }
            else
            {
                AddMetaKeyWordTitleDescription("Tinh dầu", "", "");
            }
        }
    }
}