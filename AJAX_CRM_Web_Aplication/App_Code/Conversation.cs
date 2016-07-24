using System;
using System.Data;
using System.Data.SqlClient;
using CustomerSupport.Data;
using CustomerSupport.Utility;
/// <summary>
/// Summary description for Conversation
/// </summary>
namespace CustomerSupport.Data
{
    public class Conversation
    {
        public Conversation()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet GetConversationsByAccount(string AccountID,
                int intItemsPerPage,
                int intPageCount,
                string strConversationStatus,
            string strCategoryID,
                string strProductID,
                string strTagID,
            bool bolIsPublic,
                ref int intTotalConversations)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[9];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);
                arrSQLParams[1] = new SqlParameter("@Page_Count", intItemsPerPage);
                arrSQLParams[2] = new SqlParameter("@Page_No", intPageCount);

                if (strConversationStatus == "")
                {
                    arrSQLParams[3] = new SqlParameter("@Conversation_Status", DBNull.Value);
                }
                else
                {
                    arrSQLParams[3] = new SqlParameter("@Conversation_Status", strConversationStatus);
                }
                if (strCategoryID == "")
                {
                    arrSQLParams[4] = new SqlParameter("@Category_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[4] = new SqlParameter("@Category_ID", strCategoryID);
                }

                if (strTagID == "")
                {
                    arrSQLParams[5] = new SqlParameter("@Tag_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[5] = new SqlParameter("@Tag_ID", strTagID);
                }

                if (strProductID == "")
                {
                    arrSQLParams[6] = new SqlParameter("@Product_ID", DBNull.Value);


                }
                else
                {
                    arrSQLParams[6] = new SqlParameter("@Product_ID", strProductID);
                }
                if (bolIsPublic == true)
                {
                    arrSQLParams[7] = new SqlParameter("@Is_Public", "1");


                }
                else
                {
                    arrSQLParams[7] = new SqlParameter("@Is_Public", "0");
                }

                arrSQLParams[8] = new SqlParameter("@TotalConversations", SqlDbType.Int);
                arrSQLParams[8].Direction = ParameterDirection.Output;

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords1(Procedure.SP_GET_ALL_CONVERSATIONS_BY_ACCOUNT,
                     ref arrSQLParams);

                intTotalConversations = int.Parse(arrSQLParams[8].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetNotes(string strConversationID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Conversation_ID", strConversationID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_NOTES,
                     arrSQLParams);

                //intTotalConversations = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }

        public bool DeleteNotes(string NoteID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@NoteID", NoteID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_DELETE_NOTES,
                     arrSQLParams);

                //intTotalConversations = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return bolResult;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetConversationsBySearch(string AccountID,
                int intItemsPerPage,
                int intPageCount,
                string strSearchString,
                ref int intTotalConversations)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[5];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);
                arrSQLParams[1] = new SqlParameter("@Page_Count", intItemsPerPage);
                arrSQLParams[2] = new SqlParameter("@Page_No", intPageCount);
                arrSQLParams[3] = new SqlParameter("@SearchString", strSearchString);
                arrSQLParams[4] = new SqlParameter("@TotalConversations", SqlDbType.Int);
                arrSQLParams[4].Direction = ParameterDirection.Output;

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords1(Procedure.SP_GET_ALL_CONVERSATIONS_BY_SEARCH,
                     ref arrSQLParams);

                intTotalConversations = int.Parse(arrSQLParams[4].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetConverationByID(string ConversationID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Conversation_ID", ConversationID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords1(Procedure.SP_GET_CONVERSATION_BY_ID,
                     ref arrSQLParams);

                return ds;
            }
            catch
            {

                throw;
            }
        }

        public bool AddConversation(
                    string AccountID,
                    string Conversation_Title,
                    string Conversation_Desc,
                    string Conversation_Status,
                    string Conversation_Severity,
                    DateTime Create_Date,
                    string User_ID,
                    string Product_ID,
                    string Conversation_Type,
                    string Origin_URL,
                    string Origin_IP,
                    string Origin_Location_Desc,
                    string User_Email,
                    string User_Phone,
                    string User_Name,
                    string Category_ID,
                    ref string Conversation_ID)
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

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[17];

