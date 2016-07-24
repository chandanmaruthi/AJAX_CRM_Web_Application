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
using CustomerSupport.Data;
public partial class _Default : CustomerSupportPage
{

    public int intItemsPerPage = 20;
    public int intPageNo = 1;
    public string strSearch = "";
    public string strSearchAction = "";
    public int intTotalLeads = 0;
    public int intResultStart = 0;
    public int intResultEnd = 0;
    public string strFirstLink = "", strPrevLink = "", strNextLink = "", strLastLink = "";
    public string strAccountId = "";
    public string strLeadStatus = "";
    public string strCategoryID = "";
    public string strProductName = "All";
    public string strStatusName = "New";
    public string strCategoryName = "";
    public string strUserID = "";
    public string strProductID = "";
    public string strLeadBoxClass = "LeadDeck";
    public string strFilterProductID, strFilterLeadStatus, strFilterTagID;
    public string strTagID = "";
    public string strTagName = "";
    public DataSet objAccountLeadStatusData;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strUserID = GetState(CustomerSupport.CustomerSupportPage.UserID).ToString();
            strAccountId = GetState(CustomerSupportPage.AccountID);

            //Response.Write(GetState(CustomerSupportPage.AccountID));
            if (IsPostBack != true)
            {
                BindLeads();
            }
        }
        catch
        {
            throw;
        }
    }
    private void BindLeads()
    {
        try
        {
            Conversation objConversation = new Conversation();
            Products objProducts = new Products();
            DataSet objData, objProductsData;

            
            if (Request["Lead_Status"] == null)
            {
                if (GetState(Filter_Status_ID) == "")
                {
                    SetState(Filter_Status_ID, "970FE4E1-7589-4E12-9DEA-097E831CE793");
                }
                strLeadStatus = GetState(Filter_Status_ID);
            }
            else
            {
                strLeadStatus = Request["Lead_Status"].ToString();

            }




            


            if (Request["Action"] != null && Request["ID"] != null)
            {
                if (Request["Action"] == "Delete" && Request["ID"].Length > 0)
                {
                    objConversation.DeleteConversation(Request["ID"].ToString());
                }
            }

            if (Request["Page_No"] != null)
            {
                intPageNo = int.Parse(Request["Page_No"]);
            }
            else
            {
                intPageNo = 1;
            }
            if (Request["Search"] != null)
            {
                strSearch = Request["Search"].ToString();
            }
            if (Request["Product"] != null)
            {

                strProductID = Request["Product"].ToString();
                SetState(Filter_Product_ID, strProductID);
            }
            else
            {
                strProductID = "";
                SetState(Filter_Product_ID,"");
            }
            if (Request["Category"] != null)
            {

                strCategoryID = Request["Category"].ToString();
                SetState(Filter_Category_ID, strCategoryID);
            }
            else
            {
                strCategoryID = "";
                SetState(Filter_Category_ID,"");
            }
            

            if (Request["Tag"] != null)
            {

                strTagID = Request["Tag"].ToString();
                SetState(Filter_Tag_ID, strTagID);
            }
            else
            {
                strTagID = "";
                SetState(Filter_Tag_ID,"");
            }

            if (strSearch == "")
            {
                objData = objConversation.GetConversationsByAccount(GetState(CustomerSupportPage.AccountID), intItemsPerPage, intPageNo, strLeadStatus,strCategoryID, strProductID, strTagID,false, ref intTotalLeads);
            }
            else
            {
                SetState(Filter_Product_ID,"");
                SetState(Filter_Status_ID,"");
                SetState(Filter_Tag_ID,"");
                SetState(Filter_Category_ID, "");
                lblSearchMessage.Text = "Search Results for '" + strSearch + "',  <a href='" + CustomerSupport.Utility.SysResource.HomePath + "manage/manageleads.aspx?Page_No=1" + "'><u> clear search</u></a>";
                lblSearchMessage.Visible = true;
                objData = objConversation.GetConversationsBySearch(GetState(CustomerSupportPage.AccountID), intItemsPerPage, intPageNo, strSearch, ref intTotalLeads);
            }
            intResultStart = intItemsPerPage * (intPageNo - 1);
            intResultEnd = intResultStart + objData.Tables[0].Rows.Count;

            AccountLeadStatus objAccountLeadStatus = new AccountLeadStatus();

            objAccountLeadStatusData = objAccountLeadStatus.GetAllAccountStatus(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());
            ddlConversationStatus.DataSource=objAccountLeadStatusData.Tables[0];
            ddlConversationStatus.DataTextField = "Status_Name";
            ddlConversationStatus.DataValueField = "Status_ID";

            ddlConversationStatus.DataBind();

            rptrLeadStatus.DataSource = objAccountLeadStatusData.Tables[0];
            rptrLeadStatus.DataBind();

            Account objAccount = new Account();
            DataSet objAccountSeverity;
            objAccountSeverity = objAccount.GetSeverity();
            ddlConversationSeverity.DataSource = objAccountSeverity.Tables[0];
            ddlConversationSeverity.DataTextField = "Severity_Name";
            ddlConversationSeverity.DataValueField = "Severity_ID";

            ddlConversationSeverity.DataBind();

            rptrLeads.DataSource = objData.Tables[0];
            rptrLeads.DataBind();


            objProductsData = objProducts.GetProductDetails(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());

            ddlProducts.DataSource = objProductsData.Tables[0];
            ddlProducts.DataTextField = "Product_Name";
            ddlProducts.DataValueField = "Product_ID";
            ddlProducts.DataBind();

            CategoryTopics objCategoryTopics = new CategoryTopics();
            DataSet objCategoryTopicsData;
            objCategoryTopicsData = objCategoryTopics.GetCategoryTopics(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());
            ddlCategory.DataSource = objCategoryTopicsData.Tables[0];
            ddlCategory.DataTextField = "Display_Category_Name";
            ddlCategory.DataValueField = "Category_ID";
            ddlCategory.DataBind();
            


            if (objData.Tables[1].Rows[0]["Product_Name"].ToString() == "")
            {
                strProductName = "all";
            }
            else
            {
                strProductName = objData.Tables[1].Rows[0]["Product_Name"].ToString();
                
            }

            if (objData.Tables[1].Rows[0]["Conversation_Status_Name"].ToString() == "")
            {
                strStatusName = "all";
            }
            else
            {
                strStatusName = objData.Tables[1].Rows[0]["Conversation_Status_Name"].ToString();
            }
            if (objData.Tables[1].Rows[0]["Category_Name"].ToString() == "")
            {
                strCategoryName = "all";
            }
            else
            {
                strCategoryName = objData.Tables[1].Rows[0]["Category_Name"].ToString();
            }
            if (objData.Tables[1].Rows[0]["Tag_Name"].ToString() == "")
            {
                strTagName= "all";
            }
            else
            {
                strTagName = objData.Tables[1].Rows[0]["Tag_Name"].ToString();
            }
            
            //--------Search--------
            strSearchAction = CustomerSupport.Utility.SysResource.HomePath + "manage/manageleads.aspx?Page_No=1";
            //-------End Of Search --------
            //-----------Paging----------------
            //string strPager = "";

            //int intStartPage = 1;
            int intEndPage = (intTotalLeads / intItemsPerPage) + 1;

            strFirstLink = CustomerSupport.Utility.SysResource.HomePath + "manage/manageleads.aspx?Page_No=1" + "&Search=" + strSearch;
            if (intPageNo == 1)
            {
                strPrevLink = "";
            }
            else
            {
                strPrevLink = CustomerSupport.Utility.SysResource.HomePath + "manage/manageleads.aspx?Page_No=" + (intPageNo - 1) + "&Search=" + strSearch;
            }

            if (intPageNo == intEndPage)
            {
                strNextLink = "";
            }
            else
            {
                strNextLink = CustomerSupport.Utility.SysResource.HomePath + "manage/manageleads.aspx?Page_No=" + (intPageNo + 1) + "&Search=" + strSearch;
            }

            strLastLink = CustomerSupport.Utility.SysResource.HomePath + "manage/manageleads.aspx?Page_No=" + intEndPage + "&Search=" + strSearch;


            if (intPageNo == 1 && (intTotalLeads / intItemsPerPage) < 1)
            {
                imgFirst.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_first_disabled.gif";
                imgPrev.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_previous_disabled.gif";
                imgNext.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_next.gif";
                imgLast.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_last.gif";
            }
            if (intPageNo >= 1 && intPageNo <= (intTotalLeads / intItemsPerPage))
            {
                imgFirst.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_first_disabled.gif";
                imgPrev.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_previous_disabled.gif";
                imgNext.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_next.gif";
                imgLast.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_last.gif";
            }

            if (intPageNo >= (intTotalLeads / intItemsPerPage) + 1)
            {
                imgFirst.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_first.gif";
                imgPrev.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_previous.gif";
                imgNext.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_next_disabled.gif";
                imgLast.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_last_disabled.gif";
            }
            if (intTotalLeads <= intItemsPerPage)
            {
                imgFirst.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_first_disabled.gif";
                imgPrev.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_previous_disabled.gif";
                imgNext.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_next_disabled.gif";
                imgLast.ImageUrl = CustomerSupport.Utility.SysResource.ImagePath + "resultset_last_disabled.gif";
            }
            //for (int i = 1; i <= (intTotalLeads / intItemsPerPage) + 1; i++)
            //{
            //    strPager += "<div class='Pager'> <a href='" + CustomerSupport.Utility.SysResource.HomePath + "ManageLeads.aspx?Page_No=" + i + "'>" + i + "</a></div>";

            //}

            //ltrPager.Text = strPager;
            //Literal1.Text = strPager;

            //---------End of Paging--------------
        }
        catch
        {
            throw;
        }
    }


    protected void rptrLeads_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
              RepeaterItem item = e.Item;
              if ((item.ItemType == ListItemType.Item) ||
                  (item.ItemType == ListItemType.AlternatingItem))
              {
                  //string LeadID = "";

                  //LeadID = ((HiddenField)e.Item.FindControl("hdnLeadID")).Value;
                  //DataTable dt = (DataTable)Cache.Get("Notes");


                  //DataView dv = new DataView();
                  //dv.Table = dt;
                  //dv.RowFilter = "Lead_ID = '" + LeadID.ToUpper() + "'";
                  //dv.Sort = "Date";

                  //Repeater rptr = ((Repeater)e.Item.FindControl("rptrStatus"));
                  //rptr.DataSource = objAccountLeadStatusData.Tables[0];
                  //rptr.DataBind();
              }       
        }
        catch
        {
            throw;
        }

    }
    //protected void rptrLeads_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    string strLeadID = "";
    //    string strNotesDesc = "";
    //    string strStatusID = "";

    //    Lead objLead = new Lead();
    //    bool bolResult1 = false;
    //    bool bolResult2 = false;

    //    bolResult1 = objLead.AddLeadNotes(strLeadID, strNotesDesc);
    //    bolResult2 = objLead.UpdateLeadStatus(strLeadID, strStatusID);

    //}
    //protected void rptrLeads_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    try
    //    {
    //        string strNotes = "";
    //        Lead objLead = new Lead();
    //        bool bolResult = false;
    //        string strStatusID = "";
    //        HtmlSelect objDDl;
    //        strNotes = ((TextBox)e.Item.FindControl("txtNotes")).Text;
    //        objDDl = ((HtmlSelect)e.Item.FindControl("ddlStatus"));
    //        strStatusID = objDDl.Items[objDDl.SelectedIndex].Value;
    //        if (strNotes.Length > 0)
    //        {
    //            bolResult = objLead.AddLeadNotes(e.CommandArgument.ToString(), strNotes, GetState(CustomerSupportPage.UserID), DateTime.Now);
    //        }
    //        if (strStatusID != "")
    //        {
    //            bolResult = objLead.UpdateLeadStatus(e.CommandArgument.ToString(), strStatusID, GetState(CustomerSupportPage.UserID), DateTime.Now);
    //        }
    //        ShowMessage("Lead Updated", true);
    //        BindLeads();
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}
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

  
    protected void ddlProductsSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "manage/manageleads.aspx?Page_No=1&Product=" + ddlProducts.SelectedValue);
        }
        catch
        {
            throw;
        }
    }
}
