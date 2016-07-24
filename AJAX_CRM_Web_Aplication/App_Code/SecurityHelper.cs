#region DotNetNamespaces

using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

#endregion

#region CustomNamespaces

#endregion


namespace CustomerSupport.Utility
{
    static public class Security
    {
        public static char[] firstside = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', '-', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', ':', '.', '|', '"', '<', '>', ';' };
        public static string[] secondside = new string[] { "100", "200", "300", "400", "500", "600", "700", "800", "900", "101", "201", "301", "401", "501", "601", "701", "801", "901", "103", "203", "303", "403", "503", "603", "703", "803", "903", "110", "210", "310", "410", "510", "610", "710", "810", "910", "171", "271", "371", "471", "571", "671", "771", "871", "971", "197", "291", "391", "491", "591", "691", "791", "891", "991", "151", "251", "351" };

        public static string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        //public static string Encrypt(string toEncrypt, bool useHashstring)
        //{
        //    byte[] keyArray;
        //    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        //    System.Configuration.AppSettingsReader settstringsReader =
        //                                    new AppSettingsReader();
        //    // Get the key from config file

        //    string key = (string)settstringsReader.GetValue("SecurityKey",
        //                                                 typeof(string));
        //    //System.Windows.Forms.MessageBox.Show(key);
        //    //If hashstring use get hashcode regards to your key
        //    if (useHashstring)
        //    {
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //        //Always release the resources and flush data
        //        // of the Cryptographic service provide. Best Practice

        //        hashmd5.Clear();
        //    }
        //    else
        //        keyArray = UTF8Encoding.UTF8.GetBytes(key);

        //    TripleDESCryptoServiceProvider tdes =
        //             new TripleDESCryptoServiceProvider();
        //    //set the secret key for the tripleDES algorithm
        //    tdes.Key = keyArray;
        //    //mode of operation. there are other 4 modes.
        //    //We choose ECB(Electronic code Book)
        //    tdes.Mode = CipherMode.ECB;
        //    //Padding mode(if any extra byte added)

        //    tdes.Padding = PaddingMode.PKCS7;

        //    ICryptoTransform cTransform = tdes.CreateEncryptor();
        //    //transform the specified region of bytes array to resultArray
        //    byte[] resultArray =
        //      cTransform.TransformFinalBlock(toEncryptArray, 0,
        //      toEncryptArray.Length);
        //    //Release resources held by TripleDes Encryptor
        //    tdes.Clear();
        //    //Return the encrypted data into unreadable string format
        //    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //}
        //public static string Decrypt(string cipherstring, bool useHashstring)
        //{
        //    byte[] keyArray;
        //    //get the byte code of the string

        //    byte[] toEncryptArray = Convert.FromBase64String(cipherstring);

        //    System.Configuration.AppSettingsReader settstringsReader =
        //                                    new AppSettingsReader();
        //    //Get your key from config file to open the lock!
        //    string key = (string)settstringsReader.GetValue("SecurityKey",
        //                                                 typeof(string));

        //    if (useHashstring)
        //    {
        //        //if hashstring was used get the hash code with regards to your key
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //        //release any resource held by the MD5CryptoServiceProvider

        //        hashmd5.Clear();
        //    }
        //    else
        //    {
        //        //if hashstring was not implemented get the byte code of the key
        //        keyArray = UTF8Encoding.UTF8.GetBytes(key);
        //    }

        //    TripleDESCryptoServiceProvider tdes =
        //                new TripleDESCryptoServiceProvider();
        //    //set the secret key for the tripleDES algorithm
        //    tdes.Key = keyArray;
        //    //mode of operation. there are other 4 modes. 
        //    //We choose ECB(Electronic code Book)

        //    tdes.Mode = CipherMode.ECB;
        //    //Padding mode(if any extra byte added)
        //    tdes.Padding = PaddingMode.PKCS7;

        //    ICryptoTransform cTransform = tdes.CreateDecryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(
        //                         toEncryptArray, 0, toEncryptArray.Length);
        //    //Release resources held by TripleDes Encryptor                
        //    tdes.Clear();
        //    //return the Clear decrypted TEXT
        //    return UTF8Encoding.UTF8.GetString(resultArray);
        //}

