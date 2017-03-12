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
    public partial class newtype_mod : System.Web.UI.Page
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
            string strSql, strID;

            strID = Request.QueryString["id"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL地址错误！");
                Response.End();
            }

            strSql = "select * from T_NewType order by PID,SID;select * from T_NewType where ID=" + strID;

            ddlType.Items.Add(new ListItem("无", "0"));

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            myData.InitProTypeList(myDs.Tables[0], 0, ddlType, "");

            if (myDs.Tables[1].Rows.Count > 0)
            {
                ddlType.SelectedValue = myDs.Tables[1].Rows[0]["PID"].ToString();
                tbTypeCalled.Text = myDs.Tables[1].Rows[0]["TypeCalled"].ToString();
                if (myDs.Tables[1].Rows[0]["IsShow"].ToString() == "1")
                    cblIsShow.SelectedValue = "1";
                else
                    cblIsShow.SelectedValue = "0";
            }
            else
            {
                myDs.Dispose();
                myData.ConnClose(myConn);

                FunctionClass.ShowMsgBox("没有找到这条信息！");
                Response.End();
            }

            myDs.Dispose();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strPID, strTypeCalled, strIsShow, strSql, strID;

            strID = Request.QueryString["id"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL地址错误！");
                Response.End();
            }

            strPID = ddlType.SelectedValue;
            strTypeCalled = tbTypeCalled.Text;
            strIsShow = cblIsShow.SelectedValue;

            //判断是否选自己为父ID
            if (strPID == strID)
            {
                FunctionClass.ShowMsgBox("不能选自己为父类别！");
                Response.End();
            }

            strSql = "update T_NewType set PID=@PID,TypeCalled=@TypeCalled,IsShow=@IsShow where ID=@ID";
            string[] ParamsName = new string[] { "@PID", "@TypeCalled", "@IsShow", "@ID" };
            string[] ParamsValue = new string[] { strPID, strTypeCalled, strIsShow, strID };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);
            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }
    }
}
