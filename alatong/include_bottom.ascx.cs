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
    public partial class include_bottom : System.Web.UI.UserControl
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
            string strSql;

            //赋值变量

            //判断变量

            //打开数据库连接
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            
            lbInfo1.Text = myData.GetInfo(1, myConn);
            lbInfo2.Text = myData.GetInfo(2, myConn);

            //关闭数据库连接
            myData.ConnClose(myConn);
        }
    }
}