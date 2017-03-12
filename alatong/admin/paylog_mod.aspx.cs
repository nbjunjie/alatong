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
    public partial class paylog_mod : System.Web.UI.Page
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
            string strID;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet("select * from T_PayType order by sid,id;select * from V_PayLog where ID="+strID, myConn);

            ddlPayType.DataTextField = "TypeCalled";
            ddlPayType.DataValueField = "ID";
            ddlPayType.DataSource = myDs;
            ddlPayType.DataBind();

            myDs.Dispose();

            ddlPayType.Items.Insert(0, new ListItem("请选择", "0"));

            //赋值
            DataView myDv = new DataView(myDs.Tables[1], "", "", DataViewRowState.CurrentRows);
            if (myDv.Count>0)
            {
                tbUserName.Text = myDv[0]["UserName"].ToString() + "[" + myDv[0]["Mobile"].ToString() + "]";
                tbUserID.Text = myDv[0]["UserID"].ToString();
                tbPrice.Text = myDv[0]["Price"].ToString();
                ddlPayType.SelectedValue = myDv[0]["PayType"].ToString();
                cblIsShow.SelectedValue = myDv[0]["IsShow"].ToString();
            }
            myDv.Dispose();

            myData.ConnClose(myConn);

            tbPrice.Attributes.Add("onKeyUp", "value=value.replace(/[^\\-\\.\\d]/g,'')");
            tbUserName.Attributes.Add("onKeyUp", "GetUserList('" + lbUserList.ClientID
                + "',MM_findObj('" + tbUserName.ClientID + "').value)");
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strID, strUserID, strPrice, strPayType, strIsShow, strMemo, strSql;

            strUserID = tbUserID.Text;
            strPrice = tbPrice.Text;
            strPayType = ddlPayType.SelectedValue;
            strIsShow = cblIsShow.SelectedValue;
            strMemo = tbMemo.Text;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            strSql = "update T_PayLog set UserID=@UserID,Price=@Price,PayType=@PayType,IsShow=@IsShow,Memo=@Memo,NoteTime=getDate() where ID=@ID";
            string[] ParamsName = new string[] { "@UserID", "@Price", "@PayType", "@IsShow", "@ID", "@Memo" };
            string[] ParamsValue = new string[] { strUserID, strPrice, strPayType, strIsShow, strID, strMemo };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            long id = myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }
    }
}