        //public static string EasyEncryptMessage(string plainMessage)
        //{
        //    System.Configuration.AppSettingsReader settstringsReader =
        //                                   new AppSettingsReader();
        //    // Get the key from config file

        //    string password = (string)settstringsReader.GetValue("SecurityKey",
        //                                                 typeof(string));
        //    TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        //    des.IV = new byte[8];
        //    PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[0]);
        //    des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
        //    MemoryStream ms = new MemoryStream(plainMessage.Length * 2);
        //    CryptoStream enceam = new CryptoStream(ms, des.CreateEncryptor(),
        //    CryptoStreamMode.Write);
        //    byte[] plainBytes = Encoding.UTF8.GetBytes(plainMessage);
        //    enceam.Write(plainBytes, 0, plainBytes.Length);
        //    enceam.FlushFinalBlock();
        //    byte[] encryptedBytes = new byte[ms.Length];
        //    ms.Position = 0;
        //    ms.Read(encryptedBytes, 0, (int)ms.Length);
        //    enceam.Close();
        //    return Convert.ToBase64String(encryptedBytes);
        //}
        //public static string EasyDecryptMessage(string encryptedBase64)
        //{
        //    System.Configuration.AppSettingsReader settstringsReader =
        //                                   new AppSettingsReader();
        //    // Get the key from config file

        //    string password = (string)settstringsReader.GetValue("SecurityKey",
        //                                                 typeof(string));
        //    TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        //    des.IV = new byte[8];
        //    PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[0]);
        //    des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
        //    byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64);
        //    MemoryStream ms = new MemoryStream(encryptedBase64.Length);
        //    CryptoStream deceam = new CryptoStream(ms, des.CreateDecryptor(),
        //    CryptoStreamMode.Write);
        //    deceam.Write(encryptedBytes, 0, encryptedBytes.Length);
        //    deceam.FlushFinalBlock();
        //    byte[] plainBytes = new byte[ms.Length];
        //    ms.Position = 0;
        //    ms.Read(plainBytes, 0, (int)ms.Length);
        //    deceam.Close();
        //    return Encoding.UTF8.GetString(plainBytes);
        //}
        //public static string CipherEncrypt(string s)
        //{
        //    string returnstring = "";
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        returnstring += EncryptInternal(s[i]);
        //    }
        //    return returnstring;
        //}

        //public static string CipherDecrypt(string s)
        //{
        //    string returnstring = "";
        //    int length = s.Length / 3;
        //    int index = 0;
        //    for (int i = 0; i < length; i++)
        //    {
        //        string myNumbers = s[index++].ToString() + s[index++].ToString() + s[index++].ToString();
        //        returnstring += DecryptInternal(myNumbers);
        //    }
        //    return returnstring;
        //}

        //public static char DecryptInternal(string s)
        //{
        //    for (int i = 0; i < 57; i++)
        //    {
        //        if (secondside[i] == s)
        //            return firstside[i];
        //    }
        //    return s[1];
        //}

        //public static string EncryptInternal(char c)
        //{
        //    string returnstring = "/" + c.ToString() + "/";
        //    for (int i = 0; i < 57; i++)
        //    {
        //        if (firstside[i] == c)
        //            return secondside[i];
        //    }
        //    return returnstring;
        //}
        //public static string GetUniqueKey()
        //{
        //    string strNxtOrder = "";
        //    strNxtOrder = DateTime.Now.ToString("ddMMMyy");
        //    //strNxtOrder += "-" + RandomString(2,false) + RandomNumber(1111,9999);
        //    strNxtOrder += "-" + RandomNumber(11111, 99999);
        //    return strNxtOrder.ToUpper();
        //}
        //public static int RandomNumber(int min, int max)
        //{
        //    Random random = new Random();
        //    return random.Next(min, max);
        //}
        //public static string RandomString(int size, bool lowerCase)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    Random random = new Random();
        //    char ch;
        //    for (int i = 0; i < size; i++)
        //    {
        //        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        //        builder.Append(ch);
        //    }
        //    if (lowerCase)
        //        return builder.ToString().ToLower();
        //    return builder.ToString();
        //}
    }
}