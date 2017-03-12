﻿using System;
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
    public partial class newtype_add : System.Web.UI.Page
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

            strSql = "select * from T_NewType order by PID,SID";

            ddlType.Items.Add(new ListItem("无", "0"));

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            myData.InitProTypeList(myDs.Tables[0], 0, ddlType, "");
            myDs.Dispose();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strPID, strTypeCalled, strIsShow, strSql;

            strPID = ddlType.SelectedValue;
            strTypeCalled = tbTypeCalled.Text;
            strIsShow = cblIsShow.SelectedValue;

            strSql = "insert into T_NewType (PID,TypeCalled,IsShow) values (@PID,@TypeCalled,@IsShow)";
            string[] ParamsName = new string[] { "@PID", "@TypeCalled", "@IsShow" };
            string[] ParamsValue = new string[] { strPID, strTypeCalled, strIsShow };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);
            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();
        }
    }
}
