using System;
using System.Data;
using System.Data.SqlClient;
using CustomerSupport.Data;
using CustomerSupport.Utility;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for Account
/// </summary>
namespace CustomerSupport.Data
{
    public class Account
    {
        public Account()
        {

            //
            // TODO: Add constructor logic here
            //
        }

        public string AddAccount(
                  string FullName,
                  string EmailId,
                  string Password,
                  string ContactPhone,
                  string ContactEmail,
                    ref string strUserID,
                string strAccountName,
                string strTimeZoneID,
                int intSubscription_Plan)
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

            string AccountID = "";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[11];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[0].Direction = ParameterDirection.Output;
                arrSQLParams[1] = new SqlParameter("@User_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[1].Direction = ParameterDirection.Output;
                arrSQLParams[2] = new SqlParameter("@First_Name", FullName);
                arrSQLParams[3] = new SqlParameter("@Last_Name", "");
                arrSQLParams[4] = new SqlParameter("@Email_ID", EmailId);
                arrSQLParams[5] = new SqlParameter("@Password", CustomerSupport.Utility.Security.CalculateMD5Hash(Password));
                arrSQLParams[6] = new SqlParameter("@Contact_Phone_1", ContactPhone);
                arrSQLParams[7] = new SqlParameter("@Contact_Phone_2", ContactEmail);
                arrSQLParams[8] = new SqlParameter("@Account_Name", strAccountName);
                if (strTimeZoneID == "")
                { arrSQLParams[9] = new SqlParameter("@Time_Zone_ID", DBNull.Value); 
                }
                else
                {
                    arrSQLParams[9] = new SqlParameter("@Time_Zone_ID", strTimeZoneID);
                }
                arrSQLParams[10] = new SqlParameter("@Subscription_Plan", intSubscription_Plan); 
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_ADD_ACCOUNT,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    AccountID = OutputVariables[0].ToString();
                    strUserID = OutputVariables[1].ToString();
                }
                return AccountID;
            }
            catch
            {

                throw;
            }

        }
        public bool UpdateAccount(
                    string AccountId,
                   string FullName,
                   string EmailId,
                   string ContactPhone,
                   string ContactEmail,
            string strSalesForceOrgID)
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

                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountId);
                arrSQLParams[1] = new SqlParameter("@First_Name", FullName);
                arrSQLParams[2] = new SqlParameter("@Last_Name", "");
                arrSQLParams[3] = new SqlParameter("@Email_ID", EmailId);
                arrSQLParams[4] = new SqlParameter("@Contact_Phone_1", ContactPhone);
                arrSQLParams[5] = new SqlParameter("@Contact_Phone_2", ContactEmail);
                arrSQLParams[6] = new SqlParameter("@SalesForceOrgID", strSalesForceOrgID);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_ACCOUNT,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }

        public bool IsAuthenticUser(string EmailId,
                                    string UserPass,
                                    ref string AccountID,
                                    ref string strUserID
                                   )
        {
            //---------------------------------------------------------------------------------
            //Function Name:
            //Description:
            //Created On: 
            //Created By: Chandan Maruthi
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------

            //Define Local Variables
            DataSet dstUserData = new DataSet();
            bool IsAuthentic = false;
            //string ReturnAccountID = "";
            string[] OutputVariables;
            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[5];
            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Email_ID", EmailId);
                arrSQLParams[1] = new SqlParameter("@Password", CustomerSupport.Utility.Security.CalculateMD5Hash(UserPass));

                arrSQLParams[2] = new SqlParameter("@Account_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[2].Direction = ParameterDirection.Output;

                arrSQLParams[3] = new SqlParameter("@User_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[3].Direction = ParameterDirection.Output;

                arrSQLParams[4] = new SqlParameter("@isAuthenticated", SqlDbType.Bit);
                arrSQLParams[4].Direction = ParameterDirection.Output;

                //arrSQLParams[1] = new SqlParameter("@Password", CustomerSupport.Utility.Security.CalculateMD5Hash(UserPass));

                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_AUTHENTICATE_USER,
                   arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    AccountID = OutputVariables[0].ToString();
                    strUserID = OutputVariables[1].ToString();
                    IsAuthentic = bool.Parse(OutputVariables[2].ToString());
                    return IsAuthentic;
                }

                else
                {
                    AccountID = "";
                    strUserID = "";
                    return false;
                }
            }
            catch
            {

                throw;
            }

        }
        public bool IsAuthenticSFUser(string SFOrgID,
                                    ref string AccountID
                                   )
        {
            //---------------------------------------------------------------------------------
            //Function Name:
            //Description:
            //Created On: 
            //Created By: Chandan Maruthi
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------

            //Define Local Variables
            DataSet dstUserData = new DataSet();
            bool IsAuthentic = false;
            //string ReturnAccountID = "";
            string[] OutputVariables;
            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[3];
            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@SFOrgID", SFOrgID);

                arrSQLParams[1] = new SqlParameter("@Account_ID", SqlDbType.UniqueIdentifier);
                arrSQLParams[1].Direction = ParameterDirection.Output;

                arrSQLParams[2] = new SqlParameter("@isAuthenticated", SqlDbType.Bit);
                arrSQLParams[2].Direction = ParameterDirection.Output;


                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_AUTHENTICATE_SF_USER,
                   arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    AccountID = OutputVariables[0].ToString();
                    IsAuthentic = bool.Parse(OutputVariables[1].ToString());
                    return IsAuthentic;
                }

                else
                {
                    AccountID = "";
                    return false;
                }
            }
            catch
            {

                throw;
            }

        }
        public DataSet GetAccountDetails(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_ACCOUNT,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetAccountDetailsFromWidget(string WidgetID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Widget_ID", WidgetID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_ACCOUNT_FROM_WIDGET,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }

        public void LoginValidUser(string Account_ID, string strUser_ID, bool bolPersistLogin)
        {
            Account objAccount = new Account();
            AccountUser objUser = new AccountUser();
            CustomerSupport.CustomerSupportPage objCustomerSupportPage = new CustomerSupport.CustomerSupportPage();

            DataSet objUserData;
            objUserData = objUser.GetUserDetails(strUser_ID);
            if (objUserData.Tables[0].Rows.Count > 0)
            {
                FormsAuthentication.RedirectFromLoginPage(objUserData.Tables[0].Rows[0]["Account_ID"].ToString(), bolPersistLogin);
                //FormsAuthentication.SetAuthCookie(objAccountData.Tables[0].Rows[0]["First_Name"].ToString(), false);
                objCustomerSupportPage.SetState(CustomerSupport.CustomerSupportPage.AccountID, Account_ID);
                objCustomerSupportPage.SetState(CustomerSupport.CustomerSupportPage.UserName, objUserData.Tables[0].Rows[0]["User_F_Name"].ToString());
                objCustomerSupportPage.SetState(CustomerSupport.CustomerSupportPage.IsLoggedIn, "1");
                objCustomerSupportPage.SetState(CustomerSupport.CustomerSupportPage.Email_ID, objUserData.Tables[0].Rows[0]["Email_ID"].ToString());

            }
        }

        public bool UpdateAccountCredits(
                     string AccountId,
                     int intCredits)
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
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountId);
                arrSQLParams[1] = new SqlParameter("@Credits", intCredits);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_ADD_CREDITS,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }
        public bool UpdateAccountPlan(
                 string AccountId,
                 string strPlan)
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
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[2];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountId);
                arrSQLParams[1] = new SqlParameter("@Plan", strPlan);

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_SUBSCRIPTION,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }

        public bool bolEmailExists(
                 string EmailId)
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

                arrSQLParams[0] = new SqlParameter("@Email_ID", EmailId);
                arrSQLParams[1] = new SqlParameter("@bitExists", SqlDbType.Bit);
                arrSQLParams[1].Direction = ParameterDirection.Output;
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_IS_USER_EMAIL_EXISTS,
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
        public bool bolAccountNameExists(string strAccountName)
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

                arrSQLParams[0] = new SqlParameter("@Account_Name", strAccountName);
                arrSQLParams[1] = new SqlParameter("@bitExists", SqlDbType.Bit);
                arrSQLParams[1].Direction = ParameterDirection.Output;
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_IS_ACCOUNT_NAME_EXISTS,
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
        public DataSet GetAccountSummary(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@AccountID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_ACCOUNT_SUMMARY,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetAllAccountSummary()
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[0];
            DataSet ds;
            //bool bolResult;
            //Method Logic
            try
            {
                //arrSQLParams[0] = new SqlParameter("@AccountID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_CustomerSupport_SUMMARY,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }

        public DataSet GetSeverity()
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[0];
            DataSet ds;
            //bool bolResult;
            //Method Logic
            try
            {
                //arrSQLParams[0] = new SqlParameter("@AccountID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_SEVERITY,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }

        public bool bolRedeemCoupon(
                     string strAccountID,
                     string strCouponCode)
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
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[3];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Coupon_Code", strCouponCode);
                arrSQLParams[1] = new SqlParameter("@Account_ID", strAccountID);
                arrSQLParams[2] = new SqlParameter("@bitResult", SqlDbType.Bit);
                arrSQLParams[2].Direction = ParameterDirection.Output;
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_REDEEM_COUPON,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    strResult = OutputVariables[0].ToString();
                }
                if (strResult.ToLower() == "true")
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
        public bool SetPasswordRecovery(
              string EmailID, ref string ValidationCode)
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

            string strResult = "0";
            //string strValidationCode = "";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[3];

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@EmailID", EmailID);
                arrSQLParams[1] = new SqlParameter("@Result", SqlDbType.Int);
                arrSQLParams[1].Direction = ParameterDirection.Output;
                arrSQLParams[2] = new SqlParameter("@ValidationCode", SqlDbType.UniqueIdentifier);
                arrSQLParams[2].Direction = ParameterDirection.Output;
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_SET_RECOVER_PASSWORD,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    strResult = OutputVariables[0].ToString();
                    ValidationCode = OutputVariables[1].ToString();
                }
                if (strResult == "100")
                { return true; }
                else
                { return false; }
            }
            catch
            {

                throw;
            }
        }
        public string RecoverChangePassword(
              string strValidationCode,
                string strPassword)
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

            string strResult = "0";
            string[] OutputVariables;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[3];

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Validation_Code", strValidationCode);
                arrSQLParams[1] = new SqlParameter("@Password", strPassword);
                arrSQLParams[2] = new SqlParameter("@Result", SqlDbType.Int);
                arrSQLParams[2].Direction = ParameterDirection.Output;
                OutputVariables = objDataManager.ExecuteStoredProcedureReturnVariables(CustomerSupport.Data.Procedure.SP_RECOVER_PASSWORD,
                    arrSQLParams);

                if (OutputVariables.Length > 0)
                {
                    strResult = OutputVariables[0].ToString();
                }
                return strResult;
            }
            catch
            {

                throw;
            }
        }


        public DataSet GetTimeZoneByID(string strTimeZoneID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Time_Zone_ID", strTimeZoneID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_TIME_ZONE_BY_ID,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet GetAllTimeZones()
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[0];
            DataSet ds;

            //Method Logic
            try
            {

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_TIME_ZONES,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }

        //public string GetResolveURL(String strAccountURL, string strConversationURL)
        //{
        //    //Define Objects
        //    CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
        //    //string[] OutputVariables;
        //    string RedirectURL = string.Empty;
        //    System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];
        //    //Method Logic
        //    try
        //    {
        //        arrSQLParams[0] = new SqlParameter("@AccountURL", strAccountURL);
        //        arrSQLParams[1] = new SqlParameter("@ConversationURL", strConversationURL);
        //        arrSQLParams[2] = new SqlParameter("@AccountID", SqlDbType.UniqueIdentifier);
        //        arrSQLParams[2].Direction = ParameterDirection.Output;
        //        arrSQLParams[3] = new SqlParameter("@ConversationID", SqlDbType.UniqueIdentifier);
        //        arrSQLParams[3].Direction = ParameterDirection.Output;

        //        DataSet objData;
        //        objData = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords1(Procedure.SP_GET_RESOLVE_URL,
        //                           ref arrSQLParams);

        //        string AccountID = arrSQLParams[2].Value.ToString();
        //        string ConversationID = arrSQLParams[3].Value.ToString();
        //        CustomerSupport.CustomerSupportPage objPage = new CustomerSupport.CustomerSupportPage();

        //        if (AccountID.Length == 0 && ConversationID.Length == 0)
        //        {
        //            RedirectURL = "~/default.aspx";
        //        }
        //        else if (AccountID.Length == 36 && ConversationID.Length == 0)
        //        {


        //            //objPage.SetState(CustomerSupport.CustomerSupportPage.AccountID, AccountID);
        //            RedirectURL = "~/default.aspx?Account_ID=" + AccountID;
        //        }
        //        else if (AccountID.Length == 36 && ConversationID.Length == 36)
        //        {

        //            //objPage.SetState(CustomerSupport.CustomerSupportPage.AccountID, AccountID);
        //            RedirectURL = "~/SupportCenter/topic.aspx?Account_ID=" + AccountID + "&ID=" + ConversationID;
        //        }

        //        return RedirectURL;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool UpdateAccountBranding(
                  string strAccountId,
                 string strLogo_File,
                 string strBackground_Color,
                 string strHeader_Font_Color,
                 string strHeader_Text,
                string strWelcome_Message,
            string Active_Tab_Bg_Color ,
string Active_Tab_Text_Color ,
string InActive_Tab_Bg_Color ,
string InActive_Tab_Text_Color 
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


            bool bolResult = false;

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[10];

            //Method Logic
            try
            {

                arrSQLParams[0] = new SqlParameter("@Account_id", strAccountId);
                arrSQLParams[1] = new SqlParameter("@Logo_File", strLogo_File);
                arrSQLParams[2] = new SqlParameter("@Background_Color", strBackground_Color);
                arrSQLParams[3] = new SqlParameter("@Font_Color", strHeader_Font_Color);
                arrSQLParams[4] = new SqlParameter("@Header_Text", strHeader_Text);
                arrSQLParams[5] = new SqlParameter("@Welcome_Message", strWelcome_Message);
                arrSQLParams[6] = new SqlParameter("@Active_Tab_Bg_Color", Active_Tab_Bg_Color);
                arrSQLParams[7] = new SqlParameter("@Active_Tab_Text_Color", Active_Tab_Text_Color);
                arrSQLParams[8] = new SqlParameter("@InActive_Tab_Bg_Color", InActive_Tab_Bg_Color);
                arrSQLParams[9] = new SqlParameter("@InActive_Tab_Text_Color", InActive_Tab_Text_Color);
                
 

                 
 

                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_ACCOUNT_BRANDING,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }

        public DataSet GetAccountBrandingDetails(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_ACCOUNT_BRANDING,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public bool UpdateAccountLogo(
                   string strAccountID,
                  string strLogoFileName)
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

                arrSQLParams[0] = new SqlParameter("@Account_ID", strAccountID);
                arrSQLParams[1] = new SqlParameter("@Logo_File", strLogoFileName);


                bolResult = objDataManager.ExecuteStoredProcedureNoReturn(CustomerSupport.Data.Procedure.SP_UPDATE_ACCOUNT_LOGO,
                    arrSQLParams);

                return bolResult;
            }
            catch
            {

                throw;
            }

        }
        public DataSet GetAccountDetailsBySearch(string strSearchString)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Search_String", strSearchString);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_Get_Company_Portals_By_Search,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }

        public DataSet GetAccountSetupCompletionStatus(string AccountID)
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];
            DataSet ds;

            //Method Logic
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", AccountID);

                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_Get_Setup_Completion_Status,
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