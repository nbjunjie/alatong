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
    public partial class password_mod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FunctionClass.CheckAdminLogin(0);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strUserName, strOldPassWord, strNewPassWord, strSql;
            bool isTrue=false;

            strUserName = Session["Admin_UserName"].ToString();
            strOldPassWord = tbOldPassWord.Text;
            strNewPassWord = tbNewPassWord.Text;

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            strSql = "select * from T_Admin where Username like '" + strUserName + "' and PassWord like '" + FunctionClass.ToMD5(strOldPassWord) + "'";
            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            if(myDr.Read())
            {
                isTrue=true;
            }
            myDr.Close();
            myDr.Dispose();

            if (!isTrue) 
            {
                FunctionClass.ShowMsgBox("原始密码错误！");
                myData.ConnClose(myConn);
                Response.End();
            }

            strSql = "update T_Admin set PassWord='" + FunctionClass.ToMD5(strNewPassWord) + "' where UserName like '" + strUserName + "'";
            myData.ExecuteSql(strSql, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "index.aspx", true);
            Session["Admin_UserName"] = null;
            Session["Admin_PassWord"] = null;
            Session["Admin_UserRole"] = null;
            Session["Admin_UserRoleCalled"] = null;
            Response.End();
        }
    }
}
