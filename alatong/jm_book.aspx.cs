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
    public partial class jm_book : System.Web.UI.Page
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
            string strSql, strKeyWords, strIsRecommend;

            //变量赋值
            strKeyWords = Request.QueryString["keyword"];
            strIsRecommend = Request.QueryString["IsRecommend"];

            //判断变量
            if (!FunctionClass.CheckStr(strIsRecommend, 1))
                strIsRecommend = "";

            //打开数据库
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //sql语句
            strSql = " where IsShow=1";

            if (FunctionClass.CheckStr(strKeyWords, 0))
            {
                strSql += " and (Title like '%" + strKeyWords.Replace("'", "''") + "%' or Memo like '%" + strKeyWords.Replace("'", "''") + "%')";
            }

            if (strIsRecommend != "")
                strSql += " and IsRecommend=" + strIsRecommend;

            //初始化分页变量
            int intPageIndex = FunctionClass.CurrentPage();
            int intPageSize = 5;
            int intPageCount = 0;
            int intPageRecordcount = 0;

            //创建Dataset对象读取数据记录集
            DataSet myDs = myData.GetDataSet("T_Book", strSql, "SID asc,NoteTime desc", intPageIndex, intPageSize,
                ref intPageCount, ref intPageRecordcount, myConn);

            DataView myDv = new DataView(myDs.Tables[0], "  ", "", DataViewRowState.CurrentRows);
            for (int i = 0; i < myDv.Count; i++)
            {
                lbList.Text += "<dl><dt>"+myDv[i]["Title"].ToString()+"</dt>"
					+"<dd>"+FunctionClass.WriteHtml(myDv[i]["Memo"].ToString())+"</dd></dl>";
            }
            myDv.Dispose();

            //分页
            lbPageBar.Text = FunctionClass.GetPageBar(intPageIndex, intPageRecordcount, intPageCount, 4,
                FunctionClass.GetNewURL("page","{page}",FunctionClass.PageURL), 
                "<img src=\"images/news_11.jpg\" width=\"12\" height=\"12\" />",
                "<img src=\"images/news_12.jpg\" width=\"12\" height=\"12\" />",
                "<img src=\"images/news_14.jpg\" width=\"12\" height=\"12\" />",
                "<img src=\"images/news_15.jpg\" width=\"12\" height=\"12\" />", false, false);
            myDs.Dispose();

            lbCalled.Text = "加盟问答";
            lbCalled1.Text = "F A Q";
            hyCalled.Text = "加盟问答";
            hyCalled.NavigateUrl = "jm_book.aspx";

            lbInfo11.Text = myData.GetInfo(11, myConn);

            //关闭数据库
            myData.ConnClose(myConn);
        }
    }
}