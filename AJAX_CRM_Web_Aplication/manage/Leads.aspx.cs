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
public partial class Leads : CustomerSupportPage
{
    public string strAccountId = "";
    public string strConversationID = "", strLeadStatus = "", strLeadEmailID = "", strStatusDesc = "";
    public string strConversationTitle = "", strConversationDesc = "", strProductID = "", strConversationStatus = "", strConversationSeverity = "", strUserName = "", strUserPhone = "", strUserEmail = "", strConversationNumber="";
    public string strCreateDate;
    public int intLeadProbabilty = 0;
    public string strUserID = "";
    public string strProductDesc = "", StatusDesc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strUserID = GetState(CustomerSupport.CustomerSupportPage.UserID).ToString();
            strAccountId = GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString();
            string strAction = "";

            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();

            }

            switch (strAction)
            {
                case "A": break;
                case "E": BindLead(); break;
                default: break;
            }
        }
        catch
        {
            throw;
        }
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



            DataSet objTasksData;
            Tasks objTasks = new Tasks();
            objTasksData = objTasks.GetTasks(GetState(CustomerSupport.CustomerSupportPage.AccountID), "", strConversationID);

            //rptrTasks.DataSource = objTasksData.Tables[0];
            //rptrTasks.DataBind();

            objData = objConversation.GetConverationByID(strConversationID);
            strUserName = objData.Tables[0].Rows[0]["User_Name"].ToString();
            strUserPhone = objData.Tables[0].Rows[0]["User_Phone"].ToString();
            strUserEmail= objData.Tables[0].Rows[0]["User_Email"].ToString();

            strConversationDesc = objData.Tables[0].Rows[0]["Conversation_Desc"].ToString();
            strConversationTitle= objData.Tables[0].Rows[0]["Conversation_Title"].ToString();
            strCreateDate = objData.Tables[0].Rows[0]["Create_Date"].ToString();
            //intLeadProbabilty = int.Parse(objData.Tables[0].Rows[0]["Lead_Probability"].ToString());
            strConversationStatus = objData.Tables[0].Rows[0]["Conversation_Status"].ToString();
            //txtLeadValue.Value = objData.Tables[0].Rows[0]["Lead_Value"].ToString();
            //strUserEmail// = objData.Tables[0].Rows[0]["User_Email"].ToString();
            //strStatusDesc=objData.Tables[0].Rows[0]["Status_Desc"].ToString();
            strProductDesc = objData.Tables[0].Rows[0]["Product_Desc"].ToString();
            strStatusDesc = objData.Tables[0].Rows[0]["Status_Desc"].ToString();
            strConversationNumber = objData.Tables[0].Rows[0]["Conversation_Number"].ToString();
            //rptrChild.DataSource = objData.Tables[1];
            //rptrChild.DataBind();

            DataSet objRepliesData;

            objRepliesData = objConversation.GetConversationHistory(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString(), strConversationID);
            rptrReplies.DataSource = objRepliesData.Tables[0];
            rptrReplies.DataBind();

            rptrTags.DataSource = objData.Tables[2];
            rptrTags.DataBind();


            rptrAllTags.DataSource = objData.Tables[3];
            rptrAllTags.DataBind();


            //ddlProducts.DataSource = objProductsData.Tables[0];
            //ddlProducts.DataBind();
            ddlProducts.DataSource = objProductsData.Tables[0];
            ddlProducts.DataTextField = "Product_Name";
            ddlProducts.DataValueField = "Product_ID";
            ddlProducts.DataBind();

            AccountLeadStatus objAccountLeadStatus = new AccountLeadStatus();
            DataSet objAccountLeadStatusData;
            objAccountLeadStatusData = objAccountLeadStatus.GetAllAccountStatus(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());
            ddlStatus.DataSource = objAccountLeadStatusData.Tables[0];
            ddlStatus.DataTextField = "Status_Name";
            ddlStatus.DataValueField = "Status_ID";
            ddlStatus.DataBind();
            //ddlConversationStatus.DataBind();

            Account objAccount= new Account();
            DataSet objAccountSeverity;
            objAccountSeverity = objAccount.GetSeverity();
            ddlConversationSeverity.DataSource = objAccountSeverity.Tables[0];
            ddlConversationSeverity.DataTextField = "Severity_Name";
            ddlConversationSeverity.DataValueField = "Severity_ID";

            ddlConversationSeverity.DataBind();

            AccountUser objAccountUser = new AccountUser();
            DataSet objUserDataSet;
            objUserDataSet = objAccountUser.GetUserByAccount(GetState(CustomerSupportPage.AccountID));
            ddlUsers.DataSource = objUserDataSet.Tables[0];
            ddlUsers.DataTextField = "User_F_Name";
            ddlUsers.DataValueField = "User_ID";
            ddlUsers.DataBind();

            
            CategoryTopics objCategoryTopics = new CategoryTopics();
            DataSet objCategoryTopicsData;
            objCategoryTopicsData = objCategoryTopics.GetCategoryTopics(GetState(CustomerSupportPage.AccountID));
            ddlCategory.DataSource = objCategoryTopicsData.Tables[0];
            ddlCategory.DataTextField = "Category_Name";
            ddlCategory.DataValueField = "Category_ID";
            ddlCategory.DataBind();

            //Tags objTags=new Tags
            //objTagsDats=objTags.
        }
        catch
        {
            throw;
        }
    }


}