            //Method Logic



            try
            {


                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);
                arrSQLParams[1] = new SqlParameter("@Conversation_Title", Conversation_Title);
                arrSQLParams[2] = new SqlParameter("@Conversation_Desc", Conversation_Desc);
                if (Conversation_Status == "")
                {
                    arrSQLParams[3] = new SqlParameter("@Conversation_Status", DBNull.Value);
                }
                else
                {
                    arrSQLParams[3] = new SqlParameter("@Conversation_Status", Conversation_Status);
                }
                if (Conversation_Severity == "")
                {
                    arrSQLParams[4] = new SqlParameter("@Conversation_Severity", DBNull.Value);
                }
                else
                {
                    arrSQLParams[4] = new SqlParameter("@Conversation_Severity", Conversation_Severity);
                }
                arrSQLParams[5] = new SqlParameter("@Create_Date", Create_Date);
                if (User_ID == "")
                {
                    arrSQLParams[6] = new SqlParameter("@User_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[6] = new SqlParameter("@User_ID", User_ID);
                }
                if (Product_ID == "")
                {
                    arrSQLParams[7] = new SqlParameter("@Product_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[7] = new SqlParameter("@Product_ID", Product_ID);
                }
                if (Conversation_Type == "")
                {
                    arrSQLParams[8] = new SqlParameter("@Conversation_Type", DBNull.Value);
                }
                else
                {
                    arrSQLParams[8] = new SqlParameter("@Conversation_Type", Conversation_Type);
                }

                arrSQLParams[9] = new SqlParameter("@Origin_URL", Origin_URL);
                arrSQLParams[10] = new SqlParameter("@Origin_IP", Origin_IP);
                arrSQLParams[11] = new SqlParameter("@Origin_Location_Desc", Origin_Location_Desc);
                arrSQLParams[12] = new SqlParameter("@User_Email", User_Email);
                arrSQLParams[13] = new SqlParameter("@User_Phone", User_Phone);
                arrSQLParams[14] = new SqlParameter("@User_Name", User_Name);

                if (Category_ID == "")
                {
                    arrSQLParams[15] = new SqlParameter("@Category_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[15] = new SqlParameter("@Category_ID", Category_ID);
                }


                arrSQLParams[16] = new SqlParameter("@Conversation_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[16].Direction = ParameterDirection.Output;



                DataSet objResult;
                objResult = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords1(CustomerSupport.Data.Procedure.SP_ADD_CONVERSATION,
                    ref arrSQLParams);

                Conversation_ID = arrSQLParams[15].Value.ToString();

                return true;
            }
            catch
            {

                throw;
            }

        }
        public bool AddConversationFromWidget(
                        string WidgetID,
                        string Site_URL,
                        string User_Name,
                        string Conversation_Description,
                        string Conversation_Details,
                        string User_Phone,
                        string User_Email,
                        int Hide_Email,
                        string strConversationIP,
                string strConversationIPDesc,
                        string strProductID)
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

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[13];

            //Method Logic
            try
            {


                arrSQLParams[0] = new SqlParameter("@Widget_ID", WidgetID);
                arrSQLParams[1] = new SqlParameter("@Conversation_Title", Conversation_Description);
                arrSQLParams[2] = new SqlParameter("@Conversation_Desc", Conversation_Description + Conversation_Details);
                arrSQLParams[3] = new SqlParameter("@Create_Date", DateTime.Now);
                arrSQLParams[4] = new SqlParameter("@User_ID", DBNull.Value);

                if (strProductID == "")
                {
                    arrSQLParams[5] = new SqlParameter("@Product_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[5] = new SqlParameter("@Product_ID", strProductID);
                }
                arrSQLParams[6] = new SqlParameter("@Conversation_Type", DBNull.Value);
                arrSQLParams[7] = new SqlParameter("@Origin_URL", Site_URL);
                arrSQLParams[8] = new SqlParameter("@Origin_IP", strConversationIP);
                arrSQLParams[9] = new SqlParameter("@Origin_Location_Desc", strConversationIPDesc);
                arrSQLParams[10] = new SqlParameter("@User_Email", User_Email);
                arrSQLParams[11] = new SqlParameter("@User_Phone", User_Phone);
                arrSQLParams[12] = new SqlParameter("@User_Name", User_Name);
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_CONVERSATION_FROM_WIDGET,
                    arrSQLParams);
                return true;
            }
            catch
            {

                throw;
            }

        }

        public bool UpdateConversation(
                    string Conversation_ID,
                    string AccountID,
                    string Site_URL,
                    string Conversation_Name,
                    string Conversation_Description,
                    string Conversation_Details,
                    string Conversation_Phone,
                    string Conversation_Email,
                    int ConversationValue,
                    string Conversation_Notes,
                    string Conversation_Status,
                    string Conversation_Owner,
                    string Conversation_Product_Interest,
                    int Conversation_Probability,
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

            //string AccountID = "";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[16];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Conversation_ID", Conversation_ID);
                arrSQLParams[1] = new SqlParameter("@Account_ID", AccountID);
                arrSQLParams[2] = new SqlParameter("@Site_URL", Site_URL);
                arrSQLParams[3] = new SqlParameter("@Conversation_Name", Conversation_Name);
                arrSQLParams[4] = new SqlParameter("@Conversation_Description", Conversation_Description);
                arrSQLParams[5] = new SqlParameter("@Conversation_Details", Conversation_Details);
                arrSQLParams[6] = new SqlParameter("@Conversation_Notes", Conversation_Notes);
                arrSQLParams[7] = new SqlParameter("@Conversation_Status", Conversation_Status);
                arrSQLParams[8] = new SqlParameter("@Conversation_Phone", Conversation_Phone);
                arrSQLParams[9] = new SqlParameter("@Conversation_Email", Conversation_Email);
                arrSQLParams[10] = new SqlParameter("@User_ID", strUserID);
                arrSQLParams[11] = new SqlParameter("@DateTime", dtmDate.ToString());
                arrSQLParams[12] = new SqlParameter("@Conversation_Value", ConversationValue);
                arrSQLParams[13] = new SqlParameter("@Conversation_Owner", Conversation_Owner);
                if (Conversation_Product_Interest == "")
                {
                    arrSQLParams[14] = new SqlParameter("@Conversation_Product_Interest", DBNull.Value);
                }
                else
                {
                    arrSQLParams[14] = new SqlParameter("@Conversation_Product_Interest", Conversation_Product_Interest);
                }

                arrSQLParams[15] = new SqlParameter("@Conversation_Probability", Conversation_Probability);
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_UPDATE_CONVERSATION,
                    arrSQLParams);
                return true;
            }
            catch
            {

                throw;
            }

        }

        public bool AddConversationNotes(
                    string strConversationID,
                    string NotesDesc,
                    string UserID,
                    DateTime Date)
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

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];

            //Method Logic
            try
            {


                arrSQLParams[0] = new SqlParameter("@Conversation_ID", strConversationID);
                arrSQLParams[1] = new SqlParameter("@NoteDesc", NotesDesc);
                arrSQLParams[2] = new SqlParameter("@User_ID", UserID);
                arrSQLParams[3] = new SqlParameter("@DateTime", Date);
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_CONVERSATION_NOTES,
                    arrSQLParams);
                return true;
            }
            catch
            {

                throw;
            }

        }

        public bool UpdateConversationStatus(
                  string strConversationID,
                  string StatusID,
            string strUserID,
            DateTime dtmDate
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
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];

            //Method Logic
            try
            {


                arrSQLParams[0] = new SqlParameter("@Conversation_ID", strConversationID);
                arrSQLParams[1] = new SqlParameter("@Status_ID", StatusID);
                arrSQLParams[2] = new SqlParameter("@User_ID", strUserID);
                arrSQLParams[3] = new SqlParameter("@DateTime", dtmDate);
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_UPDATE_CONVERSATION_STATUS,
                    arrSQLParams);
                return true;
            }
            catch
            {

                throw;
            }

        }
        public bool UpdateConversationRating(
                  string ConversationID,
                  int Rating,
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

            //string AccountID = "";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];

            //Method Logic
            try
            {


                arrSQLParams[0] = new SqlParameter("@Conversation_ID", ConversationID);
                arrSQLParams[1] = new SqlParameter("@Rating", Rating);
                arrSQLParams[2] = new SqlParameter("@User_ID", strUserID);
                arrSQLParams[3] = new SqlParameter("@DateTime", dtmDate.ToString());


                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_UPDATE_CONVERSATION_RATING,
                    arrSQLParams);
                return true;
            }
            catch
            {

                throw;
            }

        }
        public bool DeleteConversation(
                  string ConversationID)
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
            bool bolResult;
            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];

            //Method Logic
            try
            {


                arrSQLParams[0] = new SqlParameter("@Conversation_ID", ConversationID);
                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_DELETE_CONVERSATION,
                    arrSQLParams);
                return true;
            }
            catch
            {

                throw;
            }

        }

        public DataSet GetRecentConversations(string Account_ID, string User_ID, string Conversation_ID)
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
                if (Conversation_ID == "")
                {
                    arrSQLParams[2] = new SqlParameter("@Conversation_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[2] = new SqlParameter("@Conversation_ID", Conversation_ID);
                }
                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_RECENT,
                     arrSQLParams);

                //intTotalConversations = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetConversationHistory(string strAccount_ID, string strConversation_ID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];
            DataSet ds;

            //Method Logic
            try
            {


                if (strAccount_ID == "")
                {
                    arrSQLParams[0] = new SqlParameter("@Conversation_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[0] = new SqlParameter("@Conversation_ID", strConversation_ID);
                }
                arrSQLParams[1] = new SqlParameter("@Account_ID", strAccount_ID);
                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_Get_Conversation_History,
                     arrSQLParams);


                return ds;
            }
            catch
            {

                throw;
            }
        }

        public bool AddRecentConversations(
                   string ConversationID,
                   string AccountID,
                string UserID,
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

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];

            //Method Logic
            try
            {


                arrSQLParams[0] = new SqlParameter("@Conversation_ID", ConversationID);
                arrSQLParams[1] = new SqlParameter("@Account_ID", AccountID);

                if (UserID == "")
                {
                    arrSQLParams[2] = new SqlParameter("@User_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[2] = new SqlParameter("@User_ID", UserID);
                }
                arrSQLParams[3] = new SqlParameter("@Date_Time", dtmDateTime);
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_RECENT,
                    arrSQLParams);
                return true;
            }
            catch
            {

                throw;
            }

        }
        public DataSet GetPipeLineSummary(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_PIPELINE_SUMMARY,
                     arrSQLParams);

                //intTotalConversations = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }


        public DataSet GetConversatioMessages(string strConversationID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Coversation_ID", strConversationID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_CONVERSATION_MESSAGES_BY_ID,
                     arrSQLParams);

                //intTotalConversations = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }

        public string AddConversationMessage(
                        string strConversationID,
                        string strAccountID,
                        string strUserID,
                        string strMessage,
                        DateTime strReplyDate,
                        bool bolIsAnswer,
                        bool bolIsOfficial,
                        string strUserName,
                        string strUserEmail)
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
            string strMessageID = "";
            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[10];

            //Method Logic
            try
            {


                arrSQLParams[0] = new SqlParameter("@Coversation_ID", strConversationID);
                arrSQLParams[1] = new SqlParameter("@Account_ID", strAccountID);

                if (strUserID == "")
                {
                    arrSQLParams[2] = new SqlParameter("@User_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[2] = new SqlParameter("@User_ID", strUserID);
                }

                arrSQLParams[3] = new SqlParameter("@Reply_Message_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[3].Direction = ParameterDirection.Output;

                arrSQLParams[4] = new SqlParameter("@Reply_Message", strMessage);
                arrSQLParams[5] = new SqlParameter("@Reply_Date", strReplyDate);
                arrSQLParams[6] = new SqlParameter("@Is_Answer", bolIsAnswer);
                if (bolIsOfficial == true)
                {
                    arrSQLParams[7] = new SqlParameter("@Official", true);
                }
                else { arrSQLParams[7] = new SqlParameter("@Official", false); }
                arrSQLParams[8] = new SqlParameter("@User_Name", strUserName);
                arrSQLParams[9] = new SqlParameter("@User_Email", strUserEmail);

                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_CONVERSATION_MESSAGE,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    strMessageID = OutputVariables[0].ToString();
                }
                return strMessageID;

            }
            catch
            {

                throw;
            }

        }

        public bool DeleteConversationMessages(string strMessageID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            //DataSet ds;
            bool bolResult;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Reply_Message_ID", strMessageID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(Procedure.SP_DELETE_CONVERSATION_MESSAGE,
                     arrSQLParams);

                //intTotalConversations = int.Parse(arrSQLParams[3].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return bolResult;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetHotConverastions(string AccountID,
                    int intItemsPerPage,
                    int intPageCount,
                    string strConversationStatus,
                    string strProductID,
                    string strTagID,
                    ref int intTotalConversations)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[7];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);
                arrSQLParams[1] = new SqlParameter("@Page_Count", intItemsPerPage);
                arrSQLParams[2] = new SqlParameter("@Page_No", intPageCount);

                if (strConversationStatus == "")
                {
                    arrSQLParams[3] = new SqlParameter("@Conversation_Status", DBNull.Value);
                }
                else
                {
                    arrSQLParams[3] = new SqlParameter("@Conversation_Status", strConversationStatus);
                }
                if (strTagID == "")
                {
                    arrSQLParams[4] = new SqlParameter("@Tag_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[4] = new SqlParameter("@Tag_ID", strTagID);
                }

                if (strProductID == "")
                {
                    arrSQLParams[5] = new SqlParameter("@Product_ID", DBNull.Value);


                }
                else
                {
                    arrSQLParams[5] = new SqlParameter("@Product_ID", strProductID);
                }
                arrSQLParams[6] = new SqlParameter("@TotalConversations", SqlDbType.Int);
                arrSQLParams[6].Direction = ParameterDirection.Output;

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords1(Procedure.SP_GET_HOT_CONVERSATIONS,
                     ref arrSQLParams);

                intTotalConversations = int.Parse(arrSQLParams[6].Value.ToString());
                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());

                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetMostViewedConversations(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_Get_Most_Viewed_Topics,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }

        public bool UpdateConversationDetails(
            string strConversationID,
            string strProductID,
            string strSeverityID,
            string strAssignedTo,
            string strCategoryID,
            string strUserID,
            DateTime dtmDate
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
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[7];

            //Method Logic
            try
            {


                arrSQLParams[0] = new SqlParameter("@Conversation_ID", strConversationID);
                if (strProductID == "")
                {
                    arrSQLParams[1] = new SqlParameter("@Product_ID", DBNull.Value);
                }
                else
                {
                    arrSQLParams[1] = new SqlParameter("@Product_ID", strProductID);

                }
                if (strSeverityID == "")
                {
                    arrSQLParams[2] = new SqlParameter("@Conversation_Severity", DBNull.Value);
                }
                else
                {
                    arrSQLParams[2] = new SqlParameter("@Conversation_Severity", strSeverityID);

                }
                if (strAssignedTo == "")
                {
                    arrSQLParams[3] = new SqlParameter("@Assigned_To", DBNull.Value);

                }
                else
                {
                    arrSQLParams[3] = new SqlParameter("@Assigned_To", strAssignedTo);

                }
                if (strCategoryID == "")
                {
                    arrSQLParams[4] = new SqlParameter("@Category_ID", DBNull.Value);

                }
                else
                {
                    arrSQLParams[4] = new SqlParameter("@Category_ID", strCategoryID);

                }


                arrSQLParams[5] = new SqlParameter("@User_ID", strUserID);
                arrSQLParams[6] = new SqlParameter("@Updated_Date", dtmDate);


                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_UPDATE_CONVERSATION_DETAILS,
                    arrSQLParams);
                return true;
            }
            catch
            {

                throw;
            }

        }

    }
}