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
    public class Tags
    {
        public Tags()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public bool AddTags(
            string strAccountID,
                 string strTagName)
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
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_ID", strAccountID);
                arrSQLParams[1] = new SqlParameter("@Tag_Name", strTagName);
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_TAG,
                    arrSQLParams);
                return true;

            }
            catch
            {

                throw;
            }

        }


        public bool DeleteTag(string strTagID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Tag_ID", strTagID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_DELETE_TAG,
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
        public DataSet GetUserTags(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_TAGS,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }

        public bool AddTagToLead(string strLeadID, string strTagID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Lead_ID", strLeadID);
                arrSQLParams[1] = new SqlParameter("@Tag_ID", strTagID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_ADD_TAG_TO_LEAD,
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
        public bool RemoveTagFromLead(string strLeadID, string strTagID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Lead_ID", strLeadID);
                arrSQLParams[1] = new SqlParameter("@Tag_ID", strTagID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_REMOVE_TAG_FROM_LEAD,
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
        public DataSet GetLeadTags(string strLeadID, string strAccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Lead_ID", strLeadID);

                arrSQLParams[1] = new SqlParameter("@Account_ID", strAccountID);
                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_LEAD_TAGS,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetPopularTags(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_POPULAR_TAGS,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }

        public bool bolTagNameExists(string strTagName)
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

                arrSQLParams[0] = new SqlParameter("@Tag_Name", strTagName);
                arrSQLParams[1] = new SqlParameter("@bitExists", SqlDbType.Bit);
                arrSQLParams[1].Direction = ParameterDirection.Output;
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_IS_TAG_NAME_EXISTS,
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