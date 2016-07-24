using System;
using System.Data;
using System.Data.SqlClient;
using CustomerSupport.Data;
using CustomerSupport.Utility;

/// <summary>
/// Summary description for Tasks
/// </summary>
namespace CustomerSupport.Data
{
    public class Tasks
    {
        public Tasks()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public string AddTask(
              string TaskDesc,
              string Lead_ID,
              string Task_Status,
              DateTime Task_Date,
              string Account_ID,
              string User_ID)
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
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[7];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Task_Desc", TaskDesc);
                arrSQLParams[1] = new SqlParameter("@Lead_ID", Lead_ID);
                arrSQLParams[2] = new SqlParameter("@Task_Status", Task_Status);
                arrSQLParams[3] = new SqlParameter("@Task_Date", Task_Date);
                arrSQLParams[4] = new SqlParameter("@Account_ID", Account_ID);
                arrSQLParams[5] = new SqlParameter("@User_ID", User_ID);
                arrSQLParams[6] = new SqlParameter("@Task_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[6].Direction = ParameterDirection.Output;

                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_TASKS,
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
        public bool DeleteTask(
                    string TaskID)
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
                arrSQLParams[0] = new SqlParameter("@Task_ID", TaskID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_DELETE_TASK,
                    arrSQLParams);

                return true;
            }
            catch
            {

                throw;
            }

        }
        public DataSet GetTasks(string Account_ID, string User_ID, string Lead_ID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[3];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", Account_ID);
                if (User_ID == "")
                {
                    arrSQLParams[1] = new SqlParameter("@User_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[1] = new SqlParameter("@User_ID", User_ID);
                }
                if (Lead_ID == "")
                {
                    arrSQLParams[2] = new SqlParameter("@Lead_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[2] = new SqlParameter("@Lead_ID", Lead_ID);
                }
                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_TASKS,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetTasksSummary(string Account_ID, string User_ID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", Account_ID);
                if (User_ID == "")
                {
                    arrSQLParams[1] = new SqlParameter("@User_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[1] = new SqlParameter("@User_ID", User_ID);
                }
                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_TASKS_SUMMARY,
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