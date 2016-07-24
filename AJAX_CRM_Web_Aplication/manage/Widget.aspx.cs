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
using System.Net;
using CustomerSupport.Data;
public partial class Widget : System.Web.UI.Page
{
    public string strBgImageFileName = "";
    public string strRespEmail = "";
    public string strHeader = "";
    public string strFooter = "";
    public string strWidgetID = "";
	public string strQuestionCount = "0";
	public string strWidgetName = "";
	public string strImageFileName = "";
	public string strTitleColor = "";
	public string strBackgroundColor = "";
	public string strTextColor = "";
	public string strURlColor = "";
    public string strAccountID = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Page.IsPostBack != true)
            {
                BindWidget();
            }
        }
        catch
        {
        }

    }
    protected void BindWidget()
    {
        string strOptions = "";
        string[] arrOptions;
        Table objTable = new Table();
        objTable.CellPadding = 0;
        objTable.CellSpacing = 0;

        TableRow objRow;
        TableCell objCell;
        if (Request["ID"] != null)
        {
            strWidgetID = Request["ID"].ToString();

            LeadWidget objLeadWidget = new LeadWidget();
            DataSet objData;
            objData = objLeadWidget.GetWidget(strWidgetID);


            if (objData.Tables[0].Rows.Count > 0)
            {
                strHeader = objData.Tables[0].Rows[0]["Widget_Header"].ToString();
                strFooter = objData.Tables[0].Rows[0]["Widget_Footer"].ToString();
                //strBgImageFileName = objData.Tables[0].Rows[0]["Layout_Image_File"].ToString();
                //strRespEmail = objData.Tables[0].Rows[0]["Contact_Phone_2"].ToString();
                strWidgetName = objData.Tables[0].Rows[0]["Widget_Name"].ToString();
                strImageFileName = objData.Tables[0].Rows[0]["Image_File_Name"].ToString();
                strTitleColor = objData.Tables[0].Rows[0]["Title_Color"].ToString();
                strBackgroundColor = objData.Tables[0].Rows[0]["Background_Color"].ToString();
                strTextColor = objData.Tables[0].Rows[0]["Text_Color"].ToString();
                strURlColor = objData.Tables[0].Rows[0]["URL_Color"].ToString();
                strAccountID = objData.Tables[0].Rows[0]["Account_ID"].ToString();
                if (strImageFileName == "" || strImageFileName == "NoImage.gif")
                {
                    imgPicture.Visible = false;
                }

            }
            else
            {
                dvForm.Visible = false;
                return;
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
