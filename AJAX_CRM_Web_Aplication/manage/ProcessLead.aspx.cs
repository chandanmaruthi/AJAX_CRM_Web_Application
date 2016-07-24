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

public partial class ProcessLead : System.Web.UI.Page
{

    public string strBgImageFileName = "";
    public string strRespEmail = "";
    public string strEmail = "";
    public string strHeader = "";
    public string strFooter = "";
    public string strWidgetID = "";
    public string strQuestionCount = "";
    public string strWidgetName = "";
    public string strImageFileName = "";
    public string strTitleColor = "";
    public string strBackgroundColor = "";
    public string strTextColor = "";
    public string strURlColor = "";
    public string strPhone = "";
    public string strName = "";
    public string strComments = "";
    public string strIP = "";
    public string strIPLocationDesc = "";
    public string strPageURL = "";

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
        dvForm.Visible = true;
        //strPageURL = Request.ServerVariables["HTTP_REFERER"].ToString();
        if (Request["hdnUrl"] != null)
        {
            strPageURL = Request["hdnUrl"].ToString();
        }
        if (Request["hdnEmail"] != null)
        {
            strRespEmail = Request["hdnEmail"].ToString();
        }
        //if (Request["hdnWidgetID"] == null)
        //{
        //    dvForm.Visible = false;
        //    lblConfirmLead.Visible = true;
        //    return;
        //}
        if (Request["hdnWidgetName"] != null)
        {
            strWidgetName = Request["hdnWidgetName"].ToString();
        }
        if (Request["txtMessage"] != null)
        {

            strComments = Request["txtMessage"].ToString();
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
        if (Request["hdnWidgetID"] != null)
        {
            strWidgetID = Request["hdnWidgetID"].ToString();
        }
        if (Request["hdnQuestionCount"] != null)
        {
            strQuestionCount = Request["hdnQuestionCount"].ToString();
        }


        if (strPhone == "Phone" && strEmail == "email" || isEmail(strEmail) == false)
        {
            BindWidget();
            lblMsg.Text = "invalid email id or phone";
            lblMsg.Visible = true;
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
            string strPlan = "";
            objData = objAccount.GetAccountDetailsFromWidget(strWidgetID);
            Conversation objConversation = new Conversation();
            bool bolAddConversation;
            int intHideEmail = 0;
            if (Request["chkHideEmail"] == "on")
            { intHideEmail = 1; }
            else { intHideEmail = 0; }
            int intQuestionCount = 0;
            intQuestionCount = int.Parse(strQuestionCount);

            if (Request["txtMessage"] != null)
        {
            strComments = Request["txtMessage"].ToString();
        }


            string strQA = "";
            for (int intCount = 0; intCount < intQuestionCount; intCount++)
            {
                strQA += Request["hdnQuestionTitle" + intCount] + " : " + Request["ddlOptions" + intCount] + "<br>";
            }

            if (objData.Tables[0].Rows.Count > 0)
            {
                strPlan = objData.Tables[0].Rows[0]["Subscription_Plan"].ToString();
            }
            string strProductID = "";


            bolAddConversation = objConversation.AddConversationFromWidget(strWidgetID,
                                        strPageURL,
                                        strName,
                                        strComments,
                                        strQA,
                                        strPhone,
                                        strEmail,
                                        intHideEmail,
                                        strIP,
                                        strIPLocationDesc,
                                        strProductID);
            if (bolAddConversation == true)
            {
                if (strPlan == "1000")
                {

                    strEmailBody = System.IO.File.ReadAllText(Server.MapPath("../" + CustomerSupport.Utility.SysResource.EmailTemplate_Path + CustomerSupport.Utility.SysResource.TF_ConversationAlert));
                    strEmailBody = strEmailBody.Replace("[LeadTime]", DateTime.Now.ToString());
                    strEmailBody = strEmailBody.Replace("[UserName]", "----Free Plan - Login to Check Leads----");
                    strEmailBody = strEmailBody.Replace("[LeadEmail]", "----Free Plan - Login to Check Leads----");
                    strEmailBody = strEmailBody.Replace("[LeadPhone]", "----Free Plan - Login to Check Leads----");
                    strEmailBody = strEmailBody.Replace("[Title]", strComments);
                    strEmailBody = strEmailBody.Replace("[Product]", strQA);
                    strEmailBody = strEmailBody.Replace("[LeadSource]", strIPLocationDesc);
                }
                else
                {
                    if (intHideEmail != 1)
                    {

                        strEmailBody = System.IO.File.ReadAllText(Server.MapPath("../" + CustomerSupport.Utility.SysResource.EmailTemplate_Path + CustomerSupport.Utility.SysResource.TF_ConversationAlert));
                        strEmailBody = strEmailBody.Replace("[LeadTime]", DateTime.Now.ToString());
                        strEmailBody = strEmailBody.Replace("[LeadName]", strName);
                        strEmailBody = strEmailBody.Replace("[LeadEmail]", strEmail);
                        strEmailBody = strEmailBody.Replace("[LeadPhone]", strPhone);
                        strEmailBody = strEmailBody.Replace("[LeadDesc]", strComments);
                        strEmailBody = strEmailBody.Replace("[LeadInterest]", strQA);
                        strEmailBody = strEmailBody.Replace("[LeadSource]", strIPLocationDesc);
                    }
                    else
                    {
                        strEmailBody = System.IO.File.ReadAllText(Server.MapPath("../" + CustomerSupport.Utility.SysResource.EmailTemplate_Path + CustomerSupport.Utility.SysResource.TF_ConversationAlert));
                        strEmailBody = strEmailBody.Replace("[LeadTime]", DateTime.Now.ToString());
                        strEmailBody = strEmailBody.Replace("[LeadName]", strName);
                        strEmailBody = strEmailBody.Replace("[LeadEmail]", "----Contact Via CustomerSupport----");
                        strEmailBody = strEmailBody.Replace("[LeadPhone]", "----Contact Via CustomerSupport----");
                        strEmailBody = strEmailBody.Replace("[LeadDesc]", strComments);
                        strEmailBody = strEmailBody.Replace("[LeadInterest]", strQA);
                        strEmailBody = strEmailBody.Replace("[LeadSource]", strIPLocationDesc);
                    }
                }
                SendEmail(CustomerSupport.Utility.SysResource.FromID,strRespEmail,  "Lead Alert from CustomerSupport", strEmailBody);

                dvForm.Visible = false;
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
    protected void BindWidget()
    {
        string strOptions = "";
        string[] arrOptions;
        string strRespEmail;
        Table objTable = new Table();
        objTable.CellPadding = 0;
        objTable.CellSpacing = 0;

        TableRow objRow;
        TableCell objCell;
        DataSet objData;
        if (strWidgetID != "")
        {
            //strWidgetID = Request["ID"].ToString();
            LeadWidget objLeadWidget = new LeadWidget();

            objData = objLeadWidget.GetWidget(strWidgetID);

            //strWidgetID = Request["ID"].ToString();


            if (objData.Tables[0].Rows.Count > 0)
            {
                strHeader = objData.Tables[0].Rows[0]["Widget_Header"].ToString();
                strFooter = objData.Tables[0].Rows[0]["Widget_Footer"].ToString();
                //strBgImageFileName = objData.Tables[0].Rows[0]["Layout_Image_File"].ToString();
                strRespEmail = objData.Tables[0].Rows[0]["Contact_Phone_2"].ToString();
                strWidgetName = objData.Tables[0].Rows[0]["Widget_Name"].ToString();
                strImageFileName = objData.Tables[0].Rows[0]["Image_File_Name"].ToString();

                strTitleColor = objData.Tables[0].Rows[0]["Title_Color"].ToString();
                strBackgroundColor = objData.Tables[0].Rows[0]["Background_Color"].ToString();
                strTextColor = objData.Tables[0].Rows[0]["Text_Color"].ToString();
                strURlColor = objData.Tables[0].Rows[0]["URL_Color"].ToString();
                txtEmail.Value = strEmail;
                txtPhone.Value = strPhone;
                txtName.Value = strName;
                
                if (strImageFileName == "" || strImageFileName == "NoImage.gif")
                {
                    imgPicture.Visible = false;
                }
                strQuestionCount = objData.Tables[1].Rows.Count.ToString();
                if (objData.Tables[1].Rows.Count > 0)
                {

                    for (int qCount = 0; qCount < objData.Tables[1].Rows.Count; qCount++)
                    {
                        Label lblQuestionTitle = new Label();
                        lblQuestionTitle.ID = "lblQuestionTitle" + qCount;
                        lblQuestionTitle.Text = objData.Tables[1].Rows[qCount]["Question"].ToString();
                        lblQuestionTitle.CssClass = "LabelSections";


                        HtmlInputHidden hdnQuestionTitle = new HtmlInputHidden();
                        hdnQuestionTitle.ID = "hdnQuestionTitle" + qCount;
                        hdnQuestionTitle.Value = objData.Tables[1].Rows[qCount]["Question"].ToString();

                        HtmlSelect ddlOptions = new HtmlSelect();
                        ddlOptions.Items.Clear();
                        ddlOptions.ID = "ddlOptions" + qCount;
                        ddlOptions.Attributes.Add("Class", "DDLSections");

                        strOptions = objData.Tables[1].Rows[qCount]["Options"].ToString();
                        arrOptions = strOptions.Split(',');

                        foreach (string strOption in arrOptions)
                        {
                            ddlOptions.Items.Add(strOption);
                        }
                        objRow = new TableRow();
                        objCell = new TableCell();
                        objCell.Controls.Add(lblQuestionTitle);
                        objCell.Controls.Add(hdnQuestionTitle);

                        objRow.Cells.Add(objCell);
                        objTable.Rows.Add(objRow);

                        objRow = new TableRow();
                        objCell = new TableCell();
                        objCell.Controls.Add(ddlOptions);
                        objRow.Cells.Add(objCell);
                        objTable.Rows.Add(objRow);


                    }
                    pnlQuestions.Controls.Add(objTable);
                }
            }
        }
    }
}