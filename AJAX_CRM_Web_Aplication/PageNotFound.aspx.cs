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
using CustomerSupport.Data;
public partial class PageNotFound : CustomerSupportPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Request.Url.Host.Remove(Request.Url.Host.Length - 15).ToLower());
    }

    protected void lnlSearchPortal_Click(object sender, EventArgs e)
    {

        string strSearchString = "";

        strSearchString = Request["st"];

        Account objAccount = new Account();
        DataSet objAccountData;
        objAccountData = objAccount.GetAccountDetailsBySearch(txtSearchString.Value);
        rptrPortalLinks.DataSource = objAccountData.Tables[0];
        rptrPortalLinks.DataBind();
    }
}
