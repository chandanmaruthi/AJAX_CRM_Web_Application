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
public partial class Partials_HandleCreateAccount : CustomerSupportPage
{
    public string strAccountName = "";
    public string strEmail="";
    public string strTagID = "";
    public string strAccountID = "", strTagName = "" ;
    string strErrorString = "";
    bool bolResult = false;
    public string strLeadID = "";
    string strAction = "A";
    //bool bolResult = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bolResult = false;
            Tags objTags = new Tags();
            
            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();
            }

            if (strAction == "A")
            {

                if (Request["AccountName"] != null)
                {
                    strAccountName = Request["AccountName"].ToString();
                }
               // bolResult = objTags.DeleteTag(strTagID);
                Account objAccount = new Account();
                bolResult = objAccount.bolAccountNameExists(strAccountName);
                if (bolResult == true)
                {
                    divAccountNameTaken.Visible = true;
                }
                else
                {
                    divAccountNameAvailable.Visible = true;
                }
                pnlCheckAccountName.Visible = true; 
            }
            else if (strAction == "E")
            {

                if (Request["Email"] != null)
                {
                    strEmail = Request["Email"].ToString();
                }
                //bolResult = objTags.DeleteTag(strTagID);
                Account objAccount = new Account();
                bolResult= objAccount.bolEmailExists(strEmail);
                if(bolResult==true)
                {
                    divEmailTaken.Visible = true;
                }
                else
                {
                    divEmailAvailable.Visible = true;
                }
                pnlCheckEmail.Visible = true; 
            }
        }
        catch
        {
            throw;
        }
    }
   
}
