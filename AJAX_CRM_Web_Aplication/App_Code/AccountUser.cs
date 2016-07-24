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
    public class AccountUser
    {
        public AccountUser()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string AddUser(
            string strAccountID,
                 string FullName,
                 string EmailId,
                 string Password,
                 string ContactPhone,
                 string ContactEmail)
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

            string strUserID = "";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[10];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@User_F_Name", FullName);
                arrSQLParams[1] = new SqlParameter("@User_L_Name", "");
                arrSQLParams[2] = new SqlParameter("@User_Password", CustomerSupport.Utility.Security.CalculateMD5Hash(Password));
                arrSQLParams[3] = new SqlParameter("@Email_ID", EmailId);
                arrSQLParams[4] = new SqlParameter("@Phone_1", ContactPhone);
                arrSQLParams[5] = new SqlParameter("@Phone_2", ContactEmail);
                arrSQLParams[6] = new SqlParameter("@Status", 1);
                arrSQLParams[7] = new SqlParameter("@Is_Admin", 1);
                arrSQLParams[8] = new SqlParameter("@Account_ID", strAccountID);
                arrSQLParams[9] = new SqlParameter("@User_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[9].Direction = ParameterDirection.Output;

                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_USER,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    strUserID = OutputVariables[0].ToString();
                }
                return strUserID;
            }
            catch
            {

                throw;
            }

        }
        public bool UpdateUser(
                    string UserId,
                   string FullName,
                   string EmailId,
                   string ContactPhone,
                   string ContactEmail)
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
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[6];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@User_F_Name", FullName);
                arrSQLParams[1] = new SqlParameter("@User_L_Name", "");
                arrSQLParams[2] = new SqlParameter("@Email_ID", EmailId);
                arrSQLParams[3] = new SqlParameter("@Phone_1", ContactPhone);
                arrSQLParams[4] = new SqlParameter("@Phone_2", ContactEmail);
                arrSQLParams[5] = new SqlParameter("@User_ID", UserId);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_USER,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }

        public bool DeleteUser(string UserID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@User_ID", UserID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_DELETE_USER,
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
        public DataSet GetUserDetails(string UserID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@User_ID", UserID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_USER_BY_ID,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetUserByAccount(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_USERS_BY_ACCOUNT,
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