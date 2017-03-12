using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Specialized;

namespace alatong
{
    public partial class getIP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("您的IP地址为：" + IPAddress + "<br/>");//输出至页面
            //System.Diagnostics.Debug.WriteLine("您的IP地址为：" + IPAddress);//输出值debug

            //获取当前请求的虚拟路径
            //Label1.Text = Request.Path.ToString();
            //获取远程客户端的ip地址
            //Label1.Text = Request.UserHostAddress;
            //获取远程客户端的DNS名称
            //Label1.Text = Request.UserHostName;


            //获取远程客户端的浏览器特性 Browser属性
            Label1.Text = Request.Browser.ToString();

            //获取浏览器特性名称
            Response.Write("浏览器类型名称：" + Request.Browser["Browser"] + "<br/>");
            Response.Write("浏览器版本：" + Request.Browser["Version"] + "<br/>");
            Response.Write("浏览器主版本：" + Request.Browser["MajorVersion"] + "<br/>");
            Response.Write("浏览器次版本：" + Request.Browser["MinorVersion"] + "<br/>");
            Response.Write("是否支持框架功能：" + Request.Browser["Frames"] + "<br/>");
            Response.Write("是否支持表格功能：" + Request.Browser["Tables"] + "<br/>");
            Response.Write("是否支持Cookies：" + Request.Browser["Cookies"] + "<br/>");
            Response.Write("是否支持VBScript：" + Request.Browser["VBScript"] + "<br/>");
            Response.Write("是否支持Java小程序：" + Request.Browser["JavaApplets"] + "<br/>");
            Response.Write("是否支持ActiveX控件：" + Request.Browser["ActiveXControls"] + "<br/>");


            //获取 Web 服务器变量的集合。
            //Response.Write("客户端浏览器所发出的所有HTTP标题文件：" + Request.ServerVariables["ALL_HTTP"] + "<br/>");
            Response.Write("发送到客户端的文件长度：" + Request.ServerVariables["CONTENT_LENGTH"] + "<br/>");
            Response.Write("发送到客户端的文件类型：" + Request.ServerVariables["CONTENT_TYPE"] + "<br/>");
            Response.Write("路径信息：" + Request.ServerVariables["PATH_INFO"] + "<br/>");
            Response.Write("URL的基本部分：" + Request.ServerVariables["url"] + "<br/>");

            //int loop1, loop2;
            //NameValueCollection coll;

            //// Load ServerVariable collection into NameValueCollection object.
            //coll = Request.ServerVariables;
            //// Get names of all keys into a string array. 
            //String[] arr1 = coll.AllKeys;
            //Response.Write("arr1的长度为" + arr1.Length + "<br>");
            //for (loop1 = 0; loop1 < arr1.Length; loop1++)
            //{
            //    Response.Write("Key: " + arr1[loop1] + "<br>");
            //    String[] arr2 = coll.GetValues(arr1[loop1]);
            //    for (loop2 = 0; loop2 < arr2.Length; loop2++)
            //    {
            //        Response.Write("Value " + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
            //    }
            //}


            //获取客户端安全证书 ClientCertificate属性
            //Response.Write("安全证书：" + Request.ClientCertificate[关键字] + "<br/>");

            //获取当前请求的客户端安全证书。
            HttpClientCertificate cs = Request.ClientCertificate;
            Response.Write("ClientCertificate Settings:<br>");
            Response.Write("Certificate = " + cs.Certificate + "<br>");
            Response.Write("Cookie = " + cs.Cookie + "<br>");
            Response.Write("Flags = " + cs.Flags + "<br>");
            Response.Write("IsPresent = " + cs.IsPresent + "<br>");
            Response.Write("Issuer = " + cs.Issuer + "<br>");
            Response.Write("IsValid = " + cs.IsValid + "<br>");
            Response.Write("KeySize = " + cs.KeySize + "<br>");
            Response.Write("SecretKeySize = " + cs.SecretKeySize + "<br>");
            Response.Write("SerialNumber = " + cs.SerialNumber + "<br>");
            Response.Write("ServerIssuer = " + cs.ServerIssuer + "<br>");
            Response.Write("ServerSubject = " + cs.ServerSubject + "<br>");
            Response.Write("Subject = " + cs.Subject + "<br>");
            Response.Write("ValidFrom = " + cs.ValidFrom + "<br>");
            Response.Write("ValidUntil = " + cs.ValidUntil + "<br>");
            Response.Write("What's this = " + cs.ToString() + "<br>");

            //int loop3, loop4;
            //NameValueCollection coll2;

            //// Load ServerVariable collection into NameValueCollection object.
            //coll2 = Request.ClientCertificate;
            //// Get names of all keys into a string array. 
            //String[] arr3 = coll2.AllKeys;
            //Response.Write("arr3的长度为" + arr3.Length  + "<br>");
            //for (loop3 = 0; loop3 < arr3.Length; loop3++)
            //{
            //    Response.Write("Key: " + arr3[loop3] + "<br>");
            //    String[] arr4 = coll2.GetValues(arr3[loop3]);
            //    for (loop4 = 0; loop4 < arr4.Length; loop4++)
            //    {
            //        Response.Write("Value " + loop4 + ": " + Server.HtmlEncode(arr4[loop4]) + "<br>");
            //    }
            //}


