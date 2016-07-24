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
public partial class SetupTags : CustomerSupportPage
{
    public string strAccountID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strAccountID = GetState(CustomerSupportPage.AccountID);
            BindTags();
        }
        catch
        {
            throw;
        }
    }
    private void BindTags()
    {
        try
        {
            Tags objTags = new Tags();
            DataSet objData;
            objData = objTags.GetUserTags(GetState(CustomerSupportPage.AccountID));
            rptrTags.DataSource = objData.Tables[0];
            rptrTags.DataBind();
        }
        catch
        {
            throw;
        }
    }
}
