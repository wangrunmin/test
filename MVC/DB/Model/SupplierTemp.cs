using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.DB.Model
{
    public class SupplierTemp
    {
        public int ID { get; set; }
        public Guid GUID { get; set; }
        [ForeignKey("Supplier")]
        public Guid SupplierGUID { get; set; }
        public string Name { get; set; }
        public decimal LastYearSalesYuan { get; set; }
        public string ProcurementCategory { get; set; }
        public string Employees { get; set; }
        public string MainAccount { get; set; }
        public string Email { get; set; }
        public string CompanyAddress { get; set; }
        public string SupplyRegion { get; set; }
        public string LicenceNoOrCreditCode { get; set; }
        public string EnterpriseType { get; set; }
        public DateTime EstablishedTime { get; set; }
        public decimal RegisteredCapitalWanYuan { get; set; }
        public DateTime LastInspectionTime { get; set; }
        public string TaxClass { get; set; }
        public string Others { get; set; }
        public string Certification_JSON { get; set; }
        public string Contact_JSON { get; set; }
        public string Finance_JSON { get; set; }
    }
}