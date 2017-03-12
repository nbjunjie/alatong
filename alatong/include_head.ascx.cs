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
    public partial class include_head : System.Web.UI.UserControl
    {
        //定义全局变量
        public string strSeoTitle = "", strSeoKeywords = "", strSeoDescription = "", strSeoAuthor = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定或读取数据
        /// </summary>
        private void BindData()
        {
            //定义变量
            string strFileName, strSql;

            //获取本页面文件名称
            strFileName = Request.Url.AbsolutePath.ToLower();
            strFileName = System.IO.Path.GetFileName(strFileName);

            //筛选数据sql
            strSql = "select * from T_Seo where PageName like '" + strFileName + "'";

            //初始化数据库对象
            DataClass myData = new DataClass();
            //打开数据库连接
            SqlConnection myConn = myData.ConnOpen();

            //创建datareader并读取数据
            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                strSeoTitle = strSeoTitle + myDr["Title"].ToString();
                strSeoKeywords = strSeoKeywords + myDr["Keywords"].ToString();
                strSeoDescription = strSeoDescription + myDr["Description"].ToString();
                strSeoAuthor = strSeoAuthor + myDr["Author"].ToString();
            }
            myDr.Close();
            myDr.Dispose();

            //关闭数据库连接
            myData.ConnClose(myConn);
        }
    }
}