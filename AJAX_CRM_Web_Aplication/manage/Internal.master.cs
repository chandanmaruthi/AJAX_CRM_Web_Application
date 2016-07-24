using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CustomerSupport;
/// <summary>
/// Summary description for Internal
/// </summary>
public partial class Internal : System.Web.UI.MasterPage
{
    
    CustomerSupport.CustomerSupportPage objPage = new CustomerSupport.CustomerSupportPage();
      private int intTab;

    public int SetTab
    {
        get { return intTab; }
        set { intTab = value; }
    }
    public Internal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        lnkCss.Href = CustomerSupport.Utility.SysResource.CSSPath+ "portal.css";
        

    }
    

    

}
