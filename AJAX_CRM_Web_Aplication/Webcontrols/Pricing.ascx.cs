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

public partial class Webcontrols_Pricing : System.Web.UI.UserControl
{
    private string sPageAction;
    public string PageAction
    {
        get { return sPageAction; }
        set { sPageAction = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try{
        if (sPageAction == "ShowCart")
        {
            PlanA.Visible = true;
            PlanB.Visible = true;
            PlanC.Visible = true;
            PlanF.Visible = true;
            sPlanA.Visible = false;
            sPlanB.Visible = false;
            sPlanC.Visible = false;
            sPlanF.Visible = false;
        }
        else
        {
            PlanA.Visible = false;
            PlanB.Visible = false;
            PlanC.Visible = false;
            PlanF.Visible = false;
            sPlanA.Visible = true;
            sPlanB.Visible = true;
            sPlanC.Visible = true;
            sPlanF.Visible = true;
        }
    }
    catch
    {
        throw;
    }
    }
}
