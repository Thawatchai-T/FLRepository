using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Models;


namespace KTBLeasing.FrontLeasing.Controllers
{
    public class TreeController : Controller
    {
        private ICommonDataRepository commonDataRepository { get; set; }


        private static List<CommonData> CommonDataList { get; set; }
        enum Flag
        {
            none,insert
        }

        public TreeController()
        {
            if (CommonDataList == null)
            {
                CommonDataList = new List<CommonData>();
            }
        }
        //
        // GET: /Tree/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Root(string node)
        {
            try
            {
                SetCommonAddressData(string.Empty);

                if (node == "root" || string.IsNullOrEmpty(node))
                {
                    //return CommonAddressList.Where(w => w.Parent_Id == 0).Distinct().ToList<Object>();
                    var result = CommonDataList.Where(w => w.Parent_Id == 0).Distinct();
                    return Json(CommonDataList.Where(w => w.Parent_Id == 0).Distinct().ToList<object>(), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var list = CommonDataList.Where(w => w.Parent_Id == int.Parse(node)).ToList<CommonData>();
                    return Json(list.Select(x => new { x.Id, leaf = x.IsLeaf, x.Levels, x.Name, x.Parent_Id, x.Name_Eng }), JsonRequestBehavior.AllowGet);
                }
                //return Json(new { success = false, message = "รหัสผ่านไม่ถูกต้อง" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            //return Json("xxxx", JsonRequestBehavior.AllowGet);
        }

        private void SetCommonAddressData(string type)
        {
            if (type == "insert")
            {
                //CommonAddressList.Union<CommonAddress>(commonAddressRepository.Get());
                CommonDataList = commonDataRepository.Get("");
                //CommonAddressList.Concat(commonAddressRepository.GetRootNode());
            }
            else if (string.IsNullOrEmpty(type) && CommonDataList.Count <=0)
            {
                CommonDataList = commonDataRepository.Get("");
            }
        }

        //public JsonResult Root(CommonAddress comadd)
        //{
        //    return Json(new { sms = comadd }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult Insert(SetupViewModel commonAddress)
        {
            try
            {
                var status = false;
                if (commonAddress.Type.Equals("insert"))
                {
                    this.commonDataRepository.Insert(new CommonData
                    {
                        Parent_Id = commonAddress.Parent_Id,
                        Name = commonAddress.Name,
                        Name_Eng = commonAddress.Name_Eng,
                        Active = true,
                        Code = "NA",
                        Remark = commonAddress.Remark + "NA",
                        Update_By = "admin",
                        Create_By = "admin",
                        Create_Date = DateTime.Now,
                        Update_Date = DateTime.Now
                    });

                    status = true;
                }
                else if(commonAddress.Type.Equals("update"))
                {
                    var entity = this.commonDataRepository.GetById(commonAddress.Id);
                    
                    entity.Name = commonAddress.Name;
                    entity.Name_Eng = commonAddress.Name_Eng;
                    entity.Code = (string.IsNullOrEmpty(entity.Code)) ? "NA" : entity.Code;
                    entity.Remark = (string.IsNullOrEmpty(entity.Remark)) ? "update" : entity.Remark;
                    entity.Active = commonAddress.Active;
                    entity.Update_Date = DateTime.Now;
                    entity.Update_By = "admin";
                    
                    this.commonDataRepository.Update(entity);
                    
                    status = true;
                }
                
                if (status)
                    this.SetCommonAddressData("insert");

                return Json(new { success = status, message = (status) ? "บันทึกข้อมูลสำเร็จ" : "ไม่สามารถบันทึกข้อมูลได้" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "ไม่สามารถบันทึกข้อมูลได้" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Update(CommonData commonAddress)
        {
            try
            {
                this.commonDataRepository.Update(commonAddress);

                var status = true;
                if (status)
                    this.SetCommonAddressData("insert");
                return Json(new { success = status, message = (status) ? "บันทึกข้อมูลสำเร็จ" : "ไม่สามารถบันทึกข้อมูลได้" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "ไม่สามารถบันทึกข้อมูลได้" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete(int id)
        {
            try
            {
                this.commonDataRepository.Delete(id);

                var status = true;
                if (status)
                    this.SetCommonAddressData("insert"); 
                return Json(new { success = status }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "ไม่สามารถบันทึกข้อมูลได้" }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}
