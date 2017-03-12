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
    public partial class admin_mod : System.Web.UI.Page
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
            string strID, strUserMenu;
            strUserMenu = "";

            strID = Request.QueryString["id"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

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

            //读取数据赋值
            strSql = "select * from T_Admin where ID=" + strID;
            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                tbUserName.Text = myDr["UserName"].ToString();
                tbPassWord.Text = myDr["PassWord"].ToString();
                tbPassWord.ToolTip = myDr["PassWord"].ToString();
                tbUserRole.Text = myDr["UserRole"].ToString();
                tbUserRoleCalled.Text = myDr["UserRoleCalled"].ToString();
                cblIsLock.SelectedValue = myDr["IsLock"].ToString();
                strUserMenu = myDr["UserMenu"].ToString();
            }
            myDr.Close();
            myDr.Dispose();

            myData.ConnClose(myConn);

            FunctionClass myFun = new FunctionClass();

            if (strUserMenu != "")
            {
                ArrayList arlUser = myFun.GetArrayListForSplitString(strUserMenu, '|');

                for (int i = 0; i < cblUserMenu.Items.Count; i++)
                {
                    for (int j = 0; j < arlUser.Count; j++)
                    {
                        if (cblUserMenu.Items[i].Value == arlUser[j].ToString())
                            cblUserMenu.Items[i].Selected = true;
                    }
                }
            }
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strID, strUserName, strPassWord, strUserRole, strUserRoleCalled, strIsLock, strUserMenu, strSql;

            strUserName = tbUserName.Text;
            strPassWord = tbPassWord.Text;
            strUserRole = tbUserRole.Text;
            strUserRoleCalled = tbUserRoleCalled.Text;
            strIsLock = cblIsLock.SelectedValue;
            strUserMenu = "";

            strID = Request.QueryString["id"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            //密码重置
            if (strPassWord == "")
                strPassWord = tbPassWord.ToolTip;
            else
                strPassWord = FunctionClass.ToMD5(strPassWord);

            //获取选中用户
            for (int i = 0; i < cblUserMenu.Items.Count; i++)
            {
                if (cblUserMenu.Items[i].Selected)
                    strUserMenu += "|" + cblUserMenu.Items[i].Value + "|";
            }

            strSql = "update T_Admin set UserName=@UserName,PassWord=@PassWord,UserRole=@UserRole,UserRoleCalled=@UserRoleCalled,IsLock=@IsLock,UserMenu=@UserMenu where ID=@ID";
            string[] ParamsName = new string[] { "@UserName", "@PassWord", "@UserRole", "@UserRoleCalled", "@IsLock","@UserMenu", "@ID" };
            string[] ParamsValue = new string[] { strUserName, strPassWord, strUserRole, strUserRoleCalled, strIsLock, strUserMenu, strID };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //判断用户名是否存在
            if (myData.CheckDataRowExist("select * from T_Admin where UserName like '" + strUserName.Replace("'", "''") + "' and ID<>" + strID, myConn))
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
                    strSql = "update T_AdminMenu set AdminUser=AdminUser+'|" + strID + "|' where ID=" + cblUserMenu.Items[i].Value;
                }
                else
                {
                    strSql = "update T_AdminMenu set AdminUser=Replace(AdminUser,'|" + strID + "|','') where ID=" + cblUserMenu.Items[i].Value;
                }
                myData.ExecuteSql(strSql, myConn);
            }

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }
    }
}
