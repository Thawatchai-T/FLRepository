using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class AddressController : ApiController
    {
        private ComboboxRepository comboboxRepository { get; set; }
        private IAddressRepository AddressRepository { get; set; }
        // GET api/address
        public List<AddressViewModel> Get(string text, int page, int start, int limit)
        {
            try
            {
                return AddressRepository.GetAll(start, limit, int.Parse(text));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET api/address/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/address
        public void Post(Address form)
        {
        }

        public void DoPost(Address form)
        {
            try
            {
                AddressRepository.SaveOrUpdate(form);
            }
            catch (Exception e)
            {
            }
        }

        // PUT api/address/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/address/5
        public void Delete(int id)
        {

        }

        public List<Province> GetProvince()
        {
            try
            {
                return comboboxRepository.GetProvince();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
