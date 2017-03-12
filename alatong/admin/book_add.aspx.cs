using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Xinyi.Common;
using Xinyi.Data;
namespace ofitech.admin
{
    public partial class book_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strIsShow, strTitle,strReply, strSql, strMemo, strIsRecommend;

            strIsShow = cblIsShow.SelectedValue;
            strIsRecommend = rblIsRecommend.SelectedValue;
            strTitle = tbTitle.Text;
      
            strReply = tbReply.Text;
            strMemo = tbMemo.Text;



            strSql = "insert into T_Book (Title,IsShow,Reply,Memo,IsRecommend) values (@Title,@IsShow,@Reply,@Memo,@IsRecommend)";

            string[] ParamName = new string[] { "@Title", "@IsShow", "@Reply","@Memo","@IsRecommend" };
            string[] ParamValue = new string[] { strTitle, strIsShow, strReply,strMemo,strIsRecommend };
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            myData.InsertData(strSql, ParamName, ParamValue, myConn);
            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();

        }
    }
}
