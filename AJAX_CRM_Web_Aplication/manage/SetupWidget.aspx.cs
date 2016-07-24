using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CustomerSupport.Data;
using CustomerSupport;
public partial class _Default : CustomerSupport.CustomerSupportPage
{
    string chAction = "V";
    public string strWidgetCode;
    public string strwpWidgetCode;
    public string strDemoWidgetCode;
    Table objTable = new Table();
    TableRow objRow = new TableRow();
    TableCell objCell = new TableCell();
    protected void Page_Load(object sender, EventArgs e)
    {
        try{

            strWidgetCode = "<img src='" + CustomerSupport.Utility.SysResource.ImagePath + "SampleWidget.gif" + "' border=0>";
        if (Request["ID"] != null)
        {
            lnkAddNewQuestion.HRef = CustomerSupport.Utility.SysResource.HomePath + "manage/SetupWidget.aspx?Action=AddQ&ID=" + Request["ID"].ToString();
        }
        if (Request["Action"] == null)
        {
            chAction = "V";
        }
        if (Request["Action"] != null)
        {
            if (Request["Action"] == "Add")
            { chAction = "A"; lblNoQuestions.Visible = true; lnkAddNewQuestion.Visible = false; }
            else if (Request["Action"] == "Edit")
            { chAction = "E"; }
            else if (Request["Action"] == "Delete")
            { chAction = "D"; }
            else if (Request["Action"] == "AddQ")
            { chAction = "AQ"; }
            else if (Request["Action"] == "DelQ")
            { chAction = "DQ"; }
        }

        if (Page.IsPostBack != true)
        {
            switch (chAction)
            {
                case "V": pnlAddEditWidget.Visible = false; break;
                case "E": pnlAddEditWidget.Visible = true; BingWidget(); break;
                case "AQ": AddQuestion_Click(); pnlAddEditWidget.Visible = true; BingWidget(); break;
                case "DQ": DeleteQuestion_Click(); pnlAddEditWidget.Visible = true; BingWidget(); break;
                default: pnlAddEditWidget.Visible = false; break;
            }
        }
    }
    catch
    {
        throw;
    }
    }


