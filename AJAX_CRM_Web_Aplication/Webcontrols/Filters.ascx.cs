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
public partial class Webcontrols_Filters : CustomerSupportControl
{
    public string strLeadStatus = "";
    public string strProductName = "All";
    public string strLeadStatusName = "New";
    public string strTagID = "";
    public string strProductID = "";
    public string strCategoryID = "";

    public string strTagName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindFilters();

    }

    public void BindFilters()
    {
        strTagID=GetState(CustomerSupportControl.Filter_Tag_ID);
        strProductID = GetState(CustomerSupportControl.Filter_Product_ID);
        strCategoryID= GetState(CustomerSupportControl.Filter_Category_ID);

        Products objProducts = new Products();
        DataSet  objProductsData;

        //DataSet objAccountLeadStatusData;

        objProductsData = objProducts.GetProductDetails(GetState(CustomerSupportControl.AccountID).ToString());

        rptrProductsFilter.DataSource = objProductsData.Tables[0];
        rptrProductsFilter.DataBind();


        
        Tags objTags = new Tags();
        DataSet objTagsData;
        objTagsData = objTags.GetUserTags(GetState(CustomerSupportControl.AccountID).ToString());
        rptrTags.DataSource = objTagsData.Tables[0];
        rptrTags.DataBind();

        CategoryTopics objCategoryTopics = new CategoryTopics();
        DataSet objCategoryTopicsData;
        objCategoryTopicsData = objCategoryTopics.GetCategoryTopics(GetState(CustomerSupportControl.AccountID).ToString());
        rptrCategoryFilter.DataSource = objCategoryTopicsData.Tables[0];
        rptrCategoryFilter.DataBind();

    }
    protected void lnkSearch_OnClick(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "manage/searchresults.aspx?PageIndex=0&st=" + txtSearch.Text);
        }
        catch
        {
            throw;
        }
    }

}
