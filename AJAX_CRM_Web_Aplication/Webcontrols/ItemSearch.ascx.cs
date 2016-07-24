#region DotNetNamespaces

using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using CustomerSupport.Entity;
using CustomerSupport.Utility;
#endregion

#region CustomNamespaces
using CustomerSupport;
#endregion


public partial class EMall_EStore_Partials_ItemSearch : CustomerSupport.CustomerSupportControl
{
    private string SearchText = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindData();

            Search objSearch = new Search();
            bool bolIsIndexCreated = false;
            objSearch.IsIndexExists(out bolIsIndexCreated);
            if (bolIsIndexCreated == false)
            {
                objSearch.CreateIndex();
            }


            int intPageCount = 0;
            if (Request["PageIndex"].Length > 0)
            { 
                intPageCount = int.Parse(Request["PageIndex"].ToString()); 
            }

            if (Request["st"] != "")
            {
                SearchResult.Text = objSearch.SearchIndex(Request["st"], intPageCount, 25);
            }
        }

    }




}
