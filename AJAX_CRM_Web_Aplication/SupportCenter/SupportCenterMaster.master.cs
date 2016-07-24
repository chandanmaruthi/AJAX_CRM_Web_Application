using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerSupport;

public partial class SupportCenter_SupportCenterMaster : System.Web.UI.MasterPage
{
    public string strBackgroundColor = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerSupportPage objPage = new CustomerSupportPage();
        strBackgroundColor = objPage.GetState(CustomerSupportPage.Background_Color);
        lnkCss.Href=CustomerSupport.Utility.SysResource.HomePath + "common/css/Portal.css";

    }
}
