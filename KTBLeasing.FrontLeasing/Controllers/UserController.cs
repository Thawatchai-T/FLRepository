using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections.Generic;
using System;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.WsLoginAD;
using System.Collections.Specialized;
using System.Net.Http.Formatting;
//using System.Web.Mvc;


namespace KTBLeasing.FrontLeasing.Controllers
{
    public class UserController : ApiController
    {
        private IUsersAuthorizeRepository UsersAuthorizeRepository { get; set; }

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

        public Authorize Get()
        {
            try
            {
                return this.Get(1,0,25);

                //return null;
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
            return null;
        }

        //add by woody
        // POST api/user
        public UsersAuthorize Post(UsersAuthorize formmodel)
        {
            this.UsersAuthorizeRepository.Insert(formmodel);
            return formmodel;
        }

        //Post api/user
        public UsersAuthorize Post(string text)
        {
            //this.UsersAuthorizeRepository.Find(text);

            return null;
        }

        // PUT api/user/5
        public void Put(string name, UsersAuthorize formmodel)
        {
            formmodel.UserId = name;
            //this.UsersAuthorizeRepository.SaveOrUpdate(formmodel);

        }

        // DELETE api/user/5
        public void Delete(string id)
        {
            var idss = id;
            //this.UsersAuthorizeRepository.Delete(form);
        }

    }
}