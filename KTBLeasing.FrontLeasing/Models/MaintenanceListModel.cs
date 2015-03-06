using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class MaintenanceListModel
    {
        public long Id { get; set; }
        public long MaintenanceId { get; set; }
        public int Yearly { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; } 

        public List<MaintenanceListModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<MaintenanceListModel> list = new List<MaintenanceListModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new MaintenanceListModel
                {
                    Id= 384,
                    MaintenanceId= 317,
                    Yearly= 946,
                    Month= 39,
                    Amount= Convert.ToDecimal(964.38)
                };
                list.Add(en);
            }
            return list;
        }
    }
}