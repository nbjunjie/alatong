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
    public partial class orderform_mod : System.Web.UI.Page
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

            strSql = "select * from T_OrderFormStatus order by sid,id;select * from T_OrderForm where ID=" + strID;

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);

            ddlStatus.DataTextField = "TypeCalled";
            ddlStatus.DataValueField = "ID";
            ddlStatus.DataSource = myDs.Tables[0];
            ddlStatus.DataBind();

            DataView myDv = new DataView(myDs.Tables[1], "", "", DataViewRowState.CurrentRows);
            if (myDv.Count > 0)
            {
                ddlStatus.SelectedValue = myDv[0]["Status"].ToString();
                ddlStatus.ToolTip = myDv[0]["Status"].ToString();
                tbPrice.Text = myDv[0]["Price"].ToString();
                tbPrice.ToolTip = myDv[0]["Price"].ToString();
                tbPayPrice.Text = myDv[0]["PayPrice"].ToString();
                cblIsBilling.SelectedValue = myDv[0]["IsBilling"].ToString();
                lbPro.Text = myDv[0]["ProName"].ToString();
                lbProName.Text = "<b>" + myDv[0]["ProName"].ToString() + "&nbsp;&nbsp;下单时间：" + myDv[0]["NoteTime"].ToString() + "</b><br>"
                    + myDv[0]["Detail"].ToString();
                lbProName.ToolTip = myDv[0]["ProID"].ToString();
                lbUserName.Text = myDv[0]["UserName"].ToString();
                lbUserName.ToolTip = myDv[0]["UserID"].ToString();
                tbMobile.Text = myDv[0]["Mobile"].ToString();
                tbTel.Text = myDv[0]["Tel"].ToString();
                tbFax.Text = myDv[0]["Fax"].ToString();
                tbAddress.Text = myDv[0]["Address"].ToString();
                tbEMail.Text = myDv[0]["EMail"].ToString();
                tbCompany.Text = myDv[0]["Company"].ToString();
                tbMemo.Text = myDv[0]["Memo"].ToString();
            }
            myDv.Dispose();

            myDs.Dispose();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strID, strSql, strStatus, strPrice, strPayPrice, strIsBilling, strMobile, strTel, strFax, strEMail, strAddress, strCompany, strMemo;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            strStatus = ddlStatus.SelectedValue;
            strPrice = tbPrice.Text;
            strPayPrice = tbPayPrice.Text;
            strIsBilling = cblIsBilling.SelectedValue;
            strMobile = tbMobile.Text;
            strTel = tbTel.Text;
            strFax = tbFax.Text;
            strEMail = tbEMail.Text;
            strAddress = tbAddress.Text;
            strCompany = tbCompany.Text;
            strMemo = tbMemo.Text;

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            strSql = "update T_OrderForm set Status=@Status,Price=@Price,PayPrice=@PayPrice,IsBilling=@IsBilling,Mobile=@Mobile,Tel=@Tel,"
                + "Fax=@Fax,EMail=@EMail,Address=@Address,Company=@Company,Memo=@Memo where ID=@ID";
            string[] ParamsName = new string[] { "@Status","@Price","@PayPrice","@IsBilling","@Mobile","@Tel","@Fax","@EMail",
                "@Address","@Company","@Memo","@ID"};
            string[] ParamsValue = new string[] { strStatus, strPrice, strPayPrice, strIsBilling, strMobile, strTel,strFax,strEMail,
                strAddress, strCompany, strMemo, strID};

            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            //判断是否变更了订单价格，如果是那么增加价格日志
            if (tbPrice.ToolTip != strPrice)
            {
                //myData.InsertPriceLog(strID, "订单价格修改为：" + strPrice + "元&nbsp;[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm")
                //    + "]<br>", myConn);
            }

            //判断实际支付是否完成
            if(strPayPrice==strPrice)
                myData.ExecuteSql("update T_OrderForm set IsPay=1 where ID=" + strID, myConn);
            else
                myData.ExecuteSql("update T_OrderForm set IsPay=0 where ID=" + strID, myConn);

            //保存订单日志
            if (strStatus != ddlStatus.ToolTip)//判断是否更新状态
            {
                string strStatusCalled = myData.GetInfo("select Memo from T_OrderFormStatus where ID=" + strStatus, "Memo", myConn);
                strSql = "insert into T_OrderFormLog (OrderID,Status,Memo,UserName) values (@OrderID,@Status,@Memo,@UserName)";
                string[] ParamsName2 = new string[] { "@OrderID", "@Status", "@Memo", "@UserName" };
                string[] ParamsValue2 = new string[] { strID, strStatus, strStatusCalled, Session["Admin_UserRoleCalled"].ToString() };

                myData.InsertData(strSql, ParamsName2, ParamsValue2, myConn);
            }

            //新增扣款记录
            if (cbIsAddPayLog.Checked && strPayPrice != "0")
            {
                strSql = "insert into T_PayLog (UserID,Price,PayType,IsShow,Memo) values (@UserID,@Price,@PayType,@IsShow,@Memo)";
                string[] ParamsName3 = new string[] { "@UserID", "@Price", "@PayType", "@IsShow", "@Memo" };
                string[] ParamsValue3 = new string[] { lbUserName.ToolTip, "-" + strPayPrice, "6", "1", lbPro.Text };
                myData.InsertData(strSql, ParamsName3, ParamsValue3, myConn);
            }

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！","");
            Response.End();
        }
    }
}
