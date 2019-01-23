using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAnalysis.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public string Insurance { get; set; }
        public int InsuranceTypeId { get; set; }
        
    }
}