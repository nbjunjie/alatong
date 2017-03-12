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

namespace alatong
{
    public partial class newinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }

        /// <summary>
        /// 绑定和读取数据
        /// </summary>
        private void BindData()
        {
            //定义变量
            string strSql, strID, strNewType;

            //赋值变量
            strNewType = Request.QueryString["NewType"];
            strID = Request.QueryString["id"];

            //判断变量
            if (!FunctionClass.CheckStr(strNewType, 1))
                strNewType = "1";
            if (!FunctionClass.CheckStr(strID, 1))
                strID = "3";

            //打开数据库连接
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            strSql = "select * from V_News where isShow=1 and id=" + strID;
            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                lbTitle.Text = myDr["Title"].ToString();
                lbNoteTime.Text = myDr["NoteTime"].ToString();
                lbOrigin.Text = myDr["Origin"].ToString();
                lbAuthor.Text = myDr["Author"].ToString();
                lbContent.Text = myDr["Content"].ToString();

                include_head1.strSeoTitle = myDr["Seo_Title"].ToString();
                include_head1.strSeoKeywords = myDr["Seo_Keywords"].ToString();
                include_head1.strSeoDescription = myDr["Seo_Description"].ToString();
                include_head1.strSeoAuthor = myDr["Seo_Author"].ToString();

                lbCalled.Text = "新闻中心";
                lbCalled1.Text = "News Center";
                hyCalled.Text = "新闻中心";
                hyCalled.NavigateUrl = "news.aspx";
                
            }
            myDr.Close();
            myDr.Dispose();

            //关闭数据库连接
            myData.ConnClose(myConn);
        }
    }
}