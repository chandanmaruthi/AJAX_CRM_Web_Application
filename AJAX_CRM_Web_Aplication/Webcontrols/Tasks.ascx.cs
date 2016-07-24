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
public partial class Webcontrols_Tasks : System.Web.UI.UserControl
{
    CustomerSupport.CustomerSupportPage objPage;
    protected void Page_Load(object sender, EventArgs e)
    {
        try{
        objPage = new CustomerSupport.CustomerSupportPage();
        ShowTasks();
    }
    catch
    {
        throw;
    }
    }

    protected void ShowTasks()
    {
        try{

        DataSet objData;
        Tasks objTask = new Tasks();
        objData = objTask.GetTasks(objPage.GetState(CustomerSupport.CustomerSupportPage.AccountID),"","");
        rptrTasks.DataSource = objData.Tables[0];
        rptrTasks.DataBind();
    }
    catch
    {
        throw;
    }
    }

}

