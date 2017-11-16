using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MVCTEST.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public string Index()
        {
            XmlDocument doc = new XmlDocument();
            //var bpmResponse = WebServiceHelper.sendSupplierAccess(Request.Url.Authority, currentSupplierEnt);
            doc.LoadXml(@"<Response>
  <Status>T</Status> 
<BpmID>100</BpmID>
  <REMSG>同步成功</REMSG>
</Response>");
            XmlNode root = doc.SelectSingleNode("Response");

            return root.SelectSingleNode("Status").InnerText;
        }
    }
}