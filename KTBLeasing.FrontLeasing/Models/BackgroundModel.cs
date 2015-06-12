using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class BackgroundModel
    {
        public long Id { get; set; }
        public string Business { get; set; }
        public string Establishment { get; set; }
        public int Rating { get; set; }
        public string RatingDate { get; set; }
        public int RatingDetail { get; set; }
        public int RegisterCapital { get; set; }
        public string RegisterCapitalDetail { get; set; }
        public int Sales { get; set; }
        public string SalesDate { get; set; }
        public string SalesDetail { get; set; }
        public int ProfitLoss { get; set; }
        public string ProfitLossDate { get; set; }
        public string ProfitLossDetail { get; set; }
        public int ShareholderEquity { get; set; }
        public string ShareholderEquityDate { get; set; }
        public string ShareholderEquityDetail { get; set; }
        public int OutstandingAmount { get; set; }
        public string OutstandingAmountDate { get; set; }
        public int ExposureLimit { get; set; }
        public string ExposureLimitDate { get; set; }
        public int Committed { get; set; }
    }
}