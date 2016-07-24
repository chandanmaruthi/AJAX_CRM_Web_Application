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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CustomerSupport;
using CustomerSupport.Data;
public partial class UploadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void btnUploadTheFile_Click(object Source, EventArgs evArgs)
    {
        try
        {
            string strWidgetID = "";
            string strFileNameOnServer = "";// txtServername.Value;
            string strPath = HttpRuntime.AppDomainAppPath;
            strPath.Replace(@"\", @"\\");
            string strBaseLocation = "UserImages/";
            strWidgetID = Request["WidgetID"];
            LeadWidget objLeadWidget = new LeadWidget();
            //Response.Write(strBaseLocation);
            //return;
            strFileNameOnServer = "Image" + strWidgetID + ".jpg";
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
                    ImageFormat imgformat = ImageFormat.Jpeg;
                    ResizeImage(Server.MapPath(strBaseLocation + strFileNameOnServer).ToString(), Server.MapPath(strBaseLocation + "small_" + strFileNameOnServer), imgformat, 20);
                    objLeadWidget.UpdateWidgetImage(strWidgetID, "small_Image" + strWidgetID + ".jpg");
                    imgWidgetImage.ImageUrl = CustomerSupport.Utility.SysResource.HomePath + "UserImages/" + "small_Image" + strWidgetID + ".jpg";
                }
                catch (Exception e)
                {
                    txtOutput.InnerHtml = "Error saving <b>" +
                      strBaseLocation + strFileNameOnServer + "</b><br>" + e.ToString();
                }

            }
        }
        catch
        {
            throw;
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
}
