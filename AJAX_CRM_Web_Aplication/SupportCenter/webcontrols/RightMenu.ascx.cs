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
public partial class Webcontrols_RightMenu : CustomerSupportControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            BindProducts();
            BindTopicCategories();

            BindHotTags();
        }
        catch
        {
            throw;
        }
    }
    private void BindProducts()
    {

        Products objProducts = new Products();
        DataSet objProductsDataset;
        objProductsDataset = objProducts.GetProductDetails(GetState(CustomerSupportPage.AccountID));
        rptrProducts.DataSource = objProductsDataset.Tables[0];
        rptrProducts.DataBind();





    }
    private void BindTopicCategories()
    {
        CategoryTopics objCategoryTopics = new CategoryTopics();

        DataSet objCategoryTopicsDataset;
        objCategoryTopicsDataset = objCategoryTopics.GetCategoryTopics(GetState(CustomerSupportPage.AccountID));
        rptrTopicCategories.DataSource = objCategoryTopicsDataset.Tables[0];
        rptrTopicCategories.DataBind();
    }

    private void BindHotTags()
    {

        Tags objTags = new Tags();
        DataSet objHotTagsData;
        //int intTopics = 0;
        objHotTagsData = objTags.GetPopularTags(GetState(CustomerSupportPage.AccountID));
        rptrTags.DataSource = objHotTagsData.Tables[0];
        rptrTags.DataBind();
    }
}
