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
    public partial class seo_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FunctionClass.CheckAdminLogin(0);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strSql, strPageName, strPageNameCalled, strTitle, strKeyWords, strDescription, strAuthor;

            strPageName = tbPageName.Text;
            strTitle = tbSeo_Title.Text;
            strKeyWords = tbSeo_Keywords.Text;
            strDescription = tbSeo_Description.Text;
            strAuthor = tbSeo_Author.Text;
            strPageNameCalled = tbPageNameCalled.Text;

            FunctionClass myFun = new FunctionClass();

            strSql = "insert into T_Seo (PageName,Title,KeyWords,Description,Author,PageNameCalled) values (@PageName,@Title,@KeyWords,@Description,@Author,@PageNameCalled)";
            string[] ParamsName = new string[] { "@PageName", "@Title", "@KeyWords", "@Description", "@Author", "@PageNameCalled"};
            string[] ParamsValue = new string[] { strPageName, strTitle, strKeyWords, strDescription, strAuthor, strPageNameCalled };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            //判断页面是否存在
            if (myData.CheckDataRowExist("select * from T_Seo where PageName like '" + strPageName.Replace("'", "''") + "'", myConn))
            {
                myData.ConnClose(myConn);
                FunctionClass.ShowMsgBox("该页面已经存在！");
                Response.End();
            }

            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();
        }
    }
}
