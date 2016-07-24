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
public partial class Partials_HandlePeople : CustomerSupportPage
{
    public string strNotes = "";
    public string strUserID = "";
    public string strAccountID = "", strUserName = "", strEmailID = "", strPhone = "", strCustomMessage="";
    public int intTargetPeriod = 0, intConversionRate = 0, intTargetValue = 0;
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
            AccountUser objUser = new AccountUser();
            //Products objProduct = new Products();

            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
            }
            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();
            }
            strAccountID = GetState(CustomerSupportPage.AccountID);


            if (Request["UserID"] != null)
            {
                strUserID = Request["UserID"].ToString();
                //Product_ID = Request["UserID"].ToString();
            }
            if (strAction == "A")
            {

                HandleAddUser();
            }
            else if (strAction == "D")
            {
                bolResult = objUser.DeleteUser(strUserID);

                DataSet objdata;
                objdata = objUser.GetUserByAccount(strAccountID);
                rptrProducts.DataSource = objdata.Tables[0];
                rptrProducts.DataBind();
            }


        }
        catch
        {
            throw;
        }
    }
    private void HandleAddUser()
    {
        try
        {
            // var poststr = "AccountID=" + encodeURI(AccountID) + "&ProductName=" + encodeURI(ProductName) + "&ProductDesc=" + encodeURI(ProductDesc) + "&TargetPeriod=" + encodeURI(TargetPeriod) + "&ConversionRate=" + encodeURI(ConversionRate) + "&Target=" + encodeURI(Target) + "&Action=A";
            AccountUser objUser = new AccountUser();
            string strValidationCode = "";


            if (Request["Name"] != null)
            {
                strUserName = Request["Name"].ToString();
                if (strUserName.Length == 0) { strErrorString += "Name Required,"; }
            }
             Account ObjAccount = new Account();
            if (Request["Email"] != null)
            {

                if (ValidateInput(CustomerSupportPage.VALIDATE_EMAIL, Request["Email"].ToString()) == true)
                {
                    strEmailID = Request["Email"].ToString();

                    if (ObjAccount.bolEmailExists(strEmailID) == true)
                    {
                        strErrorString += ", Email ID is already Registered";
                        
                    }
                }
                else
                {
                    strErrorString += ", Invalid Email";
                }
            
            }
            if (Request["Phone"] != null)
            {
                strPhone = Request["Phone"].ToString();
            }
            if (Request["Message"] != null)
            {
                strCustomMessage = Request["Message"].ToString();
            }


            //string strProductID = "";

            if (strErrorString.Length == 0)
            {
                Account ObjAccount1 = new Account();
                email objEmail = new email();
                Random objRandon=new Random();
                int intPass=0;
                intPass=objRandon.Next(1000);
                strUserID = objUser.AddUser(strAccountID, strUserName, strEmailID, intPass.ToString(), strPhone, strEmailID);
                

                bolResult = ObjAccount1.SetPasswordRecovery(strEmailID, ref strValidationCode);

                objEmail.SendNewUserWelcomeEmail(strEmailID, strUserName, strValidationCode, strCustomMessage);
                DataSet objdata;
                objdata = objUser.GetUserByAccount(strAccountID);
                rptrProducts.DataSource = objdata.Tables[0];
                rptrProducts.DataBind();
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
