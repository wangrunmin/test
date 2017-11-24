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
        /// <summary>描述测试文件</summary>
        /// <param>a-String-否-物料代码</param>
        /// <param>b-String-否-物料代码</param>
        /// <param>c-String-否-物料代码JSON#{ "List": [{ "ID": "1", "Country": "中国", "AccountName": "张三", "AccountBank": "1212121", "AccountNumber": "1212121", "RelativeFileUrl": "~\\MenHu\\Upload\\36\\20171023100941217公开询价__1_.jpg" }] }</param>
        public string Index()
        {
            return "";
        }
        public string Index2()
        {
            var P_a = Request.QueryString["a"] ?? Request.Form["a"];
            return "";
        }
    }
}