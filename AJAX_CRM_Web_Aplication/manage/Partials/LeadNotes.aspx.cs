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
public partial class Partials_LeadNotes :CustomerSupportPage
{
    string strNotes = "";

    bool bolResult = false;
    string strStatusID = "";
    public string strConversationID = "";
    string strAction = "A";
    string strNoteID = "";
    //string strErrorString = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet objLeadNotes;
            Conversation objConversation = new Conversation();

            if (Request["ID"] != null)
            {
                strConversationID = Request["ID"].ToString();
            }
            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();
            }
            if (Request["Notes"] != null)
            {
                strNotes = Request["Notes"].ToString();
            }
            if (Request["NoteID"] != null)
            {
                strNoteID = Request["NoteID"].ToString();
            }
            if (Request["LeadStatus"] != null)
            {
                strStatusID = Request["LeadStatus"].ToString();
            }

            if (strAction == "A")
            {
                if (strNotes.Length > 0)
                {
                    bolResult = objConversation.AddConversationNotes(strConversationID, strNotes, GetState(CustomerSupportPage.UserID), DateTime.Now);
                }
                if (strStatusID != "")
                {
                    bolResult = objConversation.UpdateConversationStatus(strConversationID, strStatusID, GetState(CustomerSupportPage.UserID), DateTime.Now);
                }
            }
            else if (strAction == "D")
            {
                bolResult = objConversation.DeleteNotes(strNoteID);
            }

            if (strConversationID != "")
            {
                objLeadNotes = objConversation.GetNotes(strConversationID);
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
