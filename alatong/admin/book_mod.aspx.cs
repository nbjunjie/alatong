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
    public partial class book_mod : System.Web.UI.Page
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

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            strSql = "select * from T_Book where ID=" + strID;

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                lbNoteTime.Text = myDr["NoteTime"].ToString() + "&nbsp;&nbsp;[" + myDr["IP"].ToString() + "]";
                tbRealName.Text = myDr["RealName"].ToString();
                tbTel.Text = myDr["Tel"].ToString();
                tbEMail.Text = myDr["EMail"].ToString();
                tbQQ.Text = myDr["QQ"].ToString();
                cblIsShow.SelectedValue = myDr["IsShow"].ToString();
                tbTitle.Text = myDr["Title"].ToString();
                tbMemo.Text = myDr["Memo"].ToString();
                tbReplyTime.Text = myDr["ReplyTime"].ToString() == "" ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : myDr["ReplyTime"].ToString();
                tbReply.Text = myDr["Reply"].ToString();
                rblIsRecommend.SelectedValue = myDr["IsRecommend"].ToString();
                tbAddress.Text = myDr["Address"].ToString();
            }
            myDr.Close();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strID, strRealName, strTel, strEMail, strQQ, strIsShow, strTitle, strMemo, strReplyTime, strReply, strSql;
            string strIsRecommend, strAddress;
            

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            strRealName = tbRealName.Text;
            strTel = tbTel.Text;
            strEMail = tbEMail.Text;
            strQQ = tbQQ.Text;
            strIsShow = cblIsShow.SelectedValue;
            strTitle = tbTitle.Text;
            strMemo = tbMemo.Text;
            strReplyTime = tbReplyTime.Text;
            strReply = tbReply.Text;
            strIsRecommend = rblIsRecommend.SelectedValue;
            strAddress = tbAddress.Text;

            strSql = "update T_Book set RealName=@RealName,Tel=@Tel,EMail=@EMail,QQ=@QQ,IsShow=@IsShow,Title=@Title,"
                + "Memo=@Memo,ReplyTime=@ReplyTime,Reply=@Reply,IsRecommend=@IsRecommend,Address=@Address where ID=@ID";
            string[] ParamsName = new string[] { "@RealName", "@Tel", "@EMail", "@QQ", "@IsShow", "@Title", "@Memo", 
                "@ReplyTime", "@Reply","@IsRecommend","@Address", "@ID" };
            string[] ParamsValue = new string[] { strRealName, strTel, strEMail, strQQ, strIsShow, strTitle,strMemo,
                strReplyTime,strReply, strIsRecommend,strAddress, strID};

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            long id = myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }
    }
}
