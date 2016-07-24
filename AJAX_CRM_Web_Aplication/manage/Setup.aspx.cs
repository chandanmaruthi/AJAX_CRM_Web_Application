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
public partial class SetupProducts : CustomerSupportPage
{
    public string strAccountID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try{
        strAccountID = GetState(CustomerSupportPage.AccountID);
        BindProducts();
    }
    catch
    {
        throw;
    }
    }
    private void BindProducts()
    {
        try{
        Products objProducts = new Products();
        DataSet objData;
        objData=objProducts.GetProductDetails(GetState(CustomerSupportPage.AccountID));
        rptrProducts.DataSource = objData.Tables[0];
        rptrProducts.DataBind();
    }
    catch
    {
        throw;
    }
    }
}
