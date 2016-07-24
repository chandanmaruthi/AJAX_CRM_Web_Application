using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CustomerSupport;
using CustomerSupport.Data;
public partial class _Default : CustomerSupportPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GetState(CustomerSupport.CustomerSupportPage.IsLoggedIn) == "1")
        {
            Response.Redirect(CustomerSupport.Utility.SysResource.HomePath+"manage/welcome.aspx");
        }
      
    }
    protected void lnkSignUser_Click(object sender, EventArgs e)
    {
        try
        {
            Account objAccount = new Account();
            bool isValidUser = false;
            string strAccountID = "", strUserID = "";
            isValidUser = objAccount.IsAuthenticUser(txtUserName.Value, txtPassword.Value, ref strAccountID, ref strUserID);

            if (isValidUser == true)
            {


                LoginValidUser(strAccountID, strUserID, false);

                if (Request["ReturnUrl"] != null)
                {
                    if (Request["ReturnUrl"].ToString().Length > 0)
                    {
                        Response.Redirect(Request["ReturnUrl"]);
                    }
                }
                else
                {
                    Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "manage/welcome.aspx");
                }

            }
            else
            {
                ValidationMessage.Text = "Invalid email id or password";
                ValidationMessage.CssClass = "MessageBox_Warning";
                LoginValidationMsg.Visible = true;
            }
        }
        catch
        {
            throw;
        }
    }
    public void LoginValidUser(string Account_ID, string User_ID, bool bolPersistLogin)
    {
        try
        {
            AccountUser objUser = new AccountUser();
            //CustomerSupport.CustomerSupportPage objCustomerSupportPage = new CustomerSupport.CustomerSupportPage();

            DataSet objUserData;
            objUserData = objUser.GetUserDetails(User_ID);
            if (objUserData.Tables[0].Rows.Count > 0)
            {
                FormsAuthentication.RedirectFromLoginPage(objUserData.Tables[0].Rows[0]["Account_ID"].ToString(), true);
                //FormsAuthentication.SetAuthCookie(objAccountData.Tables[0].Rows[0]["First_Name"].ToString(), false);
                SetState(CustomerSupportPage.AccountID, Account_ID);
                SetState(CustomerSupportPage.UserID, User_ID);
                SetState(CustomerSupportPage.UserName, objUserData.Tables[0].Rows[0]["User_F_Name"].ToString());
                SetState(CustomerSupportPage.IsLoggedIn, "1");
                SetState(CustomerSupportPage.Email_ID, objUserData.Tables[0].Rows[0]["Email_ID"].ToString());

                //Account Details
                SetState(CustomerSupportPage.SubscriptiomPlanType, objUserData.Tables[1].Rows[0]["Subscription_Plan"].ToString());
                


                InitializeAccount();
            }
        }
        catch
        {
            throw;
        }
    }

    
}
