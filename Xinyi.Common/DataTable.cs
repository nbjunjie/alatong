using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Xinyi.Common
{
    public class DataTable
    {
        private ArrayList arlDataColumn = new ArrayList();

        /// <summary>
        /// 初始化数据表
        /// </summary>
        /// <param name="myTable">输出表</param>
        /// <param name="myData">数据表</param>
        /// <param name="intRsCount">数据总数</param>
        /// <param name="intPageCount">页总数</param>
        /// <param name="intPage">当前页</param>
        /// <param name="strURL">当前URL路径</param>
        public void InitData(Table myTable, System.Data.DataTable myData,int intRsCount,int intPageCount,int intPage,string strURL)
        {
            //添加表头
            this.AddTableHead(myTable);

            //添加文字
            this.AddTableHeadText(myTable);

            //添加数据
            for (int i = 0; i < myData.Rows.Count; i++)
            {
                this.AddDataRow(myTable, myData.Rows[i]);
            }

            //添加分页信息
            this.AddTablePage(myTable,intRsCount, intPageCount, intPage, strURL);
        }

        /// <summary>
        /// 添加表格头部
        /// </summary>
        /// <param name="myTable">输出表</param>
        private void AddTableHead(Table myTable)
        {
            myTable.BackColor = FunctionClass.ConvertColor("#6298e1");
            myTable.Attributes.Add("border", "0");
            myTable.Attributes.Add("cellSpacing", "1");
            myTable.Attributes.Add("cellPadding", "3");
            myTable.Attributes.Add("width", "100%");
        }

        /// <summary>
        /// 添加表格头部文字
        /// </summary>
        /// <param name="myTable">输出表</param>
        private void AddTableHeadText(Table myTable)
        {
            TableRow myTr = new TableRow();

            for (int i = 0; i < arlDataColumn.Count; i++)
            {
                DataColumn myDt = (DataColumn)arlDataColumn[i];

                TableCell myTc = new TableCell();
                myTc.Attributes.Add("style", "BACKGROUND:#8db5e9;color:#FFFFFF;font-WEIGHT:bold;");
                if (myDt.HeaderWidth > 0)
                    myTc.Width = myDt.HeaderWidth;
                myTc.HorizontalAlign = HorizontalAlign.Center;
                myTc.Text = myDt.HeaderText;

                myTr.Cells.Add(myTc);
            }

            myTable.Rows.Add(myTr);
        }

        /// <summary>
        /// 添加数据行
        /// </summary>
        /// <param name="myTable">输出表</param>
        /// <param name="myDr">数据行</param>
        private void AddDataRow(Table myTable, System.Data.DataRow myDr)
        {
            //中间数据行
            TableRow myTr = new TableRow();
            myTr.Attributes.Add("style", "CURSOR:hand");
            myTr.Attributes.Add("onMouseOver", "this.style.backgroundColor = '#FFFFFF'");
            myTr.Attributes.Add("onmouseout", "this.style.backgroundColor = ''");
            myTr.Attributes.Add("bgColor", "#ebf2f9");

            for (int i = 0; i < arlDataColumn.Count; i++)
            {
                DataColumn myDt = (DataColumn)arlDataColumn[i];

                TableCell myTc = new TableCell();
                myTc.Attributes.Add("align", myDt.Align);
                myTc.Attributes.Add("valign", "middle");

                //循环读取数据
                string strFieldFormat = myDt.FieldFormat;
                //判断是否数组字段
                if (myDt.FieldNames == null)
                {
                    strFieldFormat = strFieldFormat.Replace("{0}", myDr[myDt.FieldName].ToString());
                }
                else
                {
                    for (int j = 0; j < myDt.FieldNames.Length; j++)
                    {
                        //判断参数中是否有格式化语句
                        ArrayList arlArg = FunctionClass.GetArrayInStrMiddle("{" + j + ":", "}", ref strFieldFormat);
                        if (arlArg.Count > 0)
                        {
                            for (int x = 0; x < arlArg.Count; x++)
                            {
                                strFieldFormat = strFieldFormat.Replace("{:" + j + "}", String.Format("{0:" + arlArg[x].ToString() + "}", myDr[myDt.FieldNames[j]].ToString()));
                            }
                        }
                        else
                            strFieldFormat = strFieldFormat.Replace("{" + j + "}", myDr[myDt.FieldNames[j]].ToString());

                        arlArg.Clear();
                        arlArg = null;
                    }
                }
                myTc.Text = strFieldFormat;
                myTr.Cells.Add(myTc);
            }

            myTable.Rows.Add(myTr);
        }

        /// <summary>
        /// 添加表格分页显示栏
        /// </summary>
        /// <param name="myTable">输出表</param>
        /// <param name="intRsCount">数据总数</param>
        /// <param name="intPageCount">页总数</param>
        /// <param name="intPage">当前页</param>
        /// <param name="strURL">当前URL路径</param>
        private void AddTablePage(Table myTable,int intRsCount,int intPageCount,int intPage,string strURL)
        {
            TableRow myTr = new TableRow();
            TableCell myTc = new TableCell();
            myTc.Text += "<div style=\"width:1004px; background-color:#f7fbff; text-align:center; padding-top:5px; height:35px;\">";
            myTc.Text += "总共" + intRsCount + "条信息，共" + intPageCount + "页，当前为第" + intPage + "页，";
            myTc.Text += "<a href=\"" + FunctionClass.GetNewURL("page", "1", strURL) + "\">首页</a>  ";
            int intPrevPage = intPage < 2 ? 1 : intPage - 1;
            myTc.Text += "<a href=\"" + FunctionClass.GetNewURL("page", intPrevPage.ToString(), strURL) + "\">上一页</a>   ";
            int intNextPage = intPage >= intPageCount ? intPageCount : intPage + 1;
            myTc.Text += "<a href=\"" + FunctionClass.GetNewURL("page", intNextPage.ToString(), strURL) + "\">下一页</a>  ";
            myTc.Text += "<a href=\"" + FunctionClass.GetNewURL("page", intPageCount.ToString(), strURL) + "\">尾页</a>   ";
            myTc.Text += "跳转至<input type=\"text\" name=\"gotoPage\" id=\"gotoPage\" style=\"width:30px;\" value=\"" + intPage + "\" />页</div>";

            myTr.Cells.Add(myTc);
            myTable.Rows.Add(myTr);
        }

        /// <summary>
        /// 获取复选框HTML控件
        /// </summary>
        /// <param name="strObjName">控件名称</param>
        /// <param name="strObjValue">控件值</param>
        /// <param name="strScript">控件脚本</param>
        /// <returns>控件HTML</returns>
        public string GetCheckBoxHtml(string strObjName, string strObjValue, string strScript)
        {
            string strResult = "";

            strResult = "<input id=\"" + strObjName + "\" name=\"" + strObjName + "\" title='" + strObjValue + "' type=\"checkbox\" value='" + strObjValue + "'";
            if (strScript != "")
                strResult += " onclick=\"" + strScript + "\"";
            strResult += " />";

            return strResult;
        }

        /// <summary>
        /// 添加复选框列
        /// </summary>
        /// <param name="FieldName">数据绑定ID</param>
        public void AddCheckBoxColumn(string FieldName)
        {
            this.AddDataColumn(this.GetCheckBoxHtml("cbAllCheck", "", "SelCheckBox();"), 12, "center", FieldName, this.GetCheckBoxHtml("cbSel", "{0}", ""));
        }

        /// <summary>
        /// 添加数据列
        /// </summary>
        /// <param name="HeaderText">头部文字</param>
        /// <param name="HeaderWidth">宽度，0表示不限制宽度</param>
        /// <param name="Align">对其方式</param>
        /// <param name="FieldNames">数据字段</param>
        /// <param name="FieldFormat">数据显示HTML格式</param>
        public void AddDataColumn(string HeaderText, int HeaderWidth, string Align, string[] FieldNames, string FieldFormat)
        {
            //创建列数据对象
            DataColumn myDC = new DataColumn();
            myDC.HeaderText = HeaderText;
            myDC.HeaderWidth = HeaderWidth;
            myDC.Align = Align;
            myDC.FieldNames = FieldNames;
            myDC.FieldFormat = FieldFormat;

            arlDataColumn.Add(myDC);
        }

        /// <summary>
        /// 添加数据列
        /// </summary>
        /// <param name="HeaderText">头部文字</param>
        /// <param name="HeaderWidth">宽度，0表示不限制宽度</param>
        /// <param name="Align">对其方式</param>
        /// <param name="FieldName">数据字段</param>
        /// <param name="FieldFormat">数据显示HTML格式</param>
        public void AddDataColumn(string HeaderText, int HeaderWidth, string Align, string FieldName, string FieldFormat)
        {
            //创建列数据对象
            DataColumn myDC = new DataColumn();
            myDC.HeaderText = HeaderText;
            myDC.HeaderWidth = HeaderWidth;
            myDC.Align = Align;
            myDC.FieldName = FieldName;
            myDC.FieldFormat = FieldFormat;

            arlDataColumn.Add(myDC);
        }

        /// <summary>
        /// 注销资源
        /// </summary>
        public void Dispose()
        {
            arlDataColumn.Clear();
            arlDataColumn = null;
        }
    }
}
