using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Xinyi.Common;
using Xinyi.Data;

namespace web1.admin
{
    public partial class news : System.Web.UI.Page
    {
        public string strNewTp = "0";//分类

        protected void Page_Load(object sender, EventArgs e)
        {
            FunctionClass.CheckAdminLogin(0);
            DelData();
            BindData();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void DelData()
        {
            string strDel;

            strDel = Request.QueryString["del"];

            if (FunctionClass.CheckStr(strDel, 1))
            {
                DataClass myData = new DataClass();
                SqlConnection myConn = myData.ConnOpen();
                myData.ExecuteSql("delete from T_News where ID="+strDel, myConn);
                myData.ConnClose(myConn);

                FunctionClass.ShowMsgBox("删除成功！", "");
                Response.End();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            string strPage, strNewType, strKeyWord, strSql, strTypeSql, strIsRecommend;
            int intPage, intPageSize, intRsCount;
            double dbPageCount=1;

            strPage = Request.QueryString["page"];
            strKeyWord=Request.QueryString["KeyWord"];
            strNewType = Request.QueryString["NewType"];
            strIsRecommend = Request.QueryString["IsRecommend"];
            //判断页参数是否存在
            if (!FunctionClass.CheckStr(strPage, 1))
                strPage = "1";

            //赋值页和页数
            intPage = Convert.ToInt32(strPage);
            intPageSize = 10;

            //初始化sql语句
            strSql = "select * from V_News where 1=1";
            
            //判断是否有分类参数
            if (strNewType == null || strNewType == "")
            {
                strNewType = "0";//0表示所有分类
            }
            strNewTp = strNewType;//公共变量赋值

            //判断NewType参数是否正确
            if (!FunctionClass.CheckStr(strNewType, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            
            //判断在不是0的情况下，加条件
            if (strNewType != "0")
            {
                strTypeSql = myData.GetNewTypeIDSql(strNewType, myConn);
                if (strTypeSql.Length >= 4)
                {
                    strTypeSql = FunctionClass.LeftString(strTypeSql, strTypeSql.Length - 4);
                    strTypeSql = " or " + strTypeSql;
                   
                }
                if (strIsRecommend == "1")
                {
                    strSql += "and IsRecommend=1 and (NewType= " + strNewType + strTypeSql + ")";//加分类条件
                }
                else
                {
                    strSql += " and (NewType= " + strNewType + strTypeSql + ")";//加分类条件
                }
                
                
            }

           
            
            //判断是否有关键词
            if (FunctionClass.CheckStr(strKeyWord, 0))
            {
                tbKeyWord.Text = strKeyWord;
                strSql += " and Title like '%" + strKeyWord.Replace("'", "''") + "%'";
            }

            strSql += " order by SID asc,id desc;select * from T_NewType order by sid";
            
            DataSet myDs = myData.GetDataSet(strSql, myConn);

            //赋值新闻分类下拉框
            ddlNewType.Items.Add(new ListItem("所有分类", "0"));
            myData.InitProTypeList(myDs.Tables[1], 0, ddlNewType, "");
            ddlNewType.SelectedValue = strNewType;

            //获取总记录数
            intRsCount = myDs.Tables[0].Rows.Count;

            //计算总页数
            dbPageCount = Math.Ceiling((double)intRsCount / (double)intPageSize);

            //如果现有页数大于总页数，那么设定为总页数
            if (intPage > dbPageCount)
                intPage = Convert.ToInt32(dbPageCount);
            if(intPage<1)
                intPage=1;

            //读取数据
            for (int i = 0; i < intPageSize;i++ )
            {
                int intCurrentRow=i + (intPage - 1) * intPageSize;

                //判断是否已经没有数据
                if (intCurrentRow + 1 > intRsCount)
                    break;

                TableRow myTr = new TableRow();
                myTr.Attributes.Add("style","CURSOR: hand");
                myTr.Attributes.Add("onMouseOver","this.style.backgroundColor = '#FFFFFF'" );
                myTr.Attributes.Add("onmouseout","this.style.backgroundColor = ''");
                myTr.Attributes.Add("bgColor", "#ebf2f9");

                TableCell myTc1 = new TableCell();
                myTc1.Text = myDs.Tables[0].Rows[intCurrentRow]["ID"].ToString();

                TableCell myTc2 = new TableCell();
                if (myDs.Tables[0].Rows[intCurrentRow]["IsShow"].ToString() == "1")
                    myTc2.Text = "<FONT color=blue>√</FONT>";
                else
                    myTc2.Text = "<FONT color=red>×</FONT>";
                myTc2.Attributes.Add("onclick", "SetShowOrFalse(this,'1','" + myDs.Tables[0].Rows[intCurrentRow]["IsShow"].ToString()
                    + "','" + myDs.Tables[0].Rows[intCurrentRow]["ID"].ToString() + "')");

                TableCell myTc8 = new TableCell();
                if (myDs.Tables[0].Rows[intCurrentRow]["IsRecommend"].ToString() == "1")
                    myTc8.Text = "<FONT color=blue>√</FONT>";
                else
                    myTc8.Text = "<FONT color=red>×</FONT>";
                myTc8.Attributes.Add("onclick", "SetShowOrFalse(this,'2','" + myDs.Tables[0].Rows[intCurrentRow]["IsRecommend"].ToString()
                    + "','" + myDs.Tables[0].Rows[intCurrentRow]["ID"].ToString() + "')");

                TableCell myTc3 = new TableCell();
                myTc3.Text = myDs.Tables[0].Rows[intCurrentRow]["TypeCalled"].ToString();

                TableCell myTc4 = new TableCell();
                myTc4.Text = myDs.Tables[0].Rows[intCurrentRow]["Title"].ToString();

                TableCell myTc5 = new TableCell();
                myTc5.Text = myDs.Tables[0].Rows[intCurrentRow]["NoteTime"].ToString();

                myTr.Cells.Add(myTc1);
                myTr.Cells.Add(myTc2);
                myTr.Cells.Add(myTc8);
                myTr.Cells.Add(myTc3);
                myTr.Cells.Add(myTc4);
                myTr.Cells.Add(myTc5);


                TableCell myTc9 = new TableCell();
                TextBox myTb = new TextBox();
                myTb.ID = "SID_" + myDs.Tables[0].Rows[intCurrentRow]["ID"].ToString();
                myTb.Width = 40;
                myTb.Text = myDs.Tables[0].Rows[intCurrentRow]["SID"].ToString();
                myTb.Attributes.Add("onkeyup", "value=value.replace(/[^\\d]/g,'')");
                myTc9.Controls.Add(myTb);
                TableCell myTc6 = new TableCell();
                myTc6.Width = 60;
                myTc6.Text = "<a href='new_mod.aspx?id=" + myDs.Tables[0].Rows[intCurrentRow]["ID"].ToString()
                    + "' style='color:#330099;'>修改</a> <a href='news.aspx?del=" + myDs.Tables[0].Rows[intCurrentRow]["ID"].ToString() 
                    + "' style='color:#330099;' onclick='return confirm(\"是否要删除这条信息？\")'>删除</a>";
                TableCell myTc7 = new TableCell();
                CheckBox myCB=new CheckBox();
                myCB.ID = "cbSel_" + myDs.Tables[0].Rows[intCurrentRow]["ID"].ToString();
                myCB.ToolTip=myDs.Tables[0].Rows[intCurrentRow]["ID"].ToString();
                myTc7.Width = 20;
                myTc7.Controls.Add(myCB);

                myTr.Cells.Add(myTc9);
                myTr.Cells.Add(myTc6);
                myTr.Cells.Add(myTc7);

                tableMain.Rows.Add(myTr);
            }

            myDs.Dispose();
            myData.ConnClose(myConn);

            //添加按钮行
            TableRow myTrBt = new TableRow();
            myTrBt.Attributes.Add("bgColor", "#ebf2f9");
            TableCell myTcA = new TableCell();
            myTcA.ColumnSpan = 6;
            TableCell myTcB = new TableCell();
            Button myTbOrder = new Button();
            myTbOrder.ID = "tbUpdateOrder";
            myTbOrder.Text = "更新排序";
            myTbOrder.Width = 50;
            myTbOrder.Click += new EventHandler(myTbOrder_Click);
            myTcB.Controls.Add(myTbOrder);
            TableCell myTcC = new TableCell();
            myTcC.ColumnSpan = 2;
            Button myTbDel = new Button();
            myTbDel.ID = "tbDelSelected";
            myTbDel.Text = "删除所选";
            myTbDel.OnClientClick = "return confirm('是否删除选中信息？');";
            myTbDel.Width = 60;
            myTbDel.Click += new EventHandler(myTbDel_Click);
            myTcC.Controls.Add(myTbDel);

            myTrBt.Cells.Add(myTcA);
            myTrBt.Cells.Add(myTcB);
            myTrBt.Cells.Add(myTcC);

            tableMain.Rows.Add(myTrBt);

            //添加分页行
            TableRow myTrPage = new TableRow();
            myTrPage.Attributes.Add("bgColor", "#d7e4f7");
            TableCell myTcP = new TableCell();
            myTcP.ColumnSpan = 9;
            myTcP.Text = "<div style='width:50%;text-align:left;float:left;'>总共 <font color=red>" + intRsCount + "</font> 条信息　当前页：<font color=red>" +
                intPage + "</font>/" + dbPageCount + "　每页显示：<font color=red>" + intPageSize + "</font>条</div>";
            myTcP.Text += "<div style='width:50%;text-align:right;float:left;'><a href=\"" + FunctionClass.GetNewURL("page", "1", FunctionClass.PageURL) 
                + "\">首页</a>  ";
            int intPrevPage = intPage < 2 ? 1 : intPage - 1;
            myTcP.Text += "<a href=\"" + FunctionClass.GetNewURL("page", intPrevPage.ToString(), FunctionClass.PageURL) + "\">上一页</a>   ";
            int intNextPage = intPage >= dbPageCount ? (int)dbPageCount : intPage + 1;
            myTcP.Text += "<a href=\"" + FunctionClass.GetNewURL("page", intNextPage.ToString(), FunctionClass.PageURL) + "\">下一页</a>  ";
            myTcP.Text += "<a href=\"" + FunctionClass.GetNewURL("page", dbPageCount.ToString(), FunctionClass.PageURL) + "\">尾页</a>   ";
            myTcP.Text += "跳转至<input type=\"text\" name=\"gotoPage\" id=\"gotoPage\" style=\"width:20px;height:18px;\" value=\"" + intPage + "\" onKeyUp=\"value=value.replace(/[^\\d]/g,'')\" />页";
            myTcP.Text += "&nbsp;<INPUT style='WIDTH: 20px; HEIGHT: 18px' class=button onclick=\"GotoPage('" 
                + FunctionClass.GetNewURL("page", "", FunctionClass.PageURL) + "','gotoPage')\" value=GO type=button ";
            myTcP.Text+="name=submitSkip>&nbsp;&nbsp;</div>";

            myTrPage.Cells.Add(myTcP);

            tableMain.Rows.Add(myTrPage);

            Session["UserViewURL"] = FunctionClass.PageURL;
        }

        /// <summary>
        /// 点击删除所选按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myTbDel_Click(object sender, EventArgs e)
        {
            string strSql, strNewType, strKeyWord,strTypeSql;

            strNewType = Request.QueryString["NewType"];
            strKeyWord = Request.QueryString["KeyWord"];
            strSql = "select ID from T_News where 1=1";

            //判断是否有分类参数
            if (strNewType == null || strNewType == "")
            {
                strNewType = "0";//0表示所有分类
            }

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //判断在不是0的情况下，加条件
            if (strNewType != "0")
            {
                strTypeSql = myData.GetNewTypeIDSql(strNewType, myConn);
                if (strTypeSql.Length >= 4)
                {
                    strTypeSql = FunctionClass.LeftString(strTypeSql, strTypeSql.Length - 4);
                    strTypeSql = " or " + strTypeSql;
                }
                strSql += " and (NewType= " + strNewType + strTypeSql + ")";//加分类条件
            }

            //判断是否有关键词
            if (FunctionClass.CheckStr(strKeyWord, 0))
            {
                tbKeyWord.Text = strKeyWord;
                strSql += " and Title like '%" + strKeyWord.Replace("'", "''") + "%'";
            }

            strSql += " order by SID asc,id desc";

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
            {
                string strRowID = myDs.Tables[0].Rows[i]["ID"].ToString();
                CheckBox myTB = (CheckBox)form1.FindControl("cbSel_" + strRowID);
                if (myTB != null)
                {
                    if (myTB.Checked)
                        myData.ExecuteSql("delete from T_News where ID=" + strRowID, myConn);
                }
            }
            myDs.Dispose();

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("删除成功！", "");
            Response.End();
        }

        /// <summary>
        /// 点击更新排序按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myTbOrder_Click(object sender, EventArgs e)
        {
            string strSql, strNewType, strKeyWord, strTypeSql;

            strNewType = Request.QueryString["NewType"];
            strKeyWord = Request.QueryString["KeyWord"];
            strSql = "select ID from T_News where 1=1";

            //判断是否有分类参数
            if (strNewType == null || strNewType == "")
            {
                strNewType = "0";//0表示所有分类
            }

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //判断在不是0的情况下，加条件
            if (strNewType != "0")
            {
                strTypeSql = myData.GetNewTypeIDSql(strNewType, myConn);
                if (strTypeSql.Length >= 4)
                {
                    strTypeSql = FunctionClass.LeftString(strTypeSql, strTypeSql.Length - 4);
                    strTypeSql = " or " + strTypeSql;
                }
                strSql += " and (NewType= " + strNewType + strTypeSql + ")";//加分类条件
            }

            //判断是否有关键词
            if (FunctionClass.CheckStr(strKeyWord, 0))
            {
                tbKeyWord.Text = strKeyWord;
                strSql += " and Title like '%" + strKeyWord.Replace("'", "''") + "%'";
            }

            strSql += " order by SID asc,id desc";

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
            {
                string strRowID=myDs.Tables[0].Rows[i]["ID"].ToString();
                TextBox myTB = (TextBox)form1.FindControl("SID_" + strRowID);
                if (myTB != null)
                {
                    myData.ExecuteSql("update T_News set SID=" + myTB.Text + " where ID=" + strRowID, myConn);
                }
            }
            myDs.Dispose();

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("更新成功！", "");
            Response.End();
        }
    }
}
