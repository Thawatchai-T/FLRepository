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
using System.Drawing;

namespace KTBLeasing.FrontLeasing.Controllers
{
   // [Authorize]
    public class RoleController : ApiController
    {
        private IUserInRoleRepository UserInRoleRepository { get; set; }

        private IRoleRepository RoleRepository { get; set; }

        private ITabRepository TabRepository { get; set; }

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

            if (!User.Identity.IsAuthenticated)
            {
                var user = User;
            }
            else
            {
                var user = User;
            }
            UserInRoleModel view = new UserInRoleModel();
            try
            {
                var result = UserInRoleRepository.GetAll(start, limit);
                view.items = result;
                view.totalProperty = UserInRoleRepository.Count();
                //var session = KTBLeasing.FrontLeasing.Utility.SessionUtility.GetAuthenticationSession();
                //var a = result.Select(x => new { x.Id, x.Role.RoleName, x.UsersAuthorize.UserId }).ToList();
                return view;//result.Select(x => new { x.Id, x.Role.RoleName, x.UsersAuthorize.DepCode }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoleModel Get()
        {
            try
            {
                RoleModel model = new RoleModel();
                var result = RoleRepository.Get();
                model.items = result;
                return model;
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
        public bool Post(Role formmodel)
        {
            try
            {
                var user = (User)System.Web.HttpContext.Current.Session["User"];
                var username = "woody";
                formmodel.CreateBy = username;
                formmodel.CreateDate = DateTime.Now;
                formmodel.UpdateBy = username;
                formmodel.UpdateDate = DateTime.Now;

                var status = this.RoleRepository.Insert(formmodel);

                return status;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ////Post api/user
        //public UserInRole Post(UserInRole role)
        //{
        //    //this.UserInRoleRepository.Find(text);

        //    return null;
        //}
        public void Put(int id, Role value)
        {
            var model = this.RoleRepository.GetById(id);
            if (!model.Equals(null))
            {
                model.Id = value.Id;
                model.RoleName = value.RoleName;
                model.UpdateDate = DateTime.Now;
                model.UpdateBy = User.Identity.Name;

                var status = this.RoleRepository.Update(model);
            }
            else
            {
            }
        }

        // DELETE api/user/5
        public void Delete(int Id, Role modified)
        {
            var abce = this.RoleRepository.Delete(Id);

            //var oldRecord = this.Get(Id);
            //var entity = oldRecord.FirstOrDefault() as UserInRole;
            //this.UserInRoleRepository.Delete(entity);
        }

        public RoleModel GetRole()
        {
            return this.Get();
        }

        #region RoleInTabs

        public RoleInTabsModel GetTabsByRoleID(int roleId)
        {
            RoleInTabsModel view = new RoleInTabsModel();
            view.items = TabRepository.GetTabBYRoleID(roleId);
            view.totalProperty = view.items.Count;
            return view;
        }

        #endregion



    }

    public partial class UserInRoleViewModel
    {
        public int Id { get; set; }

        public int RoleName { get; set; }

        public string UserId { get; set; }
    }
}
