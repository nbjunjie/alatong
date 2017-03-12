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
    public partial class adminmenu_mod : System.Web.UI.Page
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
            string strID, strAdminUser;
            strAdminUser = "";

            strID = Request.QueryString["id"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            string strSql;

            strSql = "select * from T_AdminMenu order by PID,SID;select * from T_Admin order by id";

            ddlPID.Items.Add(new ListItem("无", "0"));

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            myData.InitProTypeList(myDs.Tables[0], 0, ddlPID, "", "Title");

            cblAdminUser.DataSource = myDs.Tables[1];
            cblAdminUser.DataTextField = "UserName";
            cblAdminUser.DataValueField = "ID";
            cblAdminUser.DataBind();

            myDs.Dispose();

            //读取数据赋值
            strSql = "select * from T_AdminMenu where ID="+strID;
            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                ddlPID.SelectedValue = myDr["PID"].ToString();
                tbTitle.Text = myDr["Title"].ToString();
                tbLink.Text = myDr["Link"].ToString();
                cblIsShow.SelectedValue = myDr["IsShow"].ToString();
                strAdminUser = myDr["AdminUser"].ToString();
            }
            myDr.Close();
            myDr.Dispose();

            myData.ConnClose(myConn);

            FunctionClass myFun=new FunctionClass();

            if (strAdminUser != "")
            {
                ArrayList arlUser = myFun.GetArrayListForSplitString(strAdminUser, '|');

                for (int i = 0; i < cblAdminUser.Items.Count; i++)
                {
                    for (int j = 0; j < arlUser.Count; j++)
                    {
                        if (cblAdminUser.Items[i].Value == arlUser[j].ToString())
                            cblAdminUser.Items[i].Selected = true;
                    }
                }
            }
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strID, strPID, strTitle, strLink, strIsShow, strAdminUser, strSql;

            strPID = ddlPID.SelectedValue;
            strTitle = tbTitle.Text;
            strLink = tbLink.Text;
            strIsShow = cblIsShow.SelectedValue;
            strAdminUser = "";

            strID = Request.QueryString["id"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            //获取选中用户
            for (int i = 0; i < cblAdminUser.Items.Count; i++)
            {
                if (cblAdminUser.Items[i].Selected)
                    strAdminUser += "|" + cblAdminUser.Items[i].Value + "|";
            }

            strSql = "update T_AdminMenu set PID=@PID,Title=@Title,Link=@Link,IsShow=@IsShow,AdminUser=@AdminUser where ID=@ID";
            string[] ParamsName = new string[] { "@PID", "@Title", "@Link", "@IsShow","@AdminUser","@ID" };
            string[] ParamsValue = new string[] { strPID, strTitle, strLink, strIsShow,strAdminUser,strID };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            long id = myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            //获取选中用户
            for (int i = 0; i < cblAdminUser.Items.Count; i++)
            {
                if (cblAdminUser.Items[i].Selected)
                {
                    strSql = "update T_Admin set UserMenu=UserMenu+'|" + strID + "|' where ID=" + cblAdminUser.Items[i].Value;
                }
                else
                {
                    strSql = "update T_Admin set UserMenu=Replace(UserMenu,'|" + strID + "|','') where ID=" + cblAdminUser.Items[i].Value;
                }
                myData.ExecuteSql(strSql, myConn);
            }

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }
    }
}
