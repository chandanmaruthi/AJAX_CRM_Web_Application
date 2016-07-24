using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerSupport;
using System.Data;
using CustomerSupport.Data;
public partial class manage_CreateContent : CustomerSupportPage
{
    public string strUserID = "", strAccountId="",strLeadStatus="";
    protected void Page_Load(object sender, EventArgs e)
    {
        strUserID = GetState(CustomerSupport.CustomerSupportPage.UserID).ToString();
        strAccountId = GetState(CustomerSupportPage.AccountID);
        BindPage();
    }
    public void BindPage()
    {

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



        DataSet objProductsData; 
        Products objProducts = new Products();
        
        objProductsData = objProducts.GetProductDetails(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());

        ddlProducts.DataSource = objProductsData.Tables[0];
        ddlProducts.DataTextField = "Product_Name";
        ddlProducts.DataValueField = "Product_ID";
        ddlProducts.DataBind();

        CategoryTopics objCategoryTopics = new CategoryTopics();
        DataSet objCategoryTopicsData;
        objCategoryTopicsData = objCategoryTopics.GetCategoryTopics(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());
        ddlCategory.DataSource = objCategoryTopicsData.Tables[0];
        ddlCategory.DataTextField = "Display_Category_Name";
        ddlCategory.DataValueField = "Category_ID";
        ddlCategory.DataBind();
    }
}
