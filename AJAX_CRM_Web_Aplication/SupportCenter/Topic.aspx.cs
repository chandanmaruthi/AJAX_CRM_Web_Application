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
public partial class SupportCenter_Topic : CustomerSupportPage
{
    public string strAccountId = "";
    public string strConversationID = "", strLeadStatus = "", strLeadEmailID = "", strStatusDesc = "";
    public string strConversationTitle = "", strConversationDesc = "", strProductID = "", strConversationStatus = "", strConversationSeverity = "", strUserName = "", strUserPhone = "", strUserEmail = "", strViewedCount="";
    public string strCreateDate;
    public int intLeadProbabilty = 0;
    public string strUserID = "";
    public string strProductDesc = "", StatusDesc = "";
    public string strMessagesCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Account_ID"] != null)
        {
            SetState(CustomerSupport.CustomerSupportPage.AccountID, Request["Account_ID"].ToString());
        }
        BindLead();
        strAccountId = GetState(CustomerSupportPage.AccountID);
    }

    private void BindLead()
    {
        try
        {
            Conversation objConversation = new Conversation();
            Products objProducts = new Products();


            DataSet objData;
            DataSet objProductsData;
            if (Request["ID"] != null)
            {
                strConversationID = Request["ID"].ToString();
            }
            else
            {
                return;
            }


            objProductsData = objProducts.GetProductDetails(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());
            DataSet objLeadHistorData;
            objLeadHistorData = objConversation.GetRecentConversations(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString(), "", strConversationID);

            //rptrHistory.DataSource = objLeadHistorData.Tables[0];
            //rptrHistory.DataBind();


            DataSet objTasksData;
            Tasks objTasks = new Tasks();
            objTasksData = objTasks.GetTasks(GetState(CustomerSupport.CustomerSupportPage.AccountID), "", strConversationID);

            //rptrTasks.DataSource = objTasksData.Tables[0];
            //rptrTasks.DataBind();

            objData = objConversation.GetConverationByID(strConversationID);
            strUserName = objData.Tables[0].Rows[0]["User_Name"].ToString();
            strUserPhone = objData.Tables[0].Rows[0]["User_Phone"].ToString();
            strUserEmail = objData.Tables[0].Rows[0]["User_Email"].ToString();
            strConversationDesc = objData.Tables[0].Rows[0]["Conversation_Desc"].ToString();
            strConversationTitle = objData.Tables[0].Rows[0]["Conversation_Title"].ToString();
            strCreateDate = objData.Tables[0].Rows[0]["Create_Date"].ToString();
            //intLeadProbabilty = int.Parse(objData.Tables[0].Rows[0]["Lead_Probability"].ToString());
            strConversationStatus = objData.Tables[0].Rows[0]["Conversation_Status"].ToString();
            //txtLeadValue.Value = objData.Tables[0].Rows[0]["Lead_Value"].ToString();
            //strUserEmail// = objData.Tables[0].Rows[0]["User_Email"].ToString();
            //strStatusDesc=objData.Tables[0].Rows[0]["Status_Desc"].ToString();
            strProductDesc = objData.Tables[0].Rows[0]["Product_Desc"].ToString();
            strStatusDesc = objData.Tables[0].Rows[0]["Status_Desc"].ToString();
            strMessagesCount = objData.Tables[0].Rows[0]["Messages_Count"].ToString();
            strViewedCount = objData.Tables[0].Rows[0]["Viewed_Count"].ToString();
            //rptrChild.DataSource = objData.Tables[1];
            //rptrChild.DataBind();s
            Page.Title = strConversationTitle+" : " + GetState(CustomerSupportPage.Account_Name);
            DataSet objRepliesData;
            objRepliesData = objConversation.GetConversatioMessages(strConversationID);
            rptrReplies.DataSource = objRepliesData.Tables[0];
            rptrReplies.DataBind();

            //rptrTags.DataSource = objData.Tables[2];
            //rptrTags.DataBind();


            //rptrAllTags.DataSource = objData.Tables[3];
            //rptrAllTags.DataBind();

            //ddlProducts.DataSource = objProductsData.Tables[0];
            //ddlProducts.DataBind();
            //ddlProducts.DataSource = objProductsData.Tables[0];
            //ddlProducts.DataTextField = "Product_Name";
            //ddlProducts.DataValueField = "Product_ID";
            //ddlProducts.DataBind();

            AccountLeadStatus objAccountLeadStatus = new AccountLeadStatus();
            DataSet objAccountLeadStatusData;
            objAccountLeadStatusData = objAccountLeadStatus.GetAllAccountStatus(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());
            //ddlConversationStatus.DataSource = objAccountLeadStatusData.Tables[0];
            //ddlConversationStatus.DataTextField = "Status_Name";
            //ddlConversationStatus.DataValueField = "Status_ID";

            //ddlConversationStatus.DataBind();

            Account objAccount = new Account();
            DataSet objAccountSeverity;
            objAccountSeverity = objAccount.GetSeverity();
            //ddlConversationSeverity.DataSource = objAccountSeverity.Tables[0];
            //ddlConversationSeverity.DataTextField = "Severity_Name";
            //ddlConversationSeverity.DataValueField = "Severity_ID";

            //ddlConversationSeverity.DataBind();



            //Tags objTags=new Tags
            //objTagsDats=objTags.
        }
        catch
        {
            throw;
        }
    }
}
