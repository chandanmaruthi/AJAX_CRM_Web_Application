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
public partial class Partials_HandleProcess : CustomerSupportPage
{
    public string strAccountID = "", strStatusName = "", strStatusDesc="",strStatusID="";
    public int intPercentageCompletion=0,intOrder=0;
    string strErrorString = "";
    bool bolResult = false;
    string strAction = "A";
    //bool bolResult = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bolResult = false;
            AccountLeadStatus objAccountLeadStatus = new AccountLeadStatus();
            //Products objProduct = new Products();

            //if (Request["ID"] != null)
            //{
            //    strLeadID = Request["ID"].ToString();
            //}
            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();
            }
            strAccountID = GetState(CustomerSupportPage.AccountID);


            if (Request["Status_ID"] != null)
            {
                strStatusID = Request["Status_ID"].ToString();
                
            }
            if (strAction == "A")
            {

                HandleAddAccountStatus();
            }
            else if (strAction == "D")
            {
                bolResult = objAccountLeadStatus.DeleteAccountLeadStatus(strAccountID, strStatusID);
                DataSet objdata;

                objdata = objAccountLeadStatus.GetAllAccountStatus(strAccountID);
                rptrAccountLeadStatus.DataSource = objdata.Tables[0];
                rptrAccountLeadStatus.DataBind();
            }


            
        }
        catch
        {
            throw;
        }
    }
    private void HandleAddAccountStatus()
    {
        try
        {
            // var poststr = "AccountID=" + encodeURI(AccountID) + "&ProductName=" + encodeURI(ProductName) + "&ProductDesc=" + encodeURI(ProductDesc) + "&TargetPeriod=" + encodeURI(TargetPeriod) + "&ConversionRate=" + encodeURI(ConversionRate) + "&Target=" + encodeURI(Target) + "&Action=A";
            AccountLeadStatus objAccountLeadStatus = new AccountLeadStatus();



            if (Request["StatusName"] != null)
            {
                strStatusName = Request["StatusName"].ToString();
                if (strStatusName.Length == 0) { strErrorString += "Description Required,"; }
            }
            if (Request["StatusDesc"] != null)
            {
                strStatusDesc = Request["StatusDesc"].ToString();
                if (strStatusDesc.Length == 0) { strErrorString += "Description Required,"; }
            }
            if (Request["PercentageCompletion"] != null)
            {
                bolResult = int.TryParse(Request["PercentageCompletion"].ToString(), out intPercentageCompletion);
                if (bolResult == false) { strErrorString += "Percentage Completion is invalid,"; }

            }
            if (Request["Order"] != null)
            {
                bolResult = int.TryParse(Request["Order"].ToString(), out intOrder);
                if (bolResult == false) { strErrorString += "Order is invalid,"; }
            }


            string strStatusID = "";
            if (strErrorString.Length == 0)
            {
                strStatusID = objAccountLeadStatus.AddAccountLeadStatus(strAccountID, strStatusName, strStatusDesc, intPercentageCompletion, intOrder);
                DataSet objdata;

                objdata = objAccountLeadStatus.GetAllAccountStatus(strAccountID);
                rptrAccountLeadStatus.DataSource = objdata.Tables[0];
                rptrAccountLeadStatus.DataBind();
            }
            else
            {
                Response.Clear();
                Response.Write("ERROR: " + strErrorString);
                return;
            }
            
        }
        catch
        {
            throw;
        }
    }

}
