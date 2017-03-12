using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Xinyi.Common
{
    public class CustomTags
    {
        public ArrayList Objects = null;

        /// <summary>
        /// 构造函数，获取自定义标签对象数组
        /// </summary>
        /// <param name="strHtml">html</param>
        public CustomTags(string strHtml) 
        {
            ArrayList arlTags=this.GetTags(strHtml);
            Objects = this.GetTagObjects(arlTags);
        }

        /// <summary>
        /// 检查文本中是否有自定义标签存在
        /// </summary>
        /// <param name="strHtml">html</param>
        /// <returns>是否存在</returns>
        public bool CheckTagExist(string strHtml)
        {
            bool Result = false;

            if (strHtml.ToLower().IndexOf("<xy:") > -1)
                Result = true;

            return Result;
        }

        /// <summary>
        /// 获取自定义标签部分代码
        /// </summary>
        /// <param name="strHtml">html</param>
        /// <returns>返回标签部分代码</returns>
        public string GetTag(string strHtml)
        {
            string strResult="";

            strResult = strHtml;

            if (strResult.ToLower().IndexOf("<xy:") > -1)
            {
                FunctionClass myFun = new FunctionClass();

                string strTempTag = "";//获取标签类型
                strTempTag = strResult;
                strTempTag = myFun.GetContent(ref strTempTag, "<xy:", " ");

                strResult = myFun.GetContent(ref strResult, "<xy:", "</xy:" + strTempTag + ">");
            }
            else
                strResult = "";

            return strResult;
        }

        /// <summary>
        /// 获取所有自定义标签
        /// </summary>
        /// <param name="strHtml">html</param>
        /// <returns>标签字符串数组</returns>
        public ArrayList GetTags(string strHtml)
        {
            ArrayList arlResult = new ArrayList();

            string strTemp, strTemp1;
            
            strTemp= strHtml;

            while (strTemp.ToLower().IndexOf("<xy:") > -1)
            {
                FunctionClass myFun = new FunctionClass();
                string strTempTag = "";//获取标签类型
                strTempTag = strTemp;
                strTempTag = myFun.GetContent(ref strTempTag, "<xy:", " ");

                strTemp1=this.GetTag(strTemp);
                if (strTemp1 != "")
                {
                    //加入数组
                    arlResult.Add(strTemp1);
                }

                strTemp = strTemp.Substring(strTemp.IndexOf("</xy:" + strTempTag + ">") + 6 + strTempTag.Length);
            }

            return arlResult;
        }

        /// <summary>
        /// 获取标签属性和对象
        /// </summary>
        /// <param name="strTag">标签文本</param>
        /// <returns>标签对象</returns>
        public CustomTag GetAttributes(string strTag)
        {
            string strTemp, strTemp1;
            int intTemp = 0;

            strTemp = strTag;

            FunctionClass myFun = new FunctionClass();

            CustomTag myTag = new CustomTag();

            //获取标签类型
            if (strTemp.IndexOf(" ") > -1)
            {
                myTag.TagType = strTemp.Substring(0, strTemp.IndexOf(" ")).Trim();
            }
            else
                myTag.TagType = "";

            //获取分类id
            if (strTemp.IndexOf("typeid=") > -1)
            {
                try
                {
                    intTemp = Convert.ToInt32(myFun.GetContent(strTemp, "typeid=\"", "\""));
                    myTag.TypeID = intTemp;
                }
                catch
                {
                    myTag.TypeID = 0;
                }
            }
            else
                myTag.TypeID = 0;

            //获取分类名称
            if (strTemp.IndexOf("typecalled=") > -1)
            {
                myTag.TypeCalled = myFun.GetContent(strTemp, "typecalled=\"", "\"");
            }
            else
                myTag.TypeCalled = "";

            //获取分类pid
            if (strTemp.IndexOf("typepid=") > -1)
            {
                try
                {
                    intTemp = Convert.ToInt32(myFun.GetContent(strTemp, "typepid=\"", "\""));
                    myTag.TypePID = intTemp;
                }
                catch
                {
                    myTag.TypePID = -1;
                }
            }
            else
                myTag.TypePID = -1;

            //获取是否显示子分类
            if (strTemp.IndexOf("subtype=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "subtype=\"", "\"");

                if (strTemp1 == "0")
                    myTag.SubType = false;
                else
                    myTag.SubType = true;
            }
            else
                myTag.SubType = true;

            //获取循环次数
            if (strTemp.IndexOf("cycle=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "cycle=\"", "\"");

                try
                {
                    intTemp = Convert.ToInt32(strTemp1);
                    myTag.Cycle = intTemp;
                }
                catch
                {
                    myTag.Cycle = -1;
                }
            }
            else
                myTag.Cycle = -1;

            //获取是否显示
            if (strTemp.IndexOf("isshow=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "isshow=\"", "\"");

                if (strTemp1 == "0")
                    myTag.IsShow = false;
                else
                    myTag.IsShow = true;
            }
            else
                myTag.IsShow = true;

            //获取是否推荐
            if (strTemp.IndexOf("isrecommend=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "isrecommend=\"", "\"");

                if (strTemp1 == "1")
                    myTag.IsRecommend = true;
                else
                    myTag.IsRecommend = false;
            }
            else
                myTag.IsRecommend = false;

            //获取where条件语句
            if (strTemp.IndexOf("where=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "where=\"", "\"");
                myTag.Where = strTemp1;
            }
            else
                myTag.Where = "";

            //获取排序类型
            if (strTemp.IndexOf("order=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "order=\"", "\"");

                try
                {
                    intTemp = Convert.ToInt32(strTemp1);
                    myTag.Order = intTemp;
                }
                catch
                {
                    myTag.Order = 1;
                }
            }
            else
                myTag.Order = 1;

            //获取显示空格
            if (strTemp.IndexOf("showspace=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "showspace=\"", "\"");

                if (strTemp1 == "1")
                    myTag.ShowSpace = true;
                else
                    myTag.ShowSpace = false;
            }
            else
                myTag.ShowSpace = true;

            //分页ID
            if (strTemp.IndexOf("pageid=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "pageid=\"", "\"");

                try
                {
                    intTemp = Convert.ToInt32(strTemp1);
                    myTag.PageID = intTemp;
                }
                catch
                {
                    myTag.PageID = -1;
                }
            }
            else
                myTag.PageID = -1;

            //分页标签
            if (strTemp.IndexOf("pagetype=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "pagetype=\"", "\"");

                try
                {
                    intTemp = Convert.ToInt32(strTemp1);
                    myTag.PageType = intTemp;
                }
                catch
                {
                    myTag.PageType = 1;
                }
            }
            else
                myTag.PageType = 1;

            //获取第一页名称
            if (strTemp.IndexOf("pagenamefirst=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "pagenamefirst=\"", "\"");
                myTag.PageNameFirst = strTemp1;
            }
            else
                myTag.PageNameFirst = "第一页";

            //获取上一页名称
            if (strTemp.IndexOf("pagenameprev=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "pagenameprev=\"", "\"");
                myTag.PageNamePrev = strTemp1;
            }
            else
                myTag.PageNamePrev = "上一页";

            //获取下一页名称
            if (strTemp.IndexOf("pagenamenext=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "pagenamenext=\"", "\"");
                myTag.PageNameNext = strTemp1;
            }
            else
                myTag.PageNameNext = "下一页";

            //获取最后页名称
            if (strTemp.IndexOf("pagenamelast=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "pagenamelast=\"", "\"");
                myTag.PageNameLast = strTemp1;
            }
            else
                myTag.PageNameLast = "最后页";

            //获取时候显示下列菜单跳转
            if (strTemp.IndexOf("pagedropdownlist=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "pagedropdownlist=\"", "\"");
                if (strTemp1 == "1")
                    myTag.PageDropDownList = true;
                else
                    myTag.PageDropDownList = false;
            }
            else
                myTag.PageDropDownList = false;

            //获取时候显示输入框跳转
            if (strTemp.IndexOf("pagenumtextbox=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "pagenumtextbox=\"", "\"");
                if (strTemp1 == "1")
                    myTag.PageNumTextBox = true;
                else
                    myTag.PageNumTextBox = false;
            }
            else
                myTag.PageNumTextBox = false;

            //获取日期列名，用“|”分割
            if (strTemp.IndexOf("datetime=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "datetime=\"", "\"");
                myTag.DateTimeStr = strTemp1;
            }
            else
                myTag.DateTimeStr = "";

            //获取日期列名，用“|”分割
            if (strTemp.IndexOf("datetimeformat=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "datetimeformat=\"", "\"");
                myTag.DateTimeFormat = strTemp1;
            }
            else
                myTag.DateTimeFormat = "";

            //获取要格式的字段，用“|”分割
            if (strTemp.IndexOf("stringcellnames=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "stringcellnames=\"", "\"");
                myTag.StringCellNames = strTemp1;
            }
            else
                myTag.StringCellNames = "";

            //获取要格式的字段，用“|”分割
            if (strTemp.IndexOf("stringformat=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "stringformat=\"", "\"");
                myTag.StringFormat = strTemp1;
            }
            else
                myTag.StringFormat = "";

            //换行ID
            if (strTemp.IndexOf("rowwarp=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "rowwarp=\"", "\"");

                try
                {
                    intTemp = Convert.ToInt32(strTemp1);
                    myTag.RowWarp = intTemp;
                }
                catch
                {
                    myTag.RowWarp = 0;
                }
            }
            else
                myTag.RowWarp = 0;

            //换行开始标签
            if (strTemp.IndexOf("rowwarpstart=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "rowwarpstart=\"", "\"");
                myTag.RowWarpStart = strTemp1.Replace("&lt;", "<").Replace("&gt;", ">");
            }
            else
                myTag.RowWarpStart = "";

            //获取换行结束标签
            if (strTemp.IndexOf("rowwarpend=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "rowwarpend=\"", "\"");
                myTag.RowWarpEnd = strTemp1.Replace("&lt;", "<").Replace("&gt;", ">");
            }
            else
                myTag.RowWarpEnd = "";

            //获取换行替换部分字符
            if (strTemp.IndexOf("rowwarpreplace=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "rowwarpreplace=\"", "\"");
                myTag.RowWarpReplace = strTemp1;
            }
            else
                myTag.RowWarpReplace = "";

            //是否写入原有文件名（分页）
            if (strTemp.IndexOf("writeoldfile=") > -1)
            {
                strTemp1 = myFun.GetContent(strTemp, "writeoldfile=\"", "\"");

                if (strTemp1 == "1")
                    myTag.WriteOldFile = true;
                else
                    myTag.WriteOldFile = false;
            }
            else
                myTag.WriteOldFile = true;

            //获取输出标签
            if (strTemp.IndexOf(">\r\n") > -1)
            {
                strTemp1 = strTemp.Substring(strTemp.IndexOf(">\r\n") + 1);
                myTag.OutputTag = strTemp1;
            }
            else
                myTag.OutputTag = "";

            return myTag;
        }

        /// <summary>
        /// 获取所有标签对象
        /// </summary>
        /// <param name="arlTags">文本标签</param>
        /// <returns>标签对象数组</returns>
        public ArrayList GetTagObjects(ArrayList arlTags)
        {
            ArrayList arlTagObjects = new ArrayList();

            for (int i = 0; i < arlTags.Count; i++)
            {
                CustomTag myTag = this.GetAttributes(arlTags[i].ToString()); 
                
                FunctionClass myFun = new FunctionClass();
                string strTempTag = "";//获取标签类型
                strTempTag = arlTags[i].ToString();
                strTempTag = myFun.GetContent(ref strTempTag, "", " ");

                //获取原始标签代码
                myTag.OriginalTag = "<xy:" + arlTags[i].ToString() + "</xy:" + strTempTag + ">";

                if (myTag.TagType != "")
                {
                    arlTagObjects.Add(myTag);
                }
            }

            return arlTagObjects;
        }

        /// <summary>
        /// 递归获取子分类sql语句
        /// </summary>
        /// <param name="myTable">数据表</param>
        /// <param name="strCellName">sql语句中的列名称</param>
        /// <param name="strPCellName">数据表中的列名称</param>
        /// <param name="strCellValue">上级分类ID</param>
        /// <returns>sql语句</returns>
        public string GetSubTypeIDSql(System.Data.DataTable myTable, string strCellName, string strPCellName, string strCellValue)
        {
            string strResult = "", strTemp = "", strID;

            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                strTemp = myTable.Rows[i][strPCellName].ToString();
                strID = myTable.Rows[i]["ID"].ToString();

                if (strTemp == strCellValue)
                {
                    strResult += strCellName + "=" + strID + " or ";
                    //递归调用
                    strResult += this.GetSubTypeIDSql(myTable, strCellName, strPCellName, strID);
                }
            }

            return strResult;
        }

        /// <summary>
        /// 获取sql条件很排序语句
        /// </summary>
        /// <param name="myTag">标签对象</param>
        /// <param name="myTable">分类数据表</param>
        /// <param name="strCellName">sql语句中的列名称</param>
        /// <param name="strPCellName">数据表中的列名称</param>
        /// <param name="strCalledName">分类名称字段名</param>
        public void GetOutputString(CustomTag myTag, System.Data.DataTable myTable, string strCellName, string strPCellName,string strCalledName) 
        {
            string strResult = "";

            //判断是否加分类条件
            if (myTag.TypeID > 0|| myTag.TagType.IndexOf("type")>-1)
            {
                //判断是否读取子分类
                if (myTag.SubType)
                {
                    strResult += this.GetSubTypeIDSql(myTable, strCellName, strPCellName, myTag.TypeID.ToString());
                }

                strResult += strCellName + "=" + myTag.TypeID;
            }
            else
            {
                //判断分类文字是否有
                if (myTag.TypeCalled != "")
                {
                    for (int i = 0; i < myTable.Rows.Count; i++)
                    {
                        if (myTable.Rows[i][strCalledName].ToString() == myTag.TypeCalled)
                        {
                            myTag.TypeID = Convert.ToInt32(myTable.Rows[i]["ID"].ToString());

                            //判断是否读取子分类
                            if (myTag.SubType)
                            {
                                strResult += this.GetSubTypeIDSql(myTable, strCellName, strPCellName, myTag.TypeID.ToString());
                            }

                            strResult += strCellName + "=" + myTag.TypeID;

                            break;
                        }
                    }
                }
            }

            //判断是否为空，加括号
            if (strResult != "")
                strResult = "(" + strResult + ")";

            if (myTag.IsShow)
                strResult += " and IsShow=1";

            if (myTag.IsRecommend)
                strResult += " and IsRecommend=1";

            if (myTag.TypePID > -1)
                strResult += " and PID=" + myTag.TypePID;

            if (strResult == "")
                strResult = myTag.Where;
            else
            {
                if (myTag.Where != "")
                    strResult += " and " + myTag.Where;
            }

            myTag.OutputWhere = strResult;

            //排序字段
            switch(myTag.Order)
            {
                case 1:
                    myTag.OutputOrder = "SID asc,ID desc";
                    break;
                case 2:
                    myTag.OutputOrder = "SID asc,ID asc";
                    break;
                case 3:
                    myTag.OutputOrder = "ID desc";
                    break;
                case 4:
                    myTag.OutputOrder = "ID asc";
                    break;
                default:
                    myTag.OutputOrder = "SID asc,ID desc";
                    break;
            }
        }

        /// <summary>
        /// 输出分页显示栏
        /// </summary>
        /// <param name="intPage">当前页</param>
        /// <param name="intRsCount">总记录数</param>
        /// <param name="intPageCount">总页数</param>
        /// <param name="myTag">自定义标签对象</param>
        /// <param name="strURL">url地址</param>
        /// <returns>HTML</returns>
        public string OutputPage(int intPage, int intRsCount, int intPageCount, CustomTag myTag, string strURL)
        {
            string strResult = "", strTemp = "";

            strURL = System.IO.Path.GetFileName(strURL);//过滤路径

            //判断是否分页id大于0
            if (myTag.PageID > 0)
            {
                //判断分页类型
                if (myTag.PageType == 2)//数字类型
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
                else//文字类型
                {
                    strTemp = strURL.Replace("{page}", "1");
                    strResult += "<a href=\"" + strTemp + "\">" + myTag.PageNameFirst + "</a>&nbsp;&nbsp;";

                    if (intPage < 2)
                        strTemp = strURL.Replace("{page}", "1");
                    else
                        strTemp = strURL.Replace("{page}", (intPage - 1).ToString());
                    strResult += "<a href=\"" + strTemp + "\">" + myTag.PageNamePrev + "</a>&nbsp;&nbsp;";

                    if (intPage < intPageCount)
                        strTemp = strURL.Replace("{page}", (intPage + 1).ToString());
                    else
                        strTemp = strURL.Replace("{page}", intPageCount.ToString());
                    strResult += "<a href=\"" + strTemp + "\">" + myTag.PageNameNext + "</a>&nbsp;&nbsp;";

                    strTemp = strURL.Replace("{page}", intPageCount.ToString());
                    strResult += "<a href=\"" + strTemp + "\">" + myTag.PageNameLast + "</a>&nbsp;&nbsp;";
                }

                //判断是否显示下拉菜单跳转框
                if (myTag.PageDropDownList)
                {
                    strResult += "<select onchange=\"window.location.href=options[selectedIndex].value\">";
                    for (int i = 1; i <= intPageCount; i++)
                    {
                        strTemp = strURL.Replace("{page}", i.ToString());
                        strResult += "<option value='" + strTemp + "'";
                        if (intPage == i)
                            strResult += " selected";
                        strResult += ">" + i + "</option>";

                    }
                    strResult += "</select>&nbsp;&nbsp;";
                }

                //判断是否显示输入框跳转
                if (myTag.PageNumTextBox)
                {
                    strResult += "<input onFocus=\"tempCurrpage=this.value;\" onblur=\"gotoPage('" + strURL + "',this.value," + intPageCount + ")\" value=\"" + intPage
                        + "\" style=\"width:40px;text-align:center;\" onKeyUp=\"value=value.replace(/[^\\d]/g,'')\" />";
                }
            }

            return strResult;
        }
    }
}
