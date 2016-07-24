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
public partial class SetupCategories : CustomerSupportPage
{
    public string strAccountID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strAccountID = GetState(CustomerSupportPage.AccountID);
            BindCategories();
        }
        catch
        {
            throw;
        }
    }
    private void BindCategories()
    {
        try
        {

            CategoryTopics objCategoryTopics = new CategoryTopics();
            DataSet objData;
            objData = objCategoryTopics.GetCategoryTopics(GetState(CustomerSupportPage.AccountID));
            rptrCategories.DataSource = objData.Tables[0];
            rptrCategories.DataBind();

            ddlParentCategories.DataSource = objData.Tables[0];
            ddlParentCategories.DataTextField = "Display_Category_Name";
            ddlParentCategories.DataValueField = "Category_ID";
            ddlParentCategories.DataBind();
        }
        catch
        {
            throw;
        }
    }
}
