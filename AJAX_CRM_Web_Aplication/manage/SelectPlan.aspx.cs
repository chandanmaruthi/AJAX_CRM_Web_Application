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
public partial class BuyLeads : CustomerSupportPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try{
        bool isPurchaseRedirect = false;
        string strPurchasedCredits = "";
        string strAccountID = "";
        string strBalanceCredits = "";
        if (Request["PurchaseRedir"] != null)
        {
            isPurchaseRedirect = true;
        }
        if (Request["Credits"] != null)
        {
            strPurchasedCredits = Request["Credits"].ToString();
        }

        Account objAccount = new Account();
        //DataSet objData;
        strAccountID = GetState(CustomerSupportPage.AccountID);
        //objData = objAccount.GetAccountDetails(strAccountID);

        //if (objData.Tables[0].Rows.Count > 0)
        //{

          //  strBalanceCredits = objData.Tables[0].Rows[0]["Balance_Credits"].ToString();
        //}

        if (isPurchaseRedirect == true)
        {
            dvSuccess.Visible = true;
            lblCreditPurchaseValue.Text = strPurchasedCredits;
            lblCreditBalance.Text = strBalanceCredits;
        }
    }
    catch
    {
        throw;
    }
    }
}
