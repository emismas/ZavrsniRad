using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialAnalysis.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string OIB { get; set; }
        public string Name{ get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int ZIPCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Job { get; set; }
        public decimal Salary { get; set; }
        public decimal ExtraIncome { get; set; }
        public string Citizenship { get; set; }
        public decimal Rent { get; set; }
        public decimal Bills { get; set; }
        public decimal Food { get; set; }
        public decimal Luxury { get; set; }
        public decimal Savings { get; set; }
        public string Bank { get; set; }
        public decimal DebtAmount { get; set; }
        public int KidsAmount { get; set; }
        public decimal LifeInsurance { get; set; }
        public decimal HealthInsurance { get; set; }
        public decimal VehicleInsurance { get; set; }
        public decimal RealEstateInsurance { get; set; }
        public string LifeInsuranceType { get; set; }
        public string HealthInsuranceType { get; set; }
        public string VehicleInsuranceType { get; set; }
        public string RealEstateInsuranceType { get; set; }
    }
}