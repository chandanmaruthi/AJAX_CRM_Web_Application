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
public partial class Help : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        }
        catch
        {
            throw;
        }
    }
    protected void lnkSendEmail_Click(object sender, EventArgs e)
    {
        try
        {
            string strConversationID;
            DataSet objData;
            string strEmailID = "";
            bool bolResult;
            CustomerSupportPage objCustomerSupportPage = new CustomerSupportPage();
            strConversationID = Request["ID"].ToString();
            Conversation objConversation = new Conversation();
            objData = objConversation.GetConverationByID(strConversationID);
            if (objData.Tables[0].Rows.Count > 0)
            {
                strEmailID = objData.Tables[0].Rows[0]["Lead_Email"].ToString();

            }

            email objEmail = new email();
            bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, strEmailID, "Response to your Question", txtMessage.Value + "<br><br> Sent by " + objCustomerSupportPage.GetState(CustomerSupportPage.Email_ID));
            if (bolResult == true)
            {
                txtMessage.Visible = false;
                lnkSendEmail.Visible = false;
                lblMessage.Text = "Message Sent Successfully ";
            }
        }
        catch
        {
            throw;
        }

    }
}
