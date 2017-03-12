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

namespace webshop.admin
{
    public partial class paytype_mod : System.Web.UI.Page
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

            DataClass myData=new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            strSql = "select * from T_PayType where ID=" + strID;
            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                tbTypeCalled.Text = myDr["TypeCalled"].ToString();
                tbTip.Text = myDr["Tip"].ToString();
                tbMemo.Text = myDr["Memo"].ToString();
                cblIsShow.SelectedValue = myDr["IsShow"].ToString();
            }
            myDr.Close();
            myDr.Dispose();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strID,strTip, strTypeCalled, strMemo, strIsShow, strSql;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            strTypeCalled = tbTypeCalled.Text;
            strTip = tbTip.Text;
            strMemo = tbMemo.Text;
            strIsShow = cblIsShow.SelectedValue;

            strSql = "update T_PayType set Tip=@Tip,TypeCalled=@TypeCalled,IsShow=@IsShow,Memo=@Memo where ID=@ID";
            string[] ParamsName = new string[] { "@Tip", "@TypeCalled", "@IsShow", "@Memo","@ID" };
            string[] ParamsValue = new string[] { strTip, strTypeCalled, strIsShow, strMemo,strID };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);
            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }
    }
}
