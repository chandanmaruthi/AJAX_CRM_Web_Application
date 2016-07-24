#region DotNetNamespaces

#endregion

#region CustomNamespaces

#endregion

namespace CustomerSupport.Data
{
    //enum procedure { }
    public static class Procedure
    {
        public const string SP_ADD_ACCOUNT = "SP_ADD_ACCOUNT";
        public const string SP_ADD_CONVERSATION = "SP_ADD_CONVERSATION";
        public const string SP_ADD_WIDGET = "SP_ADD_WIDGET";
        public const string SP_ADD_WIDGET_QUESTIONS = "SP_ADD_WIDGET_QUESTIONS";
        public const string SP_DELETE_ACCOUNT = "SP_DELETE_ACCOUNT";
        public const string SP_DELETE_LEAD = "SP_DELETE_LEAD";
        public const string SP_DELETE_WIDGET = "SP_DELETE_WIDGET";
        public const string SP_GET_ACCOUNT = "SP_GET_ACCOUNT";
        public const string SP_GET_ALL_CONVERSATIONS_BY_ACCOUNT = "SP_GET_ALL_CONVERSATIONS_BY_ACCOUNT";
        public const string SP_GET_WIDGET = "SP_GET_WIDGET";
        public const string SP_UPDATE_ACCOUNT = "SP_UPDATE_ACCOUNT";
        public const string SP_UPDATE_CONVERSATION = "SP_UPDATE_CONVERSATION";
        public const string SP_UPDATE_WIDGET = "SP_UPDATE_WIDGET";
        public const string SP_UPDATE_WIDGET_QUESTIONS = "SP_UPDATE_WIDGET_QUESTIONS";
        public const string SP_AUTHENTICATE_USER = "SP_AUTHENTICATE_USER";
        public const string SP_GET_WIDGET_LAYOUT = "SP_GET_WIDGET_LAYOUT";
        public const string SP_GET_ALL_WIDGETS_BY_ACCOUNT = "SP_GET_ALL_WIDGETS_BY_ACCOUNT";
        public const string SP_ADD_CONVERSATION_FROM_WIDGET = "SP_ADD_CONVERSATION_FROM_WIDGET";
        public const string SP_ADD_CREDITS = "SP_ADD_CREDITS";
        public const string SP_ADD_CONVERSATION_NOTES = "SP_ADD_CONVERSATION_NOTES";
        public const string SP_UPDATE_CONVERSATION_STATUS = "SP_UPDATE_CONVERSATION_STATUS";
        public const string SP_IS_USER_EMAIL_EXISTS = "SP_IS_USER_EMAIL_EXISTS";
        public const string SP_GET_ACCOUNT_SUMMARY = "SP_GET_ACCOUNT_SUMMARY";
        public const string SP_GET_CONVERSATION_BY_ID = "SP_GET_CONVERSATION_BY_ID";
        public const string SP_DELETE_WIDGET_QUESTION = "SP_DELETE_WIDGET_QUESTION";
        public const string SP_UPDATE_SUBSCRIPTION = "SP_UPDATE_SUBSCRIPTION";
        public const string SP_GET_ACCOUNT_FROM_WIDGET = "SP_GET_ACCOUNT_FROM_WIDGET";
        public const string SP_GET_ALL_CONVERSATIONS_BY_SEARCH = "SP_GET_ALL_CONVERSATIONS_BY_SEARCH";
        public const string SP_GET_CustomerSupport_SUMMARY = "SP_GET_CustomerSupport_SUMMARY";
        public const string SP_AUTHENTICATE_SF_USER = "SP_AUTHENTICATE_SF_USER";
        public const string SP_REDEEM_COUPON = "SP_REDEEM_COUPON";
        public const string SP_SET_RECOVER_PASSWORD = "SP_SET_RECOVER_PASSWORD";
        public const string SP_RECOVER_PASSWORD = "SP_RECOVER_PASSWORD";
        public const string SP_UPDATE_WIDGET_PICTURE = "SP_UPDATE_WIDGET_PICTURE";
        public const string SP_GET_NOTES = "SP_GET_NOTES";
        public const string SP_DELETE_NOTES = "SP_DELETE_LEAD_NOTES";
        public const string SP_UPDATE_CONVERSATION_RATING = "SP_UPDATE_CONVERSATION_RATING";
        public const string SP_DELETE_PRODUCTS = "SP_DELETE_PRODUCTS";
        public const string SP_ADD_PRODUCTS = "SP_ADD_PRODUCTS";
        public const string SP_UPDATE_PRODUCTS = "SP_UPDATE_PRODUCTS";
        public const string SP_GET_PRODUCTS = "SP_GET_PRODUCTS";
        public const string SP_UPDATE_TASK_STATUS = "SP_UPDATE_TASK_STATUS";
        public const string SP_ADD_TASKS = "SP_ADD_TASKS";
        public const string SP_UPDATE_TASKS = "SP_UPDATE_TASKS";
        public const string SP_DELETE_TASK = "SP_DELETE_TASK";
        public const string SP_GET_TASKS = "SP_GET_TASKS";
        public const string SP_GET_RECENT = "SP_GET_RECENT";
        public const string SP_ADD_RECENT = "SP_ADD_RECENT";
        public const string SP_GET_TASKS_SUMMARY = "SP_GET_TASKS_SUMMARY";
        public const string SP_GET_PIPELINE_SUMMARY = "SP_GET_PIPELINE_SUMMARY";
        public const string SP_ADD_USER = "SP_ADD_USER";
        public const string SP_UPDATE_USER = "SP_UPDATE_USER";
        public const string SP_DELETE_USER = "SP_DELETE_USER";
        public const string SP_GET_USER_BY_ID = "SP_GET_USER_BY_ID";
        public const string SP_GET_USERS_BY_ACCOUNT = "SP_GET_USERS_BY_ACCOUNT";
        public const string SP_ADD_SYS_ERROR = "SP_ADD_SYS_ERROR";
        public const string SP_GET_SYS_ERRORS = "SP_GET_SYS_ERRORS";
        public const string SP_ADD_TAG = "SP_ADD_TAG";
        public const string SP_DELETE_TAG = "SP_DELETE_TAG";
        public const string SP_GET_TAGS = "SP_GET_TAGS";
        public const string SP_ADD_ACCOUNT_STATUS = "SP_ADD_ACCOUNT_STATUS";
        public const string SP_UPDATE_ACCOUNT_STATUS = "SP_UPDATE_ACCOUNT_STATUS";
        public const string SP_DELETE_ACCOUNT_STATUS = "SP_DELETE_ACCOUNT_STATUS";
        public const string SP_GET_ALL_ACCOUNT_STATUS = "SP_GET_ALL_ACCOUNT_STATUS";
        public const string SP_GET_ACCOUNT_STATUS_BY_ID = "SP_GET_ACCOUNT_STATUS_BY_ID";
        public const string SP_ADD_TAG_TO_LEAD = "SP_ADD_TAG_TO_LEAD";
        public const string SP_REMOVE_TAG_FROM_LEAD = "SP_REMOVE_TAG_FROM_LEAD";
        public const string SP_GET_LEAD_TAGS = "SP_GET_LEAD_TAGS";
        public const string SP_GET_SEVERITY = "SP_GET_SEVERITY";
        public const string SP_ADD_CONVERSATION_MESSAGE = "SP_ADD_CONVERSATION_MESSAGE";
        public const string SP_UPDATE_CONVERSATION_MESSAGE = "SP_UPDATE_CONVERSATION_MESSAGE";
        public const string SP_GET_CONVERSATION_MESSAGES_BY_ID = "SP_GET_CONVERSATION_MESSAGES_BY_ID";
        public const string SP_DELETE_CONVERSATION = "SP_DELETE_CONVERSATION";
        public const string SP_DELETE_CONVERSATION_MESSAGE = "SP_DELETE_CONVERSATION_MESSAGE";
        public const string SP_ADD_TOPIC_CATEGORIES = "SP_ADD_TOPIC_CATEGORIES";
        public const string SP_UPDATE_TOPIC_CATEGORIES = "SP_UPDATE_TOPIC_CATEGORIES";
        public const string SP_DELETE_TOPIC_CATEGORIES = "SP_DELETE_TOPIC_CATEGORIES";
        public const string SP_GET_TOPIC_CATEGORIES = "SP_GET_TOPIC_CATEGORIES";
        public const string SP_GET_HOT_CONVERSATIONS = "SP_GET_HOT_CONVERSATIONS";
        public const string SP_GET_TIME_ZONES = "SP_GET_TIME_ZONES";
        public const string SP_GET_TIME_ZONE_BY_ID = "SP_GET_TIME_ZONE_BY_ID";
        public const string SP_GET_RESOLVE_URL = "SP_GET_RESOLVE_URL";
        public const string SP_ADD_ACCOUNT_BRANDING = "SP_ADD_ACCOUNT_BRANDING";
        public const string SP_UPDATE_ACCOUNT_BRANDING = "SP_UPDATE_ACCOUNT_BRANDING";
        public const string SP_GET_ACCOUNT_BRANDING = "SP_GET_ACCOUNT_BRANDING";
        public const string SP_UPDATE_ACCOUNT_LOGO = "SP_UPDATE_ACCOUNT_LOGO";
        public const string SP_GET_POPULAR_TAGS = "SP_GET_POPULAR_TAGS";
        public const string SP_Get_Most_Viewed_Topics = "SP_Get_Most_Viewed_Topics";
        public const string SP_Get_Conversation_History = "SP_Get_Conversation_History";
        public const string SP_IS_ACCOUNT_NAME_EXISTS = "SP_IS_ACCOUNT_NAME_EXISTS";
        public const string SP_Get_Data_For_Index = "SP_Get_Data_For_Index";
        public const string SP_UPDATE_CONVERSATION_DETAILS = "SP_UPDATE_CONVERSATION_DETAILS";
        public const string SP_Get_Company_Portals_By_Search = "SP_Get_Company_Portals_By_Search";
        public const string SP_IS_PRODUCT_NAME_EXISTS="SP_IS_PRODUCT_NAME_EXISTS";
        public const string SP_IS_CATEGORY_NAME_EXISTS = "SP_IS_CATEGORY_NAME_EXISTS";
        public const string SP_IS_TAG_NAME_EXISTS = "SP_IS_TAG_NAME_EXISTS";
        public const string SP_Get_Setup_Completion_Status = "SP_Get_Setup_Completion_Status";
    }
}