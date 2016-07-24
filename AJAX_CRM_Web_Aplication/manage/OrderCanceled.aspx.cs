using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CustomerSupport;
public partial class OrderCanceled : CustomerSupportPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "ManageAccount.aspx");
        }
        catch
        {
            throw;
        }
    }
}