    private void BingWidget()
    {
        try{
        LeadWidget objLeadWidget = new LeadWidget();
        DataSet objData;
        int intWidgetHeight;

        objData = objLeadWidget.GetWidget(Request["ID"].ToString());

        intWidgetHeight = 290 + objData.Tables[1].Rows.Count * 40;


        strDemoWidgetCode = "<iframe scrolling='no' width='140px' hspace='0' vspace='0' marginwidth='0' marginheight='0' id='iframeDemo' frameborder='0' \n height='" + intWidgetHeight.ToString() + "px' style='overflow: hidden; border: solid 0px;' \n src='" + CustomerSupport.Utility.SysResource.HomePath + "manage/DemoWidget.aspx?id=" + Request["ID"].ToString() + "&Show=V' \n allowtransparency='true'></iframe>";
        strWidgetCode = "<iframe scrolling='no' width='140px'  hspace='0' vspace='0' marginwidth='0' marginheight='0' frameborder='0' \n height='" + intWidgetHeight.ToString() + "px' style='overflow: hidden; border: solid 0px;' \n src='" + CustomerSupport.Utility.SysResource.HomePath + "manage/Widget.aspx?id=" + Request["ID"].ToString() + "&Show=V' \n allowtransparency='true'></iframe>";
        string strPre = "", strPost = "";
        getWordpressCode(ref strPre, ref strPost);
        strwpWidgetCode = strPre + strWidgetCode + strPost;
        hdnQuestionCount.Value = objData.Tables[1].Rows.Count.ToString();

        if (objData.Tables[0].Rows.Count > 0)
        {

            txtWidgetName.Text = objData.Tables[0].Rows[0]["Widget_Name"].ToString();
            txtHeaderMessage.Text = objData.Tables[0].Rows[0]["Widget_Header"].ToString();
            txtFooterMessage.Text = objData.Tables[0].Rows[0]["Widget_Footer"].ToString();
            txtTitle.Value = objData.Tables[0].Rows[0]["Title_Color"].ToString();
            txtBackground.Value = objData.Tables[0].Rows[0]["Background_Color"].ToString();
            txtURL.Value = objData.Tables[0].Rows[0]["URL_Color"].ToString();
            txtText.Value = objData.Tables[0].Rows[0]["Text_Color"].ToString();
            imgWidgetImage.ImageUrl = CustomerSupport.Utility.SysResource.UserData + "UserImages/" + GetState(CustomerSupportPage.AccountID) + "/" + objData.Tables[0].Rows[0]["Image_File_Name"].ToString();
           

        }
        if (objData.Tables[1].Rows.Count > 0)
        {

            HtmlInputHidden hdnQuestionID = new HtmlInputHidden();
            int qCount = 0;
            for (qCount = 0; qCount < objData.Tables[1].Rows.Count; qCount++)
            {

                objTable = new Table();
                objTable.CssClass = "WidgetQuestionsContainer";
                hdnQuestionID = new HtmlInputHidden();
                hdnQuestionID.ID = "hdnQuestionID" + qCount;
                hdnQuestionID.Value = objData.Tables[1].Rows[qCount]["Question_ID"].ToString();

                HtmlInputText txtQuestion = new HtmlInputText();
                txtQuestion.ID = "txtQuestion" + qCount;
                txtQuestion.Value = objData.Tables[1].Rows[qCount]["Question"].ToString();

                HtmlTextArea txtOptions = new HtmlTextArea();
                txtOptions.ID = "txtOptions" + qCount;
                txtOptions.Value = objData.Tables[1].Rows[qCount]["Options"].ToString().Replace(",", "\r\n");

                objRow = new TableRow();

                objCell = new TableCell();
                objCell.Text = "Question";
                objRow.Cells.Add(objCell);

                objCell = new TableCell();
                objCell.Controls.Add(txtQuestion);
                objCell.Controls.Add(hdnQuestionID);
                objRow.Cells.Add(objCell);

                objCell = new TableCell();
                objCell.Text = "<a title='Delete Question' href='" + CustomerSupport.Utility.SysResource.HomePath + "manage/SetupWidget.aspx?Action=DelQ&QID=" + objData.Tables[1].Rows[qCount]["Question_ID"].ToString() + "&ID=" + Request["ID"].ToString() + "' onclick=\"return confirm('Are you sure you want to delete?'\">" + "<img src='" + CustomerSupport.Utility.SysResource.ImagePath + "delete.png' border=0></a>";
                objRow.Cells.Add(objCell);

                objTable.CellPadding = 0;
                objTable.CellSpacing = 0;
                objTable.Width = Unit.Pixel(250);


                objTable.Rows.Add(objRow);

                objRow = new TableRow();

                objCell = new TableCell();
                objCell.Text = "Options";
                objRow.Cells.Add(objCell);
                Label objLabel = new Label();
                objLabel.Text = "<br>[enter 1 option per line]";
                objCell = new TableCell();
                objCell.Controls.Add(txtOptions);
                objCell.Controls.Add(objLabel);
                objRow.Cells.Add(objCell);



                objTable.Rows.Add(objRow);
                pnlQuestions.Controls.Add(objTable);




            }




        }
        else
        {
            lblNoQuestions.Visible = true;
            pnlQuestions.Controls.Add(objTable);

        }
    }
    catch
    {
        throw;
    }
    }
    void DeleteQuestion_Click()
    {
        try{
        LeadWidget objWidget = new LeadWidget();
        bool bolResult = false;
        bolResult = objWidget.DeleteWidgetQuestion(Request["QID"].ToString());
    }
    catch
    {
        throw;
    }
    }
    void AddQuestion_Click()
    {
        try{
        string strQuestionID = "";
        LeadWidget objWidget = new LeadWidget();
        HtmlInputHidden hdnQuestionID = new HtmlInputHidden();


        strQuestionID = objWidget.AddWidgetQuestions(Request["ID"].ToString(), "New Question", "Option 1");
        ShowMessage("Question Added", true);

        //hdnQuestionID = new HtmlInputHidden();
        //hdnQuestionID.ID = "hdnQuestionID" + e.CommandArgument.ToString();
        //hdnQuestionID.Value = strQuestionID;

    }
    catch
    {
        throw;
    }

    }


