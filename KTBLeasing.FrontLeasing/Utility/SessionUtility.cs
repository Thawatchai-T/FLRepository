/**
 * [20150407] Create By Woody 
 * Class create session and get sesson with name or object
 * v1.0
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;
using System.Web.SessionState;
using System.Web.Routing;
using KTBLeasing.FrontLeasing.Models;
using log4net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace KTBLeasing.FrontLeasing.Utility
{
    public class SessionUtility
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Register LoginModel 
        /// </summary>
        /// <param name="user"></param>
        public static void RegisterAuthenticationSession(User user)
        {
            try
            {
                System.Web.HttpContext.Current.Session[SessionUtility.GenerateMD5(user.UserName)] = user;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Get Authentication Session
        /// </summary>
        /// <returns>User </returns>
        public static User GetAuthenticationSession()
        {
            return GetSessionWithName<User>("User");
        }

        /// <summary>
        ///  use for register session wiht name
        ///  @example 
        ///       SessionUtility.RegisterSessionWithName<ojb>(sessionname);
        /// </summary>
        /// <typeparam name="T">generic type</typeparam>
        /// <param name="name">session name</param>
        /// <param name="value">session value </param>
        public static void RegisterSessionWithName<T>(string name, T value)
        {
            try
            {
                System.Web.HttpContext.Current.Session[name] = value;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        /// <summary>
        ///  Get sessoin with name 
        ///  return generic type
        ///  @example 
        ///   SessionUtility.GetSessionWithName<ojb>(sessionname);
        /// </summary>
        /// <typeparam name="T">generic type</typeparam>
        /// <param name="name">session name</param>
        /// <returns>generic type</returns>
        public static T GetSessionWithName<T>(string name)
        {
            try
            {
                return (T)System.Web.HttpContext.Current.Session[SessionUtility.GenerateMD5(name)];
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw ex;
            }
        }

        


        public static string GenerateMD5(string input)
        {
            string key = "pomnotwoody";
            input = string.Format("{0,1}", key, input);
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            return BitConverter.ToString(data);
        }

    }
}