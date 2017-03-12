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
    public partial class paytype_add : System.Web.UI.Page
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
            //
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strTip, strTypeCalled, strMemo, strIsShow, strSql;

            strTypeCalled = tbTypeCalled.Text;
            strTip = tbTip.Text;
            strMemo = tbMemo.Text;
            strIsShow = cblIsShow.SelectedValue;

            strSql = "insert into T_PayType (Tip,TypeCalled,IsShow,Memo) values (@Tip,@TypeCalled,@IsShow,@Memo)";
            string[] ParamsName = new string[] { "@Tip", "@TypeCalled", "@IsShow", "@Memo" };
            string[] ParamsValue = new string[] { strTip, strTypeCalled, strIsShow, strMemo };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);
            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();
        }
    }
}
