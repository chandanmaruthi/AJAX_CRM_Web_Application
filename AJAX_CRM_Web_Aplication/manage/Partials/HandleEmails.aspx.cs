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
public partial class Partials_HandleEmails :CustomerSupportPage
{
    //string strNotes = "";

    bool bolResult = false;
    string strStatusID = "";
    public string strLeadID = "";
    string strAction = "A";
    string strNoteID = "";
    public string strFromEmail = "", strToEmail = "", strEmailBody="";
            
    //bool bolResult = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strFromEmail = GetState(CustomerSupportPage.Email_ID);
            DataSet objLeadNotes;
            Conversation objConversation = new Conversation();

            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
            }
            if (Request["LeadEmailID"] != null)
            {
                strToEmail = Request["LeadEmailID"].ToString();
            }
            
       
            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();
            }
            if (Request["FromEmail"] != null)
            {
                strFromEmail = Request["FromEmail"].ToString();
            }
            if (Request["ToEmail"] != null)
            {
                strToEmail = Request["ToEmail"].ToString();
            }
            if (Request["EmailBody"] != null)
            {
                strEmailBody = Request["EmailBody"].ToString();
            }

            if (strAction == "S")
            {
                if (strEmailBody.Length > 0)
                {
                    email objEmail = new email();
                    bolResult = objEmail.Sendmail(strFromEmail,strToEmail,"",strEmailBody); 
                    //bolResult = objLead.AddLeadNotes(strLeadID, strNotes,GetState(CustomerSupportPage.UserID),DateTime.Now);
                }
                if (strStatusID != "")
                {
                    bolResult = objConversation.UpdateConversationStatus(strLeadID, strStatusID, GetState(CustomerSupportPage.UserID), DateTime.Now);
                }
            }
            else if (strAction == "D")
            {
                bolResult = objConversation.DeleteNotes(strNoteID);
            }

            if (strLeadID != "")
            {
                objLeadNotes = objConversation.GetNotes(strLeadID);
                rptrChild.DataSource = objLeadNotes.Tables[0];
                rptrChild.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

}
