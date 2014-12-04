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
    public class TabController : ApiController
    {
        private TabRepository tabRepository { get; set; }
        private UserInTabRepository userInTabRepository { get; set; }
        // GET api/tab
        public UserInTabModel Get()
        {
            UserInTabModel view = new UserInTabModel();
            view.items = userInTabRepository.GetAll();
            view.totalProperty = userInTabRepository.Count();
            return view;
        }

        // GET api/tab/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tab
        public void Post([FromBody]string value)
        {
        }

        // PUT api/tab/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tab/5
        public void Delete(int id)
        {
        }

        public TabModel GetTab()
        {
            TabModel view = new TabModel();
            view.items = tabRepository.Get();
            view.totalProperty = tabRepository.Count();
            return view;
        }
    }
}
