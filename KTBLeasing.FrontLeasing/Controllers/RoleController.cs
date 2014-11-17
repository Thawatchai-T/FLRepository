using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Models;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class RoleController : ApiController
    {
        private UserInRoleRepository UserInRoleRepository { get; set; }
        private RoleRepository RoleRepository { get; set; }

        // GET api/user

        //Search
        public UserInRoleModel Get(string text, int page, int start, int limit)
        {
            UserInRoleModel view = new UserInRoleModel();
            try
            {
                var result = UserInRoleRepository.Find(start, limit, text);
                view.items = result;
                view.totalProperty = UserInRoleRepository.Count(text);
                return view;//result.Select(x => new { x.Id, x.Role.RoleName, RoleID = x.Role.Id, x.UsersAuthorize.UserId }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //frist page load
        public UserInRoleModel Get(int page, int start, int limit)
        {
            UserInRoleModel view = new UserInRoleModel();
            try
            {
                var result = UserInRoleRepository.GetAll(start, limit);
                view.items = result;
                view.totalProperty = UserInRoleRepository.Count();
                //var a = result.Select(x => new { x.Id, x.Role.RoleName, x.UsersAuthorize.UserId }).ToList();
                return view;//result.Select(x => new { x.Id, x.Role.RoleName, x.UsersAuthorize.DepCode }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Role> Get()
        {
            try
            {
                var result = RoleRepository.Get();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        public List<Role> Get(int id)
        {
            try
            {
                return RoleRepository.Get();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //add by woody
        // POST api/user
        public UserInRole Post(UserInRole formmodel)
        {
            this.UserInRoleRepository.Insert(formmodel);
            return formmodel;
        }

        //Post api/user
        public UserInRole Post(string text)
        {
            //this.UserInRoleRepository.Find(text);

            return null;
        }

        // PUT api/user/5
        public void Put(string id, UserInRole formmodel)
        {
            formmodel.UsersAuthorize.UserId = id;
            this.UserInRoleRepository.SaveOrUpdate(formmodel);

        }

        // DELETE api/user/5
        public void Delete(string id)
        {
            var idss = id;
            //this.UserInRoleRepository.Delete(form);
        }

    }
}
