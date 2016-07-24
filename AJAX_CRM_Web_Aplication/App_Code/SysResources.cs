#region DotNetNamespaces

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Configuration;
//using JustOnDemand.Entity;

#endregion
using CustomerSupport.Data;
namespace CustomerSupport.Utility
{

    public static class SysResource
    {
        const string strDBConnStr = "strDBSTR";
        const string strImagePath = "strImagesPath";
        const string strCSSPath = "strCSSPath";
        const string strUserData = "strUserData";
        const string strTemplatesPath = "strTemplatesPath";
        const string strJavascriptPath = "strJavascriptPath";
        const string strFromID = "strFromID";
        const string strErrorPagePath = "strErrorPagePath";
        const string strSearchDirectory = "strSearchDirectory";
        const string strHomePath = "strHomePath";
        const string strSiteURL = "strSiteURL";
        const string strCPPath = "strCPPath";
        const string strSupportEmail = "SupportEmail";
        const string strStoreXMLFilePath = "strStoreXMLFilePath";
        const string strEmailTemplatePath = "strEmailTemplatePath";
        const string strSiteLink = "strSiteLink";
        const string strLocal = "strLocal";
        const string strPGPath = "strPaymentGWPath";
        const string strPG2Path = "strPaymentGW2Path";
        const string strSMSURL = "SMSJunctionURL";
        const string strSMSTEXT = "SMSText";
        const string strSMSTEXTRetailer = "SMSText_Retailer";
        const string strTF_ConversationAlert = "strTF_ConversationAlert";
        const string strTF_WelcomeEmail = "strTF_WelcomeEmail";
        const string strTF_ForgotPassword = "strTF_ForgotPassword";
        const string strTF_WelcomeNewUser = "strTF_WelcomeNewUser";
        const string strCustImgPath = "strCustImgPath";
        const string strRootPhyPath = "strRootPhyPath";
        const string strLoginFirst = "Please <a href='/index.aspx' title='Login'>login</a> first";
        const string strMasterTags_Description = "MasterMetaDesc";
        const string strMasterTags_Keywords = "MasterMetaKeywords";
        const string strMasterTags_Distribution = "MetaDistribution";
        const string strMasterTags_Revisit_After = "MetaRevisitAfter";


        static string strImagePathVal;
        static string strCSSPathVal;
        static string strUserDataVal;
        static string strTemplatesPathVal;
        static string strDBConStrVal;
        static string strJavascriptPathVal;
        static string strSearchDirectoryVal;
        static string strErrorPagePathVal;
        static string strHomePathVal;
        static string strSiteURLVal;
        static string strSiteLinkVal;
        static string strLocalVal;
        static string strFromIDVal;


        //EMAIL
        static string strEmailTemplatePathVal;
        static string strTF_ConversationAlertVal;
        static string strTF_WelcomeEmailVal;
        static string strTF_ForgotPasswordVal;
        static string strTF_WelcomeNewUserVal;



