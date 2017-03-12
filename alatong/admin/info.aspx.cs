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
    public partial class info : System.Web.UI.Page
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
            string strID,strSql;

            strID = Request.QueryString["ID"];

            //如果为空，默认第一条
            if (strID == null || strID == "")
            {
               
                strID = "1";

            }else
            {
                laMeno1.Text = "";
                laMeno2.Text = "";
            }
           
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL参数格式输入错误！");
                Response.End();
            }

            strSql = "select * from T_Info order by SID asc";

            DataClass myData=new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            SqlDataReader myDr=myData.GetSqlDataReader(strSql,myConn);
            //初始化下拉列表数据
            while (myDr.Read())
            {
                ddlType.Items.Add(new ListItem(myDr["Called"].ToString(), myDr["ID"].ToString()));
                if (strID == myDr["ID"].ToString())
                {
                    ddlType.SelectedValue = myDr["ID"].ToString();
                    tbMemo.Text = myDr["Memo"].ToString();
                }
            }
            myDr.Close();
            myDr.Dispose();

            myData.ConnClose(myConn);

            Session["UserViewURL"] = FunctionClass.PageURL;
        }

        /// <summary>
        /// 切换信息种类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("info.aspx?id=" + ((DropDownList)sender).SelectedValue, true);
        }

        /// <summary>
        /// 提交修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strID, strSql, strMemo;

            strMemo = tbMemo.Text;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
                strID = "1";

            strSql = "update T_Info set Memo=@Memo where ID=@ID";

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            string[] ParamsName = new string[] { "@Memo", "@ID" };
            string[] ParamsValue = new string[] { strMemo, strID };

            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("信息更新成功！", FunctionClass.PageURL);
            Response.End();
        }
    }
}
