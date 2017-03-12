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
    public partial class products : System.Web.UI.Page
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
            string strSql, strTypeID, strKeyWords, strIsRecommend;

            //变量赋值
            strTypeID = Request.QueryString["TypeID"];
            strKeyWords = Request.QueryString["keyword"];
            strIsRecommend = Request.QueryString["IsRecommend"];

            //判断变量
            if (!FunctionClass.CheckStr(strTypeID, 1))
                strTypeID = "1";
            if (!FunctionClass.CheckStr(strIsRecommend, 1))
                strIsRecommend = "";

            //打开数据库
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //sql语句
            strSql = " where IsShow=1";
            if (strTypeID != "")
                strSql += " and (" + myData.GetProTypeIDSql(strTypeID, myConn) + "TypeID=" + strTypeID + ")";

            if (FunctionClass.CheckStr(strKeyWords, 0))
            {
                strSql += " and (ProName like '%" + strKeyWords.Replace("'", "''") + "%' or Content like '%" + strKeyWords.Replace("'", "''") + "%')";
            }

            if (strIsRecommend != "")
                strSql += " and IsRecommend=" + strIsRecommend;

            //初始化分页变量
            int intPageIndex = FunctionClass.CurrentPage();
            int intPageSize = 100;
            int intPageCount = 0;
            int intPageRecordcount = 0;

            //创建Dataset对象读取数据记录集
            DataSet myDs = myData.GetDataSet("T_Products", strSql, "SID asc,NoteTime desc", intPageIndex, intPageSize,
                ref intPageCount, ref intPageRecordcount, myConn);

            DataView myDv = new DataView(myDs.Tables[0], "  ", "", DataViewRowState.CurrentRows);
            for (int i = 0; i < myDv.Count; i++)
            {
                lbList.Text += "<li><a href=" + FunctionClass.GetImgUrl(myDv[i]["Content"].ToString())
                    + " rel=\"lightbox-tour\" title=\"" + myDv[i]["ProName"].ToString()
                    + "\"><img src=\"" + FunctionClass.GetUploadFileRelativeURL(myDv[i]["ProPic"].ToString())
                    + "\" width=\"200\" height=\"133\" alt=\"" + myDv[i]["ProName"].ToString() + "\" /><br/>"
                    + myDv[i]["ProName"].ToString() + "</a></li>";
            }
            myDv.Dispose();

            //分页
            lbPageBar.Text = FunctionClass.GetPageBar(intPageIndex, intPageRecordcount, intPageCount, 4,
                FunctionClass.GetNewURL("page", "{page}", FunctionClass.PageURL), 
                "<img src=\"images/news_19.jpg\" width=\"21\" height=\"13\" alt=\"第一页\" />",
                "<img src=\"images/news_116.jpg\" width=\"21\" height=\"13\" alt=\"上一页\" />",
                "<img src=\"images/news_22.jpg\" width=\"21\" height=\"13\" alt=\"下一页\" />",
                "<img src=\"images/news_23.jpg\" width=\"21\" height=\"13\" alt=\"最后页\" />", false, false);
            myDs.Dispose();

            //分类名称赋值
            lbCalled.Text = "美食推荐";
            lbCalled1.Text = "Food recommended";
            if (strTypeID == "")
            {
                hyCalled.Text = "美食推荐";
                hyCalled.NavigateUrl = "products.aspx";
            }
            else
            {
                strSql = "select * from T_ProType where ID=" + strTypeID;
                SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
                if (myDr.Read())
                {
                    hyCalled.Text = myDr["TypeCalled"].ToString();
                    hyCalled.NavigateUrl = "products.aspx?TypeID=" + strTypeID;
                    lbTypeCalled.Text = myDr["TypeCalled"].ToString();
                    lbMemo.Text = myDr["Memo"].ToString(); ;
                }
            }

            //关闭数据库
            myData.ConnClose(myConn);
        }
    }
}