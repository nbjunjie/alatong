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
using System.Collections;

namespace nb_xy.admin
{
    public partial class admin_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FunctionClass.CheckAdminLogin(0);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            string strSql;

            strSql = "select * from T_AdminMenu where isShow=1 order by sid,id";

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);

            cblUserMenu.DataSource = myDs.Tables[0];
            cblUserMenu.DataTextField = "Title";
            cblUserMenu.DataValueField = "ID";
            cblUserMenu.DataBind();

            myDs.Dispose();
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strUserName, strPassWord, strUserRole, strUserRoleCalled, strIsLock, strUserMenu, strSql;

            strUserName = tbUserName.Text;
            strPassWord = tbPassWord.Text;
            strUserRole = tbUserRole.Text;
            strUserRoleCalled = tbUserRoleCalled.Text;
            strIsLock = cblIsLock.SelectedValue;
            strUserMenu = "";
            strPassWord = FunctionClass.ToMD5(strPassWord);

            //获取选中用户
            for (int i = 0; i < cblUserMenu.Items.Count; i++)
            {
                if (cblUserMenu.Items[i].Selected)
                    strUserMenu += "|" + cblUserMenu.Items[i].Value + "|";
            }

            strSql = "insert into T_Admin (UserName,PassWord,UserRole,UserRoleCalled,IsLock,UserMenu) values (@UserName,@PassWord,@UserRole,@UserRoleCalled,@IsLock,@UserMenu)";
            string[] ParamsName = new string[] { "@UserName", "@PassWord", "@UserRole", "@UserRoleCalled", "@IsLock", "@UserMenu" };
            string[] ParamsValue = new string[] { strUserName, strPassWord, strUserRole, strUserRoleCalled, strIsLock, strUserMenu };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //判断用户名是否存在
            if (myData.CheckDataRowExist("select * from T_Admin where UserName like '" + strUserName.Replace("'", "''") + "'", myConn))
            {
                myData.ConnClose(myConn);
                FunctionClass.ShowMsgBox("该用户名已经存在！请换一个用户名！");
                Response.End();
            }

            long id = myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            //获取选中用户
            for (int i = 0; i < cblUserMenu.Items.Count; i++)
            {
                if (cblUserMenu.Items[i].Selected)
                {
                    strSql = "update T_AdminMenu set AdminUser=AdminUser+'|" + id + "|' where ID=" + cblUserMenu.Items[i].Value;
                    myData.ExecuteSql(strSql, myConn);
                }
            }

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();
        }
    }
}
