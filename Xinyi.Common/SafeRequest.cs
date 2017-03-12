using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Collections;

namespace Xinyi.Common
{
    /// <summary>
    /// Request操作类
    /// </summary>
    public class SafeRequest
    {
        /// <summary>
        /// 判断当前页面是否接收到了Post请求
        /// </summary>
        /// <returns>是否接收到了Post请求</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }

        /// <summary>
        /// 判断当前页面是否接收到了Get请求
        /// </summary>
        /// <returns>是否接收到了Get请求</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// 返回指定的服务器变量信息
        /// </summary>
        /// <param name="strName">服务器变量名</param>
        /// <returns>服务器变量信息</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
                return "";

            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /// <summary>
        /// 返回上一个页面的地址
        /// </summary>
        /// <returns>上一个页面的地址</returns>
        public static string GetUrlReferrer()
        {
            string retVal = null;

            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }

            if (retVal == null)
                return "";

            return retVal;
        }

        /// <summary>
        /// 得到当前完整主机头
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());

            return request.Url.Host;
        }

        /// <summary>
        /// 得到主机头
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }


        /// <summary>
        /// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
        /// </summary>
        /// <returns>原始 URL</returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// </summary>
        /// <returns>当前访问是否来自浏览器软件</returns>
        public static bool IsBrowserGet()
        {
            string[] BrowserName = { "ie", "opera", "netscape", "mozilla", "konqueror", "firefox" };
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否来自搜索引擎链接
        /// </summary>
        /// <returns>是否来自搜索引擎链接</returns>
        public static bool IsSearchEnginesGet()
        {
            if (HttpContext.Current.Request.UrlReferrer == null)
                return false;

            string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };
            string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获得当前完整Url地址
        /// </summary>
        /// <returns>当前完整Url地址</returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }


        /// <summary>
        /// 获得指定Url参数的值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的值</returns>
        public static string GetQueryString(string strName)
        {
            return GetQueryString(strName, false);
        }

        /// <summary>
        /// 获得指定Url参数的值
        /// </summary> 
        /// <param name="strName">Url参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>Url参数的值</returns>
        public static string GetQueryString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
                return "";

            if (sqlSafeCheck && !FunctionClass.IsSafeSqlString(HttpContext.Current.Request.QueryString[strName]))
                return "unsafe string";

            return HttpContext.Current.Request.QueryString[strName];
        }

        /// <summary>
        /// 获得当前页面的名称
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// 返回表单或Url参数的总个数
        /// </summary>
        /// <returns></returns>
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }


        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <returns>表单参数的值</returns>
        public static string GetFormString(string strName)
        {
            return GetFormString(strName, false);
        }

        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>表单参数的值</returns>
        public static string GetFormString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
                return "";

            if (sqlSafeCheck && !FunctionClass.IsSafeSqlString(HttpContext.Current.Request.Form[strName]))
                return "unsafe string";

            return HttpContext.Current.Request.Form[strName];
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <returns>Url或表单参数的值</returns>
        public static string GetString(string strName)
        {
            return GetString(strName, false);
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>Url或表单参数的值</returns>
        public static string GetString(string strName, bool sqlSafeCheck)
        {
            if ("".Equals(GetQueryString(strName)))
                return GetFormString(strName, sqlSafeCheck);
            else
                return GetQueryString(strName, sqlSafeCheck);
        }

        /// <summary>
        /// 获得指定Url参数的int类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的int类型值</returns>
        public static int GetQueryInt(string strName)
        {
            return FunctionClass.StrToInt(HttpContext.Current.Request.QueryString[strName], 0);
        }


        /// <summary>
        /// 获得指定Url参数的int类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return FunctionClass.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// 获得指定表单参数的int类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的int类型值</returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return FunctionClass.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的int类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
                return GetFormInt(strName, defValue);
            else
                return GetQueryInt(strName, defValue);
        }

        /// <summary>
        /// 获得指定Url参数的double类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        public static double GetQueryDouble(string strName, double defValue)
        {
            return FunctionClass.StrToDouble(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// 获得指定表单参数的double类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的double类型值</returns>
        public static double GetFormDouble(string strName, double defValue)
        {
            return FunctionClass.StrToDouble(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的double类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        public static double GetDouble(string strName, double defValue)
        {
            if (GetQueryDouble(strName, defValue) == defValue)
                return GetFormDouble(strName, defValue);
            else
                return GetQueryDouble(strName, defValue);
        }

        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(result) || !FunctionClass.IsIP(result))
                return "127.0.0.1";

            return result;
        }

        /// <summary>
        /// 保存用户上传的文件
        /// </summary>
        /// <param name="path">保存路径</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }

        /// <summary>
        /// 上传并获取文件服务器相对路径
        /// </summary>
        /// <param name="FilePath">文件保存路径</param>
        /// <param name="FileType">文件类型后缀，例如：jpg|bmp</param>
        /// <param name="FileSize">文件大小限制，KB</param>
        /// <returns>服务器相对路径的数组</returns>
        public static ArrayList GetFiles(string FilePath, string FileType, int FileSize)
        {
            ArrayList arlFiles = new ArrayList();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile myFile = HttpContext.Current.Request.Files[i];

                arlFiles.Add(GetFile(myFile, FilePath, FileType, FileSize));
            }

            return arlFiles;
        }

        /// <summary>
        /// 上传并获取文件服务器相对路径
        /// </summary>
        /// <param name="FilePath">文件保存路径</param>
        /// <param name="FileType">文件类型后缀，例如：jpg|bmp</param>
        /// <param name="FileSize">文件大小限制，KB</param>
        /// <returns>服务器相对路径</returns>
        public static string GetFile(string FilePath, string FileType, int FileSize)
        {
            string strResult = "";

            if (HttpContext.Current.Request.Files.Count > 0)
            {
                strResult = GetFile(HttpContext.Current.Request.Files[0], FilePath, FileType, FileSize);
            }

            return strResult;
        }

        /// <summary>
        /// 上传并获取文件服务器相对路径
        /// </summary>
        /// <param name="myFile">文件对象</param>
        /// <param name="FilePath">文件保存路径</param>
        /// <param name="FileType">文件类型后缀，例如：jpg|bmp</param>
        /// <param name="FileSize">文件大小限制，KB</param>
        /// <returns>服务器相对路径</returns>
        public static string GetFile(HttpPostedFile myFile,string FilePath, string FileType, int FileSize)
        {
            string Result = "";
            bool isOk = false;
            string strFileName, fileExtension;

            //创建通用函数对象
            FunctionClass myFun = new FunctionClass();
            //文件名
            strFileName = myFile.FileName;
            //文件后缀名
            fileExtension = "";

            if (strFileName != String.Empty)
            {
                fileExtension = System.IO.Path.GetExtension(strFileName).ToLower();
                if (FileType == null || FileType == "")
                    FileType = "jpg|gif|bmp|doc|xls|txt|rar|zip|mdb|ppt|docx|xlsx|pptx";
                string[] arrFileType = FileType.Split('|');
                for (int i = 0; i < arrFileType.Length; i++)
                {
                    if ("." + arrFileType[i] == fileExtension)
                        isOk = true;
                }

                if (isOk)
                {
                    if (myFile.ContentLength > FileSize * 1024)
                    {
                        FunctionClass.ShowMsgBox("上传的文件不能大于" + FileSize + "KB");
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(FilePath));
                        if (!dir.Exists)
                            dir.Create();

                        //新文件名
                        strFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + myFun.GetRandomID();
                        strFileName += fileExtension;

                        myFile.SaveAs(HttpContext.Current.Server.MapPath(FilePath) + strFileName);

                        Result = FilePath + strFileName;
                    }
                }
                else
                {
                    string strURL;
                    try
                    {
                        strURL = HttpContext.Current.Request.Url.ToString();
                    }
                    catch
                    {
                        strURL = "";
                    }

                    if (strURL == "")
                        FunctionClass.ShowMsgBox("目前本系统支持的格式为：" + FileType);
                    else
                        FunctionClass.ShowMsgBox("目前本系统支持的格式为：" + FileType, strURL);
                    HttpContext.Current.Response.End();
                }
            }
            else
                Result = "";

            return Result;
        }
    }
}
