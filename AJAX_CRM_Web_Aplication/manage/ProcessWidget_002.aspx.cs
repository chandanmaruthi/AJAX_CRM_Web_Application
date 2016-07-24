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
using System.Text.RegularExpressions;
using CustomerSupport.Data;
using System.Net;

public partial class ProcessWidget : CustomerSupportPage
{

    public string strEmail = "";
    public string strPhone = "";
    public string strName = "";
    public string strMessageTitle = "";
    public string strMessageDesc = "";
    public string strAccountID = "";
    public string strIP = "";
    public string strIPLocationDesc = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SetValues();
        }
        catch
        {
        }

    }
    protected void SetValues()
    {
        strIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        strIPLocationDesc = GetIPDesc(strIP);
        if (Request["txtMessageDesc"] != null)
        {

            strMessageDesc = Request["txtMessageDesc"].ToString();
        }
        if (Request["txtMessageTitle"] != null)
        {

            strMessageTitle = Request["txtMessageTitle"].ToString();
        }
        if (Request["hdnAccountID"] != null)
        {

            strAccountID= Request["hdnAccountID"].ToString();
        }

        if (Request["txtName"] != null)
        {
            strName = Request["txtName"].ToString();
        }
        if (Request["txtPhone"] != null)
        {
            strPhone = Request["txtPhone"].ToString();
        }
        if (Request["txtEmail"] != null)
        {
            strEmail = Request["txtEmail"].ToString();
        }
 
        if (strPhone == "Phone" && strEmail == "email" || isEmail(strEmail) == false)
        {
            return;
        }
        else
        {
            SaveLead();
        }


    }
    public double IPAddressToNumber(string IPaddress)
    {
        int i;
        string[] arrDec;
        double num = 0;
        if (IPaddress == "")
        {
            return 0;
        }
        else
        {
            arrDec = IPaddress.Split('.');
            for (i = arrDec.Length - 1; i >= 0; i--)
            {
                num += ((int.Parse(arrDec[i]) % 256) * Math.Pow(256, (3 - i)));
            }
            return num;
        }
    }
    protected String GetIPDesc(string strIPAddress)
    {
        try
        {
            string strIP = strIPAddress;
            double doubleIP = IPAddressToNumber(strIP);
            String strReturnValue;

            string strDataFile = Server.MapPath("GeoIPData/GeoIPCity.dat");
            LookupService ls = new LookupService(strDataFile, LookupService.GEOIP_STANDARD);
            //get city location of the ip address
            if (strIP.Length > 0)
            {

                Location l = ls.getLocation(long.Parse(doubleIP.ToString()));
                if (l != null)
                {
                    strReturnValue = "We think this user is from ";
                    //lblIP.Text += "country code " + l.countryCode + " , " ;
                    //lblIP.Text += "region " + l.region + "\n";
                    strReturnValue += l.city + " , ";
                    strReturnValue += l.countryName + " , ";

                    //lblIP.Text += "postal code " + l.postalCode + "\n";
                    //lblIP.Text += "latitude " + l.latitude + "\n";
                    //lblIP.Text += "longitude " + l.longitude + "\n";
                    //lblIP.Text += "dma code " + l.dma_code + "\n";
                    //lblIP.Text += "area code " + l.area_code + "\n";
                    return strReturnValue;
                }
                else
                {
                    return "IP Address Not Found\n";
                }
            }
            else
            {
                return "Usage: cityExample IPAddress\n";
            }
        }
        catch (System.Exception ex)
        {
            return "Error" + ex.Message + "\n";
        }
    }

    protected void SaveLead()
    {
        try
        {
            string strEmailBody = "";
            CustomerSupportPage objPage = new CustomerSupportPage();
            Account objAccount = new Account();
            DataSet objData;
            Conversation objConversation = new Conversation();
            bool bolAddConversation;
         

            string strProductID = "";

            string strConversationID = "";

            bolAddConversation = objConversation.AddConversation(strAccountID,
                                        strMessageTitle,
                                        strMessageDesc,
                                        "",
                                        "",
                                        DateTime.Now,
                                        "",
                                        "",
                                        "",
                                        "",
                                        strIP,strIPLocationDesc,strEmail,strPhone,strName,"",ref strConversationID);
            if (bolAddConversation == true)
            {


                        strEmailBody = System.IO.File.ReadAllText(Server.MapPath("../" + CustomerSupport.Utility.SysResource.EmailTemplate_Path + CustomerSupport.Utility.SysResource.TF_ConversationAlert));
                        strEmailBody = strEmailBody.Replace("[LeadTime]", DateTime.Now.ToString());
                        strEmailBody = strEmailBody.Replace("[LeadName]", strName);
                        strEmailBody = strEmailBody.Replace("[LeadEmail]", strEmail);
                        strEmailBody = strEmailBody.Replace("[LeadPhone]", strPhone);
                        strEmailBody = strEmailBody.Replace("[LeadDesc]", strMessageDesc);
                        //strEmailBody = strEmailBody.Replace("[LeadInterest]", strQA);
                        strEmailBody = strEmailBody.Replace("[LeadSource]", strIPLocationDesc);
 
                // SendEmail(CustomerSupport.Utility.SysResource.FromID,strRespEmail,  "Lead Alert from CustomerSupport", strEmailBody);
                //dvForm.Visible = false;
                lblConfirmLead.Visible = true;
            }
        }
        catch { }
    }
    protected void SendEmail(string ToEmailId, string FromEmailId, string Subject, string Message)
    {
        try
        {
            email objEmail = new email();

            objEmail.Sendmail(FromEmailId, ToEmailId, Subject, Message);

        }
        catch
        {
            //do nothing
        }

    }
    public bool isEmail(string inputEmail)
    {
        inputEmail = NullToString(inputEmail);
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(inputEmail))
            return (true);
        else
            return (false);
    }
    public string NullToString(string s)
    {
        return (s == null) ? "" : s.Trim();
    }
}