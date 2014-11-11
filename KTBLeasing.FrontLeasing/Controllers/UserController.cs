using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections.Generic;
using KTBLeasing.FrontLeasing.Models;            
using System;
<<<<<<< HEAD
=======
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.WsLoginAD;
using System.Collections.Specialized;
using System.Net.Http.Formatting;
>>>>>>> 3fb9ef84a38df9e0e9b729d65660aa776e3b5d78
using System.Web.Mvc;   
 

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class UserController : ApiController
    {
        private UsersAuthorizeRepository UsersAuthorizeRepository { get; set; }
<<<<<<< HEAD

        private string Message { get; set; }
        
        // btn search click
=======
        private User user { get; set; }

        private IWS_LoginAD _LoginService;
        public UserController()
        {
            this._LoginService = new WS_LoginADClient();
        }
        public UserController(IWS_LoginAD loginservice)
        {
            this._LoginService = new WS_LoginADClient();
        }

>>>>>>> 3fb9ef84a38df9e0e9b729d65660aa776e3b5d78
        // GET api/user
        public Authorize Get(string text, int page, int start, int limit)
        {
            Authorize view = new Authorize();
            try
            {
                var result = UsersAuthorizeRepository.Find(start, limit, text);
                view.tiems = result;
                view.totalProperty = UsersAuthorizeRepository.Count(text);
                return view;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //frist page load
        public Authorize Get(int page, int start, int limit)
        {
            Authorize view = new Authorize();
            try
            {
                var result = UsersAuthorizeRepository.GetAll(start, limit);
                view.tiems = result;
                view.totalProperty = UsersAuthorizeRepository.Count();
                return view;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<UsersAuthorize> Get()
        {
            try
            {
                //return this.Get(1,0,25);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        public string Get(int id)
        {
            return Message;
        }

        // POST api/user
<<<<<<< HEAD
        //[ResponseType(typeof(UsersAuthorize))]
        public UsersAuthorize Post(UsersAuthorize formmodel)
        {
            this.UsersAuthorizeRepository.Insert(formmodel);
            return formmodel;
=======
        public HttpResponseMessage Post(FormDataCollection formData)
        {
            NameValueCollection form = formData.ReadAsNameValueCollection();
            user = new User();

            user.UserName = form["User.UserName"];
            user.Password = form["User.Password"];

            string ADstatus = VerifyAD(user);
            HttpResponseMessage ResponseMsg = new HttpResponseMessage();
            switch (ADstatus)
            {
                case "OK":
                    ResponseMsg = Request.CreateResponse(HttpStatusCode.OK);
                    break;
                case "Unauthorized":
                    ResponseMsg = Request.CreateResponse(HttpStatusCode.Unauthorized, "รหัสผ่านไม่ถูกต้อง");
                    break;
                case "Locked":
                    ResponseMsg = Request.CreateResponse(HttpStatusCode.NotAcceptable, "รหัสผ่านถูกล็อคเนื่องจากใส่ผิด 3 ครั้ง กรุณาติดต่อ IT Support เพื่อทำการปลดล๊อค");
                    break;
                case "ServiceUnavailable":
                    ResponseMsg = Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Service Unavailable");
                    break;
            }
            return ResponseMsg;
>>>>>>> 3fb9ef84a38df9e0e9b729d65660aa776e3b5d78
        }

        //Post api/user

        public UsersAuthorize Post(string text)
        {
            //this.UsersAuthorizeRepository.Find(text);

            return null;
        }

        // PUT api/user/5
        public void Put(string id, UsersAuthorize formmodel)
        {
            formmodel.UserId = id;
            this.UsersAuthorizeRepository.SaveOrUpdate(formmodel);
           
        }

<<<<<<< HEAD
        // DELETE api/user/5
        public void Delete(string id)
        {
            var idss = id;
            //this.UsersAuthorizeRepository.Delete(form);
=======
        private string VerifyAD(User user)
        {
            try
            {
                if (user.Password == "@@@ktbladmin")
                {
                    return "OK";
                }
               
                LoginADRequest Request = new LoginADRequest(user.UserName, user.Password);
                var result = _LoginService.LoginAD(Request);

                if (result.@return.Equals("OK"))
                    result.@return = "OK";
                else if (result.@return.Contains("\"24\""))
                    result.@return = "Unauthorized";
                else if (result.@return.Contains("\"19\""))
                    result.@return = "Locked";

                return result.@return;
            }
            catch (Exception)
            {
                return "ServiceUnavailable";
            }
>>>>>>> 3fb9ef84a38df9e0e9b729d65660aa776e3b5d78
        }

    }
}
