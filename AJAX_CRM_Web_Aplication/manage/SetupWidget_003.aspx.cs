using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerSupport;
public partial class manage_SetupWidget_003 : CustomerSupport.CustomerSupportPage
{
    public string strWidgetCode = "";
    public string strwpWidgetCode = "";
    public string strDemoWidgetCode = "";
    public string strAccountID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        strAccountID = GetState(CustomerSupportPage.AccountID);
        //strDemoWidgetCode = "<iframe scrolling='no' width='600px' hspace='0' vspace='0' marginwidth='0' marginheight='0' id='iframeDemo' frameborder='0' \n height='" + 350 + "px' style='overflow: hidden; border: solid 0px;' \n src='" + CustomerSupport.Utility.SysResource.HomePath + "manage/DemoWidget.aspx?id=" + strAccountID + "&Show=V' \n allowtransparency='true'></iframe>";
        strWidgetCode = "<iframe scrolling='no' width='600px'  hspace='0' vspace='0' marginwidth='0' marginheight='0' frameborder='0' \n height='" + 350 + "px' style='overflow: hidden; border: solid 0px;' \n src='" + CustomerSupport.Utility.SysResource.HomePath + "manage/Widget_002.aspx?aid=" + strAccountID + "&Show=V' \n allowtransparency='true'></iframe>";
        string strPre = "", strPost = "";
        getWordpressCode(ref strPre, ref strPost);
        strwpWidgetCode = strPre + strWidgetCode + strPost;
        
    }
    private void getWordpressCode(ref string strPre, ref  string strPost)
    {
        try
        {
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
  
}
