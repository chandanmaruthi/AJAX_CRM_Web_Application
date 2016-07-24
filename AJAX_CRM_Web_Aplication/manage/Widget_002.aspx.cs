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
public partial class Widget_002 : System.Web.UI.Page
{
    public string strAccountID = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
        
            strAccountID=Request["AID"].ToString();
        }
        catch
        {
        }

    }
   


}
