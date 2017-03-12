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
    public partial class about : System.Web.UI.Page
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
            string strSql, strID;

            //赋值变量
            strID=Request.QueryString["ID"];

            //判断变量
            if(!FunctionClass.CheckStr(strID,1))
                strID="3";

            //打开数据库连接
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            strSql = "select * from T_Info where ID=" + strID;
            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                lbInfo3.Text = myDr["Memo"].ToString();
                lbCalled.Text = myDr["Called"].ToString();
                hyCalled.Text = myDr["Called"].ToString();
                hyCalled.NavigateUrl = "about.aspx?id=" + strID;

                //判断英文
                if (strID == "3")
                    lbCalled1.Text = "ABOUT US";
                else if (strID == "4")
                    lbCalled1.Text = "CONTACT US";
            }
            myDr.Close();
            myDr.Dispose();

            //关闭数据库连接
            myData.ConnClose(myConn);
        }
    }
}