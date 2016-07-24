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
public partial class Partials_LeadTasks : CustomerSupportPage
{
    string strTask = "";
    DateTime dtmDate=DateTime.Now;
    bool bolResult = false;
    string strStatusID = "";
    public string strLeadID = "";
    string strAction = "A";
    string strTaskID = "";
    //string strErrorString = "";
    //bool bolResult = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet objTasksData;
            Tasks objTasks= new Tasks();

            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
            }
            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();
            }
            if (Request["Task"] != null)
            {
                strTask = Request["Task"].ToString();
            }
            if (Request["Date"] != null)
            {
                dtmDate =DateTime.Parse(Request["Date"]);
            }

            if (Request["TaskID"] != null)
            {
                strTaskID = Request["TaskID"].ToString();
            }
            if (Request["LeadStatus"] != null)
            {
                strStatusID = Request["LeadStatus"].ToString();
            }

            if (strAction == "A")
            {
                if (strTask.Length > 0)
                {
                    string newTaskID = "";
                    newTaskID = objTasks.AddTask(strTask, strLeadID, "0", dtmDate, GetState(CustomerSupportPage.AccountID), GetState(CustomerSupportPage.UserID));
                }
            }
            else if (strAction == "D")
            {
                bolResult = objTasks.DeleteTask(strTaskID);
            }

            if (strLeadID != "")
            {
                objTasksData = objTasks.GetTasks(GetState(CustomerSupportPage.AccountID),"", strLeadID);
                rptrChild.DataSource = objTasksData.Tables[0];
                rptrChild.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

}
