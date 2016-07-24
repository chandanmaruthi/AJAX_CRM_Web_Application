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
    public int intUserCount=0;
    protected void Page_Load(object sender, EventArgs e)
    {

        txtAccountName.Attributes.Add("onChange", "javascript:stringval =AjaxCheckAccountName_Params();ajaxpack.postAjaxRequest('"+ CustomerSupport.Utility.SysResource.HomePath + "/home/partials/HandleCreateAccount.aspx', stringval, AjaxCheckAccountName, 'txt');return false;");
        txtEmailID.Attributes.Add("onChange", "javascript:stringval =AjaxCheckEmail_Params();ajaxpack.postAjaxRequest('" + CustomerSupport.Utility.SysResource.HomePath + "/home/partials/HandleCreateAccount.aspx', stringval, AjaxCheckEmail, 'txt');return false;");

        if (Request["Plan"] != null)
        {
            intUserCount = int.Parse(Request["Plan"].ToString());
        }
        else 
        {
            intUserCount = 1;
        }

        //Account objAccount=new Account();
        //DataSet objTimeZoneData;
        //objTimeZoneData = objAccount.GetAllTimeZones();
        //ddlTimeZone.DataSource = objTimeZoneData.Tables[0];
        //ddlTimeZone.DataTextField = "Time_Zone_Value";
        //ddlTimeZone.DataValueField = "Time_Zone_ID";
        //ddlTimeZone.DataBind();
        //ddlTimeZone.Items.FindByValue("9D850ED6-88BF-403C-972B-51A977E866F9").Selected=true;
    }


    protected void lnkSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid == false)
            {
                //divMessage.Visible = true;
                //lblMessage.Text = strMessage;

                return;
            }

            Account ObjAccount = new Account();

            string strAccountID = "";
            string strUserID = "";
            email objEmail = new email();
            if (ObjAccount.bolEmailExists(txtEmailID.Text) == true)
            {
                ShowMessage("Email ID is already Registered", true, "MessageBox_Warning");
                return;
            }

            if (ObjAccount.bolAccountNameExists(txtAccountName.Text) == true)
            {
                ShowMessage("Account Name is already Registered", true, "MessageBox_Warning");
                return;
            }

            strAccountID = ObjAccount.AddAccount(txtName.Text, txtEmailID.Text.ToLower(), txtPassword.Text, "", txtEmailID.Text.ToLower(), ref strUserID, txtAccountName.Text, "", intUserCount);
                if (AccountID.Length > 0)
                {
                    ObjAccount.LoginValidUser(strAccountID, strUserID, false);
                    objEmail.SendWelcomeEmail(txtEmailID.Text, txtName.Text);
                    SetState(CustomerSupport.CustomerSupportPage.AccountID, strAccountID);
                    InitializeAccount();
                    
                    Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "manage/HowTo.aspx");
                    
                }
            
        }
        catch(Exception ex)
        {
            throw ex;
        }


    }
   

    protected void ShowMessage(string strMessage, bool bolShow, string strClass)
    {
        try
        {divMessage.Visible = bolShow;
        lblMessage.Text = strMessage;
        lblMessage.CssClass = strClass;
 }
        catch
        {
            throw;
        }
    }
    
    protected void ValidateEmailIDs_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            if (isEmail(args.Value) == true)
            {

                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        catch
        {
            throw;
        }

    }
    protected void CheckPasswords(object source, ServerValidateEventArgs args)
    {
        try
        {
            if (txtPassword.Text != txtRetypePassword.Text)
            {
                args.IsValid = false;
            }
        }
        catch
        {
            throw;
        }
    }

}
