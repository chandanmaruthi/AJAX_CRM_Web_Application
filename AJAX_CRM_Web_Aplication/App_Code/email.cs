
using System.Configuration;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System;
using CustomerSupport;
/// <summary>
/// Summary description for email
/// </summary>
public class email : CustomerSupportPage
{
	public email()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Sendmail(string MailFrom,
                        string MailTo,
                        string MailSubject,
                        string MailBody
                       )
    {
        //---------------------------------------------------------------------------------
        //Function Name:Sendmail
        //Description:Send Email
        //Created On: 08-Jan-2007
        //Created By: Vipul Limbachiya
        //Usage Inuctions:
        //Edit History:
        //Change No.    Date    Version     ChangeBy    
        //---------------------------------------------------------------------------------
        try
        {
            System.Configuration.AppSettingsReader objAppSettingsReader = new AppSettingsReader();
            string SMTPServer = objAppSettingsReader.GetValue("SMTPServer", typeof(string)).ToString();

            MailAddress to = new MailAddress(MailTo);
            MailAddress from = new MailAddress(MailFrom);
            MailMessage message = new MailMessage(from, to);
            message.Subject = MailSubject;
            message.Body = MailBody;

            System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString
            (System.Text.RegularExpressions.Regex.Replace(MailBody, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(MailBody, null, "text/html");

            message.AlternateViews.Add(plainView);
            message.AlternateViews.Add(htmlView);

            SmtpClient smtpClient = new SmtpClient(SMTPServer);
            smtpClient.Send(message);
            //AddToMailQueue(From, From, To, To, Subject, MailBody, DateTime.Now.ToString(), DateTime.Now.ToString());
            return true;
        }
        catch
        {
            throw ;
        }
    }
    public void SendConversationAlert(string strConversationTitle, string strConversationDesc, DateTime dtmDateTime, string strUserName, string strProductName, string strTo)
    {
        try
        {
            email objEmail = new email();
            bool bolResult;
            string strEmailBody = "";

            //Send Welcome Email
            strEmailBody = System.IO.File.ReadAllText(Server.MapPath("~/" + CustomerSupport.Utility.SysResource.EmailTemplate_Path + CustomerSupport.Utility.SysResource.TF_ConversationAlert));
            strEmailBody = strEmailBody.Replace("[Title]", strConversationTitle);
            strEmailBody = strEmailBody.Replace("[Desc]", strConversationDesc);
            strEmailBody = strEmailBody.Replace("[UserName]", strUserName);
            strEmailBody = strEmailBody.Replace("[Time]", dtmDateTime.ToString());
            strEmailBody = strEmailBody.Replace("[Product]", strProductName);

            bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, strTo, "Welcome To CustomerSupport", strEmailBody);
            //bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, CustomerSupport.Utility.SysResource.FromID, "Conversation Alert" + "test" + " Has joined CustomerSupport", "test" + " Has joined CustomerSupport");



        }
        catch
        {
            throw;
        }
    }
    public void SendConversationAlertAck(string strConversationTitle, string strConversationDesc, DateTime dtmDateTime, string strUserName, string strProductName, string strTo)
    {
        try
        {
            email objEmail = new email();
            bool bolResult;
            string strEmailBody = "";

            //Send Welcome Email
            strEmailBody = System.IO.File.ReadAllText(Server.MapPath("~/" + CustomerSupport.Utility.SysResource.EmailTemplate_Path + CustomerSupport.Utility.SysResource.TF_ConversationAlert));
            strEmailBody = strEmailBody.Replace("[Title]", strConversationTitle);
            strEmailBody = strEmailBody.Replace("[Desc]", strConversationDesc);
            strEmailBody = strEmailBody.Replace("[UserName]", strUserName);
            strEmailBody = strEmailBody.Replace("[Time]", dtmDateTime.ToString());
            strEmailBody = strEmailBody.Replace("[Product]", strProductName);

            bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, strTo, "Welcome To CustomerSupport", strEmailBody);
            //bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, CustomerSupport.Utility.SysResource.FromID, "New User Sign Up " + "test" + " Has joined CustomerSupport", "test" + " Has joined CustomerSupport");



        }
        catch
        {
            throw;
        }
    }
    public void SendWelcomeEmail(string strEmail, string strName)
    {
        try
        {
            email objEmail = new email();
            bool bolResult;
            string strEmailBody = "";

            //Send Welcome Email
            strEmailBody = System.IO.File.ReadAllText(Server.MapPath("~/" + CustomerSupport.Utility.SysResource.EmailTemplate_Path + CustomerSupport.Utility.SysResource.TF_Welcome));
            strEmailBody = strEmailBody.Replace("[Time]", DateTime.Now.ToString());
            strEmailBody = strEmailBody.Replace("[UserName]", strName);

            bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, strEmail, "Welcome To CustomerSupport", strEmailBody);
            bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, CustomerSupport.Utility.SysResource.FromID, "New User Sign Up " + strName + " Has joined CustomerSupport", strName + " Has joined CustomerSupport");
        }
        catch
        {
            throw;
        }
    }
    public void SendNewUserWelcomeEmail(string strEmail, string strName,string strValidationCode,string strCustomMessage)
    {
        try
        {
            email objEmail = new email();
            bool bolResult;
            string strEmailBody = "", strRecoveryLink="";

            //Send Welcome Email
            strEmailBody = System.IO.File.ReadAllText(Server.MapPath("~/" + CustomerSupport.Utility.SysResource.EmailTemplate_Path + CustomerSupport.Utility.SysResource.TF_WelcomeNewUser));
            strEmailBody = strEmailBody.Replace("[Time]", DateTime.Now.ToString());
            strEmailBody = strEmailBody.Replace("[UserName]", strName);
            strEmailBody = strEmailBody.Replace("[CustomMessage]", strCustomMessage);
            strRecoveryLink = "<a href='" + CustomerSupport.Utility.SysResource.HomePath + "home/forgotpassword.aspx?Action=Recover&V=" + strValidationCode + "'>Click Here</a>";
            strEmailBody = strEmailBody.Replace("[Recovery_Link]", strRecoveryLink);


            bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, strEmail, "Welcome To CustomerSupport", strEmailBody);
            bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, CustomerSupport.Utility.SysResource.FromID, "New User Sign Up " + strName + " Has joined CustomerSupport", strName + " Has joined CustomerSupport");
        }
        catch
        {
            throw;
        }
    }
    public void SendRecoveryEmail(string ValidationCode, string strEmail)
    {
        email objEmail = new email();
        bool bolResult;
        string strRecoveryLink = "", strEmailBody = "";
        try
        {
            //Send Welcome Email

            strRecoveryLink = "<a href='" + CustomerSupport.Utility.SysResource.HomePath + "home/forgotpassword.aspx?Action=Recover&V=" + ValidationCode + "'>Click Here</a>";
            strEmailBody = System.IO.File.ReadAllText(Server.MapPath("~/" + CustomerSupport.Utility.SysResource.EmailTemplate_Path + CustomerSupport.Utility.SysResource.TF_ForgotPassord));
            strEmailBody = strEmailBody.Replace("[Recovery_Link]", strRecoveryLink);
            bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, strEmail, "Recover Password", strEmailBody);

        }
        catch
        {
        }
    }
}