            Label2.Text = "您当前的IP为：" + IpLocation(IPAddress)[0];
            Label3.Text = "该IP所在地为：" + IpLocation(IPAddress)[1];



        }

        /// <summary>  
        /// 获取IP地址 属性  
        /// </summary>  
        public static string IPAddress
        {
            get
            {
                string userIP;
                // HttpRequest Request = HttpContext.Current.Request;  
                HttpRequest Request = HttpContext.Current.Request; // ForumContext.Current.Context.Request;  
                // 如果使用代理，获取真实IP  
                if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                    userIP = Request.ServerVariables["REMOTE_ADDR"];
                else
                    userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (userIP == null || userIP == "")
                    userIP = Request.UserHostAddress;
                System.Diagnostics.Debug.WriteLine("userIP的返回值为：" + userIP);
                return userIP;
            }
        }

        /// <summary>  
        /// 获取IP地址  
        /// </summary>  
        static public string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            return result;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Label4.Text = GetUserLocation();

            Response.Write("Please Login: <br>");
            //输出当前目录下的login.txt文件里的内容
            //Response.WriteFile("login.txt");

            //Response.ContentType = "image/JPEG";
            //Response.WriteFile("images/index_03.jpg");
        }

        /// <summary>  
        /// 获取IP地址和该ip的地理位置信息  
        /// </summary>  
        public string[] IpLocation(string ipAddress)
        {
            //string[] result;
            if (string.IsNullOrEmpty(ipAddress.Trim()))
            {
                System.Diagnostics.Debug.Write("IP地址为空");
                return null;
            }
            WebClient client = new WebClient();
            //client.Encoding = System.Text.Encoding.GetEncoding("GB2312");
            client.Encoding = System.Text.Encoding.GetEncoding("utf-8");
            string url = "http://ip.chinaz.com/getip.aspx";
            string post = "ip=" + ipAddress + "&action=2";
            //string post = "ip=" + ipAddress + "&action=queryip&ip_url=";
            System.Diagnostics.Debug.WriteLine("post的值为：" + post);
            client.Headers.Set("Content-Type", "application/x-www-form-urlencoded");
            string response = client.UploadString(url, post);
            System.Diagnostics.Debug.WriteLine("response的值为：" + response);

            //利用多个字符来分隔字符串
            string[] sArray = response.Split(new char[5] { '{', ':', '\'', ',', '}' });
            System.Diagnostics.Debug.WriteLine("sArray[0]的值为：" + sArray[0]);
            System.Diagnostics.Debug.WriteLine("sArray[1]的值为：" + sArray[1]);
            System.Diagnostics.Debug.WriteLine("sArray[2]的值为：" + sArray[2]);
            System.Diagnostics.Debug.WriteLine("sArray[3]的值为：" + sArray[3]);
            System.Diagnostics.Debug.WriteLine("sArray[4]的值为：" + sArray[4]);
            System.Diagnostics.Debug.WriteLine("sArray[5]的值为：" + sArray[5]);
            System.Diagnostics.Debug.WriteLine("sArray[6]的值为：" + sArray[6]);
            System.Diagnostics.Debug.WriteLine("sArray[7]的值为：" + sArray[7]);

            ////Server.UrlEncode("需要编码的字符串")Server.UrlDecode("需要解码的字符串")
            //sArray[7] = Server.UrlEncode(sArray[7]);
            //System.Diagnostics.Debug.WriteLine("sArray[7]的值为：" + sArray[7]);
            //sArray[7] = Server.UrlDecode(sArray[7]);
            //System.Diagnostics.Debug.WriteLine("sArray[7]的值为：" + sArray[7]);

            System.Diagnostics.Debug.WriteLine("sArray[8]的值为：" + sArray[8]);
            System.Diagnostics.Debug.WriteLine("sArray[9]的值为：" + sArray[9]);

            List<System.String> listS = new List<System.String>();
            listS.Add(sArray[3]);
            listS.Add(sArray[7]);
            System.String[] str = listS.ToArray();
            return str;

            //string p = @"<li>参考数据二：(?<location>[^<>]+?)</li>";
            //System.Diagnostics.Debug.WriteLine("p的值为：" + p);
            //Match match = Regex.Match(response, p);
            //System.Diagnostics.Debug.WriteLine("match的值为：" + match);
            //string m_Location = match.Groups["location"].Value.Trim();
            //System.Diagnostics.Debug.WriteLine("m_Location的值为：" + m_Location);
            //result = m_Location.Split(' ');
            //System.Diagnostics.Debug.WriteLine("result的值为：" + result);
            //return result[0];
        }

        /// <summary>  
        /// 获取IP地址  
        /// </summary>  
        public static string GetUserLocation()
        {
            try
            {
                WebClient webGetting = new WebClient();
                webGetting.Encoding = System.Text.Encoding.GetEncoding("utf-8");
                string userIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                System.Diagnostics.Debug.WriteLine("userIP的值为：" + userIP);
                System.Diagnostics.Debug.Write("您的IP地址为："); System.Diagnostics.Debug.Write(userIP);
                //string ipQueryResult = webGetting.DownloadString("http://ip.chinaz.com/getip.aspx?action=queryip&ip_url=" + userIP);
                string ipQueryResult = webGetting.DownloadString("http://ip.chinaz.com/getip.aspx");
                System.Diagnostics.Debug.Write("您的登录地为："); System.Diagnostics.Debug.Write(ipQueryResult);
                string startString = @"来自：";
                int startIndex = ipQueryResult.LastIndexOf(startString) + startString.Length;
                int endIndex = ipQueryResult.LastIndexOf(@" ", startIndex);
                return ipQueryResult.Substring(startIndex, ipQueryResult.Length - startIndex);
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}