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
public partial class Webcontrols_QuickConversationSearch : System.Web.UI.UserControl
{
    //CustomerSupport.CustomerSupportPage objPage;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //objPage = new CustomerSupport.CustomerSupportPage();
            //ShowTasks();
        }
        catch
        {
            throw;
        }
    }

    //protected void ShowTasks()
    //{
    //    try
    //    {

    //        DataSet objLeadData;
    //        Lead objLeads = new Lead();
    //        objLeadData = objLeads.GetPipeLineSummary(objPage.GetState(CustomerSupport.CustomerSupportPage.AccountID));

    //        rptrOverview.DataSource = objLeadData.Tables[0];
    //        rptrOverview.DataBind();

    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}

}

