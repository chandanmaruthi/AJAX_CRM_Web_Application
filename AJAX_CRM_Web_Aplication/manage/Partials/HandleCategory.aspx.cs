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
public partial class Partials_HandleCategory : CustomerSupportPage
{
    public string strNotes = "";
    public string strCategoryID = "";
    public string strAccountID = "", strCategoryName = "", strParentCategoryID="";
    string strErrorString = "";
    bool bolResult = false;
    public string strLeadID = "";
    string strAction = "A";
    //bool bolResult = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bolResult = false;
            CategoryTopics objCategoryTopics = new CategoryTopics();
            //Products objProduct = new Products();

            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
            }
            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();
            }
            strAccountID = GetState(CustomerSupportPage.AccountID);


            if (Request["CategoryID"] != null)
            {
                strCategoryID = Request["CategoryID"].ToString();
                //Product_ID = Request["UserID"].ToString();
            }
            if (Request["ParentCategoryID"] != null)
            {
                strParentCategoryID = Request["ParentCategoryID"].ToString();
                //Product_ID = Request["UserID"].ToString();
            }
            
            if (strAction == "A")
            {

                HandleAddTags();
            }
            else if (strAction == "D")
            {
                bolResult = objCategoryTopics.DeleteCategoryTopics(strCategoryID,strAccountID);

                DataSet objdata;
                objdata = objCategoryTopics.GetCategoryTopics(strAccountID);
                rptrViewCategory.DataSource = objdata.Tables[0];
                rptrViewCategory.DataBind();
                pnlViewCategory.Visible = true;
            }
           
        }
        catch
        {
            throw;
        }
    }
    private void HandleAddTags()
    {
        try
        {

            CategoryTopics objCategoryTopics = new CategoryTopics();
            string strAccountID = "";
                if (Request["Name"] != null)
            {
                strAccountID = Request["AccountID"].ToString();
                if (strAccountID.Length == 0) { strErrorString += "Category Name Required"; }
            }
            if (Request["Name"] != null)
            {
                strCategoryName = Request["Name"].ToString();
                if (strCategoryName.Length == 0) { strErrorString += "Category Name Required"; }
                bool bolCategoryNamerExists=false;
                bolCategoryNamerExists = objCategoryTopics.bolCategoryNameExists(strCategoryName);
                if (bolCategoryNamerExists == true)
                {
                    strErrorString += "Category Already Exists"; 
                }


            }


          
            if (strErrorString.Length == 0)
            {
                bool objResult = objCategoryTopics.AddCategoryTopics(strAccountID, strCategoryName,strCategoryName,strParentCategoryID);

                DataSet objdata;
                objdata = objCategoryTopics.GetCategoryTopics(strAccountID);
                rptrViewCategory.DataSource = objdata.Tables[0];
                rptrViewCategory.DataBind();
                pnlViewCategory.Visible = true;
            }
            else
            {
                Response.Clear();
                Response.Write("ERROR: " + strErrorString);
                return;
            }
        }
        catch
        {
            throw;
        }
    }

}
