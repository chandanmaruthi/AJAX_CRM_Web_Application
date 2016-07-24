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
public partial class SupportCenter_default : CustomerSupportPage
{
    public HttpServerUtility objHttpServerUtility;
    
    public string strAccountID = "", strBackgroundColor = "", strHeaderColor = "", strLogoFileName = "", strHeaderText = "", strWelcomeMessage = "";
    public string strConversationType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        strConversationType = "A3351F34-CB58-4940-A452-96F2A0527181";
        if (Request["Account_ID"] != null)
        {



            SetState(CustomerSupport.CustomerSupportPage.AccountID, Request["Account_ID"].ToString());
            //SetState(CustomerSupport.CustomerSupportPage.Request["Account_ID"].ToString());


        }
        else
        {

            Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "PageNotFound.aspx");

        }

        BindProducts();
        Page.Title = GetState(CustomerSupportPage.Header_Text);
       

        strAccountID = GetState(CustomerSupportPage.AccountID);
        InitializeAccount();
        BindHotTopics();

        BindMostViewed();
    }
     private void BindHotTopics()
    {
        Conversation objConversations = new Conversation();

        DataSet objHotTopicsDataset;
       int intTopics=0;
       objHotTopicsDataset = objConversations.GetHotConverastions(GetState(CustomerSupportPage.AccountID), 10, 1, "", "", "", ref intTopics);
        rptrHotTopics.DataSource = objHotTopicsDataset.Tables[0];
        rptrHotTopics.DataBind();
     
    }
   
   private void BindMostViewed()
   {

       Conversation objConversation = new Conversation();
       DataSet objMostViewedData;
       //int intTopics = 0;
       objMostViewedData = objConversation.GetMostViewedConversations(GetState(CustomerSupportPage.AccountID));
       rptrMostViewed.DataSource = objMostViewedData.Tables[0];
       rptrMostViewed.DataBind();
   }
   private void BindProducts()
   {

       Products objProducts = new Products();
       DataSet objProductsDataset;
       objProductsDataset = objProducts.GetProductDetails(GetState(CustomerSupportPage.AccountID));
       ddlProducts.DataSource = objProductsDataset.Tables[0];
       ddlProducts.DataTextField = "Product_Name";
       ddlProducts.DataValueField = "Product_ID";
       ddlProducts.DataBind();





   }
}
