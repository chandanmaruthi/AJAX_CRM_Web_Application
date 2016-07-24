<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Caching" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="CustomerSupport" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="CustomerSupport.Data" %>
<%@ Import Namespace="CustomerSupport.Utility" %>
<script RunAt="server">
   
    void Application_BeginRequest(object sender, EventArgs e)
    {
        string StoreID = string.Empty;
        string sCurPath;
        sCurPath = Request.ServerVariables["PATH_INFO"].ToLower();
        if (CustomerSupport.Utility.SysResource.isLocal == "1")
        {

        }
        else
        { 
        
        }
        
        
        if (sCurPath.IndexOf(".aspx".ToLower()) != -1 || sCurPath.IndexOf(".html".ToLower()) != -1 || sCurPath.IndexOf(".ashx".ToLower()) != -1 || sCurPath.IndexOf(".txt".ToLower()) != -1 || sCurPath.IndexOf(".htm".ToLower()) != -1 || sCurPath.IndexOf(".axd".ToLower()) != -1 || sCurPath.IndexOf(".js".ToLower()) != -1 || sCurPath.IndexOf(".css".ToLower()) != -1 || sCurPath.IndexOf(".jpg".ToLower()) != -1 || sCurPath.IndexOf(".jpeg".ToLower()) != -1 || sCurPath.IndexOf(".gif".ToLower()) != -1 || sCurPath.IndexOf(".png".ToLower()) != -1)
            return;
        if (sCurPath.IndexOf("Common".ToLower()) != -1)
            return;

        if (sCurPath == "/")
        {
            if (sCurPath.IndexOf(".aspx") == -1)
            {
                HttpContext.Current.RewritePath("~/index.aspx");
                return;
            }
        }

        string sFileName = string.Empty;
        
        // CompanyName and Topic rewriting
        string[] Seperator = { "/" };
        string[] arrURL = sCurPath.Split(Seperator, StringSplitOptions.RemoveEmptyEntries);
        string strAccountURL = "";
        string strTopicURL = "";

        if (arrURL.Length == 0)
        {
            HttpContext.Current.RewritePath("~/index.aspx");
            return;
        }
        
        if (arrURL.Length == 3)
        {
            strAccountURL = arrURL[0];
            
            strTopicURL = arrURL[1];
        }
        else if (arrURL.Length == 1)
        {
            strAccountURL = arrURL[0];
            strTopicURL = "";
        }



        String RedirectURL = ReadItem(strAccountURL, strTopicURL);

        HttpContext.Current.RewritePath(RedirectURL);

        return;
    }
    void Application_Start(object sender, EventArgs e)
    {
    

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        ////Code that runs when an unhandled error occurs
        Exception ex = Server.GetLastError();
        email objEmail = new email();
        bool bolResult;
        Errors objErrors = new Errors();

        //Log error
        bolResult = objErrors.bolAddError(ex.Message + ex.StackTrace, Request.ServerVariables["SERVER_NAME"].ToString(), ex.Source, ex.Source);

        //Notify admin
        bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, CustomerSupport.Utility.SysResource.FromID, "Error", ex.Source + "<br>Message" + ex.Message + "<br>InnerException" + ex.InnerException.ToString() + ex.StackTrace);

        //clear error
       // Server.ClearError();


        //signout user to prevent further problems
       // FormsAuthentication.SignOut();

        //display error message
       // Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "manage/Error.aspx");
    }


    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started



    }

    void Session_End(object sender, EventArgs e)
    {

    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        // Extract the forms authentication cookie
        string cookieName = FormsAuthentication.FormsCookieName;
        HttpCookie authCookie = Context.Request.Cookies[cookieName];

        if (null == authCookie)
        {
            // There is no authentication cookie.
            return;
        }
        FormsAuthenticationTicket authTicket = null;
        try
        {
            authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        }
        catch
        {
            // Log exception details (omitted for simplicity)
            throw;
        }

        if (null == authTicket)
        {
            // Cookie failed to decrypt.
            return;
        }
        // When the Conversation was created, the UserData property was assigned a
        // pipe delimited string of role names.
        string[] roles = authTicket.UserData.Split(new char[] { '|' });
        // Create an Identity object
        FormsIdentity id = new FormsIdentity(authTicket);

        // This principal will flow throughout the request.
        GenericPrincipal principal = new GenericPrincipal(id, roles);
        // Attach the new principal object to the current HttpContext object
        Context.User = principal;
    }
    public  String ReadItem(string strAccountURL, string strConversationURL)
    {
        string RedirectURL = GetResolveURL(strAccountURL, strConversationURL);
        return RedirectURL;
    }
    public string GetResolveURL(String strAccountURL, string strConversationURL)
    {
        //Define Objects
        CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
        //string[] OutputVariables;
        string RedirectURL = string.Empty;
        System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[4];
        //Method Logic
        try
        {
            arrSQLParams[0] = new SqlParameter("@AccountURL", strAccountURL);
            arrSQLParams[1] = new SqlParameter("@ConversationURL", strConversationURL);
            arrSQLParams[2] = new SqlParameter("@AccountID", SqlDbType.UniqueIdentifier);
            arrSQLParams[2].Direction = ParameterDirection.Output;
            arrSQLParams[3] = new SqlParameter("@ConversationID", SqlDbType.UniqueIdentifier);
            arrSQLParams[3].Direction = ParameterDirection.Output;

            DataSet objData;
            objData = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords1(Procedure.SP_GET_RESOLVE_URL,
                               ref arrSQLParams);

            string AccountID = arrSQLParams[2].Value.ToString();
            string ConversationID = arrSQLParams[3].Value.ToString();
            CustomerSupport.CustomerSupportPage objPage = new CustomerSupport.CustomerSupportPage();

            if (AccountID.Length == 0 && ConversationID.Length == 0)
            {
                RedirectURL = "~/default.aspx";
            }
            else if (AccountID.Length == 36 && ConversationID.Length == 0)
            {


                //objPage.SetState(CustomerSupport.CustomerSupportPage.AccountID, AccountID);
                RedirectURL = "~/default.aspx?Account_ID=" + AccountID;
            }
            else if (AccountID.Length == 36 && ConversationID.Length == 36)
            {

                //objPage.SetState(CustomerSupport.CustomerSupportPage.AccountID, AccountID);
                RedirectURL = "~/SupportCenter/topic.aspx?Account_ID=" + AccountID + "&ID=" + ConversationID;
            }

            return RedirectURL;
        }
        catch (Exception)
        {
            throw;
        }
    }

   
</script>

