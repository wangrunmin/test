using MVC.DB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HROCSController : Controller
    {
        public string CreateSupplier()
        {
            try
            {
                #region 定义参数变量:P_
                var P_ID = Request.QueryString["ID"] ?? Request.Form["ID"];
                var P_GUID = Request.QueryString["GUID"] ?? Request.Form["GUID"];
                var P_Name = Request.QueryString["Name"] ?? Request.Form["Name"];
                var P_LastYearSalesYuan = Request.QueryString["LastYearSalesYuan"] ?? Request.Form["LastYearSalesYuan"];
                var P_ProcurementCategory = Request.QueryString["ProcurementCategory"] ?? Request.Form["ProcurementCategory"];
                var P_Employees = Request.QueryString["Employees"] ?? Request.Form["Employees"];
                var P_MainAccount = Request.QueryString["MainAccount"] ?? Request.Form["MainAccount"];
                var P_Email = Request.QueryString["Email"] ?? Request.Form["Email"];
                var P_CompanyAddress = Request.QueryString["CompanyAddress"] ?? Request.Form["CompanyAddress"];
                var P_SupplyRegion = Request.QueryString["SupplyRegion"] ?? Request.Form["SupplyRegion"];
                var P_LicenceNoOrCreditCode = Request.QueryString["LicenceNoOrCreditCode"] ?? Request.Form["LicenceNoOrCreditCode"];
                var P_EnterpriseType = Request.QueryString["EnterpriseType"] ?? Request.Form["EnterpriseType"];
                var P_EstablishedTime = Request.QueryString["EstablishedTime"] ?? Request.Form["EstablishedTime"];
                var P_RegisteredCapitalWanYuan = Request.QueryString["RegisteredCapitalWanYuan"] ?? Request.Form["RegisteredCapitalWanYuan"];
                var P_LastInspectionTime = Request.QueryString["LastInspectionTime"] ?? Request.Form["LastInspectionTime"];
                var P_TaxClass = Request.QueryString["TaxClass"] ?? Request.Form["TaxClass"];
                var P_Others = Request.QueryString["Others"] ?? Request.Form["Others"];
                var P_Certification_JSON = Request.QueryString["Certification_JSON"] ?? Request.Form["Certification_JSON"];
                var P_Contact_JSON = Request.QueryString["Contact_JSON"] ?? Request.Form["Contact_JSON"];
                var P_Finance_JSON = Request.QueryString["Finance_JSON"] ?? Request.Form["Finance_JSON"];
                var P_Status = Request.QueryString["Status"] ?? Request.Form["Status"];
                var P_StatusReason = Request.QueryString["StatusReason"] ?? Request.Form["StatusReason"];
                var P_Module = Request.QueryString["Module"] ?? Request.Form["Module"];
                #endregion
                #region 非空验证
                if (string.IsNullOrEmpty(P_ID)) throw new Exception("P_ID不能为空");
                if (string.IsNullOrEmpty(P_GUID)) throw new Exception("P_GUID不能为空");
                if (string.IsNullOrEmpty(P_Name)) throw new Exception("P_Name不能为空");
                if (string.IsNullOrEmpty(P_LastYearSalesYuan)) throw new Exception("P_LastYearSalesYuan不能为空");
                if (string.IsNullOrEmpty(P_ProcurementCategory)) throw new Exception("P_ProcurementCategory不能为空");
                if (string.IsNullOrEmpty(P_Employees)) throw new Exception("P_Employees不能为空");
                if (string.IsNullOrEmpty(P_MainAccount)) throw new Exception("P_MainAccount不能为空");
                if (string.IsNullOrEmpty(P_Email)) throw new Exception("P_Email不能为空");
                if (string.IsNullOrEmpty(P_CompanyAddress)) throw new Exception("P_CompanyAddress不能为空");
                if (string.IsNullOrEmpty(P_SupplyRegion)) throw new Exception("P_SupplyRegion不能为空");
                if (string.IsNullOrEmpty(P_LicenceNoOrCreditCode)) throw new Exception("P_LicenceNoOrCreditCode不能为空");
                if (string.IsNullOrEmpty(P_EnterpriseType)) throw new Exception("P_EnterpriseType不能为空");
                if (string.IsNullOrEmpty(P_EstablishedTime)) throw new Exception("P_EstablishedTime不能为空");
                if (string.IsNullOrEmpty(P_RegisteredCapitalWanYuan)) throw new Exception("P_RegisteredCapitalWanYuan不能为空");
                if (string.IsNullOrEmpty(P_LastInspectionTime)) throw new Exception("P_LastInspectionTime不能为空");
                if (string.IsNullOrEmpty(P_TaxClass)) throw new Exception("P_TaxClass不能为空");
                if (string.IsNullOrEmpty(P_Others)) throw new Exception("P_Others不能为空");
                if (string.IsNullOrEmpty(P_Certification_JSON)) throw new Exception("P_Certification_JSON不能为空");
                if (string.IsNullOrEmpty(P_Contact_JSON)) throw new Exception("P_Contact_JSON不能为空");
                if (string.IsNullOrEmpty(P_Finance_JSON)) throw new Exception("P_Finance_JSON不能为空");
                if (string.IsNullOrEmpty(P_Status)) throw new Exception("P_Status不能为空");
                if (string.IsNullOrEmpty(P_StatusReason)) throw new Exception("P_StatusReason不能为空");
                if (string.IsNullOrEmpty(P_Module)) throw new Exception("P_Module不能为空");
                #endregion
                #region JSON格式验证
                var Ent_P_Certification_JSON = JsonConvert.DeserializeObject<CertificationList>(P_Certification_JSON);
                var Ent_P_Contact_JSON = JsonConvert.DeserializeObject<ContactList>(P_Contact_JSON);
                var Ent_P_Finance_JSON = JsonConvert.DeserializeObject<FinanceList>(P_Finance_JSON);
                #endregion
                return JsonConvert.SerializeObject(new
                {
                    res = "OK",
                    msg = "供应商信息已完善，请耐心等待审核"
                });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new
                {
                    res = "ERROR",
                    msg = "失败，" + e.Message
                });
            }
        }
    }
}