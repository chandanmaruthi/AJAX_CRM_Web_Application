using System;
using System.Data;
using System.Data.SqlClient;
using CustomerSupport.Data;
using CustomerSupport.Utility;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for Products
/// </summary>
namespace CustomerSupport.Data
{
    public class Products
    {
        public Products()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string AddProduct(
              string AccountID,
              string ProductName,
              string ProductDesc,
            string strUserID,
            DateTime dtmDate)
        {
            //---------------------------------------------------------------------------------
            //Function Name:AddAisle
            //Description:Add Aisle to format
            //Created On: 05/01/07
            //Created By: Chandan Maruthi
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------

            //Define Local Variables

            string strProductID = "";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[6];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_id", AccountID);
                arrSQLParams[1] = new SqlParameter("@Product_Desc", ProductDesc);
                arrSQLParams[2] = new SqlParameter("@Poduct_Name", ProductName);
                arrSQLParams[3] = new SqlParameter("@Product_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[3].Direction = ParameterDirection.Output;
                arrSQLParams[4] = new SqlParameter("@User_ID", strUserID);
                arrSQLParams[5] = new SqlParameter("@DateTime", dtmDate);

                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_PRODUCTS,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    strProductID = OutputVariables[0].ToString();
                }
                return strProductID;
            }
            catch
            {

                throw;
            }

        }
        public bool UpdateAccount(
                    string ProductID,
                   string AccountID,
                  string ProductName,
                  string ProductDesc,
                  int TargetPeriod,
                  double TargetValue,
                  int ConversionRate)
        {
            //---------------------------------------------------------------------------------
            //Function Name:AddAisle
            //Description:Add Aisle to format
            //Created On: 05/01/07
            //Created By: Chandan Maruthi
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------

            //Define Local Variables


            bool bolResult = false;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[7];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_id", AccountID);
                arrSQLParams[1] = new SqlParameter("@Product_ID", ProductID);
                arrSQLParams[2] = new SqlParameter("@Product_Desc", ProductDesc);
                arrSQLParams[3] = new SqlParameter("@Poduct_Name", ProductName);
                arrSQLParams[4] = new SqlParameter("@Target_Period", TargetPeriod);
                arrSQLParams[5] = new SqlParameter("@Target_Value", TargetValue);
                arrSQLParams[6] = new SqlParameter("@Conversion_Rate", ConversionRate);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_PRODUCTS,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }
        public bool DeleteProduct(
                    string ProductID)
        {
            //---------------------------------------------------------------------------------
            //Function Name:AddAisle
            //Description:Add Aisle to format
            //Created On: 05/01/07
            //Created By: Chandan Maruthi
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------

            //Define Local Variables


            bool bolResult = false;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Product_ID", ProductID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_DELETE_PRODUCTS,
                    arrSQLParams);

                return true;
            }
            catch
            {

                throw;
            }

        }
        public DataSet GetProductDetails(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_PRODUCTS,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public bool bolProductNameExists(string strProducttName)
        {
            //---------------------------------------------------------------------------------
            //Function Name:AddAisle
            //Description:Add Aisle to format
            //Created On: 05/01/07
            //Created By: Chandan Maruthi
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------

            //Define Local Variables

            string strResult = "";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Product_Name", strProducttName);
                arrSQLParams[1] = new SqlParameter("@bitExists", SqlDbType.Bit);
                arrSQLParams[1].Direction = ParameterDirection.Output;
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_IS_PRODUCT_NAME_EXISTS,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    strResult = OutputVariables[0].ToString();
                }
                if (strResult == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {

                throw;
            }
        }
    }
}