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

namespace nb_xy.admin
{
    public partial class adminmenu_add : System.Web.UI.Page
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

            strSql = "select * from T_AdminMenu order by PID,SID;select * from T_Admin order by id";

            ddlPID.Items.Add(new ListItem("无", "0"));

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            myData.InitProTypeList(myDs.Tables[0], 0, ddlPID, "","Title");

            cblAdminUser.DataSource = myDs.Tables[1];
            cblAdminUser.DataTextField = "UserName";
            cblAdminUser.DataValueField = "ID";
            cblAdminUser.DataBind();

            myDs.Dispose();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strPID, strTitle, strLink, strIsShow, strAdminUser, strSql;

            strPID = ddlPID.SelectedValue;
            strTitle = tbTitle.Text;
            strLink = tbLink.Text;
            strIsShow = cblIsShow.SelectedValue;
            strAdminUser = "";

            //获取选中用户
            for (int i = 0; i < cblAdminUser.Items.Count; i++)
            {
                if (cblAdminUser.Items[i].Selected)
                    strAdminUser += "|" + cblAdminUser.Items[i].Value + "|";
            }

            strSql = "insert into T_AdminMenu (PID,Title,Link,IsShow,AdminUser) values (@PID,@Title,@Link,@IsShow,@AdminUser)";
            string[] ParamsName = new string[] { "@PID", "@Title", "@Link", "@IsShow", "@AdminUser" };
            string[] ParamsValue = new string[] { strPID, strTitle,strLink, strIsShow,strAdminUser };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            long id = myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            //获取选中用户
            for (int i = 0; i < cblAdminUser.Items.Count; i++)
            {
                if (cblAdminUser.Items[i].Selected)
                {
                    strSql = "update T_Admin set UserMenu=UserMenu+'|" + id + "|' where ID=" + cblAdminUser.Items[i].Value;
                }
                else
                {
                    strSql = "update T_Admin set UserMenu=Replace(UserMenu,'|" + id + "|','') where ID=" + cblAdminUser.Items[i].Value;
                }
                myData.ExecuteSql(strSql, myConn);
            }

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();
        }
    }
}
