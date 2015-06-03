using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class SellerController : ApiController
    {
        private ISellerRepository SellerRepository { get; set; }

        // GET api/contact
        //public IEnumerable<SellerModel> Get()
        //{
        //    return new SellerModel().Dummy();
        //}

        // GET api/contact/5
        public List<Seller> Get(int page, int start, int limit, long id)
        {
            return SellerRepository.GetAll(0, 30, id);
        }

        public List<SellerModel> DoPost(SellerModel form)
        {
            return null;
        }

        // POST api/contact
        public void Post(Seller entity)
        {
            SellerRepository.SaveOrUpdate(entity);
        }

        // PUT api/contact/5
        public void Put(long id, Seller entity)
        {
            SellerRepository.SaveOrUpdate(entity);
        }

        // DELETE api/contact/5
        public void Delete(long id)
        {
            //SellerRepository.Delete(id);
        }
    }
}
