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
    public partial class seo_mod : System.Web.UI.Page
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

            strSql = "select * from T_Seo where ID=" + strID;

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);

            if (myDs.Tables[0].Rows.Count > 0)
            {
                lbPageName.Text= myDs.Tables[0].Rows[0]["PageName"].ToString();
                tbSeo_Title.Text = myDs.Tables[0].Rows[0]["Title"].ToString();
                tbSeo_Keywords.Text = myDs.Tables[0].Rows[0]["Keywords"].ToString();
                tbSeo_Description.Text = myDs.Tables[0].Rows[0]["Description"].ToString();
                tbSeo_Author.Text = myDs.Tables[0].Rows[0]["Author"].ToString();
                tbPageNameCalled.Text = myDs.Tables[0].Rows[0]["PageNameCalled"].ToString();
            }
            else
            {
                myDs.Dispose();
                myData.ConnClose(myConn);

                FunctionClass.ShowMsgBox("没有找到这条数据记录！");
                Response.End();
            }

            myDs.Dispose();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strSql, strID, strTitle, strKeyWords, strDescription, strAuthor, strPageNameCalled;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            strTitle = tbSeo_Title.Text;
            strKeyWords = tbSeo_Keywords.Text;
            strDescription = tbSeo_Description.Text;
            strAuthor = tbSeo_Author.Text;
            strPageNameCalled = tbPageNameCalled.Text;

            FunctionClass myFun = new FunctionClass();

            strSql = "update T_Seo set Title=@Title,KeyWords=@KeyWords,Description=@Description,Author=@Author,PageNameCalled=@PageNameCalled where ID=@ID";
            string[] ParamsName = new string[] { "@Title", "@KeyWords", "@Description", "@Author", "@ID", "@PageNameCalled" };
            string[] ParamsValue = new string[] { strTitle, strKeyWords, strDescription, strAuthor, strID, strPageNameCalled };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }
    }
}
