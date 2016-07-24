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
public partial class CustomizeProcess : CustomerSupportPage
{
    public string strAccountID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
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
        try
        {

            AccountLeadStatus objAccountLeadStatus = new AccountLeadStatus();
            DataSet objData;
            objData = objAccountLeadStatus.GetAllAccountStatus(GetState(CustomerSupportPage.AccountID));
            rptrAccountLeadStatus.DataSource = objData.Tables[0];
            rptrAccountLeadStatus.DataBind();
        }
        catch
        {
            throw;
        }
    }
}
