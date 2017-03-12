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
    public partial class user_mod : System.Web.UI.Page
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
            string strID, strSql;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet("select * from T_UserType order by sid,id", myConn);
            ddlUserType.DataSource = myDs;
            ddlUserType.DataTextField = "TypeCalled";
            ddlUserType.DataValueField = "ID";
            ddlUserType.DataBind();
            myDs.Dispose();

            strSql = "select * from T_User where ID=" + strID;
            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                tbUserName.Text = myDr["UserName"].ToString();
                tbMobile.Text = myDr["Mobile"].ToString();
                tbMobile.ToolTip = myDr["Mobile"].ToString();
                tbPassWord.Text = myDr["PassWord"].ToString();
                tbTel.Text = myDr["Tel"].ToString();
                tbFax.Text = myDr["Fax"].ToString();
                tbEMail.Text = myDr["EMail"].ToString();
                tbCompany.Text = myDr["Company"].ToString();
                tbAddress.Text = myDr["Address"].ToString();
                cblIsLock.SelectedValue = myDr["IsLock"].ToString();
                ddlUserType.SelectedValue = myDr["UserType"].ToString();
                tbQQ.Text = myDr["QQ"].ToString();
                tbMemo.Text = myDr["Memo"].ToString();
                if (myDr["AutoCheck"].ToString() == "1")
                {
                    plbt.Visible = false;
                }
                else
                {
                    plbt.Visible = true;
                }
            }
            myDr.Close();
            myDr.Dispose();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strID, strUserName, strPassWord, strMobile, strTel, strFax, strEMail, strCompany, strAddress, strUserType, strIsLock, strSql;
            string strQQ, strMemo;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

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

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //判断用户是否存在，如果存在那么登录，不存在直接注册后登录
            DataSet myDs = myData.GetDataSet("select * from T_User where ID=" + strID
                + ";select * from T_User where Mobile like '" + strMobile.Replace("'", "''") + "'", myConn);

            //判断是否修改手机号码
            if (strMobile != tbMobile.ToolTip)
            {
                if (myDs.Tables[1].Rows.Count > 0)
                {
                    FunctionClass.ShowMsgBox("您设置的新手机号码（既登录ID）已经有被使用！请换一个号码或者使用原有号码！");
                    myDs.Dispose();
                    myData.ConnClose(myConn);
                    Response.End();
                }
            }

            if (myDs.Tables[0].Rows.Count > 0)//有用户数据，修改用户。
            {
                strSql = "update T_User set UserName=@UserName,PassWord=@PassWord,Mobile=@Mobile,Tel=@Tel,Fax=@Fax,Address=@Address"
                    + ",EMail=@EMail,Company=@Company,IsLock=@IsLock,UserType=@UserType,QQ=@QQ,Memo=@Memo where ID=@ID";
                string[] ParamsName = new string[] { "@UserName", "@PassWord", "@Mobile", "@Tel", "@Fax", "@Address", "@EMail", 
                    "@Company","@IsLock","@UserType","@QQ","@Memo" ,"@ID" };
                string[] ParamsValue = new string[] { strUserName, strPassWord, strMobile, strTel, strFax, strAddress, strEMail, 
                    strCompany,strIsLock,strUserType,strQQ,strMemo, strID };

                //插入数据库
                myData.InsertData(strSql, ParamsName, ParamsValue, myConn);
            }
            else//没有用户
            {
                FunctionClass.ShowMsgBox("没有该用户！请核实！");
                myDs.Dispose();
                myData.ConnClose(myConn);
                Response.End();
            }

            myDs.Dispose();
            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //判断参数是否正确
            string strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            //打开数据库连接
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //获取数据集
            string strSql = "update T_User set AutoCheck=1 where ID=@ID";

            string[] ParamsName = new string[] { "@ID" };
            string[] ParamsValue = new string[] { strID };

            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);
            FunctionClass.ShowMsgBox("确认审核成功成功！", "");
            //关闭数据库连接
            myData.ConnClose(myConn);
        }
    }
}
