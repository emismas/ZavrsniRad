using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAnalysis.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        public int RealEstateTypeId { get; set; }
        public string Insurance { get; set; }
        public int InsuranceTypeId { get; set; }
        


    }
}