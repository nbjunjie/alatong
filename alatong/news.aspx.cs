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
using System.Text.RegularExpressions;

namespace alatong
{
    public partial class news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FunctionClass.CheckData();
            if (!IsPostBack)
                BindData();
        }

        /// <summary>
        /// 绑定读取数据
        /// </summary>
        private void BindData()
        {
            //定义变量
            string strSql, strNewType, strKeyWords, strIsRecommend;

            //变量赋值
            strNewType = Request.QueryString["NewType"];
            strKeyWords = Request.QueryString["keyword"];
            strIsRecommend = Request.QueryString["IsRecommend"];

            //判断变量
            if (!FunctionClass.CheckStr(strNewType, 1))
                strNewType = "1";
            if (!FunctionClass.CheckStr(strIsRecommend, 1))
                strIsRecommend = "";

            //打开数据库
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //sql语句
            strSql = " where IsShow=1";
            if (strNewType != "")
                strSql += " and (" + myData.GetNewTypeIDSql(strNewType, myConn) + "NewType=" + strNewType + ")";

            if (FunctionClass.CheckStr(strKeyWords, 0))
            {
                strSql += " and (Title like '%" + strKeyWords.Replace("'", "''") + "%' or Content like '%" + strKeyWords.Replace("'", "''") + "%')";
                tbKeyword.Text = strKeyWords;
            }

            if (strIsRecommend != "")
                strSql += " and IsRecommend=" + strIsRecommend;

            //初始化分页变量
            int intPageIndex = FunctionClass.CurrentPage();
            int intPageSize = 10;
            int intPageCount = 0;
            int intPageRecordcount = 0;

            //创建Dataset对象读取数据记录集
            DataSet myDs = myData.GetDataSet("T_News", strSql, "SID asc,NoteTime desc", intPageIndex, intPageSize,
                ref intPageCount, ref intPageRecordcount, myConn);

            DataView myDv = new DataView(myDs.Tables[0], "  ", "", DataViewRowState.CurrentRows);
            for (int i = 0; i < myDv.Count; i++)
            {
                lbList.Text += "<tr";
                if (i % 2 != 0) lbList.Text += " class='curr'";
                lbList.Text += ">"
                        + "<td width=\"75\">"+(intPageSize*(intPageIndex-1)+i+1)+"</td>"
                        + "<th width=\"395\"><a href=\"newinfo.aspx?id=" + myDv[i]["ID"].ToString()
                        + "\" target=\"_blank\">" + myDv[i]["Title"].ToString() + "</a></th>"
                        + "<td width=\"130\">" + DateTime.Parse(myDv[i]["NoteTime"].ToString()).ToString("yyyy-MM-dd") + "</td>"
                        + "<td>【<a href=\"newinfo.aspx?id=" + myDv[i]["ID"].ToString() + "\" target=\"_blank\">查看详情</a>】</td>"
                    + "</tr>";
            }
            myDv.Dispose();

            //分页
            lbPageBar.Text = FunctionClass.GetPageBar(intPageIndex, intPageRecordcount, intPageCount, 4,
                FunctionClass.GetNewURL("page", "{page}", FunctionClass.PageURL), 
                "<img src=\"images/news_11.jpg\" width=\"12\" height=\"12\" />",
                "<img src=\"images/news_12.jpg\" width=\"12\" height=\"12\" />",
                "<img src=\"images/news_14.jpg\" width=\"12\" height=\"12\" />",
                "<img src=\"images/news_15.jpg\" width=\"12\" height=\"12\" />", false, false);
            myDs.Dispose();

            lbCalled.Text = "新闻中心";
            lbCalled1.Text = "News Center";
            hyCalled.Text = "新闻中心";
            hyCalled.NavigateUrl = "news.aspx";

            //关闭数据库
            myData.ConnClose(myConn);
        }

        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtSearch_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("news.aspx?keyword=" + tbKeyword.Text, true);
        }
    }
}