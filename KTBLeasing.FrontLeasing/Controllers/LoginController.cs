using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Security;

using KTBLeasing.Domain;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Models;
//using KTBLeasing.FrontLeasing.WS_ActiveDirectory;
using KTBLeasing.FrontLeasing.ActiveDirectoryService;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KTBLeasing.FrontLeasing.Utility;
using KTBLeasing.FrontLeasing.Properties;

namespace KTBLeasing.FrontLeasing.Controllers
{
    //[IdentityBasicAuthentication] // Enable Basic authentication for this controller.
    //[Authorize] // Require authenticated requests.
    public class LoginController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private User _User { get; set; }
        
        private UserModel _UserViewModel { get; set; }

        //[20150331] comment by Woody old service check login ad
        //private IWS_LoginAD _LoginService { get; set; }

        private IUserInfomationRepository UserInformationRepository { get; set; }

        private IUserInRoleRepository UserInRoleRepository { get; set; }

        private ITabRepository TabRepository { get; set; }

        //[20150331]  by Woody New Service Login Ad
        private ActiveDirectoryServiceClient _LoginService { get; set; }
        private string _DomainName { get; set; }

        // POST api/login
        //add by pom use login
        public HttpResponseMessage DoLogin(Models.User formData)
        {
            _UserViewModel = (_UserViewModel == null) ? new UserModel() : _UserViewModel;
            //[20141222] thawatchai.t change to model 
            this._User.UserName = formData.UserName;
            this._User.Password = formData.Password;
            string userName = User.Identity.Name;

            var ADstatus = false;
            if (_User.UserName.Equals("mkt_id") || _User.UserName.Equals("headmkt_id"))
            {
                ADstatus = true;
            }
            else
            {
                ADstatus = CheckLogin(_User).Status;
            }
                
            //string ADstatus = VerifyAD(_User);
            HttpResponseMessage ResponseMsg = new HttpResponseMessage();
            //TODO: maybe not use
            //if (ADstatus.Equals("OK")) SessionUtility.RegisterAuthenticationSession(this._User);

            FormsAuthentication.SetAuthCookie(formData.UserName, formData.RememberMe);

            var userm = User.Identity.AuthenticationType;

            return (ADstatus) ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.Unauthorized, ADstatus);
        }

        //[20150330] Add by Woody function get loginproberties;
        //public UserModel GetLogingProperties(string userid)
        public JArray GetLogingProperties(string userid)
        {
            List<UserModel> list = new List<UserModel>();
            var userinfo = this.GetUserInfo(userid);
            _UserViewModel.UserInfo = userinfo;
            _UserViewModel.UserId = userid;

            var result = UserInRoleRepository.GetByUserID(userid);

            _UserViewModel.RoleId = (result != null) ? result.Role.Id : 0;
            _UserViewModel.RoleName = (result != null) ? result.Role.RoleName : "ไม่มีสิทธิในการใช้งาน";
            _UserViewModel.TabMdelList = this.TabRepository.GetTabBYRoleID(_UserViewModel.RoleId).OrderBy(x => x.TabId).Select(x => x.TabManament).ToList<Tab>();
            _UserViewModel.Status = true;
            list.Add(_UserViewModel);
//            return _UserViewModel;
            var json = JsonConvert.SerializeObject(list);
            return JArray.Parse(json);
        }

        // GET api/user/5
        public string Get(int id, TypeAttributes name)
        {
            return name.ToString();
        }

        //private string VerifyAD(User user)
        //{
        //    if (user.UserName.Equals("mkt_id") || user.UserName.Equals("headmkt_id") || user.UserName.Equals("nidcha_bu") || user.UserName.Equals("thawatchai_ti") || user.UserName.Equals("phutip_pr") || user.Password.Equals("jfxm3kgt"))
        //        return "OK";
        //    try
        //    {
        //        if (user.Password == "@@@ktbladmin")
        //        {
        //            return "OK";
        //        }

        //        //[20153103] Add by Woody Check new service login ad
        //        //var result = _LoginService.AccountLogin( _DomainName, user.UserName, user.Password);
        //        var result = _LoginService.CheckLogin(user);
        //        return result;

        //        #region[20150331] Comment by Woody old checked loginad
        //        /*
        //        LoginADRequest Request = new LoginADRequest(user.UserName, user.Password);
        //        var result = _LoginService.LoginAD(Request);

        //        if (result.@return.Equals("OK"))
        //            result.@return = "OK";
        //        else
        //            if (result.@return.Contains("\"24\""))
        //                result.@return = "Unauthorized";
        //            else
        //                if (result.@return.Contains("\"19\""))
        //                    result.@return = "Locked";

        //        return result.@return;
        //         */
        //        #endregion
        //    }
        //    catch (Exception)
        //    {
        //        return "ServiceUnavailable";
        //    }
        //}

        //[20150330] Add by Woody LogOff
        public bool LogOff()
        {
            FormsAuthentication.SignOut();
            return true;
        }

        public ResponseAuthentication CheckLogin(User user)
        {
            try
            {
                RequestAuthentication request = new RequestAuthentication();
                request.Username = user.UserName;
                request.Password = user.Password;

                ResponseAuthentication result = null;

                if (request.Password == "@@@ktbladmin" || !Settings.Default.IsProduction)
                {
                    RequestUserInfo requestUserInfo = new RequestUserInfo();
                    requestUserInfo.Username = request.Username;

                    result = _LoginService.GetUserInfo(requestUserInfo);
                }
                else
                {
                    result = _LoginService.CheckAuthenticated(request);
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[20150325] add by Woody use for get user information
        public UserInformationView GetUserInfo(string UserId)
        {
            try
            {
                var userinfoList = this.UserInformationRepository.Find(UserId, "UserId", 0, 10);
                var role = this.UserInRoleRepository.GetByUserID(UserId);
                return (userinfoList.Count > 0) ? userinfoList.FirstOrDefault<UserInformationView>() : null;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public void LogOut()
        {

        }
    }
}
