using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.DB.Model
{
    public class Supplier
    {
        public int ID { get; set; }
        public Guid GUID { get; set; }
        public string Name { get; set; }
        public decimal LastYearSalesYuan { get; set; }
        public string ProcurementCategory { get; set; }
        public int Employees { get; set; }
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
        public string Status { get; set; }
        public string StatusReason { get; set; }
        public string Module { get; set; }
    }
    public class CertificationList
    {
        public List<Certification> List { get; set; }
        public class Certification
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public DateTime EffectiveTime { get; set; }
            public DateTime ExpireTime { get; set; }
            public string RelativeFileUrl { get; set; }
        }
    }
    public class ContactList
    {
        public List<Contact> List { get; set; }
        public class Contact
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Job { get; set; }
            public string Tel { get; set; }
            public string MobilePhone { get; set; }
            public string Email { get; set; }
        }
    }
    public class FinanceList
    {
        public List<Finance> List { get; set; }
        public class Finance
        {
            public string ID { get; set; }
            public string Country { get; set; }
            public string AccountName { get; set; }
            public string AccountBank { get; set; }
            public string AccountNumber { get; set; }
            public string RelativeFileUrl { get; set; }
        }
    }
}