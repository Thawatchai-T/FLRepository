using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public class CommonRepository:NhRepository
    {

        public List<ProvinceTree> GetProvinceTree()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.QueryOver<ProvinceTree>().List<ProvinceTree>() as List<ProvinceTree>;

                return result;
            }
          
        }
           
    }
}
