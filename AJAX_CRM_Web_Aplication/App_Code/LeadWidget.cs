using System;
using System.Data;
using System.Data.SqlClient;
using CustomerSupport.Data;
using CustomerSupport.Utility;

/// <summary>
/// Summary description for Widget
/// </summary>
namespace CustomerSupport.Data
{
    public class LeadWidget
    {
        public LeadWidget()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string AddWidget(
                    string WidgetName,
                    string WidgetHeader,
                    string WidgetFooter,
                    string Layout_ID,
                    string Account_ID,
                        string strBackground_Color,
                        string strText_Color,
                        string strURL_Color,
                        string strTitle_Color,
            string strUserId,
            DateTime dtmDateTime)
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

            //string AccountID = "";
            string[] OutputVariables;
            string Widget_ID = "";
            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[12];

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Widget_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[0].Direction = ParameterDirection.Output;
                arrSQLParams[1] = new SqlParameter("@Widget_Name", WidgetName);
                arrSQLParams[2] = new SqlParameter("@Layout_ID", DBNull.Value);
                arrSQLParams[3] = new SqlParameter("@Widget_Header", WidgetHeader);
                arrSQLParams[4] = new SqlParameter("@Widget_Footer", WidgetFooter);
                arrSQLParams[5] = new SqlParameter("@Account_ID", Account_ID);
                arrSQLParams[6] = new SqlParameter("@Background_Color", strBackground_Color);
                arrSQLParams[7] = new SqlParameter("@Text_Color", strText_Color);
                arrSQLParams[8] = new SqlParameter("@URL_Color", strURL_Color);
                arrSQLParams[9] = new SqlParameter("@Title_Color", strTitle_Color);
                arrSQLParams[10] = new SqlParameter("@User_ID", strUserId);
                arrSQLParams[11] = new SqlParameter("@DateTime", dtmDateTime);

                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_WIDGET,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    Widget_ID = OutputVariables[0].ToString();
                }
                return Widget_ID;
            }
            catch
            {

                throw;
            }

        }
        public bool UpdateWidget(
                        string Widget_ID,
                        string WidgetName,
                        string WidgetHeader,
                        string WidgetFooter,
                        string Layout_ID,
                        string Account_ID,
                        string strBackground_Color,
                        string strText_Color,
                        string strURL_Color,
                        string strTitle_Color
            )
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

            //string AccountID = "";
            bool bolResult;
            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[10];

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Widget_Name", WidgetName);
                arrSQLParams[1] = new SqlParameter("@Widget_ID", Widget_ID);
                arrSQLParams[2] = new SqlParameter("@Layout_ID", DBNull.Value);
                arrSQLParams[3] = new SqlParameter("@Widget_Header", WidgetHeader);
                arrSQLParams[4] = new SqlParameter("@Widget_Footer", WidgetFooter);
                arrSQLParams[5] = new SqlParameter("@Account_ID", Account_ID);
                arrSQLParams[6] = new SqlParameter("@Background_Color", strBackground_Color);
                arrSQLParams[7] = new SqlParameter("@Text_Color", strText_Color);
                arrSQLParams[8] = new SqlParameter("@URL_Color", strURL_Color);
                arrSQLParams[9] = new SqlParameter("@Title_Color", strTitle_Color);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_WIDGET,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }
        public string AddWidgetQuestions(
                    string Widget_ID,
                    string QuestionTitle,
                    string Options)
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

            //string AccountID = "";
            string[] OutputVariables;
            string Question_id = "";
            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Question_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[0].Direction = ParameterDirection.Output;
                arrSQLParams[1] = new SqlParameter("@Question", QuestionTitle);
                arrSQLParams[2] = new SqlParameter("@Options", Options);
                arrSQLParams[3] = new SqlParameter("@Widget_ID", Widget_ID);


                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_WIDGET_QUESTIONS,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    Question_id = OutputVariables[0].ToString();
                }
                return Question_id;
            }
            catch
            {

                throw;
            }

        }
        public bool UpdateWidgetQuestions(
                    string Question_ID,
                    string Widget_ID,
                    string QuestionTitle,
                    string Options)
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

            //string AccountID = "";
            //string[] OutputVariables;
            //string Question_id = "";
            bool bolResult = false;
            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Question_ID", Question_ID);
                arrSQLParams[1] = new SqlParameter("@Question", QuestionTitle);
                arrSQLParams[2] = new SqlParameter("@Options", Options);
                arrSQLParams[3] = new SqlParameter("@Widget_ID", Widget_ID);


                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_WIDGET_QUESTIONS,
                    arrSQLParams);


                return bolResult;
            }
            catch
            {

                throw;
            }

        }

        public DataSet GetWidgetsByAccount(string AccountID,
                    int intItemsPerPage,
                    int intPageCount,
                    ref int intTotalWidgets)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);
                arrSQLParams[1] = new SqlParameter("@Page_Count", intItemsPerPage);
                arrSQLParams[2] = new SqlParameter("@Page_No", intPageCount);
                arrSQLParams[3] = new SqlParameter("@TotalWidgets", SqlDbType.Int);
                arrSQLParams[3].Direction = ParameterDirection.Output;

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords1(Procedure.SP_GET_ALL_WIDGETS_BY_ACCOUNT,
                     ref arrSQLParams);

                intTotalWidgets = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }

        public DataSet GetWidget(string WidgetID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Widget_ID", WidgetID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords1(Procedure.SP_GET_WIDGET,
                     ref arrSQLParams);

                //intTotalWidgets = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }
        public bool DeleteWidget(string WidgetID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Widget_ID", WidgetID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_DELETE_WIDGET,
                     arrSQLParams);

                //intTotalWidgets = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return bolResult;
            }
            catch
            {

                throw;
            }
        }
        public bool DeleteWidgetQuestion(string QuestionID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Question_ID", QuestionID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_DELETE_WIDGET_QUESTION,
                     arrSQLParams);

                //intTotalWidgets = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return bolResult;
            }
            catch
            {

                throw;
            }
        }
        public bool UpdateWidgetImage(
                    string Widget_ID,
                   string ImageFileName)
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

            //string AccountID = "";
            bool bolResult;
            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Widget_ID", Widget_ID);
                arrSQLParams[1] = new SqlParameter("@Image_File_Name", ImageFileName);


                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_WIDGET_PICTURE,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }

    }
}