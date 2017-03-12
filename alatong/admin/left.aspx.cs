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
    public partial class left : System.Web.UI.Page
    {
        public string strLeftMenu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string strUserID;

            FunctionClass.CheckAdminLogin(0);
            lbAdmin_UserName.Text = Session["Admin_UserName"].ToString();
            lbAdmin_UserRoleCalled.Text = Session["Admin_UserRoleCalled"].ToString();
            lbIP.Text = Request.UserHostAddress.ToString();
            strUserID = Session["Admin_UserID"].ToString();

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            string strSql = "select * from T_AdminMenu where IsShow=1 order by sid,id";

            DataSet myDs = myData.GetDataSet(strSql, myConn);

            DataView myDv = new DataView(myDs.Tables[0], "PID=0 and AdminUser like '%|"+strUserID+"|%'", "", DataViewRowState.CurrentRows);
            for (int i = 0; i < myDv.Count; i++)
            {
                string strTemp = "";
                string strTemp1="";

                strTemp = tbLeftMenu.Text;

                strTemp = strTemp.Replace("$i$", i.ToString());
                strTemp = strTemp.Replace("$link$", myDv[i]["Link"].ToString());
                strTemp = strTemp.Replace("$title$", myDv[i]["title"].ToString());

                DataView myDv1 = new DataView(myDs.Tables[0], "PID=" + myDv[i]["ID"].ToString() + " and AdminUser like '%|" + strUserID + "|%'", "", DataViewRowState.CurrentRows);
                for (int j = 0; j < myDv1.Count; j++)
                {
                    strTemp1 += "<TR><TD height=20><A href=\"" + myDv1[j]["Link"].ToString() + "\" target=main>" + myDv1[j]["title"].ToString()
                        + "</A></TD></TR>";
                }
                myDv1.Dispose();

                strTemp = strTemp.Replace("$submenu$", strTemp1);

                strLeftMenu += strTemp;
            }
            myDv.Dispose();

            myDs.Dispose();

            myData.ConnClose(myConn);
        }
    }
}
