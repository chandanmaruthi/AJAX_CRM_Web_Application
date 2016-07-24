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
using CustomerSupport.Utility;
using CustomerSupport.Data;
public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Action"] != null)
        {
            ChangePassword.Visible = true;
            RecoverPassword.Visible = false;
        }
        else
        {
            ChangePassword.Visible = false;
            RecoverPassword.Visible = true;
        }
        if (Request["v"] != null)
        {

            lblValidationCode.Text = Request["v"].ToString();
        }

    }
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        Account objAccount = new Account();
        bool bolResult = false;
        string strValidationCode = "";

        bolResult = objAccount.SetPasswordRecovery(txtEmail.Text,ref strValidationCode);

        if (bolResult == true)
        {
            email objEmail = new email();

            objEmail.SendRecoveryEmail(strValidationCode, txtEmail.Text);
            ShowMessage("We have sent you an email to recover password.", true,"MessageBox");
        }
        else 
        {
            ShowMessage("Invalid Email Id, are you sure you have entered the right one?", true, "MessageBox_Warning");
        }
    }
    protected void ShowMessage(string strMessage, bool bolShow,string strClass)
    {
        divMessage.Visible = bolShow;
        lblMessage.Text = strMessage;
        lblMessage.CssClass = strClass;

    }
    protected void ShowMessageCP(string strMessage, bool bolShow, string strClass)
    {
        divCPMessage.Visible = bolShow;
        lblCPMessage.Text = strMessage;
        lblCPMessage.CssClass = strClass;

    }
   
    protected void lnkChangePassword_Click(object sender, EventArgs e)
    {
        divMessage.Visible = false;
        if (Page.IsValid == false)
        {
            return;
        }
        Account objAccount = new Account();
        string strResult = "";
        string strValidationCode = "";

        strValidationCode = Request["v"].ToString();
        strResult = objAccount.RecoverChangePassword(strValidationCode, CustomerSupport.Utility.Security.CalculateMD5Hash(txtPassword.Text));

        if (strResult == "100")
        {

            //SendRecoveryEmail(strValidationCode, txtEmail.Text);
            ShowMessageCP("Your Password has been successfully changed. Please Login", true, "MessageBox");
        }
        else if (strResult == "101")
        {
            ShowMessageCP("Invalid Vaidation Code, Try again with a new recovery code ", true, "MessageBox_Warning");
        }
        else if (strResult == "102")
        {
            ShowMessageCP("This Validation Code has Expired , please get a new code", true, "MessageBox_Warning");
        }
    }
    protected void CheckPasswords(object source, ServerValidateEventArgs args)
    {
        if (txtPassword.Text != txtVerifyPassword.Text)
        {
            args.IsValid = false;
        }
    }
}
