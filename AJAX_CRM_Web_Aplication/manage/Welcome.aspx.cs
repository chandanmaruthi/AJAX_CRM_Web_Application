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
public partial class Welcome : CustomerSupportPage
{
    public string strUnQualifiedLead = "", strCategories = "", strProducts = "", strBranding = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindValues();
        ShowTasks();
        ShowSetupCompletionStatus();
        if (GetState(CustomerSupportPage.Background_Color) == "")
        { InitializeAccount(); }
    }
    protected void BindValues()
    {
        Page.Master.Attributes.Add("SetTab","1");
        string strAccountID = "";
        Account objAccount = new Account();
        Tasks objTasks = new Tasks();
        Conversation objConversation = new Conversation();
        DataSet objTasksData;
        DataSet objData;
        DataSet objLeadData;
        
        strAccountID = GetState(CustomerSupportPage.AccountID);
        if (strAccountID.Length > 0)
        {
            objData = objAccount.GetAccountSummary(strAccountID);
            objLeadData = objConversation.GetPipeLineSummary(strAccountID);
            
            
            rptrPipleLineSummary.DataSource=objLeadData.Tables[0];
            rptrPipleLineSummary.DataBind();

            DataSet objHistoryData;

            objHistoryData = objConversation.GetRecentConversations(GetState(CustomerSupport.CustomerSupportPage.AccountID), "", "");
            
            AccountLeadStatus objAccountLeadStatus = new AccountLeadStatus();
            DataSet objAccountLeadStatusData;
            objAccountLeadStatusData = objAccountLeadStatus.GetAllAccountStatus(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());

            rptrLeadStatus.DataSource = objAccountLeadStatusData.Tables[0];
            rptrLeadStatus.DataBind();
            strUnQualifiedLead = objLeadData.Tables[1].Rows[0]["UnQualified_Leads"].ToString();

            if (objData.Tables[0].Rows.Count > 0)
            {
                //lblInProgressLeads.Text = objData.Tables[0].Rows[0]["InProgress_Leads"].ToString();
                //lblPendingLeads.Text = objData.Tables[0].Rows[0]["Pending_Leads"].ToString();
                //lblBalanceCredits.Text = objData.Tables[0].Rows[0]["Balance_Credits"].ToString();
                //lblActiveWidgets.Text = objData.Tables[0].Rows[0]["Active_Widgets"].ToString();
                //lblContactEmail.Text = objData.Tables[0].Rows[0]["Contact_Email"].ToString();
                //switch (objData.Tables[0].Rows[0]["Subscription_Plan"].ToString())
                //{
                //    case "1000": lblPlan.Text = "Free Plan, upgrade now"; break;
                //    case "1001": lblPlan.Text = "Basic Plan"; break;
                //    case "1002": lblPlan.Text = "Standard Plan"; break;
                //    case "1003": lblPlan.Text = "Power Plan"; break;
                //    default: lblPlan.Text = "Free Plan"; break;

                //}

            }

        }
    }
    protected void ShowTasks()
    {
        try
        {

            DataSet objData;
            Conversation objConversation = new Conversation();
            objData = objConversation.GetRecentConversations(GetState(CustomerSupportPage.AccountID), "", "");
            rptrTasks.DataSource = objData.Tables[0];
            rptrTasks.DataBind();
        }
        catch
        {
            throw;
        }
    }
    protected void ShowSetupCompletionStatus()
    { 
    
    Account objAccount = new Account();
    DataSet objData;
    objData=objAccount.GetAccountSetupCompletionStatus(GetState(CustomerSupportPage.AccountID));
    strCategories = objData.Tables[0].Rows[0]["Categories"].ToString();
    strProducts = objData.Tables[0].Rows[0]["Products"].ToString();
    strBranding = objData.Tables[0].Rows[0]["Branding"].ToString(); 
      
    }
}