        static SysResource()
        {


            //Define Objects
            System.Configuration.AppSettingsReader objAppSettingsReader = new AppSettingsReader();

            //Method Logic
            try
            {
                //DecryptAppSettings();
                strSiteURLVal = objAppSettingsReader.GetValue(strSiteURL, typeof(String)).ToString();
                strDBConStrVal = objAppSettingsReader.GetValue(strDBConnStr, typeof(String)).ToString(); //Moved to Decrypt Function
                strImagePathVal = strSiteURLVal + objAppSettingsReader.GetValue(strImagePath, typeof(String)).ToString();
                strCSSPathVal = strSiteURLVal + objAppSettingsReader.GetValue(strCSSPath, typeof(String)).ToString();
                strTemplatesPathVal = strSiteURLVal + objAppSettingsReader.GetValue(strTemplatesPath, typeof(String)).ToString();
                strJavascriptPathVal = strSiteURLVal + objAppSettingsReader.GetValue(strJavascriptPath, typeof(String)).ToString();
                strErrorPagePathVal = objAppSettingsReader.GetValue(strErrorPagePath, typeof(String)).ToString();
                strHomePathVal = objAppSettingsReader.GetValue(strHomePath, typeof(String)).ToString();
                strUserDataVal = objAppSettingsReader.GetValue(strUserData, typeof(String)).ToString();
                strSearchDirectoryVal = objAppSettingsReader.GetValue(strSearchDirectory, typeof(String)).ToString();

                strEmailTemplatePathVal = objAppSettingsReader.GetValue(strEmailTemplatePath, typeof(String)).ToString();
                strTF_ForgotPasswordVal = objAppSettingsReader.GetValue(strTF_ForgotPassword, typeof(String)).ToString();
                strTF_ConversationAlertVal = objAppSettingsReader.GetValue(strTF_ConversationAlert, typeof(String)).ToString();
                strTF_WelcomeEmailVal = objAppSettingsReader.GetValue(strTF_WelcomeEmail, typeof(String)).ToString();
                strTF_WelcomeNewUserVal = objAppSettingsReader.GetValue(strTF_WelcomeNewUser, typeof(String)).ToString();
                strFromIDVal = objAppSettingsReader.GetValue(strFromID, typeof(String)).ToString();
                strSiteLinkVal = objAppSettingsReader.GetValue(strSiteLink, typeof(String)).ToString();
                strLocalVal = objAppSettingsReader.GetValue(strLocal, typeof(String)).ToString();


            }
            catch
            {
                throw;
            }
        }
        private static void EncryptAppSettings()
        {
            Configuration objConfig = WebConfigurationManager.OpenWebConfiguration("~");
            ConfigurationSection section = objConfig.ConnectionStrings;
            //AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");
            if (!section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                section.SectionInformation.ForceSave = true;
                objConfig.Save(ConfigurationSaveMode.Modified);
            }
        }

        private static void DecryptAppSettings()
        {
            Configuration objConfig = WebConfigurationManager.OpenWebConfiguration("~");
            ConfigurationSection section = objConfig.ConnectionStrings;

            strDBConStrVal = objConfig.ConnectionStrings.ConnectionStrings["strDBSTR"].ToString();

            //AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");
            if (section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
                section.SectionInformation.ForceSave = true;
                objConfig.Save(ConfigurationSaveMode.Modified);
            }
        }
        public static bool None()
        {
            return true;
        }


        public static string EmailTemplate_Path
        {
            get
            {
                return strEmailTemplatePathVal;// "http://66.36.229.70:8800/?user=jod[amp]password=jod567[amp]PhoneNumber=[PHONE][amp]";
            }
        }
        public static string FromID
        {
            get
            {
                return strFromIDVal;
            }
        }

        public static string ConnString
        {
            get
            {
                return strDBConStrVal;
            }
        }
        public static string ImagePath
        {
            get
            {
                return strImagePathVal;
            }
        }
        public static string CSSPath
        {
            get
            {
                return strCSSPathVal;
            }
        }
        public static string SearchDirectory
        {
            get
            {
                return strSearchDirectoryVal;
            }
        }
        public static string TemplatesPath
        {
            get
            {
                return strTemplatesPathVal;
            }
        }
        public static string JavascriptPath
        {
            get
            {
                return strJavascriptPathVal;
            }
        }
        public static string ErrorPagePath
        {
            get
            {
                return strErrorPagePathVal;
            }
        }
        public static string HomePath
        {
            get
            {
                return strHomePathVal;
            }
        }
        public static string SiteURL
        {
            get
            {
                return strSiteURLVal;
            }
        }

        public static string TF_Welcome
        {
            get
            {
                return strTF_WelcomeEmailVal;
            }
        }
        public static string TF_WelcomeNewUser
        {
            get
            {
                return strTF_WelcomeNewUserVal;
            }
        }
        public static string TF_ForgotPassord
        {
            get
            {
                return strTF_ForgotPasswordVal;
            }
        }
        public static string TF_ConversationAlert
        {
            get
            {
                return strTF_ConversationAlertVal;
            }
        }
        public static string UserData
        {
            get
            {
                return strUserDataVal;
            }
        }
        public static string SiteLink
        {
            get
            {
                return strSiteLinkVal;
            }
        }
        public static string isLocal
        {
            get
            {
                return strLocalVal;
            }
        }

    }
}