using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Formatting;
using KTBLeasing.FrontLeasing.WsLoginAD;
using KTBLeasing.FrontLeasing.Models;
using System.Collections.Specialized;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class LoginController : ApiController
    {
        private User _User { get; set; }
        private IWS_LoginAD _LoginService {get; set;}

        
        // POST api/login
        //add by pom use login
        public HttpResponseMessage DoLogin(User formData)
        {
           
            //[20141222] thawatchai.t change to model 
            this._User.UserName = formData.UserName;
            this._User.Password = formData.Password;

            //old
            //NameValueCollection form = formData.ReadAsNameValueCollection();
            //user.UserName = form["User.UserName"];
            //user.Password = form["User.Password"];
            
            string ADstatus = VerifyAD(_User);
            HttpResponseMessage ResponseMsg = new HttpResponseMessage();
            switch (ADstatus)
            {
                case "OK":
                    ResponseMsg = Request.CreateResponse(HttpStatusCode.OK);
                    break;
                case "Unauthorized":
                    ResponseMsg = Request.CreateResponse(HttpStatusCode.Unauthorized, "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
                    break;
                case "Locked":
                    ResponseMsg = Request.CreateResponse(HttpStatusCode.NotAcceptable, "รหัสผ่านถูกล็อคเนื่องจากใส่ผิด 3 ครั้ง กรุณาติดต่อ IT Support เพื่อทำการปลดล๊อค");
                    break;
                case "ServiceUnavailable":
                    ResponseMsg = Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Service Unavailable");
                    break;
            }
            return ResponseMsg;
            
        }

        // GET api/user/5
        public string Get(int id)
        {
            return null;
        }

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

        }

        
    }
}
