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
public partial class People : CustomerSupportPage
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
            AccountUser objUsers = new AccountUser();
            DataSet objData;
            //GetState(CustomerSupportPage.
            int intUserCount=0;

            objData = objUsers.GetUserByAccount(GetState(CustomerSupportPage.AccountID));

            intUserCount=objData.Tables[0].Rows.Count;
            if (intUserCount >= int.Parse(GetState(CustomerSupportPage.SubscriptiomPlanType).ToString()))
            {
            divAddUsers.Visible=false;
            }
            lblUserCount.Text = GetState(CustomerSupportPage.SubscriptiomPlanType).ToString();
            
            rptrProducts.DataSource = objData.Tables[0];
            rptrProducts.DataBind();
        }
        catch
        {
            throw;
        }
    }
}
