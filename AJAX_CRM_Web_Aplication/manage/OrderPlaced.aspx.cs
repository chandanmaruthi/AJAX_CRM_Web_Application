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
public partial class OrderPlaced : CustomerSupportPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strPurchaseType = "";
            //string strPlanOrdered = "";
            if (Request["purchase_currency"] != null)
            {
                strPurchaseType = Request["purchase_currency"].ToString();
            }
            //switch (strPurchaseType)
            //{
            //    case "1001": strPlanOrdered = 1001; break;
            //    case "1002": strPlanOrdered = 1002; break;
            //    case "1003": strPlanOrdered = 1003; break;
            //    default: strPlanOrdered = 1000; break;

            //}
            bolUpdatePlan(strPurchaseType);
        }
        catch
        {
            throw;
        }
    }
    protected void bolUpdatePlan(string strPlan)
    {
        try
        {
            bool bolResult = false;
            Account objAccount = new Account();
            string strAccountID = "";
            strAccountID = GetState(CustomerSupportPage.AccountID);
            bolResult = objAccount.UpdateAccountPlan(strAccountID, strPlan);
            if (bolResult == true)
            {
                Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "ManageAccount.aspx?");
            }
        }
        catch
        {
            throw;
        }

    }
}
