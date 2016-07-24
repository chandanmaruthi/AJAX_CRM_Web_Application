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
public partial class Webcontrols_WidgetList : CustomerSupportControl
{
    public int intItemsPerPage = 25;
    public int intPageNo = 1;
    public int intTotalWidgets = 0;
    public int intResultStart = 0;
    public int intResultEnd = 0;
    public string strWidgetsByPlan = "";
    public string strUpgradeMessage = "";
    CustomerSupportPage objPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            objPage = new CustomerSupportPage();

            if (Request["Action"] != null)
            {
                if (Request["Action"] == "Delete")
                {
                    DeleteWidget();
                }

            }
            BindViewWidgets();
        }
        catch
        {
            throw;
        }
    }

    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            string strWidgetID = "";
            LeadWidget objWidget = new LeadWidget();
            string strQuestionID;
            strWidgetID = objWidget.AddWidget("New Widget",
                                        "",
                                        "",
                                        "20652BB5-E081-4AB8-87CE-14A382A4D3A5",
                                        objPage.GetState(CustomerSupport.CustomerSupportPage.AccountID),
                                        "",
                                        "",
                                        "",
                                        "",
                                        GetState(CustomerSupport.CustomerSupportPage.UserID),
                                        DateTime.Now);
            strQuestionID = objWidget.AddWidgetQuestions(strWidgetID, "New Question", "Option 1");
            Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "manage/SetupWidget.aspx?Action=Edit&ID=" + strWidgetID);
        }
        catch
        {
            throw;
        }
    }

    private void BindViewWidgets()
    {
        try
        {
            Account objAccount = new Account();
            LeadWidget objLeadWidget = new LeadWidget();
            DataSet objData;
            DataSet objData1;
            int intWidgets = 0;
            objData1 = objAccount.GetAccountDetails(objPage.GetState(CustomerSupportPage.AccountID));

            if (Request["Page_No"] != null)
            {
                intPageNo = int.Parse(Request["Page_No"]);
            }
            else
            {
                intPageNo = 1;
            }
            objData = objLeadWidget.GetWidgetsByAccount(objPage.GetState(CustomerSupport.CustomerSupportPage.AccountID), intItemsPerPage, intPageNo, ref intTotalWidgets);
            rptrViewWidgets.DataSource = objData;
            rptrViewWidgets.DataBind();

            if (objData1.Tables[0].Rows.Count > 0)
            {
                switch (objData1.Tables[0].Rows[0]["Subscription_Plan"].ToString())
                {
                    case "1000": intWidgets = 1; strUpgradeMessage = "you can have upto" + intWidgets.ToString() + " widgets"; break;
                    case "1001": intWidgets = 5; break;
                    case "1002": intWidgets = 25; break;
                    case "1003": intWidgets = 1000; break;
                    default: intWidgets = 1; break;
                }
            }
            if (intWidgets < 1000)
            {
                strWidgetsByPlan = intWidgets.ToString();
            }
            else
            {
                strWidgetsByPlan = "unlimited";
            }
            //if (objData.Tables[0].Rows.Count >= intWidgets)
            //{
                lnkAddNewDiv.Visible = true;
                // lblNoMoreWidgets.Visible = true;
            //}
        }
        catch
        {
            throw;
        }
    }

    private void DeleteWidget()
    {
        try
        {
            LeadWidget objLeadWidget = new LeadWidget();
            bool bolResult;
            bolResult = objLeadWidget.DeleteWidget(Request["ID"].ToString());
        }
        catch
        {
            throw;
        }
    }
}
