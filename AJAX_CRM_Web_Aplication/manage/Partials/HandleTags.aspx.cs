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
public partial class Partials_HandleTags : CustomerSupportPage
{
    public string strNotes = "";
    public string strTagID = "";
    public string strAccountID = "", strTagName = "" ;
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
            Tags objTags = new Tags();
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


            if (Request["TagID"] != null)
            {
                strTagID = Request["TagID"].ToString();
                //Product_ID = Request["UserID"].ToString();
            }
            if (strAction == "A")
            {

                HandleAddTags();
            }
            else if (strAction == "D")
            {
                bolResult = objTags.DeleteTag(strTagID);

                DataSet objdata;
                objdata = objTags.GetUserTags(strAccountID);
                rptrViewTags.DataSource = objdata.Tables[0];
                rptrViewTags.DataBind();
                pnlViewTags.Visible = true;
            }
            else if (strAction == "ATL")
            {
                HandleAddTagsToLead();
            }
            
            else if (strAction == "DTL")
            {
                HandleDeleteTagsToLead();
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
            
            Tags objTags=new Tags();
            string strAccountID = "";
                if (Request["Name"] != null)
            {
                strAccountID = Request["AccountID"].ToString();
                if (strAccountID.Length == 0) { strErrorString += "Tag Name Required"; }
            }
            if (Request["Name"] != null)
            {
                strTagName = Request["Name"].ToString();
                if (strTagName.Length == 0) { strErrorString += "Tag Name Required"; }

                bool bolTagExists = false;
                bolTagExists = objTags.bolTagNameExists(strTagName);
                if (bolTagExists == true)
                {
                    strErrorString += "Tag Already Exists"; 
                }
            }

          
            if (strErrorString.Length == 0)
            {
                bool objResult = objTags.AddTags(strAccountID, strTagName);

                DataSet objdata;
                objdata = objTags.GetUserTags(strAccountID);
                rptrViewTags.DataSource = objdata.Tables[0];
                rptrViewTags.DataBind();
                pnlViewTags.Visible = true;
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
    private void HandleAddTagsToLead()
    {
        try
        {

            Tags objTags = new Tags();


            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
                //if (strTagName.Length == 0) { strErrorString += "Tag Name Required"; }
            }

            if (Request["Tag_ID"] != null)
            {
                strTagID = Request["Tag_ID"].ToString();
                //if (strTagName.Length == 0) { strErrorString += "Tag Name Required"; }
            }

            if (strErrorString.Length == 0)
            {
                bool objResult = objTags.AddTagToLead(strLeadID, strTagID);

                DataSet objdata;
                objdata = objTags.GetLeadTags(strLeadID,strAccountID);
                rptrLeadTags.DataSource = objdata.Tables[0];
                rptrLeadTags.DataBind();
                rptrAllTags.DataSource = objdata.Tables[1];
                rptrAllTags.DataBind();
                pnlAddTagsToLead.Visible = true;
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
    private void HandleDeleteTagsToLead()
    {
        try
        {

            Tags objTags = new Tags();


            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
                //if (strTagName.Length == 0) { strErrorString += "Tag Name Required"; }
            }

            if (Request["Tag_ID"] != null)
            {
                strTagID = Request["Tag_ID"].ToString();
                //if (strTagName.Length == 0) { strErrorString += "Tag Name Required"; }
            }

            if (strErrorString.Length == 0)
            {
                bool objResult = objTags.RemoveTagFromLead(strLeadID, strTagID);

                DataSet objdata;
                objdata = objTags.GetLeadTags(strLeadID, strAccountID);
                rptrLeadTags.DataSource = objdata.Tables[0];
                rptrLeadTags.DataBind();
                rptrAllTags.DataSource = objdata.Tables[1];
                rptrAllTags.DataBind();
                pnlAddTagsToLead.Visible = true;
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
