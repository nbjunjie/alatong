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
    public partial class paylog_add : System.Web.UI.Page
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

            DataSet myDs = myData.GetDataSet("select * from T_PayType order by sid,id", myConn);

            ddlPayType.DataTextField = "TypeCalled";
            ddlPayType.DataValueField = "ID";
            ddlPayType.DataSource = myDs;
            ddlPayType.DataBind();

            myDs.Dispose();

            ddlPayType.Items.Insert(0, new ListItem("请选择", "0"));

            myData.ConnClose(myConn);

            tbPrice.Attributes.Add("onKeyUp", "value=value.replace(/[^\\-\\.\\d]/g,'')");
            tbUserName.Attributes.Add("onKeyUp", "GetUserList('" + lbUserList.ClientID
                + "',MM_findObj('" + tbUserName.ClientID + "').value)");
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strUserID, strPrice,strPayType,strIsShow, strMemo, strSql;

            strUserID = tbUserID.Text;
            strPrice = tbPrice.Text;
            strPayType = ddlPayType.SelectedValue;
            strIsShow = cblIsShow.SelectedValue;
            strMemo = tbMemo.Text;

            strSql = "insert into T_PayLog (UserID,Price,PayType,IsShow,Memo) values (@UserID,@Price,@PayType,@IsShow,@Memo)";
            string[] ParamsName = new string[] { "@UserID", "@Price", "@PayType", "@IsShow", "@Memo" };
            string[] ParamsValue = new string[] { strUserID, strPrice, strPayType, strIsShow, strMemo };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            long id = myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();
        }
    }
}
