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
    public partial class UpdateData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FunctionClass.CheckAdminLogin();
            BindData();
        }

        private void BindData()
        {
            string strResult,strSql, strAction;
            strResult = "";

            strAction = Request.Form["Action"];
            if (strAction == null)
                strAction = "";

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            switch (strAction)
            {
                case "SetShowOrFalse":
                    string strTypeID = Request.Form["TypeID"];
                    string strV = Request.Form["v"];
                    string strID = Request.Form["id"];

                    if (strTypeID == null || strV == null || strID == null)
                    { }
                    else
                    {
                        strSql = this.GetUpdateSql(strTypeID, strV, strID);
                        if (strSql != "")
                            myData.ExecuteSql(strSql, myConn);

                        if (strV == "1")
                            strResult = "0";
                        else
                            strResult = "1";
                    }
                    break;
                case "GetUserList":
                    string strUserName;
                    strUserName = Request.Form["username"];

                    strSql = "select * from T_User where 1=1";

                    if (FunctionClass.CheckStr(strUserName, 0))
                        strSql += " and (Mobile like '%" + strUserName.Replace("'", "''") + "%' or UserName like '%"
                            + strUserName.Replace("'", "''") + "%')";

                    strSql += " order by id desc";

                    SqlDataReader myDr = myData.GetSqlDataReader(strSql, myConn);
                    while (myDr.Read())
                    {
                        strResult += "<br><input type='radio' id='userlist" + myDr["ID"].ToString() + "' name='userlist' value='"
                            + myDr["ID"].ToString() + "' onclick=\"SetUserID(this.value,'" + myDr["UserName"].ToString() + "[" +
                            myDr["Mobile"].ToString() + "]"
                            +"')\"><label for='userlist" + myDr["ID"].ToString() + "'>" + myDr["UserName"].ToString() + "[" +
                            myDr["Mobile"].ToString() + "]" + "</label>";
                    }
                    myDr.Close();
                    myDr.Dispose();
                    break;
                default:
                    break;
            }

            myData.ConnClose(myConn);

            Response.Write(strResult);
            Response.End();
        }

        /// <summary>
        /// 获取跟新语句
        /// </summary>
        /// <param name="strTypeID">更新类型</param>
        /// <param name="strV">值</param>
        /// <param name="strID">id</param>
        /// <returns>sql语句</returns>
        private string GetUpdateSql(string strTypeID, string strV,string strID)
        {
            string strResult = "";
            string strTable, strCellName;

            strTable = "";
            strCellName = "";
            strResult = strV == "1" ? "0" : "1";

            switch (strTypeID)
            {
                case "1":
                    strTable = "T_News";
                    strCellName = "IsShow";
                    break;
                case "2":
                    strTable = "T_News";
                    strCellName = "IsRecommend";
                    break;
                case "3":
                    strTable = "T_Products";
                    strCellName = "IsShow";
                    break;
                case "4":
                    strTable = "T_Products";
                    strCellName = "IsRecommend";
                    break;
                case "5":
                    strTable = "T_Admin";
                    strCellName = "IsLock";
                    break;
                case "6":
                    strTable = "T_AdminMenu";
                    strCellName = "IsShow";
                    break;
                case "7":
                    strTable = "T_Link";
                    strCellName = "IsShow";
                    break;
                case "8":
                    strTable = "T_Link";
                    strCellName = "IsShowOther";
                    break;
                case "9":
                    strTable = "T_User";
                    strCellName = "IsLock";
                    break;
                case "10":
                    strTable = "T_PayLog";
                    strCellName = "IsShow";
                    break;
                default:
                    break;
            }

            if (strTable == "" || strCellName == "")
                strResult = "";
            else
                strResult = "update " + strTable + " set " + strCellName + "=" + strResult + " where ID=" + strID;

            return strResult;
        }
    }
}
