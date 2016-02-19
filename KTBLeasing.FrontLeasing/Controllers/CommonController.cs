using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.Domain;
using KTBLeasing.Domain.ViewCommonData;

namespace KTBLeasing.FrontLeasing.Controllers
{
    //[20141219] Thawatchai.t Crate function get Provicne district and subdistrict 

    public class CommonController : ApiController
    {
        ICommonDataRepository CommonDataRepository { get; set; }

        #region properties 
        private static List<Province> Province { get; set; }
        #endregion

        #region Province District and SubDistrict

        public IEnumerable<Province> GetAllProvince()
        {
            SetProvince();
            return Province;
        }

        public IEnumerable<Province> GetAll(string text, int page, int start, int limit)
        {
            SetProvince();
            if (!string.IsNullOrEmpty(text))
                return Province.Where(x => x.Zipcode.ToString().Contains(text) || x.SubdistrictName.Contains(text) || x.DistrictName.Contains(text) || x.ProvinceName.Contains(text) || x.SubdistrictId.ToString() == text);
            else
                return Province;
        }
        
        /// <summary>
        /// Get Provinct 
        /// </summary>
        /// <returns>List of ProvinceModel</returns>
        public IEnumerable<ProvinceModel> GetProvince()
        {
            SetProvince();
            return Province.GroupBy(g => new { g.ProvinceId, g.ProvinceName }).Select(x => new ProvinceModel { ProvinceId = x.Key.ProvinceId, ProvinceName = x.Key.ProvinceName }).ToList<ProvinceModel>();
        }

        /// <summary>
        /// Get District
        /// </summary>
        /// <returns>List of districtModel </returns>
        public IEnumerable<DistrictModel> GetDistrict()
        {
            SetProvince();
            var result =  Province.GroupBy(g => new { g.ProvinceId, g.DistrictId, g.DistrictName })
                .Select(x => new DistrictModel {
                    ProvinceId = x.Key.ProvinceId,
                    DistrictId = x.Key.DistrictId,
                    DistrictName = x.Key.DistrictName
                }).ToList<DistrictModel>();
            return result;
        }

        /// <summary>
        /// Get SubDistrict
        /// </summary>
        /// <returns>Lit of SubDistrctModel</returns>
        
        public IEnumerable<SubDistrictModel> GetSubDistrict()
        {
            SetProvince();
            var result = Province.GroupBy(g => new { g.DistrictId, g.SubdistrictId, g.SubdistrictName,g.Zipcode })
                .Select(x => new SubDistrictModel
                {
                    SubDistrictId = x.Key.SubdistrictId,
                    DistrictId = x.Key.DistrictId,
                    SubDistrictName = x.Key.SubdistrictName,
                    ZipCode = x.Key.Zipcode
                }).ToList<SubDistrictModel>();

            return result;
        }

        public IEnumerable<CommonData> GetCommonByNameEng(string NameEng)
        {
            return this.CommonDataRepository.GetCommonByNameEng(NameEng).OrderBy(x => x.Name);
        }

        public List<CommonData> GetSubCommonById()
        {
            return new List<CommonData>();
        }

        public List<CommonData> GetSubCommonById(long id)
        {
            return this.CommonDataRepository.GetSubCommonById(id);
        }

        #endregion

        private List<Province> SetProvince()
        {
            if (Province.Count > 0) return Province;
            else
            {
                Province = this.CommonDataRepository.GetProvince();
                return Province;
            }
        }

        public List<EQP> GetEQP() 
        {
            return CommonDataRepository.GetEQP();
        }

        public List<AssetType> GetAssetType()
        {
            return CommonDataRepository.GetAssetType();
        }
    }
}
