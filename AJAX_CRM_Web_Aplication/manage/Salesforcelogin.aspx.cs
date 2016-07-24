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
public partial class Salesforcelogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bool bolLoginUserResult = false;
            bolLoginUserResult = bolLoginUser();
            if (bolLoginUserResult != true)
            {
                dvNotRegistered.Visible = true;
            }
            else
            {
                Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "manageleads.aspx");
            }
        }
        catch
        {
            throw;
        }
    }

    private bool bolLoginUser()
    {
        try
        {
            string strSFOrgID = "";

            Account objAccount = new Account();
            string strAccountID = "";
            bool bolIsAuthentic = false;
            if (Request["q"] != null)
            {
                strSFOrgID = Request["q"];
                lblOrdId.Text = strSFOrgID;
            }
            bolIsAuthentic = objAccount.IsAuthenticSFUser(strSFOrgID, ref strAccountID);
            if (bolIsAuthentic == true)
            {
                LoginValidUser(strAccountID, true);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            throw;
        }
    }
    public void LoginValidUser(string Account_ID, bool bolPersistLogin)
    {
        try
        {
            Account objAccount = new Account();
            CustomerSupport.CustomerSupportPage objCustomerSupportPage = new CustomerSupport.CustomerSupportPage();

            DataSet objAccountData;
            objAccountData = objAccount.GetAccountDetails(Account_ID);
            if (objAccountData.Tables[0].Rows.Count > 0)
            {
                FormsAuthentication.RedirectFromLoginPage(objAccountData.Tables[0].Rows[0]["Account_ID"].ToString(), bolPersistLogin);
                //FormsAuthentication.SetAuthCookie(objAccountData.Tables[0].Rows[0]["First_Name"].ToString(), false);
                objCustomerSupportPage.SetState(CustomerSupport.CustomerSupportPage.AccountID, Account_ID);
                objCustomerSupportPage.SetState(CustomerSupport.CustomerSupportPage.UserName, objAccountData.Tables[0].Rows[0]["First_Name"].ToString());
                objCustomerSupportPage.SetState(CustomerSupport.CustomerSupportPage.IsLoggedIn, "1");
                objCustomerSupportPage.SetState(CustomerSupport.CustomerSupportPage.Email_ID, objAccountData.Tables[0].Rows[0]["Email_ID"].ToString());

            }
        }
        catch
        {
            throw;
        }
    }
}

