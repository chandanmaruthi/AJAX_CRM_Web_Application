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
public partial class RedeemCoupon : CustomerSupportPage
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
    protected void RedeemCouponCode(string strAccountID)
    {
        try
        {
            Account objAccount = new Account();
            bool bolRedeemResult = false;

            bolRedeemResult = objAccount.bolRedeemCoupon(strAccountID, txtCouponCode.Text);

            if (bolRedeemResult == true)
            {
                Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "OrderPlaced.aspx?purchase_currency=1001");
            }
            else
            {
                ShowMessage("Invalid or Expired Coupon", true);
            }
        }
        catch
        {
            throw;
        }
    }
    protected void ShowMessage(string strMessage, bool bolShow)
    {
        try
        {
            divMessage.Visible = bolShow;
            lblMessage.Text = strMessage;
        }
        catch
        {
            throw;
        }
    }

    protected void lnkRedeem_Click(object sender, EventArgs e)
    {
        try
        {
            RedeemCouponCode(GetState(CustomerSupportPage.AccountID));

        }
        catch
        {
            throw;
        }
    }
}
