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
using CustomerSupport;
using CustomerSupport.Data;
public partial class Branding : CustomerSupportPage
{
    public string strPBackgroundColor = "", strHeaderColor = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            BindValues();
        }
    }


    protected void BindValues()
    {
        Account objAccount = new Account();
        //bool bolResult;
        DataSet objBrandingData;
        objBrandingData = objAccount.GetAccountBrandingDetails(GetState(CustomerSupportPage.AccountID));

        if (objBrandingData.Tables[0].Rows.Count > 0)
        {
            txtBackgroundColor.Value = objBrandingData.Tables[0].Rows[0]["Background_Color"].ToString();
            strPBackgroundColor = objBrandingData.Tables[0].Rows[0]["Background_Color"].ToString();
            txtHeaderColor.Value = objBrandingData.Tables[0].Rows[0]["Font_Color"].ToString();
            strHeaderColor = objBrandingData.Tables[0].Rows[0]["Font_Color"].ToString();
            txtHeader.Value = objBrandingData.Tables[0].Rows[0]["Header_Text"].ToString();
            txtWelcomeMessage.Value = objBrandingData.Tables[0].Rows[0]["Welcome_Message"].ToString();
            txtActiveTabBgColor.Value = objBrandingData.Tables[0].Rows[0]["Active_Tab_Bg_Color"].ToString();
            txtActiveTabTextColor.Value = objBrandingData.Tables[0].Rows[0]["Active_Tab_Text_Color"].ToString();
            txtInActiveTabBgColor.Value = objBrandingData.Tables[0].Rows[0]["InActive_Tab_Bg_Color"].ToString();
            txtInActiveTabTextColor.Value = objBrandingData.Tables[0].Rows[0]["InActive_Tab_Text_Color"].ToString();


            //uplTheFile.Value = objBrandingData.Tables[0].Rows[0]["Logo_File"].ToString();
            imgWidgetImage.ImageUrl = CustomerSupport.Utility.SysResource.UserData + "UserImages/" + GetState(CustomerSupportPage.AccountID) +"/"+ objBrandingData.Tables[0].Rows[0]["Logo_File"].ToString();
        }

    }
    protected void lnkSave_Click(object sender, EventArgs e)
    {


        string strBackgroundColor = "", strHeaderFontColor = "", strHeaderText = "", strWelcomeMessage = "", strLogoFile = "", strActive_Tab_Bg_Color = "", strActive_Tab_Text_Color = "", strInActive_Tab_Bg_Color = "", strInActive_Tab_Text_Color = "";
        strBackgroundColor = txtBackgroundColor.Value;
        strHeaderFontColor = txtHeaderColor.Value;
        strHeaderText = txtHeader.Value;
        strWelcomeMessage = txtWelcomeMessage.Value;
        strLogoFile = uplTheFile.Value;
        strActive_Tab_Bg_Color = txtActiveTabBgColor.Value;
        strActive_Tab_Text_Color = txtActiveTabTextColor.Value;
        strInActive_Tab_Bg_Color = txtInActiveTabBgColor.Value;
        strInActive_Tab_Text_Color = txtInActiveTabTextColor.Value;

        Account objAccount = new Account();
        bool bolResult;
        bolResult = objAccount.UpdateAccountBranding(GetState(CustomerSupportPage.AccountID), strLogoFile, strBackgroundColor, strHeaderFontColor, strHeaderText, strWelcomeMessage,strActive_Tab_Bg_Color,strActive_Tab_Text_Color,strInActive_Tab_Bg_Color,strInActive_Tab_Text_Color);
        if (strLogoFile.Length > 0)
        {
            UploadImage();
        }
        InitializeAccount();
    }
    public void UploadImage()
    {
        string strWidgetID = "";
        string strFileNameOnServer = "";// txtServername.Value;
        string strPath = HttpRuntime.AppDomainAppPath;
        strPath.Replace(@"\", @"\\");
        string strBaseLocation = MapPath("~//UserData//") + "UserImages/" + GetState(CustomerSupportPage.AccountID) + "/";
        strWidgetID = Request["ID"];
        LeadWidget objLeadWidget = new LeadWidget();
        string strImageType = "";
        ImageFormat imgformat = ImageFormat.Jpeg;
        Account objAccount=new Account();
        //Response.Write(strBaseLocation);
        //return;

        if (Directory.Exists(MapPath("~\\UserData") + "\\UserImages\\" + GetState(CustomerSupportPage.AccountID)) != true)
        {
            Directory.CreateDirectory(MapPath("~\\UserData") + "\\UserImages\\" + GetState(CustomerSupportPage.AccountID));
        }
        if (uplTheFile.PostedFile.FileName == "")
        {
            //do nothing
            return;
        }
        strImageType = uplTheFile.PostedFile.FileName.Substring(uplTheFile.PostedFile.FileName.IndexOf('.'), 4);
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

        strFileNameOnServer = "Image" + strWidgetID + strImageType;

        if ("" == strFileNameOnServer)
        {
            txtOutput.InnerHtml = "Error - a file name must be specified.";
            return;
        }

        if (null != uplTheFile.PostedFile)
        {
            try
            {

                uplTheFile.PostedFile.SaveAs(strBaseLocation + strFileNameOnServer);
                txtOutput.InnerHtml = "File uploaded successfully";
                uplTheFile.Dispose();
                ResizeImage(strBaseLocation + strFileNameOnServer, strBaseLocation + "small_" + strFileNameOnServer, imgformat, 20);
                

                objAccount.UpdateAccountLogo(GetState(CustomerSupportPage.AccountID), "small_Image" + strWidgetID + strImageType);

                imgWidgetImage.ImageUrl = CustomerSupport.Utility.SysResource.UserData + "UserImages/" + GetState(CustomerSupportPage.AccountID) + "/small_Image" + strWidgetID + strImageType;
                
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
            

            using (Bitmap img = new Bitmap(fileName) )
            {
                int width = 0;
                int height = 0;
                int intDimension = 150;
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
                System.Drawing.Image thumbNail = new Bitmap(width, height);
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
        catch (Exception)
        {
            return false;
        }
    }
}
