using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CustomerSupport.Data;
public partial class _Default : CustomerSupport.CustomerSupportPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsPostBack != true)
            {
                if (GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString().Length > 0)
                {
                    BindValues(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString(), GetState(CustomerSupport.CustomerSupportPage.UserID).ToString());
                }
            }
        }
        catch
        {
            throw;
        }
    }
    private void BindValues(string strAccountID, string strUserID)
    {
        try
        {
            AccountUser ObjUser = new AccountUser();
            DataSet objData;
            objData = ObjUser.GetUserDetails(strUserID);
            if (objData.Tables[0].Rows.Count > 0)
            {
                txtName.Text = objData.Tables[0].Rows[0]["User_F_Name"].ToString();
                txtEmailID.Text = objData.Tables[0].Rows[0]["Email_ID"].ToString();
                txtPhone.Text = objData.Tables[0].Rows[0]["Phone_1"].ToString();
                txtContactEmail.Text = objData.Tables[0].Rows[0]["Phone_2"].ToString();
                //txtSalesForceOrgId.Text = objData.Tables[0].Rows[0]["SALESFORCE_ORG_ID"].ToString();
                //lblBalanceCredits.Text = objData.Tables[0].Rows[0]["Balance_Credits"].ToString();
                //switch (objData.Tables[0].Rows[0]["Subscription_Plan"].ToString())
                //{
                //    case "1000": lblPlan.InnerText = "Free Plan, upgrade now"; txtSalesForceOrgId.Enabled = false; break;
                //    case "1001": lblPlan.InnerText = "Basic Plan"; txtSalesForceOrgId.Enabled = false; break;
                //    case "1002": lblPlan.InnerText = "Standard Plan"; txtSalesForceOrgId.Enabled = true; break;
                //    case "1003": lblPlan.InnerText = "Power Plan"; txtSalesForceOrgId.Enabled = true; break;
                //    default: lblPlan.InnerText = "Free Plan"; break;

                //}
            }
        }
        catch
        {
            throw;
        }
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
            Account ObjAccount = new Account();
            //string AccountID = "";
            bool bolResult;
            bolResult = ObjAccount.UpdateAccount(
                    GetState(CustomerSupport.CustomerSupportPage.AccountID),
                    txtName.Text,
                    txtEmailID.Text,
                    txtPhone.Text,
                    txtContactEmail.Text,
                    txtSalesForceOrgId.Text);
            if (bolResult == true)
            {
                divMessage.Visible = true;
                lblMessage.Text = "Account Updated";
                BindValues(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString(), GetState(CustomerSupport.CustomerSupportPage.UserID).ToString());

            }
            else
            {
                divMessage.Visible = true;
                lblMessage.Text = "Account Not Updated";

            }
        }
        catch
        {
            throw;
        }
    }
}
