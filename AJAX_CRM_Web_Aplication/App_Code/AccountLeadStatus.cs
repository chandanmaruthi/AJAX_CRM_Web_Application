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
    public class AccountLeadStatus
    {
        public AccountLeadStatus()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string AddAccountLeadStatus(
            string strAccountID,
                 string Status_Name,
                 string Status_Desc,
                 int Percetntage_Commision,
                int intOrder)
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

            string strAccountLeadStatusID = "";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[6];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_ID", strAccountID);
                arrSQLParams[1] = new SqlParameter("@Status_Name", Status_Name);
                arrSQLParams[2] = new SqlParameter("@Status_Desc", Status_Desc);
                arrSQLParams[3] = new SqlParameter("@Percentage_Completion", Percetntage_Commision);
                arrSQLParams[4] = new SqlParameter("@Status_Order", intOrder);
                arrSQLParams[5] = new SqlParameter("@Status_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[5].Direction = ParameterDirection.Output;

                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_ACCOUNT_STATUS,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    strAccountLeadStatusID = OutputVariables[0].ToString();
                }
                return strAccountLeadStatusID;
            }
            catch
            {

                throw;
            }

        }
        public bool UpdateUser(
                   string strAccountID,
                   string strStatusID,
                   string strStatusName,
                   string strStatusDesc,
                   int intPercentageCommision)
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
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[5];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_ID", strAccountID);
                arrSQLParams[1] = new SqlParameter("@Status_Name", strStatusName);
                arrSQLParams[2] = new SqlParameter("@Status_Desc", strStatusDesc);
                arrSQLParams[3] = new SqlParameter("@Percetntage_Commision", intPercentageCommision);
                arrSQLParams[4] = new SqlParameter("@Status_ID", strStatusID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_ACCOUNT_STATUS,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }

        public bool DeleteAccountLeadStatus(string strAccountID, string strStatusID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", strAccountID);
                arrSQLParams[1] = new SqlParameter("@Status_ID", strStatusID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_DELETE_ACCOUNT_STATUS,
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
        public DataSet GetAccountStatusByID(string strAccountID, string Status_ID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", strAccountID);
                arrSQLParams[1] = new SqlParameter("@Status_ID", Status_ID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_ACCOUNT_STATUS_BY_ID,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetAllAccountStatus(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_ALL_ACCOUNT_STATUS,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
    }
}