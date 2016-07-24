using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerSupport.Data;
using CustomerSupport;
using CustomerSupport.Entity;
public partial class SearchResults : System.Web.UI.Page
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
                SearchResult.Text = objSearch.SearchIndexInternal(Request["st"], intPageCount, 25);
            }
        }

    }

}
