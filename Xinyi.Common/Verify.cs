using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Xinyi.Common
{
    public class Verify
    {
        public Verify()
        { }

        /// <summary>
        /// 脚本头部，包含函数名称
        /// </summary>
        /// <param name="strFunctionName">函数名称</param>
        /// <returns>脚本头部js</returns>
        public static string ScriptsHead(string strFunctionName)
        {
            string strResult = "";

            strResult += "<script language='javascript'>function " + strFunctionName + "(){";

            return strResult;
        }

        /// <summary>
        /// 脚本结尾
        /// </summary>
        /// <returns>脚本结尾js</returns>
        public static string ScriptsFoot()
        {
            string strResult = "";

            strResult += "}</script>";

            return strResult;
        }

        /// <summary>
        /// 脚本检测，文本框值是否符合长度规范
        /// </summary>
        /// <param name="strControlName">控件id</param>
        /// <param name="minLen">最小长度，0表示不限制空白</param>
        /// <param name="maxLen">最大长度，英文字节</param>
        /// <param name="strMsg">提示文字</param>
        /// <returns>验证脚本js</returns>
        public static string ScriptsCheckTextBoxValueLen(string strControlName, int minLen, int maxLen,string strMsg)
        {
            string strResult = "";

            strResult += "tempObj=MM_findObj('" + strControlName + "');";
            strResult += "if(tempObj!=null){";
            strResult += "if(!CheckStringLength(" + minLen + "," + maxLen + ",tempObj.value)){SetMsgBoxDiv(\""+strMsg
                + "\");ShowDialogDiv(1);tempObj.focus();return false;}";
            strResult += "}";

            return strResult;
        }

        /// <summary>
        /// 脚本检测，文本框值是否符合正则表达式
        /// </summary>
        /// <param name="strControlName">控件id</param>
        /// <param name="strRegex">正则表达式</param>
        /// <param name="strMsg">提示文字</param>
        /// <returns>验证脚本js</returns>
        public static string ScriptsCheckTextBoxValueRegex(string strControlName, string strRegex, string strMsg)
        {
            string strResult = "";

            strResult += "tempObj=MM_findObj('" + strControlName + "');";
            strResult += "var patrn=/" + strRegex + "/;";
            strResult += "if(tempObj!=null){";
            strResult += "if(!patrn.test(tempObj.value)){SetMsgBoxDiv(\"" + strMsg
                + "\");ShowDialogDiv(1);tempObj.focus();return false;}";
            strResult += "}";

            return strResult;
        }

        /// <summary>
        /// 脚本检测，下拉菜单是否选中
        /// </summary>
        /// <param name="strControlName">控件id</param>
        /// <param name="strValue">选中值</param>
        /// <param name="strMsg">提示文字</param>
        /// <returns>验证脚本js</returns>
        public static string ScriptsCheckDropDownListSelected(string strControlName, string strValue, string strMsg)
        {
            string strResult = "";

            strResult += "tempObj=MM_findObj('" + strControlName + "');";
            strResult += "if(tempObj!=null){";
            strResult += "if(tempObj.options[tempObj.selectedIndex].value=='" + strValue + "'){SetMsgBoxDiv(\"" + strMsg
                + "\");ShowDialogDiv(1);tempObj.focus();return false;}";
            strResult += "}";

            return strResult;
        }

        /// <summary>
        /// 初始化文字列表脚本
        /// </summary>
        /// <returns>验证脚本js</returns>
        public static string ScriptsInitializeErrorMsg()
        {
            return "var strErrorMsg='<ul>';";
        }

        /// <summary>
        /// 判断错误信息，并显示
        /// </summary>
        /// <returns></returns>
        public static string ScriptsShowErrorMsg()
        {
            return "if(strErrorMsg!='<ul>'){strErrorMsg+='</ul>';SetMsgBoxDiv(strErrorMsg);ShowDialogDiv(1);return false;}";
        }

        /// <summary>
        /// 脚本检测
        /// </summary>
        /// <param name="ControlNams">控件数组</param>
        /// <param name="minLen">最小长度，0表示不限制空白，数组</param>
        /// <param name="maxLen">最大长度，英文字节，数组</param>
        /// <param name="Msgs">提示文字，数组</param>
        /// <returns>验证脚本js</returns>
        public static string ScriptsCheckTextBoxValueLen(string[] ControlNams, int[] minLen, int[] maxLen, string[] Msgs)
        {
            string strResult = "";

            string strControlName = "";

            for (int i = 0; i < ControlNams.Length; i++)
            {
                strControlName = ControlNams[i];
                strResult += "tempObj=MM_findObj('" + strControlName + "');";
                strResult += "if(tempObj!=null){";
                strResult += "if(!CheckStringLength(" + minLen[i] + "," + maxLen[i] + ",tempObj.value)){strErrorMsg+=\"<li>"+Msgs[i]+"</li>\";}";
                strResult += "}";
            }

            return strResult;
        }


        /// <summary>
        /// 脚本检测，文本框值是否符合正则表达式
        /// </summary>
        /// <param name="ControlNams">控件id数组</param>
        /// <param name="Regexs">正则表达式数组</param>
        /// <param name="Msgs">提示文字数组</param>
        /// <returns>验证脚本js</returns>
        public static string ScriptsCheckTextBoxValueRegex(string[] ControlNams, string[] Regexs, string[] Msgs)
        {
            string strResult = "";

            string strControlName = "", strRegex="";

            for (int i = 0; i < ControlNams.Length; i++)
            {
                strControlName = ControlNams[i];
                strRegex = Regexs[i];
                strResult += "tempObj=MM_findObj('" + strControlName + "');";
                strResult += "var patrn=/" + strRegex + "/;";
                strResult += "if(tempObj!=null){";
                strResult += "if(!patrn.test(tempObj.value)){strErrorMsg+=\"<li>" + Msgs[i] + "</li>\";}";
                strResult += "}";
            }

            return strResult;
        }

        /// <summary>
        /// 脚本检测
        /// </summary>
        /// <param name="ControlNams">控件数组</param>
        /// <param name="Values">选中值，数组</param>
        /// <param name="Msgs">消息数组</param>
        /// <returns>验证脚本js</returns>
        public static string ScriptsCheckDropDownListSelected(string[] ControlNams, string[] Values, string[] Msgs)
        {
            string strResult = "";

            string strControlName = "";

            for (int i = 0; i < ControlNams.Length; i++)
            {
                strControlName = ControlNams[i];
                strResult += "tempObj=MM_findObj('" + strControlName + "');";
                strResult += "if(tempObj!=null){";
                strResult += "if(tempObj.options[tempObj.selectedIndex].value=='" + Values[i] + "'){strErrorMsg+=\"<li>" + Msgs[i] + "</li>\";}";
                strResult += "}";
            }

            return strResult;
        }
    }
}
