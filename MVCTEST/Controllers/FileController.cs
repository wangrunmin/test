using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCTEST.Controllers
{
    public class FileController : Controller
    {
        /// <summary>
        /// 一个动作方法需要做的：
        /// 取得参数
        /// 需要对参数进行验证
        /// 处理参数
        /// 存入数据库
        /// </summary>
        /// <returns></returns>
        public string 动作模板()
        {
            try
            {
                var P_参数 = Request.QueryString["参数"] ?? Request.Form["参数"];
                var P_JSON = Request.QueryString[""] ?? Request.Form[""];
                var Ent_P_JSON = JsonConvert.DeserializeObject<A>(P_JSON);
                if (Ent_P_JSON == null) throw new Exception("参数读取失败");
                P_JSON = JsonConvert.SerializeObject(Ent_P_JSON);
                if (string.IsNullOrEmpty(P_参数)) throw new Exception("参数不能为空");
                var 对象实例 = new
                {
                    参数 = P_参数
                };
                using (var ctx = new TempDataContext())
                {
                    if (ctx.AB.Where(m => m.AGUID == P_参数).FirstOrDefault() != null) throw new Exception("参数已经存在");

                    ctx.AB.InsertOnSubmit(new AB());
                }
                return JsonConvert.SerializeObject(new
                {
                    res = "OK",
                    msg = "数据"
                });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new
                {
                    res = "ERROR",
                    msg = e.Message
                });
            }
        }

        //  总结就是两个点：GUID、HASH文件目录的使用。
        /// <summary>
        /// 现在遇到的问题：自动插入数据库，如果失败自动回滚。包含附件。
        /// 首先验证各个待插入对象，再保存文件，如果保存失败，返回错误，成功则提交更改。
        /// 涉及到多个文件的情况下。
        /// 附件使用一张新表有无必要的问题。解决了什么，为什么要这么做？
        /// 可以解决文件引用次数的问题，从而在个人删除文件的时候确定是不是要把文件删除，还是仅仅删除引用。
        /// 还可以保留文件名。
        /// 统一查看文件
        /// 坏处呢？
        /// 插入数据库多了一步。
        /// 浪费空间？
        /// </summary>
        /// <returns></returns>
        public string AB()
        {
            var p = Request.QueryString["P"] + Request.Form["P"];
            var aa = Request.Params["P"];
            using (var ctx = new TempDataContext())
            {
                var a = new A()
                {
                    GUID = Guid.NewGuid().ToString("N").ToUpper()
                };
                ctx.A.InsertOnSubmit(a);
                var b = new B()
                {
                    GUID = Guid.NewGuid().ToString("N").ToUpper()
                };
                ctx.B.InsertOnSubmit(b);
                var ab = new AB()
                {
                    AGUID = a.ID.ToString(),
                    BGUID = b.GUID
                };
                ctx.AB.InsertOnSubmit(ab);
                var file = Request.Files[0];
                var ent = CreateFile(file);
                file.SaveAs(ent.Url);
                ctx.File.InsertOnSubmit(ent);
                ctx.SubmitChanges();
                return "OK";
            }
        }
        public File CreateFile(HttpPostedFileBase file)
        {
            #region 创建MD5目录
            MD5 calculator = MD5.Create();
            var buffer = calculator.ComputeHash(file.InputStream);
            StringBuilder md5Hex = new StringBuilder();
            for (int j = 0; j < buffer.Length; j++)
            {
                md5Hex.Append(buffer[j].ToString("X2"));
            }
            var directory = Path.Combine("~\\Files\\", buffer[0].ToString("X2"), buffer[1].ToString("X2"));
            if (!Directory.Exists(Server.MapPath(directory))) Directory.CreateDirectory(Server.MapPath(directory));
            #endregion
            #region 文件路径
            var fileName = file.FileName.Split('.');
            var fileRelativeUrl = Path.Combine(directory, md5Hex.ToString() + "." + fileName[fileName.Length - 1]);
            #endregion
            #region 新建对象，等待插入数据库
            var ent = new File()
            {
                FileName = file.FileName,
                GUID = Guid.NewGuid().ToString("N").ToUpper(),
                Url = fileRelativeUrl,
                ContentType = file.ContentType,
                ContentLength = file.ContentLength
            };
            #endregion
            return ent;
        }
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns>文件的详细信息</returns>
        public string Upload()
        {
            using (var ctx = new TempDataContext())
            {
                var list = new List<File>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    #region 创建MD5目录
                    MD5 calculator = MD5.Create();
                    if (file.ContentLength == 0 && string.IsNullOrEmpty(file.FileName)) continue;
                    var buffer = calculator.ComputeHash(file.InputStream);
                    StringBuilder md5Hex = new StringBuilder();
                    for (int j = 0; j < buffer.Length; j++)
                    {
                        md5Hex.Append(buffer[j].ToString("X2"));
                    }
                    var directory = Path.Combine("~\\Files\\", buffer[0].ToString("X2"), buffer[1].ToString("X2"));
                    if (!Directory.Exists(Server.MapPath(directory))) Directory.CreateDirectory(Server.MapPath(directory));
                    #endregion
                    #region 保存文件
                    var fileName = file.FileName.Split('.');
                    var fileRelativeUrl = Path.Combine(directory, md5Hex.ToString() + "." + fileName[fileName.Length - 1]);
                    if (!System.IO.File.Exists(Server.MapPath(fileRelativeUrl))) file.SaveAs(Server.MapPath(fileRelativeUrl));
                    #endregion
                    #region 新建对象，等待插入数据库
                    var ent = new File()
                    {
                        FileName = file.FileName,
                        GUID = Guid.NewGuid().ToString("N").ToUpper(),
                        Url = fileRelativeUrl,
                        ContentType = file.ContentType,
                        ContentLength = file.ContentLength
                    };
                    list.Add(ent);
                    #endregion
                }
                ctx.File.InsertAllOnSubmit(list);
                ctx.SubmitChanges();
                return JsonConvert.SerializeObject(list);
            }
        }

        public string Preview()
        {
            using (var ctx = new TempDataContext())
            {
                var fileEnt = ctx.File.Where(m => m.GUID == Request.QueryString["GUID"]).Single();
                return "data:image/jpeg;base64," + Convert.ToBase64String(System.IO.File.ReadAllBytes(Server.MapPath(fileEnt.Url)));
            }
        }
    }
}