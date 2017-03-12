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
    public partial class link_add : System.Web.UI.Page
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
            string strSql;

            strSql = "select * from T_LinkType order by SID,ID desc";

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            ddlType.DataTextField = "TypeCalled";
            ddlType.DataValueField = "ID";
            ddlType.DataSource = myDs.Tables[0];
            ddlType.DataBind();
            myDs.Dispose();

            myData.ConnClose(myConn);

            ddlType.Items.Insert(0, new ListItem("请选择", "0"));
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strSql, strTypeID, strCalled,strLink,strPic,strIsShow, strIsShowOther;

            strTypeID = ddlType.SelectedValue;
            strCalled = tbCalled.Text;
            strLink = tbLink.Text;
            strIsShow = cblIsShow.SelectedValue;
            strIsShowOther = cblIsShowOther.SelectedValue;

            FunctionClass myFun = new FunctionClass();

            strPic = myFun.UploadFile(fuProPic, "../upload/", "jpg|png|gif", 512);

            strSql = "insert into T_Link (TypeID,Called,Link,Pic,IsShow,IsShowOther) values (@TypeID,@Called,@Link,@Pic,@IsShow,@IsShowOther)";
            string[] ParamsName = new string[] { "@TypeID", "@Called", "@Link", "@Pic", "@IsShow","@IsShowOther" };
            string[] ParamsValue = new string[] { strTypeID, strCalled, strLink, strPic, strIsShow, strIsShowOther };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();
        }
    }
}
