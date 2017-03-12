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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibtLogin_Click(object sender, ImageClickEventArgs e)
        {
            string strUserID, strUserName, strPassWord, strUserRoleCalled, strUserMenu, strUserMenuUrl, strCode, strSql;
            bool isLogin = false, isLock = false;
            int intUserRole=0;

            //获取数据
            strUserName = username.Text;
            strPassWord = password.Text;
            strCode = code.Text;
            strUserRoleCalled = "";
            strUserID = "";
            strUserMenu = "";

            //判断验证码是否存在
            if (Session["CheckVerifyCode"] == null)
            {
                FunctionClass.ShowMsgBox("验证码输入错误！");
                Response.End();
            }
            else
            {
                //判断验证码是否一致
                if (strCode.ToLower() != Session["CheckVerifyCode"].ToString().ToLower())
                {
                    FunctionClass.ShowMsgBox("验证码输入错误！");
                    Response.End();
                }
            }

            //判断用户名或密码是否存在
            if (strUserName.Trim() == "" || strPassWord.Trim() == "")
            {
                FunctionClass.ShowMsgBox("用户名或密码不能为空！");
                Response.End();
            }
            else
                strPassWord = FunctionClass.ToMD5(strPassWord);

            //创建sql语句
            strSql = "select * from T_Admin where PassWord like '" + strPassWord + "'";

            //创建数据对象
            DataClass myData=new DataClass();
            //创建数据库链接
            SqlConnection myConn = myData.ConnOpen();

            //创建sqlreader对象
            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            while (myDr.Read())
            {
                if (myDr["UserName"].ToString().ToLower() == strUserName.ToLower())
                {
                    if (myDr["IsLock"].ToString() == "1")
                    {
                        isLock = true;
                    }
                    else
                    {
                        strUserID = myDr["ID"].ToString();
                        intUserRole = (int)myDr["UserRole"];
                        strUserRoleCalled = myDr["UserRoleCalled"].ToString();
                        strUserMenu = myDr["UserMenu"].ToString();
                        isLogin = true;
                    }
                }
            }
            myDr.Close();
            myDr.Dispose();

            //获取用户菜单直接连接名称
            strUserMenuUrl = myData.GetUserMenuUrl(strUserMenu, myConn);
            strUserMenuUrl += "|main.aspx|";
            strUserMenuUrl += "|left.aspx|";
            strUserMenuUrl += "|top.aspx|";
            strUserMenuUrl += "|sysinfo.aspx|";

            //关闭数据库链接
            myData.ConnClose(myConn);

            //判断是否锁定
            if (isLock)
            {
                FunctionClass.ShowMsgBox("该用户已经被管理员锁定，请联系系统管理员！");
                Response.End();
            }

            //判断是否登录成功
            if (isLogin)
            {
                //写入session
                Session["Admin_UserID"] = strUserID;
                Session["Admin_UserName"] = strUserName;
                Session["Admin_PassWord"] = strPassWord;
                Session["Admin_UserRole"] = intUserRole;
                Session["Admin_UserRoleCalled"] = strUserRoleCalled;
                Session["Admin_UserMenu"] = strUserMenu;
                Session["Admin_UserMenuUrl"] = strUserMenuUrl;

                Response.Redirect("main.aspx", true);
            }
            else
            {
                FunctionClass.ShowMsgBox("用户名或密码错误，请重新输入！");
                Response.End();
            }
        }
    }
}
