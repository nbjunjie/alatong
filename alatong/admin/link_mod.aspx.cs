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
    public partial class link_mod : System.Web.UI.Page
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

            strSql = "select * from T_LinkType order by SID,ID desc;select * from T_Link where ID=" + strID;

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            ddlType.DataTextField = "TypeCalled";
            ddlType.DataValueField = "ID";
            ddlType.DataSource = myDs.Tables[0];
            ddlType.DataBind();

            ddlType.Items.Insert(0, new ListItem("请选择", "0"));

            if (myDs.Tables[1].Rows.Count > 0)
            {
                ddlType.SelectedValue = myDs.Tables[1].Rows[0]["TypeID"].ToString();
                tbCalled.Text = myDs.Tables[1].Rows[0]["Called"].ToString();
                tbLink.Text = myDs.Tables[1].Rows[0]["Link"].ToString();
                tbLink.Text = myDs.Tables[1].Rows[0]["Link"].ToString();
                imgPic.ImageUrl = "../"+myDs.Tables[1].Rows[0]["Pic"].ToString();
                if (myDs.Tables[1].Rows[0]["Pic"].ToString() == "")
                    imgPic.Visible = false;
                if (myDs.Tables[1].Rows[0]["IsShow"].ToString() == "1")
                    cblIsShow.SelectedValue = "1";
                else
                    cblIsShow.SelectedValue = "0";
                if (myDs.Tables[1].Rows[0]["IsShowOther"].ToString() == "1")
                    cblIsShowOther.SelectedValue = "1";
                else
                    cblIsShowOther.SelectedValue = "0";
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
            string strSql, strTypeID, strCalled, strLink, strPic, strIsShow, strIsShowOther, strID;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            strTypeID = ddlType.SelectedValue;
            strCalled = tbCalled.Text;
            strLink = tbLink.Text;
            strIsShow = cblIsShow.SelectedValue;
            strIsShowOther = cblIsShowOther.SelectedValue;

            FunctionClass myFun = new FunctionClass();

            strPic = myFun.UploadFile(fuProPic, "../upload/", "jpg|png|gif", 512);

            strSql = "update T_Link set TypeID=@TypeID,Called=@Called,Link=@Link,IsShow=@IsShow,IsShowOther=@IsShowOther where ID=@ID";
            string[] ParamsName = new string[] { "@TypeID", "@Called", "@Link", "@IsShow" ,"@ID","@IsShowOther"};
            string[] ParamsValue = new string[] { strTypeID, strCalled, strLink, strIsShow, strID,strIsShowOther };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);
            if (strPic != "")
                myData.ExecuteSql("update T_Link set Pic='" + strPic + "' where ID=" + strID,myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }
    }
}
