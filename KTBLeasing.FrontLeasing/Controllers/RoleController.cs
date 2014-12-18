using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Models;
using Newtonsoft.Json;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class RoleController : ApiController
    {
        private IUserInRoleRepository UserInRoleRepository { get; set; }
        private IRoleRepository RoleRepository { get; set; }

        // GET api/user

        //Search
        public UserInRoleModel Get(string text, int page, int start, int limit)
        {
            UserInRoleModel view = new UserInRoleModel();
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    var result = UserInRoleRepository.Find(start, limit, text);
                    view.items = result;
                    view.totalProperty = UserInRoleRepository.Count(text);
                }
                else
                {
                    view = this.Get(page, start, limit);
                }

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
        public List<UserInRole> Get(long id)
        {
            try
            {
                return UserInRoleRepository.Get(id);
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
        public void Put(long Id, UserInRoleViewModel modified)
        {
            var oldRecord = this.Get(Id);
            
            //[20141218] thawatchai.t fix ojb to userinrole ojb
            UserInRole entity = new UserInRole();
            //var entity = new object();
            
            //if count >0 update data else insert data
            if (oldRecord.Count > 0)
            {
                oldRecord[0].Role.Id = modified.RoleName;
                entity = oldRecord.FirstOrDefault() as UserInRole;
            }
            else
            {
                UserInRole newRecord = new UserInRole();
                newRecord.Role.Id = modified.RoleName;
                newRecord.UsersAuthorize.UserId = modified.UserId;
                entity = newRecord;
            }
            this.UserInRoleRepository.SaveOrUpdate(entity);
        }

        // DELETE api/user/5
        public void Delete(int Id, UserInRoleViewModel modified)
        {
            var oldRecord = this.Get(Id);
            var entity = oldRecord.FirstOrDefault() as UserInRole;
            this.UserInRoleRepository.Delete(entity);
        }

        public IEnumerable<Role> GetRole()
        {
            return this.Get();
        }

    }

    public partial class UserInRoleViewModel
    {
        public int Id { get; set; }
        public int RoleName { get; set; }
        public string UserId { get; set; }
    }
}
