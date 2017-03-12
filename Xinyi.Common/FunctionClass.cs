using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Xinyi.Common
{
    public class FunctionClass
    {
        public FunctionClass()
        {}

        /// <summary>
        /// 弹出提示窗口
        /// </summary>
        /// <param name="strMsg">提示信息</param>
        public static void ShowMsgBox(string strMsg)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + strMsg + "');history.back();</script>");
        }

        /// <summary>
        /// 弹出提示窗口
        /// </summary>
        /// <param name="strMsg">提示信息</param>
        /// <param name="isCloseWindow">是否关闭本窗口</param>
        public static void ShowMsgBox(string strMsg, bool isCloseWindow)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + strMsg + "');");
            if (isCloseWindow)
                HttpContext.Current.Response.Write("window.close();");
            HttpContext.Current.Response.Write("</script>");
        }

        /// <summary>
        /// 弹出提示窗口
        /// </summary>
        /// <param name="strMsg">提示信息</param>
        /// <param name="strURL">指向页面，如果为空，那么指向Session["UserViewURL"]</param>
        public static void ShowMsgBox(string strMsg, string strURL)
        {
            if (strURL == null || strURL == "")
            {
                if (HttpContext.Current.Session["UserViewURL"] == null)
                    ShowMsgBox(strMsg);
                else
                    HttpContext.Current.Response.Write("<script language='javascript'>alert('" + strMsg + "');location.href='" + HttpContext.Current.Session["UserViewURL"].ToString() + "';</script>");
            }
            else
                HttpContext.Current.Response.Write("<script language='javascript'>alert('" + strMsg + "');location.href='" + strURL + "';</script>");
        }

        /// <summary>
        /// 弹出提示窗口
        /// </summary>
        /// <param name="strMsg">提示信息</param>
        /// <param name="strURL">指向页面，如果为空，那么指向Session["UserViewURL"]</param>
        /// <param name="isParent">是否父级页面跳转</param>
        public static void ShowMsgBox(string strMsg, string strURL, bool isParent)
        {
            if (isParent)
            {
                if (strURL == null || strURL == "")
                {
                    if (HttpContext.Current.Session["UserViewURL"] == null)
                        ShowMsgBox(strMsg);
                    else
                        HttpContext.Current.Response.Write("<script language='javascript'>alert('" + strMsg + "');if(parent){parent.location.href='" + HttpContext.Current.Session["UserViewURL"].ToString() + "';}else{location.href='" + HttpContext.Current.Session["UserViewURL"].ToString() + "';};</script>");
                }
                else
                    HttpContext.Current.Response.Write("<script language='javascript'>alert('" + strMsg + "');if(parent){parent.location.href='" + strURL + "';}else{location.href='" + strURL + "';};</script>");
            }
            else
            {
                ShowMsgBox(strMsg, strURL);
            }
        }

        /// <summary>
        /// 弹出是否对话框
        /// </summary>
        /// <param name="strMsg">提示信息</param>
        /// <param name="strURL">跳转地址</param>
        /// <param name="strURL1">跳转地址1</param>
        public static void ShowConfirm(string strMsg, string strURL, string strURL1)
        {
            if (strURL == null || strURL == "")
            {
                if (HttpContext.Current.Session["UserViewURL"] == null)
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>if(confirm('" + strMsg + "'))location.href='" + strURL1 + "';else{history.back();}</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>if(confirm('" + strMsg + "'))location.href='" + strURL1 + "';else{location.href='" + HttpContext.Current.Session["UserViewURL"].ToString() + "';}</script>");
                }
            }
            else
                HttpContext.Current.Response.Write("<script language='javascript'>if(confirm('" + strMsg + "'))location.href='" + strURL1 + "';else{location.href='" + strURL + "';}</script>");
        }

        public static string InitializeMsgDiv()
        {
            return "<script language='javascript'>WriteMaskDiv();WriteLoadingDiv();WriteMsgBoxDiv('');WriteQuestionBoxDiv('');"
                + "WriteInputBoxDiv('','','');SetDivCenter('ProgressPanel');SetDivCenter('dialog_div1');SetDivCenter('dialog_div2');SetDivCenter('dialog_div3');</script>";
        }

        public static string ShowMsgDiv(string strMsg)
        {
            return "<script language='javascript'>WriteMaskDiv();WriteMsgBoxDiv(\"" + strMsg + "\");ShowDialogDiv(1);SetDivCenter('dialog_div1');</script>";
        }

        /// <summary>
        /// 检查字符串是否合法
        /// </summary>
        /// <param name="theStr">字符串</param>
        /// <param name="type">判断的分类</param>
        /// <returns>返回是否</returns>
        public static bool CheckStr(string theStr, int type)
        {
            bool isOk = false;
            switch (type)
            {
                case 0://判断是否空值
                    if (theStr == null || theStr == "")
                        isOk = false;
                    else
                        isOk = true;
                    break;
                case 1://判断是否数字
                    if (theStr == null || theStr == "")
                        isOk = false;
                    else
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(theStr, @"^-?\d+$"))
                            isOk = true;
                        else
                            isOk = false;
                    }
                    break;
            }
            return isOk;
        }

        /// <summary>
        /// 检查IP地址是否合法
        /// </summary>
        /// <param name="IP">IP地址</param>
        /// <returns>是否合法</returns>
        public bool CheckIPValue(string IP)
        {
            bool Result;
            Result = false;
            if (IP != null)
            {
                string[] arrIP = IP.Split('.');
                if (arrIP.Length == 4)
                {
                    for (int i = 0; i < arrIP.Length; i++)
                    {
                        if (CheckStr(arrIP[i].ToString(), 1))
                        {
                            if (int.Parse(arrIP[i].ToString()) <= 255 && int.Parse(arrIP[i].ToString()) >= 0)
                                Result = true;
                            else
                            {
                                Result = false;
                                break;
                            }
                        }
                        else
                        {
                            Result = false;
                            break;
                        }
                    }
                }
            }

            return Result;
        }

        /// <summary>
        /// 检查IP段是否合法
        /// </summary>
        /// <param name="IP1">IP地址1</param>
        /// <param name="IP2">IP地址2</param>
        /// <param name="myIP">要检查的IP</param>
        /// <returns>是否合法</returns>
        public bool CheckIP(string IP1, string IP2, string myIP)
        {
            //判断IP字符串是否是IP地址
            if (!CheckIPValue(IP1))
                return false;
            if (!CheckIPValue(IP2))
                return false;
            if (!CheckIPValue(myIP))
                return false;

            //检查我的IP是否在制定IP范围内
            bool Result = false;
            string[] arrIP1 = IP1.Split('.');
            string[] arrIP2 = IP2.Split('.');
            string[] arrmyIP = myIP.Split('.');

            for (int i = 0; i < 4; i++)
            {
                int intIP1 = int.Parse(arrIP1[i].ToString());
                int intIP2 = int.Parse(arrIP2[i].ToString());
                int intmyIP = int.Parse(arrmyIP[i].ToString());
                if (intmyIP >= intIP1 && intmyIP <= intIP2)
                    Result = true;
                else
                {
                    Result = false;
                    break;
                }
            }

            return Result;
        }

        //函数功能:给URL加上新变量
        //说明:
        //返回值:string URL
        public static string GetNewURL(string ParamsName, string Params, string URL)
        {
            string strNewURL = "";
            if (URL == null || URL == "")
            {
                strNewURL = "";
            }
            else
            {
                if (URL.ToLower().IndexOf("aspx?") > -1)
                {
                    if (URL.IndexOf(ParamsName + "=") > -1)
                    {
                        if (URL.IndexOf("&", URL.IndexOf(ParamsName)) > -1)
                        {
                            //HttpContext.Current.Response.Write(URL.Substring(0,URL.IndexOf(ParamsName))+"<br>"+URL.Substring(URL.IndexOf("&",URL.IndexOf(ParamsName)),(URL.Length-URL.IndexOf("&",URL.IndexOf(ParamsName)))));
                            strNewURL = URL.Substring(0, URL.IndexOf(ParamsName) - 1) + URL.Substring(URL.IndexOf("&", URL.IndexOf(ParamsName)), (URL.Length - URL.IndexOf("&", URL.IndexOf(ParamsName))));
                            strNewURL = strNewURL + "&" + ParamsName + "=" + UrlEncode(Params);
                        }
                        else
                        {
                            strNewURL = URL.Substring(0, URL.IndexOf(ParamsName));
                            strNewURL = strNewURL + ParamsName + "=" + UrlEncode(Params);
                        }
                    }
                    else
                    {
                        strNewURL = URL + "&" + ParamsName + "=" + UrlEncode(Params);
                    }
                }
                else
                {
                    strNewURL = URL + "?" + ParamsName + "=" + UrlEncode(Params);
                }
            }

            if (strNewURL.IndexOf("&") > -1)
            {
                if (strNewURL.IndexOf("?") > -1)
                { }
                else
                    strNewURL = strNewURL.Substring(0, strNewURL.IndexOf("&")) + "?" + strNewURL.Substring(strNewURL.IndexOf("&") + 1);
            }

            return strNewURL;
        }

        /// <summary>
        /// 分析sql语句，替换条件参数
        /// </summary>
        /// <param name="strSql">老sql语句</param>
        /// <param name="ParamsName">参数名</param>
        /// <param name="Params">参数值</param>
        /// <returns>新sql语句</returns>
        public string GetNewSql(string strSql, string ParamsName, string Params)
        {
            string Result = "";
            string strOrder = "", strWhere = "", str1 = "";
            if (strSql == null || strSql == "")
                Result = "";
            else
            {
                if (Params == null)
                    Result = strSql;
                else
                {
                    int intOrder = strSql.ToLower().IndexOf(" order by");
                    if (intOrder > -1)
                    {
                        strOrder = strSql.Substring(intOrder, strSql.Length - intOrder);
                        strWhere = strSql.Substring(0, intOrder);
                    }
                    else
                    {
                        strOrder = "";
                        strWhere = strSql;
                    }
                    int intWhere = strWhere.IndexOf(ParamsName);
                    if (intWhere > -1)
                    {
                        str1 = strWhere.Substring(intWhere + ParamsName.Length - 1);
                        if (str1.IndexOf(" ") > -1)
                            str1 = str1.Substring(0, str1.IndexOf(" "));
                        strWhere = strWhere.Replace(ParamsName + str1, ParamsName + Params);
                    }
                    else
                    {
                        strWhere += " and " + ParamsName + Params;
                    }
                    Result = strWhere + strOrder;
                }
            }
            return Result;
        }

        /// <summary> 
        /// 编码转换 
        /// </summary> 
        /// <param name="strIn">要转换的字符串</param> 
        /// <param name="encoding">编码</param> 
        /// <returns>转换好的结果</returns> 
        public string StrConv(string strIn, string encoding)
        {
            return System.Web.HttpUtility.UrlEncode(strIn, System.Text.Encoding.GetEncoding(encoding));
        }

        /// <summary>
        /// 给URL中的中文字符编码
        /// </summary>
        /// <param name="strOld">旧字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string UrlEncode(string strOld)
        {
            string strNew;
            strNew = strOld;
            if (strOld == null || strOld == "")
            { }
            else
            {
                strNew = "";
                for (int i = 0; i < strOld.Length; i++)
                {
                    if (strOld[i] >= 0x4e00 && strOld[i] <= 0x9fa5)
                    {
                        strNew += HttpContext.Current.Server.UrlEncode(strOld[i].ToString());
                    }
                    else
                        strNew += strOld[i].ToString();
                }
            }
            return strNew;
        }

         /// <summary>
        ///  检查是否含有中文
        /// </summary>
        /// <param name="InputText">需要检查的字符串</param>
        /// <returns></returns>
        public static bool isHasChzn(string str)
        {
            byte[] strASCII = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            int tmpNum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                //中文检查
                if ((int)strASCII[i] >= 63 && (int)strASCII[i] < 91)
                {

                    tmpNum += 2;
                }
            }
            if (tmpNum > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 中文编码过的页面URL
        /// </summary>
        public static string PageURL
        {
            get
            {
                if (HttpContext.Current.Request.Url == null)
                    return null;
                else
                {
                    //获取URL
                    string tmpUrl = HttpContext.Current.Request.Url.ToString();
                    string[] arrUrl = tmpUrl.Split('?');

                    //判断是否有参数
                    if (arrUrl.Length > 1)
                    {
                        string tmpNewUrl = "";
                        for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
                        {
                            tmpNewUrl += HttpContext.Current.Request.QueryString.GetKey(i) + "="
                                + (!FunctionClass.isHasChzn(HttpContext.Current.Request.QueryString[i])?
                                HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.QueryString[i]) : UrlEncode(HttpContext.Current.Request.QueryString[i].ToString()));

                            if (i < HttpContext.Current.Request.QueryString.Count - 1)
                                tmpNewUrl += "&";
                        }

                        return arrUrl[0]+"?" + tmpNewUrl;
                        //return HttpContext.Current.Server.UrlEncode(UrlEncode(HttpContext.Current.Request.Url.ToString()));
                    }
                    else
                        return UrlEncode(HttpContext.Current.Request.Url.ToString());
                }
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns>加密字符串</returns>
        public static string ToMD5(string sourceString)
        {
            return ToMD5("utf-8", sourceString);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="codeName">字符串编码</param>
        /// <param name="sourceString">源字符串</param>
        /// <returns>加密字符串</returns>
        public static string ToMD5(string codeName, string sourceString)
        {
            MD5 md5 = MD5.Create();
            byte[] source = md5.ComputeHash(Encoding.GetEncoding(codeName).GetBytes(sourceString));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                sBuilder.Append(source[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }


        //函数功能:把字符窜中的回车转换为<br>
        //说明:
        //返回值:替换好的字符串
        public static string WriteHtml(string oldStr)
        {
            string newStr;

            if (oldStr == null)
                return null;

            newStr = oldStr.Replace("<", "&lt;");
            newStr = newStr.Replace(">", "&gt;");
            newStr = newStr.Replace(" ", "&nbsp;");
            newStr = newStr.Replace("\n", "<br>");

            return newStr;
        }

        /// <summary>
        /// 获取分页条
        /// </summary>
        /// <param name="intPage">当前页</param>
        /// <param name="intRsCount">总记录数</param>
        /// <param name="intPageCount">总页数</param>
        /// <param name="intPageType">分页类型，1文字，2数字，3数字文字混合</param>
        /// <param name="strURL">链接地址</param>
        /// <param name="PageNameFirst">分页名称：第一条</param>
        /// <param name="PageNamePrev">分页名称：前一条</param>
        /// <param name="PageNameNext">分页名称：下一条</param>
        /// <param name="PageNameLast">分页名称：最后一条</param>
        /// <param name="PageDropDownList">是否显示下拉选取分页框</param>
        /// <param name="PageNumTextBox">是否显示数字跳转分页框</param>
        /// <returns>分页条html</returns>
        public static string GetPageBar(int intPage, int intRsCount, int intPageCount, int intPageType, string strURL,
            string PageNameFirst, string PageNamePrev, string PageNameNext, string PageNameLast, bool PageDropDownList, bool PageNumTextBox)
        {
            string strResult = "", strTemp = "";

            //判断分页类型
            if (intPageType == 2)//数字类型
            {
                for (int i = 1; i <= intPageCount; i++)
                {
                    if (i == intPage)
                    {
                        strResult += "<b>" + i + "</b>&nbsp;";
                    }
                    else
                    {
                        strTemp = strURL.Replace("{page}", i.ToString());
                        strResult += "<a href=\"" + strTemp + "\">[" + i + "]</a>&nbsp;";
                    }
                }
            }
            else if (intPageType == 3)
            {
                strTemp = strURL.Replace("{page}", "1");
                strResult += "<a href=\"" + strTemp + "\">" + PageNameFirst + "</a>&nbsp;&nbsp;";

                if (intPage < 2)
                    strTemp = strURL.Replace("{page}", "1");
                else
                    strTemp = strURL.Replace("{page}", (intPage - 1).ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNamePrev + "</a>&nbsp;&nbsp;";

                if (intPageCount <= 5)
                {
                    //数字
                    for (int i = 1; i <= intPageCount; i++)
                    {
                        if (i == intPage)
                        {
                            strResult += "<b>" + i + "</b>&nbsp;";
                        }
                        else
                        {
                            strTemp = strURL.Replace("{page}", i.ToString());
                            strResult += "<a href=\"" + strTemp + "\">[" + i + "]</a>&nbsp;";
                        }
                    }
                }
                else
                {
                    int startid = 0;
                    int endid = 0;
                    startid = intPage - 2;
                    endid = intPage + 2;
                    if (startid <= 1)
                    {
                        endid = endid + 1 - startid;
                        startid = 1;
                    }
                    if (endid > intPageCount)
                    {
                        startid = startid - endid + intPageCount;
                        endid = intPageCount;
                    }

                    if (startid > 1)
                    {
                        strResult += "<span>...</span>";
                    }
                    for (int i = startid; i <= endid; i++)
                    {
                        if (i == intPage)
                            strResult += "<b>" + i + "</b>&nbsp;";
                        else
                        {
                            strTemp = strURL.Replace("{page}", i.ToString());
                            strResult += "<a href=\"" + strTemp + "\">[" + i + "]</a>&nbsp;";
                        }
                    }
                    if (endid < intPageCount)
                    {
                        strResult += "<b>...</b>&nbsp;";
                        strTemp = strURL.Replace("{page}", intPageCount.ToString());
                        strResult += "<a href=\"" + strTemp + "\">[" + intPageCount + "]</a>&nbsp;";
                    }
                }

                if (intPage < intPageCount)
                    strTemp = strURL.Replace("{page}", (intPage + 1).ToString());
                else
                    strTemp = strURL.Replace("{page}", intPageCount.ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNameNext + "</a>&nbsp;&nbsp;";

                strTemp = strURL.Replace("{page}", intPageCount.ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNameLast + "</a>&nbsp;&nbsp;";
            }

            else if (intPageType == 4)
            {
                strTemp = strURL.Replace("{page}", "1");
                if (PageNameFirst != "")
                    strResult += "<a href=\"" + strTemp + "\">" + PageNameFirst + "</a>&nbsp;&nbsp;";

                if (intPage < 2)
                    strTemp = strURL.Replace("{page}", "1");
                else
                    strTemp = strURL.Replace("{page}", (intPage - 1).ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNamePrev + "</a>&nbsp;&nbsp;";

                if (intPageCount <= 5)
                {
                    //数字
                    for (int i = 1; i <= intPageCount; i++)
                    {
                        if (i == intPage)
                        {
                            strResult += "<span class=\"current\">" + i + "</span>&nbsp;";
                        }
                        else
                        {
                            strTemp = strURL.Replace("{page}", i.ToString());
                            strResult += "<a href=\"" + strTemp + "\">" + i + "</a>&nbsp;";
                        }
                    }
                }
                else
                {
                    int startid = 0;
                    int endid = 0;
                    startid = intPage - 2;
                    endid = intPage + 2;
                    if (startid <= 1)
                    {
                        endid = endid + 1 - startid;
                        startid = 1;
                    }
                    if (endid > intPageCount)
                    {
                        startid = startid - endid + intPageCount;
                        endid = intPageCount;
                    }

                    if (startid > 1)
                    {
                        strResult += "...";
                    }
                    for (int i = startid; i <= endid; i++)
                    {
                        if (i == intPage)
                            strResult += "<span class=\"current\">" + i + "</span>&nbsp;";
                        else
                        {
                            strTemp = strURL.Replace("{page}", i.ToString());
                            strResult += "<a href=\"" + strTemp + "\">" + i + "</a>&nbsp;";
                        }
                    }
                    if (endid < intPageCount)
                    {
                        strResult += "...&nbsp;";
                        strTemp = strURL.Replace("{page}", intPageCount.ToString());
                        strResult += "<a href=\"" + strTemp + "\">" + intPageCount + "</a>&nbsp;";
                    }
                }

                if (intPage < intPageCount)
                    strTemp = strURL.Replace("{page}", (intPage + 1).ToString());
                else
                    strTemp = strURL.Replace("{page}", intPageCount.ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNameNext + "</a>&nbsp;&nbsp;";

                strTemp = strURL.Replace("{page}", intPageCount.ToString());

                if (PageNameLast != "")
                    strResult += "<a href=\"" + strTemp + "\">" + PageNameLast + "</a>&nbsp;&nbsp;";
            }
            else//文字类型
            {
                strTemp = strURL.Replace("{page}", "1");
                strResult += "<a href=\"" + strTemp + "\">" + PageNameFirst + "</a>&nbsp;&nbsp;";

                if (intPage < 2)
                    strTemp = strURL.Replace("{page}", "1");
                else
                    strTemp = strURL.Replace("{page}", (intPage - 1).ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNamePrev + "</a>&nbsp;&nbsp;";

                if (intPage < intPageCount)
                    strTemp = strURL.Replace("{page}", (intPage + 1).ToString());
                else
                    strTemp = strURL.Replace("{page}", intPageCount.ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNameNext + "</a>&nbsp;&nbsp;";

                strTemp = strURL.Replace("{page}", intPageCount.ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNameLast + "</a>&nbsp;&nbsp;";
            }

            //判断是否显示下拉菜单跳转框
            if (PageDropDownList)
            {
                strResult += "<select onchange=\"window.location.href=options[selectedIndex].value\">";
                for (int i = 1; i <= intPageCount; i++)
                {
                    strTemp = strURL.Replace("{page}", i.ToString());
                    strResult += "<option value=\"" + strTemp + "\"";
                    if (intPage == i)
                        strResult += " selected";
                    strResult += ">" + i + "</option>";

                }
                strResult += "</select>&nbsp;&nbsp;";
            }

            //判断是否显示输入框跳转
            if (PageNumTextBox)
            {
                strResult += "<input onFocus=\"tempCurrpage=this.value;\" onblur=\"gotoPage('" + strURL.Replace("'","") + "',this.value," + intPageCount + ")\" value=\"" + intPage
                    + "\" style=\"width:40px;text-align:center;\" onKeyUp=\"value=value.replace(/[^\\d]/g,'')\" />";
            }

            return strResult;
        }
        /// <summary>
        /// 获取分页条伪静态
        /// </summary>
        /// <param name="intPage">当前页</param>
        /// <param name="intRsCount">总记录数</param>
        /// <param name="intPageCount">总页数</param>
        /// <param name="intPageType">分页类型，1文字，2数字，3数字文字混合</param>
        /// <param name="strURL">链接地址</param>
        /// <param name="PageNameFirst">分页名称：第一条</param>
        /// <param name="PageNamePrev">分页名称：前一条</param>
        /// <param name="PageNameNext">分页名称：下一条</param>
        /// <param name="PageNameLast">分页名称：最后一条</param>
        /// <param name="PageDropDownList">是否显示下拉选取分页框</param>
        /// <param name="PageNumTextBox">是否显示数字跳转分页框</param>
        /// <returns>分页条html</returns>
        public static string GetPageBarW(int intPage, int intRsCount, int intPageCount, int intPageType, string strURL,
            string PageNameFirst, string PageNamePrev, string PageNameNext, string PageNameLast, bool PageDropDownList, bool PageNumTextBox)
        {
            string strResult = "", strTemp = "";

            //判断分页类型
            if (intPageType == 2)//数字类型
            {
                for (int i = 1; i <= intPageCount; i++)
                {
                    if (i == intPage)
                    {
                        strResult += "<b>" + i + "</b>&nbsp;";
                    }
                    else
                    {
                        if (i == 1)
                        {
                            strTemp = strURL;
                        }
                        else
                        {
                            strTemp = strURL + "page/" + i.ToString() + ".html";
                        }
                        strResult += "<a href=\"" + strTemp + "\">[" + i + "]</a>&nbsp;";
                    }
                }
            }
            else if (intPageType == 3)
            {
                strTemp = strURL;
                strResult += "<a href=\"" + strTemp + "\">" + PageNameFirst + "</a>&nbsp;&nbsp;";

                if (intPage < 2)
                    strTemp = strURL;
                else
                {
                    if (intPage - 1 == 1)
                    {
                        strTemp = strURL;
                    }
                    else
                    {
                        strTemp = strURL.Replace("{page}", (intPage - 1).ToString());
                    }
                }
                strResult += "<a href=\"" + strTemp + "\">" + PageNamePrev + "</a>&nbsp;&nbsp;";

                if (intPageCount <= 5)
                {
                    //数字
                    for (int i = 1; i <= intPageCount; i++)
                    {
                        if (i == intPage)
                        {
                            strResult += "<b>" + i + "</b>&nbsp;";
                        }
                        else
                        {
                            if (i == 1)
                            {
                                strTemp = strURL;
                            }
                            else
                            {
                                strTemp = strURL + "page/" + i.ToString() + ".html";
                            }
                            strResult += "<a href=\"" + strTemp + "\">[" + i + "]</a>&nbsp;";
                        }
                    }
                }
                else
                {
                    int startid = 0;
                    int endid = 0;
                    startid = intPage - 2;
                    endid = intPage + 2;
                    if (startid <= 1)
                    {
                        endid = endid + 1 - startid;
                        startid = 1;
                    }
                    if (endid > intPageCount)
                    {
                        startid = startid - endid + intPageCount;
                        endid = intPageCount;
                    }

                    if (startid > 1)
                    {
                        strResult += "<span>...</span>";
                    }
                    for (int i = startid; i <= endid; i++)
                    {
                        if (i == intPage)
                            strResult += "<b>" + i + "</b>&nbsp;";
                        else
                        {
                            if (i == 1)
                            {
                                strTemp = strURL;
                            }
                            else
                            {
                                strTemp = strURL + "page/" + i.ToString() + ".html";
                            }
                            strResult += "<a href=\"" + strTemp + "\">[" + i + "]</a>&nbsp;";
                        }
                    }
                    if (endid < intPageCount)
                    {
                        strResult += "<b>...</b>&nbsp;";
                        strTemp = strURL + "page/" + intPageCount.ToString() + ".html";
                        strResult += "<a href=\"" + strTemp + "\">[" + intPageCount + "]</a>&nbsp;";
                    }
                }

                if (intPage < intPageCount)
                {
                    strTemp = strURL + "page/" + (intPage + 1).ToString() + ".html";
                }
                else
                {
                    if (intPageCount == 1)
                    {
                        strTemp = strURL;
                    }
                    else
                    {
                        strTemp = strURL + "page/" + intPageCount.ToString() + ".html";
                    }
                    
                }
                strResult += "<a href=\"" + strTemp + "\">" + PageNameNext + "</a>&nbsp;&nbsp;";
                if (intPageCount == 1)
                {
                    strTemp = strURL;
                }
                else
                {
                    strTemp = strURL + "page/" + intPageCount.ToString() + ".html";
                }
                strResult += "<a href=\"" + strTemp + "\">" + PageNameLast + "</a>&nbsp;&nbsp;";
            }
            else//文字类型
            {
                strTemp = strURL.Replace("{page}", "1");
                strResult += "<a href=\"" + strTemp + "\">" + PageNameFirst + "</a>&nbsp;&nbsp;";

                if (intPage < 2)
                    strTemp = strURL.Replace("{page}", "1");
                else
                    strTemp = strURL.Replace("{page}", (intPage - 1).ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNamePrev + "</a>&nbsp;&nbsp;";

                if (intPage < intPageCount)
                    strTemp = strURL.Replace("{page}", (intPage + 1).ToString());
                else
                    strTemp = strURL.Replace("{page}", intPageCount.ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNameNext + "</a>&nbsp;&nbsp;";

                strTemp = strURL.Replace("{page}", intPageCount.ToString());
                strResult += "<a href=\"" + strTemp + "\">" + PageNameLast + "</a>&nbsp;&nbsp;";
            }

            //判断是否显示下拉菜单跳转框
            if (PageDropDownList)
            {
                strResult += "<select onchange=\"window.location.href=options[selectedIndex].value\">";
                for (int i = 1; i <= intPageCount; i++)
                {
                    strTemp = strURL + "page/" + i.ToString() + ".html";
                    strResult += "<option value=\"" + strTemp + "\"";
                    if (intPage == i)
                        strResult += " selected";
                    strResult += ">" + i + "</option>";

                }
                strResult += "</select>&nbsp;&nbsp;";
            }

            //判断是否显示输入框跳转
            if (PageNumTextBox)
            {
                strResult += "<input onFocus=\"tempCurrpage=this.value;\" onblur=\"gotoPage('" + strURL.Replace("'", "") + "',this.value," + intPageCount + ")\" value=\"" + intPage
                    + "\" style=\"width:40px;text-align:center;\" onKeyUp=\"value=value.replace(/[^\\d]/g,'')\" />";
            }

            return strResult;
        }
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>        
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

#region 静态函数区域

        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns>字符长度</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(object expression, int defValue)
        {
            return expression == null ? defValue : Convert.ToInt32(expression);
        }

        /// <summary>
        /// 将对象转换为Double类型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的Dobule类型结果</returns>
        public static double StrToDouble(object expression, double defValue)
        {
            return expression == null ? defValue : Convert.ToDouble(expression);
        }

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 转换颜色
        /// </summary>
        /// <param name="strWebColor">网页颜色，格式#FF0000</param>
        /// <returns>系统颜色</returns>
        public static Color ConvertColor(string strWebColor)
        {
            ColorConverter wcc = new WebColorConverter();
            return (Color)wcc.ConvertFromString(strWebColor);
        }

        /// <summary>
        /// 检查用户是否登录
        /// </summary>
        public static void CheckUserLogin()
        {
            CheckUserLogin("2");
        }

        /// <summary>
        /// 检查用户是否登录
        /// </summary>
        /// <param name="strUserType">用户类型</param>
        public static void CheckUserLogin(string strUserType)
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserID"] == null || HttpContext.Current.Session["UserType"].ToString() == "")
            {
                //判断用户类型
                if (strUserType == "2")
                {
                    FunctionClass.ShowMsgBox("您没有登录或者登录超时！", "index.aspx", true);
                }
                else
                    FunctionClass.ShowMsgBox("您没有登录或者登录超时！", "index.aspx", true);
                HttpContext.Current.Response.End();
            }
            //else
            //{
            //    //判断用户权限
            //    if (strUserType != HttpContext.Current.Session["UserType"].ToString())
            //    {
            //        //判断用户类型
            //        if (HttpContext.Current.Session["UserType"].ToString() == "2")
            //        {
            //            FunctionClass.ShowMsgBox("您没有权限进入这个页面！", "dealer_login.aspx", true);
            //        }
            //        else
            //            FunctionClass.ShowMsgBox("您没有权限进入这个页面！", "user_login.aspx", true);
            //        HttpContext.Current.Response.End();
            //    }
            //}
        }

        /// <summary>
        /// 检查用户是否登录
        /// </summary>
        public static void CheckAdminLogin()
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["Admin_UserName"] == null || HttpContext.Current.Session["Admin_PassWord"].ToString() == "")
            {
                FunctionClass.ShowMsgBox("您没有登录或者登录超时！", "index.aspx", true);
                HttpContext.Current.Response.End();
            }
        }

        
        /// <summary>
        /// 检查用户是否登录
        /// </summary>
        /// <param name="intNeedUserRole">需用的权限，正整数</param>
        public static void CheckAdminLogin(int intNeedUserRole)
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["Admin_UserRole"] == null || HttpContext.Current.Session["Admin_UserRole"].ToString() == "")
            {
                FunctionClass.ShowMsgBox("您没有登录或者登录超时！", "index.aspx", true);
                HttpContext.Current.Response.End();
            }
            else
            {
                if (intNeedUserRole > (int)HttpContext.Current.Session["Admin_UserRole"])
                {
                    FunctionClass.ShowMsgBox("您没有权限进去该页面！");
                    HttpContext.Current.Response.End();
                }
                else
                {
                    string strUrl=HttpContext.Current.Request.FilePath;
                    strUrl = System.IO.Path.GetFileName(strUrl).ToLower();

                    if (strUrl.IndexOf("password") > -1)
                    { }
                    else
                    {
                        strUrl = strUrl.Replace("new_add", "news");
                        strUrl = strUrl.Replace("new_mod", "news");
                        strUrl = strUrl.Replace("pro_add", "products");
                        strUrl = strUrl.Replace("pro_mod", "products");
                        strUrl = strUrl.Replace("_add", "");
                        strUrl = strUrl.Replace("_mod", "");
                        strUrl = strUrl.Replace("_jj", "");
                    }

                    if (HttpContext.Current.Session["Admin_UserMenuUrl"].ToString().ToLower().IndexOf(strUrl) > -1)
                    { }
                    else
                    {
                        FunctionClass.ShowMsgBox("您没有权限进去该页面！");
                        HttpContext.Current.Response.End();
                    }
                }
            }
        }

        /// <summary>
        /// 判读奇偶数
        /// </summary>
        /// <param name="intNum">数字</param>
        /// <returns>true是技术，flash是偶数</returns>
        public static bool IsOddNumber(int intNum)
        {
            bool Result=false;
            if (intNum % 2 == 1)
                Result = true;

            return Result;
        }

        /// <summary>
        /// 获取当前页码
        /// </summary>
        /// <returns>返回页码</returns>
        public static int CurrentPage()
        {
            int intPage = 1;
            string strPage = HttpContext.Current.Request.QueryString["page"];

            if (CheckStr(strPage, 1))
            {
                intPage = Convert.ToInt32(strPage);

                if (intPage <= 1)
                    intPage = 1;
            }
            else
            {
                intPage = 1;
            }

            return intPage;
        }

        /// <summary>
        /// 截取字符串左侧几个字符
        /// </summary>
        /// <param name="strSource">原有字符串</param>
        /// <param name="intLen">截取长度</param>
        /// <returns>截取的字符串</returns>
        public static string LeftString(string strSource, int intLen)
        {
            string strResult = strSource;

            if (strSource.Length > intLen)
                strResult = strSource.Substring(0, intLen);

            return strResult;
        }
        
        /// <summary>
        /// 截取字符串左侧几个字符
        /// </summary>
        /// <param name="strSource">原有字符串</param>
        /// <param name="intLen">截取长度</param>
        /// <param name="strDocString">省略字符</param>
        /// <returns>截取的字符串</returns>
        public static string LeftString(string strSource, int intLen, string strDocString)
        {
            string strResult = strSource;

            if (strSource.Length > intLen)
                strResult = strSource.Substring(0, intLen) + strDocString;

            return strResult;
        }

        /// <summary>
        /// 截取字符串右侧几个字符
        /// </summary>
        /// <param name="strSource">原有字符串</param>
        /// <param name="intLen">截取长度</param>
        /// <returns>截取的字符串</returns>
        public static string RightString(string strSource, int intLen)
        {
            string strResult = strSource;

            if (strSource.Length > intLen)
                strResult = strSource.Substring(strSource.Length - intLen, intLen);

            return strResult;
        }

        /// <summary>
        /// 截取字符串中间几个字符
        /// </summary>
        /// <param name="strSource">原有字符串</param>
        /// <param name="intStart">开始字符</param>
        /// <param name="intEnd">结束字符</param>
        /// <returns>截取的字符串</returns>
        public static string MiddleString(string strSource, int intStart,int intEnd)
        {
            string strResult = strSource;

            if (intStart > 0 && intEnd < strSource.Length && intEnd > intStart)
                strResult = strSource.Substring(intStart, intEnd - intStart);

            return strResult;
        }

        /// <summary>
        /// 在字符串中截取中间字符串
        /// </summary>
        /// <param name="strStart">开始标识</param>
        /// <param name="strEnd">结束标识</param>
        /// <param name="strSource">原始字符串</param>
        /// <returns>截取的字符串</returns>
        public static string GetStrInStrMiddle(string strStart, string strEnd, ref string strSource)
        {
            string strLeft, strMiddle, strRight;

            int intStart, intEnd;
            intStart = strSource.IndexOf(strStart);
            intEnd = strSource.IndexOf(strEnd);

            strLeft = LeftString(strSource, intStart);
            strMiddle = MiddleString(strSource, intStart + strStart.Length, intEnd);
            strRight = RightString(strSource, strSource.Length - strEnd.Length - intEnd);

            strSource = strLeft + strStart + strEnd + strRight;

            return strMiddle;
        }

        /// <summary>
        /// 返回多个截取字符串
        /// </summary>
        /// <param name="strStart">开始标识</param>
        /// <param name="strEnd">结束标识</param>
        /// <param name="strSource">原始字符串</param>
        /// <returns>截取的字符串</returns>
        public static ArrayList GetArrayInStrMiddle(string strStart, string strEnd, ref string strSource)
        {
            ArrayList arlResult = new ArrayList();

            //循环10次
            for (int i = 0; i < 10; i++)
            {
                //判断是否有参数
                if (strSource.IndexOf(strStart) > -1)
                {
                    arlResult.Add(GetStrInStrMiddle(strStart, strEnd, ref strSource));
                }
                else
                    break;
            }

            return arlResult;
        }

        /// <summary>
        /// 创建下拉菜单控件
        /// </summary>
        /// <param name="ControlName">控件名称</param>
        /// <param name="Width">控件长度</param>
        /// <param name="strAttributes">附加属性</param>
        /// <param name="strTipText">控件的文字描述</param>
        /// <param name="myLists">控件列表对象</param>
        /// <returns>返回控件HTML</returns>
        public static string CreateControlDropDownList(string ControlName, int Width, string strAttributes, string strTipText, ListItemCollection myLists)
        {
            string strResult = "";

            strResult += "<select id=\"" + ControlName + "\" name=\"" + ControlName + "\" class=\"textinput\"";
            //判断长度
            if (Width > 0)
                strResult += " style=\"width:" + Width + "px;\"";
            //判断是否有附加属性
            if (strAttributes != "")
                strResult += strAttributes;
            strResult += ">";

            for (int i = 0; i < myLists.Count; i++)
            {
                strResult += "<option value=\"" + myLists[i].Value + "\"";
                if (myLists[i].Selected)
                    strResult += " selected";
                strResult += ">" + myLists[i].Text + "</option>";
            }

            strResult += "</select>";

            //判断是否有文字描述
            if (strTipText == null || strTipText == "")
            { }
            else
                strResult += "&nbsp;" + strTipText;

            return strResult;
        }

        /// <summary>
        /// 创建输入框控件TextBox
        /// </summary>
        /// <param name="ControlName">控件名称</param>
        /// <param name="Width">长度</param>
        /// <param name="strValue">属性值</param>
        /// <param name="strAttributes">附加属性</param>
        /// <param name="strClass">css样式</param>
        /// <param name="InputType">输入框类型，text或者password</param>
        /// <param name="strTipText">描述文字</param>
        /// <returns>返回控件HTML</returns>
        public static string CreateControlTextBox(string ControlName, int Width, string strValue, string strAttributes, string strClass, string InputType, string strTipText)
        {
            string strResult = "";

            strResult += "<input type=\"" + InputType + "\" id=\"" + ControlName + "\" name=\"" + ControlName + "\" class=\"" + strClass + "\" value=\"" + strValue + "\"";
            //判断长度
            if (Width > 0)
                strResult += " style=\"width:" + Width + "px;\"";
            //判断是否有附加属性
            if (strAttributes != "")
                strResult += strAttributes;
            strResult += "/>";

            //判断是否有文字描述
            if (strTipText == null || strTipText == "")
            { }
            else
                strResult += "&nbsp;" + strTipText;

            return strResult;
        }

        /// <summary>
        /// 创建输入框控件TextBox
        /// </summary>
        /// <param name="ControlName">控件名称</param>
        /// <param name="Width">长度</param>
        /// <param name="strValue">属性值</param>
        /// <param name="strAttributes">附加属性</param>
        /// <param name="strClass">css样式</param>
        /// <param name="InputType">输入框类型，text或者password</param>
        /// <returns>返回控件HTML</returns>
        public static string CreateControlTextBox(string ControlName, int Width, string strValue, string strAttributes, string strClass, string InputType)
        {
            string strResult = "";

            strResult = CreateControlTextBox(ControlName, Width, strValue, strAttributes, strClass, InputType, "");

            return strResult;
        }

        /// <summary>
        /// 创建输入框控件TextBox
        /// </summary>
        /// <param name="ControlName">控件名称</param>
        /// <param name="Width">长度</param>
        /// <param name="strValue">属性值</param>
        /// <param name="strAttributes">附加属性</param>
        /// <param name="InputType">输入框类型，text或者password</param>
        /// <returns>返回控件HTML</returns>
        public static string CreateControlTextBox(string ControlName, int Width, string strValue, string strAttributes, string InputType)
        {
            string strResult = "";

            strResult = CreateControlTextBox(ControlName, Width, strValue, strAttributes, "textinput", InputType);

            return strResult;
        }

        /// <summary>
        /// 创建输入框控件TextBox
        /// </summary>
        /// <param name="ControlName">控件名称</param>
        /// <param name="Width">长度</param>
        /// <param name="strValue">属性值</param>
        /// <param name="InputType">输入框类型，text或者password</param>
        /// <returns>返回控件HTML</returns>
        public static string CreateControlTextBox(string ControlName, int Width, string strValue, string InputType)
        {
            string strResult = "";

            strResult = CreateControlTextBox(ControlName, Width, strValue,"", "textinput", InputType);

            return strResult;
        }

        /// <summary>
        /// 创建输入框控件TextBox
        /// </summary>
        /// <param name="ControlName">控件名称</param>
        /// <param name="Width">长度</param>
        /// <param name="InputType">输入框类型，text或者password</param>
        /// <returns>返回控件HTML</returns>
        public static string CreateControlTextBox(string ControlName, int Width, string InputType)
        {
            string strResult = "";

            strResult = CreateControlTextBox(ControlName, Width, "", "", "textinput", InputType);

            return strResult;
        }

        /// <summary>
        /// 创建输入控件TextArea
        /// </summary>
        /// <param name="ControlName">控件名称</param>
        /// <param name="Width">长度</param>
        /// <param name="Height">高度</param>
        /// <param name="strValue">属性值</param>
        /// <param name="strAttributes">附加属性</param>
        /// <returns>返回控件HTML</returns>
        public static string CreateControlTextArea(string ControlName, int Width,int Height, string strValue, string strAttributes)
        {
            string strResult = "";

            strResult += "<textarea id=\"" + ControlName + "\" name=\"" + ControlName + "\" class=\"textinput\"";
            //判断长度
            if (Width > 0)
            {
                strResult += " style=\"width:" + Width + "px;";
                //判断高度
                if (Height > 0)
                    strResult += "height:" + Height + "px;";
                strResult += "\"";
            }
            else
            {
                //判断高度
                if (Height > 0)
                    strResult += " style=\"height:" + Height + "px;\"";
            }
            //判断是否有附加属性
            if (strAttributes != "")
                strResult += strAttributes;
            strResult += "/>" + strValue + "</textarea>";

            return strResult;
        }

        /// <summary>
        /// 创建输入框控件File
        /// </summary>
        /// <param name="ControlName">控件名称</param>
        /// <param name="Width">长度</param>
        /// <returns>返回控件HTML</returns>
        public static string CreateControlUploadFile(string ControlName, int Width)
        {
            string strResult = "";

            strResult = CreateControlTextBox(ControlName, Width, "", "", "textinput", "file");

            return strResult;
        }

        /// <summary>
        /// 检查日期是否有效
        /// </summary>
        /// <param name="strDateTime">时间字符串</param>
        /// <returns>是否</returns>
        public static bool CheckDateTime(string strDateTime)
        {
            if (strDateTime == null || strDateTime == "")
                return false;
            else
            {
                DateTime myDT = new DateTime();
                return DateTime.TryParse(strDateTime, out myDT);
            }
        }

        /// <summary>
        /// 获取文件夹大小
        /// </summary>
        /// <param name="dirPath">路径</param>
        /// <returns>大小</returns>
        public static long GetDirectoryLength(string dirPath)
        {
            //判断给定的路径是否存在,如果不存在则退出
            if (!Directory.Exists(dirPath))
                return 0;
            long len = 0;

            //定义一个DirectoryInfo对象
            DirectoryInfo di = new DirectoryInfo(dirPath);

            //通过GetFiles方法,获取di目录中的所有文件的大小
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }

            //获取di中所有的文件夹,并存到一个新的对象数组中,以进行递归
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }

        /// <summary>
        /// 格式化文件大小
        /// </summary>
        /// <param name="lngSize">文件大小</param>
        /// <param name="intType">类型</param>
        /// <returns>字符串</returns>
        public static string FormatFileSize(long lngSize,int intType)
        {
            string strResult = "";

            switch (intType)
            {
                case 1:
                    strResult = Math.Round((double)lngSize / 1024, 3) + "KB";
                    break;
                case 2:
                    strResult = Math.Round((double)(lngSize / 1024) / 1024, 3) + "MB";
                    break;
                case 3:
                    strResult = Math.Round((double)((lngSize / 1024) / 1024) / 1024, 3) + "GB";
                    break;
                default:
                    strResult = Math.Round((double)lngSize / 1024, 3) + "KB";
                    break;
            }

            return strResult;
        }

        /// <summary>
        /// 获取上传图片或文件的相对路径（前台）
        /// </summary>
        /// <param name="strURL">原有路径</param>
        /// <returns>去掉../后的路径</returns>
        public static string GetUploadFileRelativeURL(string strURL)
        {
            string sss = strURL.Replace("../upload/", "upload/").Replace("../", "");
            return sss.Replace("upload/", "/upload/");
        }

        /// <summary>
        /// 递归调用获取整个站点的所有url地址（带过滤的）
        /// </summary>
        /// <param name="strDomain">站点域名</param>
        /// <param name="strUrl">路径，文件名</param>
        /// <param name="arlUrl">存储数组</param>
        /// <param name="intRunTimes">递归层次</param>
        public static void GetSiteURL(string strDomain,string strUrl,ArrayList arlUrl,int intRunTimes)
        {
            ArrayList arlNewUrl = new ArrayList();
            try
            {
                HttpWebRequest MyPageRequest = (HttpWebRequest)WebRequest.Create(new Uri(strDomain+strUrl));
                WebResponse MyPageResponse = MyPageRequest.GetResponse();
                StreamReader MyReader = new StreamReader(MyPageResponse.GetResponseStream());
                string MyPage = MyReader.ReadToEnd();//获取到网页的字符串
                MyReader.Close();
                String MyHrefPattern = @"<a[^>]+href=\s*(?:'(?<href>[^']+)'|""(?<href>[^""]+)""|(?<href>[^>\s]+))\s*[^>]*>(?<text>.*?)</a>"; //提取超链接的正则表达式
                Regex MyHrefRegex = new Regex(MyHrefPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                Match MyHrefMatch = MyHrefRegex.Match(MyPage);
                while (MyHrefMatch.Success)
                {
                    string MyLink = MyHrefMatch.Groups[1].Value;
                    if (MyLink.Substring(0, 1) != "#")//忽略书签，查找超级链接
                    {
                        //bool MyAbsolute = false;
                        //if (MyLink.Length > 8)
                        //{
                        //    string MyScheme = Uri.UriSchemeHttp + "://";
                        //    if (MyLink.Substring(0, MyScheme.Length) == MyScheme) MyAbsolute = true;
                        //    MyScheme = Uri.UriSchemeHttps + "://";
                        //    if (MyLink.Substring(0, MyScheme.Length) == MyScheme) MyAbsolute = true;
                        //    MyScheme = Uri.UriSchemeFile + "://";
                        //    if (MyLink.Substring(0, MyScheme.Length) == MyScheme) MyAbsolute = true;
                        //}
                        //if (!MyAbsolute) arlUrl.Add(MyLink);
                        if (MyLink.ToLower().IndexOf(".asp") > -1)
                        {
                            //判断在老的url中是否存在
                            if (arlUrl.IndexOf(MyLink) == -1)
                            {
                                //判断在新的url中是否存在
                                if (arlNewUrl.IndexOf(MyLink) == -1)
                                    arlNewUrl.Add(MyLink);
                            }
                        }
                    }
                    MyHrefMatch = MyHrefMatch.NextMatch();//继续查找超级链接
                }
            }
            catch { }

            //判断如果有新url，那么融入
            if (arlNewUrl.Count > 0)
                arlUrl.AddRange(arlNewUrl);

            //5次循环内递归调用
            if (intRunTimes < 50)
            {
                //递归调用
                for (int i = 0; i < arlNewUrl.Count; i++)
                {
                    GetSiteURL(strDomain, arlNewUrl[i].ToString(), arlUrl, intRunTimes + 1);
                }
            }
        }

        ///<summary>
        ///验证输入的数据是不是正整数
        ///</summary>
        ///<param name="str">传入字符串</param>
        ///<returns>返回true或者false</returns>
        public static bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str);
        }

        /// <summary>
        /// 去除字符串中的HTML代码
        /// </summary>
        /// <param name="Htmlstring">带有HTML的原始字符串</param>
        /// <returns>去除后的HTML</returns>
        public static string NoHTML(string Htmlstring) //去除HTML标记
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        /// <summary>
        /// 四舍五入小数
        /// </summary>
        /// <param name="Value">小数值</param>
        /// <param name="Digits">保留位数</param>
        /// <returns>四舍五入后的小数</returns>
        public static double MathRound(double Value, int Digits)
        {
            double d = Convert.ToDouble(Value);
            if (Digits > 0)
                d = d / Math.Pow(10, Digits);
            string fractionString = "";   //小数部分字符串
            //取得小数点的位置，将字符串分为整数部分和小数部分，没有小数部分就为空。
            int dotPosition = d.ToString().IndexOf(".");
            if (dotPosition != -1)
                fractionString = d.ToString().Substring(dotPosition + 1);
            if (fractionString.Length <= -Digits + 1)
                d += Math.Pow(10, Digits - 2);
            if (Digits <= 0)
                return Math.Round(d, -Digits);
            else
                return Math.Round(d, 0) * Math.Pow(10, Digits);
        }

        /// <summary>
        /// 删除所有cookies
        /// </summary>
        public static void DelAllCookies()
        {
            int limit = HttpContext.Current.Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                HttpCookie aCookie = HttpContext.Current.Request.Cookies[i];
                aCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(aCookie);
            }
        }

        /// <summary>
        /// 检查Cookie有效性
        /// </summary>
        /// <param name="strCookieName">Cookie的名称</param>
        /// <returns>是否有效</returns>
        public static bool CheckCookie(string strCookieName)
        {
            bool isResult = false;

            if (HttpContext.Current.Request.Cookies != null)
            {
                if (HttpContext.Current.Request.Cookies[strCookieName] != null)
                {
                    if (HttpContext.Current.Request.Cookies[strCookieName].Value != null)
                    {
                        if (HttpContext.Current.Request.Cookies[strCookieName].Value.Trim() != "")
                            isResult = true;
                    }
                }
            }

            return isResult;
        }

        /// <summary>
        /// IP地址转INT
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns>INT形式的IP</returns>
        public static long IpToInt(string ip)
        {
            char[] dot = new char[] { '.' };
            string[] ipArr = ip.Split(dot);
            if (ipArr.Length == 3)
                ip = ip + ".0";
            ipArr = ip.Split(dot);

            long ip_Int = 0;
            long p1 = long.Parse(ipArr[0]) * 256 * 256 * 256;
            long p2 = long.Parse(ipArr[1]) * 256 * 256;
            long p3 = long.Parse(ipArr[2]) * 256;
            long p4 = long.Parse(ipArr[3]);
            ip_Int = p1 + p2 + p3 + p4;
            return ip_Int;
        }

        /// <summary>
        /// INT转IP地址
        /// </summary>
        /// <param name="ip_Int">int形式</param>
        /// <returns>IP地址</returns>
        public static string IntToIP(long ip_Int)
        {
            long seg1 = (ip_Int & 0xff000000) >> 24;
            if (seg1 < 0)
                seg1 += 0x100;
            long seg2 = (ip_Int & 0x00ff0000) >> 16;
            if (seg2 < 0)
                seg2 += 0x100;
            long seg3 = (ip_Int & 0x0000ff00) >> 8;
            if (seg3 < 0)
                seg3 += 0x100;
            long seg4 = (ip_Int & 0x000000ff);
            if (seg4 < 0)
                seg4 += 0x100;
            string ip = seg1.ToString() + "." + seg2.ToString() + "." + seg3.ToString() + "." + seg4.ToString();
            return ip;
        }

        /// <summary>
        /// 获取姓名中的姓
        /// </summary>
        /// <param name="strUserName">用户名称</param>
        /// <returns>姓</returns>
        public static string GetFirstName(string strUserName)
        {
            string strResult = "";

            if (strUserName.Length > 0)
            {
                strResult = FunctionClass.LeftString(strUserName, 1);
            }

            return strResult;
        }

        /// <summary>
        /// 获取屏蔽手机号码
        /// </summary>
        /// <param name="strMobile">手机号码</param>
        /// <returns>屏蔽的手机号码</returns>
        public static string GetMaskMobileNum(string strMobile)
        {
            string strResult = "";

            for (int i = 0; i < strMobile.Length; i++)
            {
                if (i > 2 && i < 8)
                    strResult += "*";
                else
                    strResult += strMobile[i];
            }

            return strResult;
        }

        /// <summary>
        /// 获取活动事件年份
        /// </summary>
        /// <param name="strDate">结束时间</param>
        /// <returns>年份</returns>
        public static string GetEventsYear(string strDate)
        {
            DateTime myDt = Convert.ToDateTime(strDate).AddDays(-1);

            return myDt.ToString("yyyy");
        }

        /// <summary>
        /// 获取活动事件月份
        /// </summary>
        /// <param name="strDate">结束时间</param>
        /// <returns>月份</returns>
        public static string GetEventsMonth(string strDate)
        {
            DateTime myDt = Convert.ToDateTime(strDate).AddDays(-1);

            return myDt.ToString("MM");
        }

        /// <summary>
        /// 获取活动事件日
        /// </summary>
        /// <param name="strDate">结束时间</param>
        /// <returns>日期</returns>
        public static string GetEventsDay(string strDate)
        {
            DateTime myDt = Convert.ToDateTime(strDate).AddDays(-1);

            return myDt.ToString("dd");
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns>是否发送成功</returns>
        public static bool SendMail(string strSubject, string strBody, string strMailTo)
        {
            bool isResult = false;

            MailAddress mySendAdd = new MailAddress(strMailTo);

            MailMessage myMail = new MailMessage();
            myMail.From = new MailAddress("sale24_xinyi@qq.com", "新意网络");

            try
            {
                myMail.IsBodyHtml = true;
                myMail.Subject = strSubject;
                myMail.Body = strBody;
                myMail.Priority = MailPriority.High;
                //5个收件人
                myMail.To.Add(mySendAdd);
            }
            catch
            {
            }

            //发送邮件
            SmtpClient mySc = new SmtpClient("smtp.qq.com");

            try
            {
                if (myMail.To.Count > 0)
                {
                    mySc.Credentials = new NetworkCredential("sale24_xinyi@qq.com", "xyadmin");

                    mySc.Send(myMail);

                    isResult = true;
                }
                else
                {
                }
            }
            catch (System.Net.Mail.SmtpException ex)
            {
            }

            return isResult;
        }

        /// <summary>
        /// 获取小图片路径
        /// </summary>
        /// <param name="strFilePath">大图片路径</param>
        /// <param name="intType">0自店图，1商家图</param>
        /// <returns>小图片路径</returns>
        public static string GetSmallPic(string strFilePath, string strType)
        {
            string strResult = "";
            string strRealPath = "";
            string strP = "";

            if (HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("/admin/") > -1)
                strP = "../";

            if (strType == "0")
                strResult = strP + "/images/zkyl_03.jpg";
            else if (strType == "1")
                strResult = strP + "/images/zkyl_04.jpg";
            else if (strType == "2")
                strResult = strP + "/images/pp01.jpg";

            strRealPath = HttpContext.Current.Server.MapPath(strP + FunctionClass.GetUploadFileRelativeURL(strFilePath));



            if (System.IO.File.Exists(strRealPath))
                strResult = "" + FunctionClass.GetUploadFileRelativeURL(
                    strFilePath.Replace(System.IO.Path.GetFileNameWithoutExtension(strFilePath),
                    System.IO.Path.GetFileNameWithoutExtension(strFilePath) + "_small"));

            return strResult;
        }

        /// <summary>
        /// 返回模糊查询字符串
        /// </summary>
        /// <param name="strCellName">列名称</param>
        /// <param name="strKeyWords">搜索关键词</param>
        /// <returns>返回where条件的sql语句</returns>
        public static string GetFuzzyQueryStr(string strCellName,string strKeyWords)
        {
            string strResult = "";

            for (int i = 0; i < strKeyWords.Length; i++)
            {
                if (strKeyWords[i].ToString().Trim() != ""&&strKeyWords[i].ToString().Trim() != "'")
                {
                    strResult += " and " + strCellName + " like '%" + strKeyWords[i] + "%'";
                }
            }

            if (strResult.Length > 5)
                strResult = strResult.Substring(5, strResult.Length - 5);

            return strResult;
        }

        /// <summary>
        /// 检查字符串中是否有恶意代码
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        public static void CheckData(string inputData)
        {
            string StrRegex = @"^\+/v(8|9)|\b(and|or)\b.{1,6}?(=|>|<|\bin\b|\blike\b)|/\*.+?\*/|<\s*script\b|<\s*img\b|\bEXEC\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\s+(TABLE|DATABASE)";

            if (Regex.IsMatch(inputData, StrRegex))
            {
                FunctionClass.ShowMsgBox("接收数据中含有恶意代码，页面已经被服务器终止！");
                HttpContext.Current.Response.End();
            }
            else
            {
                if (inputData.ToLower().IndexOf("alert(") > -1 || inputData.ToLower().IndexOf("location.") > -1
                    || inputData.ToLower().IndexOf("onmouse") > -1)
                {
                    FunctionClass.ShowMsgBox("接收数据中含有恶意代码，页面已经被服务器终止！");
                    HttpContext.Current.Response.End();
                }
            }
        }

        /// <summary>
        /// 检查字符串中是否有恶意代码
        /// </summary>
        public static void CheckData()
        {
            if (HttpContext.Current.Request.QueryString != null)
                FunctionClass.CheckData(HttpContext.Current.Request.QueryString.ToString());
            if (HttpContext.Current.Request.Form != null)
                FunctionClass.CheckData(HttpContext.Current.Request.Form.ToString());
        }

        /// <summary>
        /// html中返回单个图片路径
        /// </summary>
        /// <param name="HTMLStr">html</param>
        /// <returns></returns>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
            RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }
        
        /// <summary>
        /// 返回多个路径的情况
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static StringBuilder MyGetImgUrl(string text)
        {
            StringBuilder str = new StringBuilder();
            string pat = @"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>";

            Regex r = new Regex(pat, RegexOptions.Compiled);

            Match m = r.Match(text.ToLower());
            //int matchCount = 0;
            while (m.Success)
            {
                Group g = m.Groups[2];
                str.Append(g).Append(",");
                m = m.NextMatch();
            }
            return str;
        }
#endregion

        /// <summary>
        /// 随机函数上次存储的字符串
        /// </summary>
        private string strTempRandom = "100000";

        /// <summary>
        /// 随即获取一个ID
        /// </summary>
        /// <returns>随机ID</returns>
        public string GetRandomID()
        {
            string strResult;
            Random rd = new Random((int)DateTime.Now.Ticks + Convert.ToInt32(strTempRandom));
            strResult = rd.Next(1000).ToString() + rd.Next(1000).ToString();

            //判断是否重复，如果重复重新获取
            while (strResult == strTempRandom)
            {
                strResult = rd.Next(1000).ToString() + rd.Next(1000).ToString();
            }

            strTempRandom = strResult;

            return strResult;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="myFU">上传控件</param>
        /// <param name="FilePath">文件路径</param>
        /// <param name="FileType">文件后缀限制</param>
        /// <param name="FileSize">文件大小限制</param>
        /// <returns>文件虚拟路径</returns>
        public string UploadFile(FileUpload myFU, string FilePath, string FileType, int FileSize)
        {
            string Result = "";
            bool isOk = false;
            string strFileName, fileExtension;
            //strFileName=DateTime.Now.ToString("yyyyMMddHHmmssfff");
            strFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + this.GetRandomID();
            fileExtension = "";

            if (myFU.HasFile)
            {
                fileExtension = System.IO.Path.GetExtension(myFU.FileName).ToLower();
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
                    if (myFU.FileBytes.Length > FileSize * 1024)
                    {
                        ShowMsgBox("上传的文件不能大于" + FileSize + "KB");
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(FilePath));
                        if (!dir.Exists)
                            dir.Create();

                        strFileName += fileExtension;

                        myFU.SaveAs(HttpContext.Current.Server.MapPath(FilePath) + strFileName);

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
                        ShowMsgBox("目前本系统支持的格式为：" + FileType);
                    else
                        ShowMsgBox("目前本系统支持的格式为：" + FileType, strURL);
                    HttpContext.Current.Response.End();
                }
            }
            else
                Result = "";

            return Result;
        }
        
        /// <summary>
        /// 获取网页源码中制定的内容
        /// </summary>
        /// <param name="strHTML">网页源码</param>
        /// <param name="strH1">开始标识</param>
        /// <param name="strH2">结束标识</param>
        /// <returns>想要的字符串</returns>
        public string GetContent(ref string strHTML, string strH1, string strH2)
        {
            string Result = "";
            string strFind = strH1;

            int intFind = strHTML.IndexOf(strFind);
            if (intFind > -1)
            {
                strHTML = strHTML.Substring(intFind + strFind.Length);

                intFind = strHTML.IndexOf(strH2);
                if (intFind > -1)
                {
                    Result = strHTML.Substring(0, intFind);
                    strHTML = strHTML.Substring(intFind);
                }
            }
            else
                Result = "";

            //Result = Result.Replace("&nbsp;", "");
            //Result = Result.Trim();

            return Result;
        }

        /// <summary>
        /// 获取网页源码中制定的内容
        /// </summary>
        /// <param name="strHTML">网页源码</param>
        /// <param name="strH1">开始标识</param>
        /// <param name="strH2">结束标识</param>
        /// <returns>想要的字符串</returns>
        public string GetContent(string strHTML, string strH1, string strH2)
        {
            string Result = "";
            string strFind = strH1;

            int intFind = strHTML.IndexOf(strFind);
            if (intFind > -1)
            {
                strHTML = strHTML.Substring(intFind + strFind.Length);

                intFind = strHTML.IndexOf(strH2);
                if (intFind > -1)
                {
                    Result = strHTML.Substring(0, intFind);
                    strHTML = strHTML.Substring(intFind);
                }
            }
            else
                Result = "";

            //Result = Result.Replace("&nbsp;", "");
            //Result = Result.Trim();

            return Result;
        }

        /// <summary>
        /// 分割字符串并获取数组对象
        /// </summary>
        /// <param name="strS">原始字符串</param>
        /// <param name="chrSplit">分割符号</param>
        /// <returns>数组对象</returns>
        public ArrayList GetArrayListForSplitString(string strS, char chrSplit)
        {
            ArrayList arlResult = new ArrayList();

            string[] arrS = strS.Split(chrSplit);
            for (int i = 0; i < arrS.Length; i++)
            {
                if (arrS[i].ToString().Trim() != "")
                    arlResult.Add(arrS[i].ToString().Trim());
            }

            return arlResult;
        }

        /// <summary>
        /// 生成选中ID的sql语句条件
        /// </summary>
        /// <param name="arlID">选中ID数组</param>
        /// <param name="strCellName">列名</param>
        /// <returns>sql语句条件部分</returns>
        public string GetIDSql(ArrayList arlID, string strCellName)
        {
            string strSql = "";
            for (int i = 0; i < arlID.Count; i++)
            {
                strSql += strCellName + "=" + arlID[i].ToString() + " or ";
            }
            if (strSql.Length > 4)
                strSql = strSql.Substring(0, strSql.Length - 4);
            return strSql;
        }

        /// <summary>
        /// 生成选中ID的sql语句条件
        /// </summary>
        /// <param name="strIDS">分类ID字符串</param>
        /// <param name="chrSplit">分割字符</param>
        /// <param name="strCellName">列名</param>
        /// <returns>sql语句条件部分</returns>
        public string GetIDSql(string strIDS, char chrSplit, string strCellName)
        {
            string strSql = "";
            string[] arrIDS = strIDS.Split(chrSplit);
            for (int i = 0; i < arrIDS.Length; i++)
            {
                if (arrIDS[i].ToString().Trim() != "")
                    strSql += strCellName + "=" + arrIDS[i] + " or ";
            }
            if (strSql.Length > 4)
                strSql = strSql.Substring(0, strSql.Length - 4);
            return strSql;
        }
    }
}
