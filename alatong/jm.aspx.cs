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
    public partial class jm : System.Web.UI.Page
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
            strID = Request.QueryString["ID"];

            //判断变量
            if (!FunctionClass.CheckStr(strID, 1))
                strID = "7";

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
                hyCalled.NavigateUrl = "jm.aspx?id=" + strID;

                //判断英文
                if (strID == "7")
                    lbCalled1.Text = "The join conditions";
                else if (strID == "8")
                    lbCalled1.Text = "Investment budget";
                else if (strID == "9")
                    lbCalled1.Text = "The joining process";
                else if (strID == "10")
                    lbCalled1.Text = "Joined in support of";
                else if (strID == "11")
                    lbCalled1.Text = "F A Q";
            }
            myDr.Close();
            myDr.Dispose();

            if (strID == "9") lbInfo12.Text = "<div class=\"about_process\">" + myData.GetInfo(12, myConn) + "</div>";

            //关闭数据库连接
            myData.ConnClose(myConn);

            //加盟问答
            if (strID == "11") Response.Redirect("jm_book.aspx", true);
        }
    }
}