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
public partial class SupportCenter_Products : CustomerSupportPage
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
    public string strProductName = "Explore Products";
    public string strStatusName = "New";
    public string strUserID = "";
    public string strCategoryName = "";
    public string strProductID = "";
    public string strLeadBoxClass = "LeadDeck";
    public string strFilterProductID, strFilterLeadStatus, strFilterTagID;
    public string strTagID = "";
    public string strTagName = "";
    public DataSet objAccountLeadStatusData;
    public string strCategoryID = "";
    public string strAccountName = "";
    protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Product"] == null)
            {
                BindMainProducts();
                divAllProductsHeader.Visible = true;
                divSpecificProductsHeader.Visible = false;
                Page.Title="Explore by Products" + " : " + GetState(CustomerSupportPage.Account_Name);
                
            }
            else
            { 
                BindLeads();
                BindRightProducts();
                divAllProductsHeader.Visible = false;
                divSpecificProductsHeader.Visible = true;
                Page.Title = strProductName + " : " + GetState(CustomerSupportPage.Account_Name);
               
            }
            
            
            
            strAccountName = GetState(CustomerSupportPage.Account_Name);
        }
    private void BindLeads()
    {
        try
        {
            Conversation objConversation = new Conversation();
            Products objProducts = new Products();
            DataSet objData;


            if (Request["Lead_Status"] == null)
            {
                //if (GetState(Filter_Status_ID) == "")
                //{
                //    SetState(Filter_Status_ID, "970FE4E1-7589-4E12-9DEA-097E831CE793");
                //}
                //strLeadStatus = GetState(Filter_Status_ID);
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
                //SetState(Filter_Product_ID, strProductID);
            }
            else
            {
                strProductID = GetState(Filter_Product_ID);
            }
            if (Request["Category"] != null)
            {

                strCategoryID = Request["Category"].ToString();
                //SetState(Filter_Product_ID, strProductID);
            }
            else
            {
                //strCategoryID = GetState(Filter_Product_ID);
            }
            if (Request["Tag"] != null)
            {

                strTagID = Request["Tag"].ToString();
                //SetState(Filter_Tag_ID, strTagID);
            }
            else
            {
                strTagID = GetState(Filter_Tag_ID);
            }

            if (strSearch == "")
            {
                objData = objConversation.GetConversationsByAccount(GetState(CustomerSupportPage.AccountID), intItemsPerPage, intPageNo, strLeadStatus, strCategoryID, strProductID, strTagID, true, ref intTotalLeads);
            }
            else
            {
                SetState(Filter_Product_ID, "");
                SetState(Filter_Status_ID, "");
                SetState(Filter_Tag_ID, "");
                //lblSearchMessage.Text = "Search Results for '" + strSearch + "',  <a href='" + CustomerSupport.Utility.SysResource.HomePath + "manageleads.aspx?Page_No=1" + "'><u> clear search</u></a>";
                //lblSearchMessage.Visible = true;
                objData = objConversation.GetConversationsBySearch(GetState(CustomerSupportPage.AccountID), intItemsPerPage, intPageNo, strSearch, ref intTotalLeads);
            }
            intResultStart = intItemsPerPage * (intPageNo - 1);
            intResultEnd = intResultStart + objData.Tables[0].Rows.Count;

            AccountLeadStatus objAccountLeadStatus = new AccountLeadStatus();

            //objAccountLeadStatusData = objAccountLeadStatus.GetAllAccountStatus(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());
            //ddlConversationStatus.DataSource = objAccountLeadStatusData.Tables[0];
            //ddlConversationStatus.DataTextField = "Status_Name";
            //ddlConversationStatus.DataValueField = "Status_ID";

            //ddlConversationStatus.DataBind();

            //rptrLeadStatus.DataSource = objAccountLeadStatusData.Tables[0];
            //rptrLeadStatus.DataBind();

            //Account objAccount = new Account();
            //DataSet objAccountSeverity;
            //objAccountSeverity = objAccount.GetSeverity();
            //ddlConversationSeverity.DataSource = objAccountSeverity.Tables[0];
            //ddlConversationSeverity.DataTextField = "Severity_Name";
            //ddlConversationSeverity.DataValueField = "Severity_ID";

            //ddlConversationSeverity.DataBind();

            rptrLeads.DataSource = objData.Tables[0];
            rptrLeads.DataBind();


            //objProductsData = objProducts.GetProductDetails(GetState(CustomerSupport.CustomerSupportPage.AccountID).ToString());

            //ddlProducts.DataSource = objProductsData.Tables[0];
            //ddlProducts.DataTextField = "Product_Name";
            //ddlProducts.DataValueField = "Product_ID";
            //ddlProducts.DataBind();




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
                strTagName = "all";
            }
            else
            {
                strTagName = objData.Tables[1].Rows[0]["Tag_Name"].ToString();
            }

            //--------Search--------
            strSearchAction = CustomerSupport.Utility.SysResource.HomePath + "manage/show.aspx?Page_No=1";
            //-------End Of Search --------
            //-----------Paging----------------
            //string strPager = "";

            //int intStartPage = 1;
            int intEndPage = (intTotalLeads / intItemsPerPage) + 1;

            strFirstLink = CustomerSupport.Utility.SysResource.HomePath + "manage/show.aspx?Page_No=1" + "&Search=" + strSearch;
            if (intPageNo == 1)
            {
                strPrevLink = "";
            }
            else
            {
                strPrevLink = CustomerSupport.Utility.SysResource.HomePath + "manage/show.aspx?Page_No=" + (intPageNo - 1) + "&Search=" + strSearch;
            }

            if (intPageNo == intEndPage)
            {
                strNextLink = "";
            }
            else
            {
                strNextLink = CustomerSupport.Utility.SysResource.HomePath + "manage/show.aspx?Page_No=" + (intPageNo + 1) + "&Search=" + strSearch;
            }

            strLastLink = CustomerSupport.Utility.SysResource.HomePath + "manage/show.aspx?Page_No=" + intEndPage + "&Search=" + strSearch;


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
    private void BindMainProducts()
    {

        Products objProducts = new Products();
        DataSet objProductsDataset;
        objProductsDataset = objProducts.GetProductDetails(GetState(CustomerSupportPage.AccountID));
        rptrMainProducts.DataSource = objProductsDataset.Tables[0];
        rptrMainProducts.DataBind();
        if (objProductsDataset.Tables[0].Rows.Count == 0)
        {
            divNoRecordsFound.Visible = true;
        }
        else
        {
            divNoRecordsFound.Visible = false;
        }




    }
    private void BindRightProducts()
    {

        Products objProducts = new Products();
        DataSet objProductsDataset;
        objProductsDataset = objProducts.GetProductDetails(GetState(CustomerSupportPage.AccountID));
        rptrRightProducts.DataSource = objProductsDataset.Tables[0];
        rptrRightProducts.DataBind();





    }
}
