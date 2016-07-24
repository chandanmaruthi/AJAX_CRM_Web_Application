using System;
using System.Data;
using System.Data.SqlClient;
using CustomerSupport.Data;
using CustomerSupport.Utility;
using System.Web;
using System.Web.Security; 

/// <summary>
/// Summary description for Errors
/// </summary>

    public class Errors
    {
        public Errors()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public bool bolAddError(
            string strErrorDesc,
            string strUserName,
            string strWebsiteURL,
            string strPageName)
        {
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];

            //Method Logic



            arrSQLParams[0] = new SqlParameter("@Error_Desc", strErrorDesc);
            arrSQLParams[1] = new SqlParameter("@User_Name", strUserName);
            arrSQLParams[2] = new SqlParameter("@Website_URL", strWebsiteURL);
            arrSQLParams[3] = new SqlParameter("@Page_Name", strPageName);
            OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_SYS_ERROR,
                arrSQLParams);
            return true;

        }
        public DataSet GetErrorLog(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@AccountID", DBNull.Value);
                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_SYS_ERRORS,
                     arrSQLParams);

                //intTotalLeads = int.Parse(arrSQLParams[5].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }
    }
