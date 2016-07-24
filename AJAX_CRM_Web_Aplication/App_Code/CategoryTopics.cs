using System;
using System.Data;
using System.Data.SqlClient;
using CustomerSupport.Data;
using CustomerSupport.Utility;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for AccountUser
/// </summary>
namespace CustomerSupport.Data
{
    public class CategoryTopics
    {
        public CategoryTopics()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public bool AddCategoryTopics(
            string strAccountID,
                 string strCategoryName,
                 string strCategoryDesc,
            string strParentCategoryID)
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

            //string strUserID = "";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[5];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_ID", strAccountID);
                arrSQLParams[1] = new SqlParameter("@Category_Name", strCategoryName);
                arrSQLParams[2] = new SqlParameter("@Category_Desc", strCategoryDesc);
                if (strParentCategoryID == "")
                {
                    arrSQLParams[3] = new SqlParameter("@Parent_Category_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[3] = new SqlParameter("@Parent_Category_ID", strParentCategoryID);
                }
                arrSQLParams[4] = new SqlParameter("@Category_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[4].Direction = ParameterDirection.Output;


                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_TOPIC_CATEGORIES,
                    arrSQLParams);
                return true;

            }
            catch
            {

                throw;
            }

        }


        public bool DeleteCategoryTopics(string strCategoryID, string strAccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Category_ID", strCategoryID);
                arrSQLParams[1] = new SqlParameter("@Account_ID", strAccountID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_DELETE_TOPIC_CATEGORIES,
                     arrSQLParams);

                //intTotalLeads = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return bolResult;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetCategoryTopics(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_TOPIC_CATEGORIES,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public bool bolCategoryNameExists(string strCategoryName)
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

                arrSQLParams[0] = new SqlParameter("@Category_Name", strCategoryName);
                arrSQLParams[1] = new SqlParameter("@bitExists", SqlDbType.Bit);
                arrSQLParams[1].Direction = ParameterDirection.Output;
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_IS_CATEGORY_NAME_EXISTS,
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