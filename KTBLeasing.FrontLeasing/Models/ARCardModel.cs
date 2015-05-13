using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using Com.Ktbl.Database.DB2.Domain;

namespace KTBLeasing.FrontLeasing.Models
{
    public class ARCardModel
    {
        //public long Id { get; set; }
        public string Agreement { get; set; }
        public string Customer { get; set; }
        public DateTime? RestructureDate { get; set; }
        public decimal OS_PR { get; set; }
        public decimal FlatRate { get; set; }
        public int Day { get; set; }
        public decimal Interest { get; set; }
        public decimal UnpaidVAT { get; set; }
        public decimal Penalty { get; set; }
        public decimal DebitNote { get; set; }
        public decimal NewFlatRate { get; set; }
        public DateTime? NewFirstDueDate { get; set; }
        public int SubsequentDueDay { get; set; }
        public decimal NewTerm { get; set; }
        public CustomerDomain Customers { get; set; }
    }
}