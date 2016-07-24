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
public partial class CustomerSupportSummary : CustomerSupportPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            BindSummary();
        }
        catch
        {
            throw;
        }
    }
    public void BindSummary()
    {
        try
        {
            DataSet objData;
            Account objAccount = new Account();
            objData = objAccount.GetAllAccountSummary();
            rptrSummary.DataSource = objData;
            rptrSummary.DataBind();
        }
        catch
        {
            throw;
        }
    }
}
