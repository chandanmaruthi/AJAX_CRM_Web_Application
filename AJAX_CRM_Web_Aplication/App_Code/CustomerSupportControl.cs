#region DotNetNamespaces

using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Net;

#endregion
//using CustomerSupport.Entity;
using CustomerSupport.Utility;
using CustomerSupport.Data;

namespace CustomerSupport
{
    public class CustomerSupportControl : System.Web.UI.UserControl
    {
        public const string AccountID = "AccountID";
        public const string UserName = "UserName";
        public const string UserID = "UserID";
        public const string Email_ID = "EmailID";
        public const string IsLoggedIn = "IsLoggedIn";

        //Filter Conditions
        public const string Filter_Product_ID = "Filter_Product_ID";
        public const string Filter_Product_Name = "Filter_Product_Name";
        public const string Filter_Status_ID = "Filter_Status_ID";
        public const string Filter_Status_Name = "Filter_Status_Name";
        public const string Filter_Probability_ID = "Filter_Probability_ID";
        public const string Filter_Category_ID = "Filter_Category_ID";
        public const string Filter_Tag_ID = "Filter_Tag_ID";

        //Branding
        public const string Background_Color = "Background_Color";
        public const string Font_Color = "Font__Color";
        public const string Header_Text = "Header_Text";
        public const string Welcome_Message = "Welcome_Message";
        public const string Logo_File = "Logo_File";
        public const string Account_Name = "Account_Name";
        public const string Active_Tab_Bg_Color = "Active_Tab_Bg_Color";
        public const string Active_Tab_Text_Color = "Active_Tab_Text_Color";
        public const string InActive_Tab_Bg_Color = "InActive_Tab_Bg_Color";
        public const string InActive_Tab_Text_Color = "InActive_Tab_Text_Color";
        
        public const string VALIDATE_EMAIL = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string VALIDATE_USZIPCODE = "^d{5}(-d{4})?$";
        public const string VALIDATE_USPHONE = "^(((d{3})s?)|[-.s]?(d{3}[-.s]))d{3}[-.s]d{4}$";
        public const string VALIDATE_USSSN = "^d{3}-d{2}-d{4}$";
        public const string VALIDATE_URL = "^http(s)?://([w-]+.?)+[w-]*(/[w- ./?%=]*)?";
        public const string VALIDATE_INTEGER = "^[0-9]+$";
        public const string VALIDATE_FLOAT = "^[0-9.]+$";
        public const string VALIDATE_ALPHA = "^[a-zA-Zs]+$";

        public bool ValidateInput(string strFormat, string strValue)
        {
            //strFormat = NullToString(strFormat);
            Regex re = new Regex(strFormat);
            if (re.IsMatch(strValue))
                return (true);
            else
                return (false);
        }

        public string GetState(string s)
        {
            if (Session[s] != null) { return (string)Session[s]; } else { return string.Empty; }
        }
        public void SetState(string s, string v)
        {
            Session[s] = v;
        }
        public string NullToString(string s)
        {
            return (s == null) ? "" : s.Trim();
        }
        public string NullToString_Obj(object obj)
        {
            return (obj == null) ? "" : obj.ToString();
        }

        public bool isEmail(string inputEmail)
        {
            inputEmail = NullToString(inputEmail);
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }


    }


}