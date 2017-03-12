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

namespace webshop.admin
{
    public partial class user_add : System.Web.UI.Page
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
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet("select * from T_UserType order by sid,id", myConn);
            ddlUserType.DataSource = myDs;
            ddlUserType.DataTextField = "TypeCalled";
            ddlUserType.DataValueField = "ID";
            ddlUserType.DataBind();
            myDs.Dispose();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strUserName, strPassWord, strMobile, strTel, strFax, strEMail, strCompany, strAddress, strIsLock, strUserType, strSql;
            string strQQ, strMemo;

            strUserName = tbUserName.Text;
            strPassWord = tbPassWord.Text;
            strMobile = FunctionClass.ToDBC(tbMobile.Text);
            strTel = tbTel.Text;
            strFax = tbFax.Text;
            strEMail = tbEMail.Text;
            strCompany = tbCompany.Text;
            strAddress = tbAddress.Text;
            strIsLock = cblIsLock.SelectedValue;
            strUserType = ddlUserType.SelectedValue;
            strQQ = tbQQ.Text;
            strMemo = tbMemo.Text;

            //判断手机号码是否11位
            if (strMobile.Length != 11)
            {
                FunctionClass.ShowMsgBox("手机号码必须是11位数字！前面请不要加0或其他字符");
                Response.End();
            }

            strSql = "insert into T_User (UserName,PassWord,Mobile,Tel,Fax,EMail,Company,Address,IsLock,UserType,QQ,Memo) values "
                + "(@UserName,@PassWord,@Mobile,@Tel,@Fax,@EMail,@Company,@Address,@IsLock,@UserType,@QQ,@Memo)";
            string[] ParamsName = new string[] { "@UserName", "@PassWord", "@Mobile", "@Tel", "@Fax", "@EMail", "@Company", "@Address", 
                "@IsLock","@UserType","@QQ","@Memo" };
            string[] ParamsValue = new string[] { strUserName, strPassWord, strMobile, strTel, strFax, strEMail, strCompany, strAddress, 
                strIsLock,strUserType,strQQ,strMemo };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //判断用户名是否存在
            if (myData.CheckDataRowExist("select * from T_User where Mobile like '" + strMobile.Replace("'", "''") + "'", myConn))
            {
                myData.ConnClose(myConn);
                FunctionClass.ShowMsgBox("手机号码已经能够存在！请换一个！");
                Response.End();
            }

            long id = myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();
        }
    }
}