    private void BindWidgetLayouts()
    {
        try{
        //WidgetLayout objWidgetLayout = new WidgetLayout();
        //DataSet objData = objWidgetLayout.GetWidgetLayouts();
        //Response.Write(objData.Tables[0].Rows.Count);
        //rptrLayouts.DataSource = objData;
        //rptrLayouts.DataBind();
        //hdnSelectedLayout.Value = objData.Tables[0].Rows[0]["Layout_ID"].ToString();
        //ddlStyles.DataSource = objData;
        //ddlStyles.DataTextField = "Layout_Name";
        //ddlStyles.DataValueField = "Layout_ID";
        //ddlStyles.DataBind();
        }
        catch
        {
            throw;
        }
    }
    protected void lnkAddEditWidget_Click(object sender, EventArgs e)
    {
        try{
        LeadWidget objWidget = new LeadWidget();
        string strWidgetID = "";
        //string strQuestionID = "";
        bool bolResult;
        string strOptions = "";

        if (Request["ID"] != null)
        {
            strWidgetID = Request["ID"].ToString();
        }
        else
        { return; }



        bolResult = objWidget.UpdateWidget(strWidgetID,
                                        txtWidgetName.Text,
                                        txtHeaderMessage.Text,
                                        txtFooterMessage.Text,
                                       "",
                                        GetState(CustomerSupport.CustomerSupportPage.AccountID),
                                        txtBackground.Value,
                                        txtText.Value,
                                        txtURL.Value,
                                        txtTitle.Value);

        UploadImage();

        if (hdnQuestionCount != null)
        {
            int intTotalQuestions = 0;
            intTotalQuestions = int.Parse(hdnQuestionCount.Value);
            string strQuestion = "";

            for (int intQCount = 0; intQCount < intTotalQuestions; intQCount++)
            {

                //HtmlTextArea txtOptions = this.Page.FindControl("ctl00_ContentBody_"+"txtOptions" + intQCount) as HtmlTextArea;
                if (Request["ctl00$ContentBody$" + "txtOptions" + intQCount.ToString()] != null)
                {
                    strOptions = Request["ctl00$ContentBody$" + "txtOptions" + intQCount.ToString()].ToString().Replace("\r\n", ",");
                }
                //HtmlInputText txtQuestion = this.Page.FindControl("ctl00_ContentBody_"+"txtQuestion" + intQCount) as HtmlInputText;
                if (Request["ctl00$ContentBody$" + "txtQuestion" + intQCount.ToString()] != null)
                {
                    strQuestion = Request["ctl00$ContentBody$" + "txtQuestion" + intQCount.ToString()].ToString();
                }
                bolResult = objWidget.UpdateWidgetQuestions(Request["ctl00$ContentBody$hdnQuestionID" + intQCount.ToString()].ToString(), Request["ID"].ToString(), strQuestion, strOptions);
            }

        }


        if (bolResult == true)
        {
            ShowMessage("Widget Saved", true);
            BingWidget();
            //Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "SetupWidget.aspx?Action=Edit&ID=" + Request["ID"].ToString());
            // Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "SetupWidget.aspx?");
        }
    }
    catch
    {
        throw;
    }
    }

    //protected void rptrViewWidgets_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "SetupWidget.aspx?Action=Add&ID=");
    //}
    protected void ShowMessage(string strMessage, bool bolShow)
    {
        try{
        divMessage.Visible = bolShow;
        lblMessage.Text = strMessage;
    }
    catch
    {
        throw;
    }
    }



