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
using CustomerSupport.Data;
using CustomerSupport;
public partial class Partials_HandleConversation : CustomerSupportPage
{
    //string strNotes = "";

    bool bolResult = false;
    public string strStatusID = "";
    public string strLeadID = "";
    public string strAction = "A";
    //string strNoteID = "";
    public string Conversation_ID = "", ConversationTitle = "", ConversationDesc = "", ProductID = "", ConversationStatus = "", ConversationSeverity = "", strConversationType = "", strCategoryID = "", ConversationCategory="";
    public string strAccountID = "", UserName = "", UserPhone = "", UserEmail = "", LeadProduct = "", LeadNotes = "", LeadStatus = "", LeadOwner = "", strReply = "";
    public int LeadProbability = 0, LeadValue = 0, intStar = 0;
    string strErrorString = "";
    //bool bolResult = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            //DataSet objLeadNotes;
            Conversation objConversation = new Conversation();


            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();
            }

            if (strAction == "A")
            {
                HandleAddLead();
            }
            if (strAction == "AR")
            {
                HandleAddReply();
            }
            else if (strAction == "E")
            {
                HandleEditLead();
            }
            else if (strAction == "D")
            {
                if (Request["ID"] != null)
                {
                    strLeadID = Request["ID"].ToString();
                }

                bolResult = objConversation.DeleteConversation(strLeadID);
            }
            else if (strAction == "S")
            {
                HandleStars();
            }
            else if (strAction == "ST")
            {
                HandleStatus();
            }
            else if (strAction == "QR")
            {
                HandleAddQuickReply();
            }
            else if (strAction == "ACUD")
            {
                HandleUpdateConversation();
            }
        }
        catch
        {
            throw;
        }

    }

    public void HandleAddReply()
    {

        Conversation objConversation = new Conversation();
        if (Request["ID"] != null)
        {
            strLeadID = Request["ID"].ToString();
        }
        if (Request["AccountID"] != null)
        {
            strAccountID = Request["AccountID"].ToString();
        }
        if (Request["ConversationStatus"] != null)
        {
            strStatusID = Request["ConversationStatus"].ToString();
        }
        
        if (Request["Reply"] != null)
        {
            strReply = Request["Reply"].ToString();
        }
        string strReplyID;
        strReplyID = objConversation.AddConversationMessage(strLeadID, strAccountID, GetState(CustomerSupportPage.UserID), HttpUtility.UrlDecode(strReply), DateTime.Now, false, true, "", "");
        bolResult = objConversation.UpdateConversationStatus(strLeadID, strStatusID, GetState(CustomerSupportPage.UserID), DateTime.Now);

        DataSet objData;
        objData = objConversation.GetConversationHistory(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString(), strLeadID);
        rptrReplies.DataSource = objData.Tables[0];
        rptrReplies.DataBind();
        pnlReply.Visible = true;

        //Send Email

        email objEmail = new email();
        //objEmail.s 


    }
    public void HandleAddQuickReply()
    {

        Conversation objConversation = new Conversation();
        if (Request["ID"] != null)
        {
            strLeadID = Request["ID"].ToString();
        }
        if (Request["AccountID"] != null)
        {
            strAccountID = Request["AccountID"].ToString();
        }
        if (Request["Status"] != null)
        {
            strStatusID = Request["Status"].ToString();
        }

        if (Request["Reply"] != null)
        {
            strReply = Request["Reply"].ToString();
        }
        string strReplyID;
        strReplyID = objConversation.AddConversationMessage(strLeadID, strAccountID, GetState(CustomerSupportPage.UserID), strReply, DateTime.Now, false, true, "", "");
        bolResult = objConversation.UpdateConversationStatus(strLeadID, strStatusID, GetState(CustomerSupportPage.UserID), DateTime.Now);

        //DataSet objData;
        //objData = objLead.GetConversatioMessages(strLeadID);
        //rptrReplies.DataSource = objData.Tables[0];
        //rptrReplies.DataBind();
        //pnlReply.Visible = true;


    }

    public void HandleAddLead()
    {
        try
        {
            Conversation objConversation = new Conversation();

            //Validate Input Values
            //Validation SuccessFull
            if (Request["AccountID"] != null)
            {
                strAccountID = Request["AccountID"].ToString();
            }


            if (Request["UserName"] != null)
            {
                if (Request["UserName"].ToString().Length > 0)
                { UserName = Request["UserName"].ToString(); }
                else { strErrorString += ", Lead Name Cannot be Empty "; }
            }

            if (Request["UserPhone"] != null)
            {
                UserPhone = Request["UserPhone"].ToString();
            }

            if (Request["UserEmail"] != null)
            {
                if (ValidateInput(CustomerSupportPage.VALIDATE_EMAIL, Request["UserEmail"].ToString()) == true)
                {
                    UserEmail = Request["UserEmail"].ToString();
                }
                else
                {
                    strErrorString += ", Invalid Email";
                }
            }

            if (Request["ConversationType"] != null)
            {
                strConversationType = Request["ConversationType"].ToString();
            }
            if (Request["ConversationTitle"] != null)
            {
                ConversationTitle = Request["ConversationTitle"].ToString();
            }
            if (Request["ConversationDesc"] != null)
            {
                ConversationDesc = Request["ConversationDesc"].ToString();
            }
            if (Request["ProductID"] != null)
            {
                ProductID = Request["ProductID"].ToString();
            }
            if (Request["ConversationStatus"] != null)
            {
                ConversationStatus = Request["ConversationStatus"].ToString();
            }
            if (Request["ConversationSeverity"] != null)
            {
                ConversationSeverity = Request["ConversationSeverity"].ToString();
            }
            if (Request["ConversationCategory"] != null)
            {
                ConversationCategory = Request["ConversationCategory"].ToString();
            }
            
            email objEmail = new email();
            if (strErrorString.Length == 0)
            {

                bolResult = objConversation.AddConversation(strAccountID, ConversationTitle, HttpUtility.UrlDecode(ConversationDesc), ConversationStatus, ConversationSeverity, DateTime.Now, "", ProductID, strConversationType, "", "", "", UserEmail, UserPhone, UserName,ConversationCategory, ref Conversation_ID);
                objEmail.SendConversationAlert(ConversationTitle, ConversationDesc, DateTime.Now, UserName, ProductID, GetState(CustomerSupportPage.Email_ID));
                objEmail.SendConversationAlertAck(ConversationTitle, ConversationDesc, DateTime.Now, UserName, ProductID, UserEmail);
            }
            else
            {
                Response.Clear();
                Response.Write("ERROR: " + strErrorString);
                return;
            }


            pnlNewLeadBox.Visible = true;
            pnlStarContainer.Visible = false;
            pnlStatusContainer.Visible = false;
        }
        catch
        {
            throw;
        }

    }
    public void HandleEditLead()
    {
        try
        {
            Conversation objConversation = new Conversation();

            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
            }
            if (Request["AccountID"] != null)
            {
                strAccountID = Request["AccountID"].ToString();
            }



            if (Request["UserName"] != null)
            {
                if (Request["UserName"].ToString().Length > 0)
                { UserName = Request["UserName"].ToString(); }
                else { strErrorString += ", Lead Name Cannot be Empty "; }
            }

            if (Request["UserPhone"] != null)
            {
                UserPhone = Request["UserPhone"].ToString();
            }

            if (Request["UserEmail"] != null)
            {
                if (ValidateInput(CustomerSupportPage.VALIDATE_EMAIL, Request["UserEmail"].ToString()) == true)
                {
                    UserEmail = Request["UserEmail"].ToString();
                }
                else
                {
                    strErrorString += ", Invalid Email";
                }
            }


            if (Request["ConversationTitle"] != null)
            {
                ConversationTitle = Request["ConversationTitle"].ToString();
            }
            if (Request["ConversationDesc"] != null)
            {
                ConversationDesc = Request["ConversationDesc"].ToString();
            }
            if (Request["ProductID"] != null)
            {
                ProductID = Request["ProductID"].ToString();
            }
            if (Request["ConversationStatus"] != null)
            {
                ConversationStatus = Request["ConversationStatus"].ToString();
            }
            if (Request["ConversationSeverity"] != null)
            {
                ConversationSeverity = Request["ConversationSeverity"].ToString();
            }

            if (strErrorString.Length == 0)
            {
                bolResult = objConversation.UpdateConversation(strLeadID, strAccountID, "", UserName, "", "", UserPhone, UserEmail, LeadValue, "", LeadStatus, GetState(CustomerSupportPage.UserID), LeadProduct, LeadProbability, GetState(CustomerSupportPage.UserID), DateTime.Today);
            }
            else
            {
                Response.Clear();
                Response.Write("ERROR: " + strErrorString);
                return;
            }


        }
        catch
        {
            throw;
        }

    }
    public void HandleStars()
    {
        try
        {
            Conversation objConversation = new Conversation();

            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
            }


            if (Request["Stars"] != null)
            {
                intStar = int.Parse(Request["Stars"].ToString());
            }
            bolResult = objConversation.UpdateConversationRating(strLeadID, intStar, GetState(CustomerSupport.CustomerSupportPage.UserID), DateTime.Now);

            pnlStarContainer.Visible = true;
            pnlNewLeadBox.Visible = false;
            pnlStatusContainer.Visible = false;
        }
        catch
        {
            throw;
        }
    }
    public void HandleStatus()
    {
        try
        {
            Conversation objConversation = new Conversation();

            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
            }


            if (Request["Status"] != null)
            {
                strStatusID = Request["Status"].ToString();
            }
            bolResult = objConversation.UpdateConversationStatus(strLeadID, strStatusID, GetState(CustomerSupport.CustomerSupportPage.UserID), DateTime.Now);

            //Page.Controls.Remove(StarContainer);

            //pnl

            pnlStatusContainer.Visible = true;
            pnlNewLeadBox.Visible = false;
            pnlStarContainer.Visible = false;
        }
        catch
        {
            throw;
        }
    }

    public void HandleUpdateConversation()
    {
        try
        {
            Conversation objConversation = new Conversation();
            //var poststr = "ID=" + LeadID + "&AccountID=" + encodeURI(AccountID) + "&ProductID=" + encodeURI(ProductID) + "&SeverityID=" + encodeURI(SeverityID) + "&AssignedToID=" + encodeURI(AssignedToID) + "&Action=ACUD";

            string strProductID = "", strSeverityID = "", strAssignedToID="";

            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
            }
            if (Request["AccountID"] != null)
            {
                strAccountID = Request["AccountID"].ToString();
            }

            if (Request["CategoryID"] != null)
            {
                strCategoryID = Request["CategoryID"].ToString();
            }
            if (Request["ProductID"] != null)
            {
                strProductID = Request["ProductID"].ToString();
            }
            if (Request["SeverityID"] != null)
            {
                strSeverityID = Request["SeverityID"].ToString();
            }
            if (Request["AssignedToID"] != null)
            {
                strAssignedToID = Request["AssignedToID"].ToString();
            }

            bolResult = objConversation.UpdateConversationDetails(strLeadID, strProductID, strSeverityID, strAssignedToID,strCategoryID, GetState(CustomerSupport.CustomerSupportPage.UserID), DateTime.Now);
            Response.Write("Status Updated");
            //pnlStarContainer.Visible = true;
            //pnlNewLeadBox.Visible = false;
            //pnlStatusContainer.Visible = false;
        }
        catch
        {
            throw;
        }


    }
}
