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
public partial class Partials_SetupProducts : CustomerSupportPage
{
    public string strNotes = "";
    public string Product_ID = "";
    public string strAccountID = "", strProductDesc = "", strProductName = "", strProductID = "";
    public int intTargetPeriod = 0, intConversionRate = 0, intTargetValue = 0;
    string strErrorString = "";
    public string strLeadID = "";
    public bool bolResult;
    string strAction = "A";
    //bool bolResult = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bolResult = false;

            Products objProduct = new Products();

            if (Request["ID"] != null)
            {
                strLeadID = Request["ID"].ToString();
            }
            if (Request["Action"] != null)
            {
                strAction = Request["Action"].ToString();
            }
            strAccountID = GetState(CustomerSupportPage.AccountID);


            if (Request["ProductID"] != null)
            {
                strProductID = Request["ProductID"].ToString();
                Product_ID = Request["ProductID"].ToString();
            }
            if (strAction == "A")
            {

                HandleAddProduct();
            }
            else if (strAction == "D")
            {
                bolResult = objProduct.DeleteProduct(strProductID);
                DataSet objdata;
                objdata = objProduct.GetProductDetails(strAccountID);
                rptrProducts.DataSource = objdata.Tables[0];
                rptrProducts.DataBind();
            }


            
        }
        catch
        {
            throw;
        }
    }
    private void HandleAddProduct()
    {

        try
        {
            // var poststr = "AccountID=" + encodeURI(AccountID) + "&ProductName=" + encodeURI(ProductName) + "&ProductDesc=" + encodeURI(ProductDesc) + "&TargetPeriod=" + encodeURI(TargetPeriod) + "&ConversionRate=" + encodeURI(ConversionRate) + "&Target=" + encodeURI(Target) + "&Action=A";
            Products objProduct = new Products();



            if (Request["ProductName"] != null)
            {
                strProductName = Request["ProductName"].ToString();
                if (strProductName.Length == 0) { strErrorString += "Name Required,"; }

                bool bolProductNameExists=false;

                bolProductNameExists = objProduct.bolProductNameExists(strProductName);
                if (bolProductNameExists == true)
                {
                    strErrorString += "Product Name Exists,"; 
                }


            }
            if (Request["ProductDesc"] != null)
            {
                strProductDesc = Request["ProductDesc"].ToString();
                if (strProductName.Length == 0) { strErrorString += "Description Required,"; }

            }
           

            string strProductID = "";


            if (strErrorString.Length == 0)
            {
                strProductID = objProduct.AddProduct(strAccountID, strProductName, strProductDesc,GetState(CustomerSupportPage.UserID),DateTime.Now);
                DataSet objdata;
                objdata = objProduct.GetProductDetails(strAccountID);
                rptrProducts.DataSource = objdata.Tables[0];
                rptrProducts.DataBind();
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