    private void getWordpressCode(ref string strPre, ref  string strPost)
    {
        try{
        strPre = "";
        strPre += "\n<?php ";
        strPre += "\n/* ";
        strPre += "\nPlugin Name: delightDeskWidget ";
        strPre += "\nPlugin URI: http://www.CustomerSupport.com ";
        strPre += "\nDescription: This is a wordpress plugin to show <a href='http://www.CustomerSupport.com'>delightDeskwidgets</a> on your Blog. ";
        strPre += "\nAuthor: delightDesk";
        strPre += "\nVersion: 0.1  ";
        strPre += "\nAuthor URI: http://www.CustomerSupport.com/ ";
        strPre += "\n*/ ";

        strPre += "\nfunction widget_leadgini_data(){?> ";

        strPost += "\n<?php ";
        strPost += "\n} ";

        strPost += "\nfunction widget_leadgini() { ";
        strPost += "\n	if ( !function_exists('register_sidebar_widget') ) ";
        strPost += "\n		return; ";
        strPost += "\n		register_sidebar_widget('delightDeskWidget', 'widget_leadgini_data'); ";
        strPost += "\n} ";
        strPost += "\nadd_action('plugins_loaded', 'widget_leadgini'); ";
        strPost += "\n?>";
    }
    catch
    {
        throw;
    }
    }
    public void UploadImage()
    {
        string strWidgetID = "";
        string strFileNameOnServer = "";// txtServername.Value;
        string strPath = HttpRuntime.AppDomainAppPath;
        strPath.Replace(@"\", @"\\");
        string strBaseLocation =  "~/UserData/UserImages/" + GetState(CustomerSupportPage.AccountID)+"/";
        strWidgetID = Request["ID"];
        LeadWidget objLeadWidget = new LeadWidget();
        string strImageType = "";
        ImageFormat imgformat = ImageFormat.Jpeg;
        //Response.Write(strBaseLocation);
        //return;
        if (uplTheFile.PostedFile.FileName == "")
        {
            //do nothing
            return;
        }
        strImageType=uplTheFile.PostedFile.FileName.Substring(uplTheFile.PostedFile.FileName.IndexOf('.'), 4) ;
        strImageType = strImageType.ToLower();
        if (strImageType.ToLower() == ".gif")
        {
            imgformat = ImageFormat.Gif;
        }
        else if (strImageType == ".jpg" || strImageType == ".jpe")
        {
            imgformat = ImageFormat.Jpeg;
            strImageType = ".jpg";
        }

        strFileNameOnServer = "SmallImage" + strWidgetID + strImageType;
        
        if ("" == strFileNameOnServer)
        {
            txtOutput.InnerHtml = "Error - a file name must be specified.";
            return;
        }

        if (null != uplTheFile.PostedFile)
        {
            try
            {

                uplTheFile.PostedFile.SaveAs(Server.MapPath(strBaseLocation + strFileNameOnServer));
                txtOutput.InnerHtml = "File uploaded successfully";
                
                ResizeImage(Server.MapPath(strBaseLocation + strFileNameOnServer).ToString(), Server.MapPath(strBaseLocation + "small_" + strFileNameOnServer), imgformat, 20);
                objLeadWidget.UpdateWidgetImage(strWidgetID, "small_Image" + strWidgetID + strImageType);
                imgWidgetImage.ImageUrl = CustomerSupport.Utility.SysResource.UserData + "UserImages/" + GetState(CustomerSupportPage.AccountID) + "/" + "small_Image" + strWidgetID + strImageType;
            }
            catch (Exception e)
            {
                txtOutput.InnerHtml = "Error saving <b>" +
                  strBaseLocation + strFileNameOnServer + "</b><br>" + e.ToString();
            }
        }
    }
    public bool ResizeImage(string fileName, string imgFileName,
        ImageFormat format, int percent)
    {
        try
        {
            using (System.Drawing.Image img = System.Drawing.Image.FromFile(fileName))
            {
                int width = 0;
                int height = 0;
                int intDimension = 40;
                if (img.Width > img.Height)
                {
                    width = intDimension;
                    height = Convert.ToInt32((intDimension * img.Height) / img.Width);

                }
                else
                {
                    height = intDimension;
                    width = Convert.ToInt32((intDimension * img.Width) / img.Height);

                }
                System.Drawing.Image thumbNail = new Bitmap(width, height, img.PixelFormat);
                Graphics g = Graphics.FromImage(thumbNail);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                Rectangle rect = new Rectangle(0, 0, width, height);
                g.DrawImage(img, rect);
                thumbNail.Save(imgFileName, format);
            }
            return true;
        }
        catch
        {
            return false;
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
                                        GetState(CustomerSupport.CustomerSupportPage.AccountID),
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
}
