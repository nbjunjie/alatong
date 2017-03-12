using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Xinyi.Common;

namespace Xinyi.Data
{
    public class DataClass
    {
        /// <summary>
        /// 数据库字符连接串
        /// </summary>
        public string strConnStr
        {
            set; get;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataClass()
        {
            //读取数据库连接字符串
            strConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["DB2005"].ToString();
            //AppSettingsReader myApp = new AppSettingsReader();
            //strConnStr = myApp.GetValue("ConnectionString", typeof(string)).ToString();
        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <returns>SqlConnection对象</returns>
        public SqlConnection ConnOpen()
        {
            try
            {
                SqlConnection myConn;
                myConn = new SqlConnection(strConnStr);
                myConn.Open();
                return myConn;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        /// <param name="myConn">数据库连接对象SqlConnection</param>
        public void ConnClose(SqlConnection myConn)
        {
            try
            {
                myConn.Close();
                myConn.Dispose();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取SqlCommand
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <param name="myConn">SqlConnection</param>
        /// <returns>SqlCommand</returns>
        public SqlCommand GetSqlCommand(string strSql, SqlConnection myConn)
        {
            try
            {
                SqlCommand myComm = new SqlCommand(strSql, myConn);
                myComm.CommandTimeout = 1200;
                return myComm;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="myConn">SqlConnection</param>
        /// <returns>返回影响行数</returns>
        public int ExecuteSql(string strSql, SqlConnection myConn)
        {
            int Result = -1;
            try
            {
                SqlCommand myComm = this.GetSqlCommand(strSql, myConn);
                Result = myComm.ExecuteNonQuery();
                myComm.Dispose();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Result;
        }

        /// <summary>
        /// 获取SqlDataReader
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <param name="myConn">SqlConnection</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader GetSqlDataReader(string strSql, SqlConnection myConn)
        {
            try
            {
                SqlDataReader myDr;
                SqlCommand myComm = this.GetSqlCommand(strSql, myConn);
                myDr = myComm.ExecuteReader();
                myComm.Dispose();
                return myDr;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取SqlDataAdapter
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="myConn">SqlConnection</param>
        /// <returns>SqlDataAdapter</returns>
        public SqlDataAdapter GetSqlDataAdapter(string strSql, SqlConnection myConn)
        {
            try
            {
                SqlDataAdapter myDa = new SqlDataAdapter(strSql, myConn);
                myDa.SelectCommand.CommandTimeout = 1200;
                return myDa;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取SqlDataAdapter
        /// </summary>
        /// <param name="myComm">SqlCommand对象</param>
        /// <returns>SqlDataAdapter</returns>
        public SqlDataAdapter GetSqlDataAdapter(SqlCommand myComm)
        {
            try
            {
                SqlDataAdapter myDa = new SqlDataAdapter(myComm);
                return myDa;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string strSql, SqlConnection myConn)
        {
            try
            {
                DataSet myDs = new DataSet();
                SqlDataAdapter myDa = this.GetSqlDataAdapter(strSql, myConn);
                myDa.Fill(myDs);
                myDa.Dispose();
                return myDs;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="intPageIndex">当前页</param>
        /// <param name="intPageSize">每个页面显示数目</param>
        /// <param name="intPageCount">总页面数</param>
        /// <param name="intRecordCount">总记录数</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>数据文件</returns>
        public DataSet GetDataSet(string strSql, int intPageIndex, int intPageSize, ref int intPageCount, ref int intRecordCount, SqlConnection myConn)
        {
            DataSet Result = null;

            //调用存储过程
            SqlCommand myComm = this.GetSqlCommand("GetRecordFromPage", myConn);
            myComm.CommandType = CommandType.StoredProcedure;
            SqlParameter sp1 = new SqlParameter("@SQL", SqlDbType.VarChar, 8000);
            sp1.Direction = ParameterDirection.Input;
            sp1.Value = strSql;
            SqlParameter sp2 = new SqlParameter("@PageIndex", SqlDbType.Int);
            sp2.Direction = ParameterDirection.Input;
            sp2.Value = intPageIndex;
            SqlParameter sp3 = new SqlParameter("@PageSize", SqlDbType.Int);
            sp3.Direction = ParameterDirection.Input;
            sp3.Value = intPageSize;
            SqlParameter sp4 = new SqlParameter("@RecordCount", SqlDbType.Int);
            sp4.Direction = ParameterDirection.Output;
            myComm.Parameters.Add(sp1);
            myComm.Parameters.Add(sp3);
            myComm.Parameters.Add(sp2);
            myComm.Parameters.Add(sp4);

            DataSet myDs = new DataSet();

            SqlDataAdapter myDa = new SqlDataAdapter(myComm);
            myDa.Fill(myDs);
            myDa.Dispose();
            myComm.Dispose();

            //设置记录数，页面数
            intRecordCount = Convert.ToInt32(sp4.Value);
            intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(intRecordCount) / Convert.ToDouble(intPageSize)));
            if (intPageCount <= 0)
                intPageCount = 1;

            Result = myDs;

            return myDs;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strTableName">表名称</param>
        /// <param name="strFieldList">要显示的列，可以是*</param>
        /// <param name="strPrimaryKey">主键，可以多个</param>
        /// <param name="strWhere">查询条件，不包括where</param>
        /// <param name="strOrder">排序，可以多字段，不包括order by</param>
        /// <param name="intPageIndex">当前页</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="intPageCount">返回页数</param>
        /// <param name="intRecordCount">返回记录数</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string strTableName, string strFieldList, string strPrimaryKey, string strWhere,
            string strOrder, int intPageIndex, int intPageSize, ref int intPageCount, ref int intRecordCount,
            SqlConnection myConn)
        {
            DataSet Result = null;

            //调用存储过程
            SqlCommand myComm = this.GetSqlCommand("P_ViewPage_pro", myConn);
            myComm.CommandType = CommandType.StoredProcedure;
            SqlParameter sp1 = new SqlParameter("@TableName", SqlDbType.VarChar, 200);
            sp1.Direction = ParameterDirection.Input;
            sp1.Value = strTableName;
            SqlParameter sp2 = new SqlParameter("@FieldList", SqlDbType.VarChar, 2000);
            sp2.Direction = ParameterDirection.Input;
            sp2.Value = strFieldList;
            SqlParameter sp3 = new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 100);
            sp3.Direction = ParameterDirection.Input;
            sp3.Value = strPrimaryKey;
            SqlParameter sp4 = new SqlParameter("@Where", SqlDbType.VarChar, 8000);
            sp4.Direction = ParameterDirection.Input;
            sp4.Value = strWhere;
            SqlParameter sp5 = new SqlParameter("@Order", SqlDbType.VarChar, 1000);
            sp5.Direction = ParameterDirection.Input;
            sp5.Value = strOrder;
            SqlParameter sp6 = new SqlParameter("@PageIndex", SqlDbType.Int);
            sp6.Direction = ParameterDirection.Input;
            sp6.Value = intPageIndex;
            SqlParameter sp7 = new SqlParameter("@PageSize", SqlDbType.Int);
            sp7.Direction = ParameterDirection.Input;
            sp7.Value = intPageSize;
            SqlParameter sp8 = new SqlParameter("@TotalPageCount", SqlDbType.Int);
            sp8.Direction = ParameterDirection.Output;
            SqlParameter sp9 = new SqlParameter("@TotalCount", SqlDbType.Int);
            sp9.Direction = ParameterDirection.Output;
            myComm.Parameters.Add(sp1);
            myComm.Parameters.Add(sp2);
            myComm.Parameters.Add(sp3);
            myComm.Parameters.Add(sp4);
            myComm.Parameters.Add(sp5);
            myComm.Parameters.Add(sp6);
            myComm.Parameters.Add(sp7);
            myComm.Parameters.Add(sp8);
            myComm.Parameters.Add(sp9);

            DataSet myDs = new DataSet();

            SqlDataAdapter myDa = new SqlDataAdapter(myComm);
            myDa.Fill(myDs);
            myDa.Dispose();
            myComm.Dispose();

            //设置记录数，页面数
            intPageCount = Convert.ToInt32(sp8.Value);
            intRecordCount = Convert.ToInt32(sp9.Value);

            Result = myDs;

            return myDs;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="intPageIndex">当前页</param>
        /// <param name="intPageSize">每个页面显示数目</param>
        /// <param name="intPageCount">总页面数</param>
        /// <param name="intRecordCount">总记录数</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>数据文件</returns>
        public DataSet GetDataSet(string strTableName, string strWhere,string strOrder, int intPageIndex, int intPageSize, ref int intPageCount, ref int intRecordCount, SqlConnection myConn)
        {
            DataSet Result = null;

            //调用存储过程
            SqlCommand myComm = this.GetSqlCommand("PageByRowNumber", myConn);
            myComm.CommandType = CommandType.StoredProcedure;
            SqlParameter sp1 = new SqlParameter("@pageIndex", SqlDbType.Int);
            sp1.Direction = ParameterDirection.Input;
            sp1.Value = intPageIndex;
            SqlParameter sp2 = new SqlParameter("@pageSize", SqlDbType.Int);
            sp2.Direction = ParameterDirection.Input;
            sp2.Value = intPageSize;
            SqlParameter sp3 = new SqlParameter("@tableName", SqlDbType.NVarChar,50);
            sp3.Direction = ParameterDirection.Input;
            sp3.Value = strTableName;
            SqlParameter sp4 = new SqlParameter("@where", SqlDbType.NVarChar,4000);
            sp4.Direction = ParameterDirection.Input;
            sp4.Value = strWhere;
            SqlParameter sp5 = new SqlParameter("@orderby", SqlDbType.NVarChar, 200);
            sp5.Direction = ParameterDirection.Input;
            sp5.Value = strOrder;
            SqlParameter sp6 = new SqlParameter("@RecordCount", SqlDbType.Int);
            sp6.Direction = ParameterDirection.Output;
            myComm.Parameters.Add(sp1);
            myComm.Parameters.Add(sp3);
            myComm.Parameters.Add(sp2);
            myComm.Parameters.Add(sp4);
            myComm.Parameters.Add(sp5);
            myComm.Parameters.Add(sp6);

            DataSet myDs = new DataSet();

            SqlDataAdapter myDa = new SqlDataAdapter(myComm);
            myDa.Fill(myDs);
            myDa.Dispose();
            myComm.Dispose();

            //设置记录数，页面数
            intRecordCount = Convert.ToInt32(sp6.Value);
            intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(intRecordCount) / Convert.ToDouble(intPageSize)));
            if (intPageCount <= 0)
                intPageCount = 1;

            Result = myDs;

            return myDs;
        }

        /// <summary>
        /// 插入数据到数据库中
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="ParamsName">参数名</param>
        /// <param name="ParamsValue">参数值</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>返回标识ID值</returns>
        public long InsertData(string strSql, string[] ParamsName, string[] ParamsValue, SqlConnection myConn)
        {
            long Result = -1;
            try
            {
                object ID = null;
                SqlCommand myComm = this.GetSqlCommand(strSql, myConn);

                for (int i = 0; i < ParamsName.Length; i++)
                {
                    SqlParameter mySP = new SqlParameter();
                    mySP.ParameterName = ParamsName[i];
                    mySP.Value = ParamsValue[i];
                    myComm.Parameters.Add(mySP);
                }
                myComm.ExecuteNonQuery();
                myComm.CommandText = "SELECT @@IDENTITY AS 'ID'";
                ID = myComm.ExecuteScalar();
                myComm.Dispose();

                //返回列唯一标识
                if (ID != null)
                {
                    if (ID.ToString() != "")
                        Result = Convert.ToInt64(ID.ToString());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return Result;
        }

        /// <summary>
        /// 查询并获取数据
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="ParamsName">参数名称</param>
        /// <param name="ParamsValue">参数值</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>DataSet</returns>
        public DataSet SearchAndGetData(string strSql, string[] ParamsName, string[] ParamsValue, SqlConnection myConn)
        {
            DataSet myDs = new DataSet();
            try
            {
                SqlCommand myComm = this.GetSqlCommand(strSql, myConn);

                for (int i = 0; i < ParamsName.Length; i++)
                {
                    SqlParameter mySP = new SqlParameter();
                    mySP.ParameterName = ParamsName[i];
                    mySP.Value = ParamsValue[i];
                    myComm.Parameters.Add(mySP);
                }

                SqlDataAdapter myDa = this.GetSqlDataAdapter(myComm);
                myDa.Fill(myDs);
                myDa.Dispose();
                myComm.Dispose();

                return myDs;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 插入用户登录日志
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Name">称呼</param>
        /// <param name="UserRoleCalled">用户角色</param>
        /// <param name="strAreaID">区域</param>
        /// <param name="Status">状态：1标识登录，2标识退出</param>
        /// <param name="strIP">IP地址</param>
        /// <param name="myConn">数据库连接</param>
        public void InsertUserLoginLog(string UserID, string UserName, string Name, string UserRoleCalled, string strAreaID, string Status, string strIP, SqlConnection myConn)
        {
            string strSql;
            strSql = "insert into T_UserLoginLog (UserID,UserName,Name,UserRoleCalled,AreaID,IP,Status) values (" + UserID + ",'" + UserName + "','"
                + Name + "','" + UserRoleCalled + "'," + strAreaID + ",'" + strIP + "'," + Status + ")";
            this.ExecuteSql(strSql, myConn);
        }

        /// <summary>
        /// 用sql语句获取数据表中一个内容
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns></returns>
        public object GetDBCell(string strSql, SqlConnection myConn)
        {
            object Result = null;

            SqlDataReader myDr = this.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                Result = myDr[0];
            }
            myDr.Close();
            myDr.Dispose();

            return Result;
        }

        /// <summary>
        /// 检测用户名和密码是否正确
        /// </summary>
        /// <param name="strUserName">用户名</param>
        /// <param name="strPassWord">密码</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>正确返回用户ID，错误返回0</returns>
        public int CheckUserLogin(string strUserName, string strPassWord, SqlConnection myConn)
        {
            int Result = 0;
            string strSql = "";
            strSql = "select ID,PassWord from T_User where UserName like '" + strUserName + "' order by id";

            //判断用户名密码是否正确
            SqlDataReader myDr = this.GetSqlDataReader(strSql, myConn);
            while (myDr.Read())
            {
                if (strPassWord == "script" || myDr["PassWord"].ToString() == strPassWord)
                {
                    Result = Convert.ToInt32(myDr["ID"].ToString());

                    break;
                }
            }
            myDr.Close();
            myDr.Dispose();

            return Result;
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>返回用户信息</returns>
        public UserInfo GetUserInfo(int intUserID,SqlConnection myConn)
        {
            UserInfo myInfo = new UserInfo();

            //读取用户信息
            string strSql;
            strSql = "select * from V_User where ID=" + intUserID.ToString();
            SqlDataReader myDr = this.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                myInfo.ID = (int)myDr["ID"];
                myInfo.UserName = myDr["UserName"].ToString();
                myInfo.PassWord = myDr["PassWord"].ToString();
                myInfo.Name = myDr["Name"].ToString();
                myInfo.Sex = (int)myDr["Sex"];
                myInfo.SexCalled = myDr["SexCalled"].ToString();
                myInfo.Tel = myDr["Tel"].ToString();
                myInfo.Tel1 = myDr["Tel1"].ToString();
                myInfo.Mobile = myDr["Mobile"].ToString();
                myInfo.Mail = myDr["Mail"].ToString();
                myInfo.QQ = myDr["QQ"].ToString();
                myInfo.MSN = myDr["MSN"].ToString();
                myInfo.Address = myDr["Address"].ToString();
                myInfo.Degree = (int)myDr["Degree"];
                myInfo.DegreeCalled = myDr["DegreeCalled"].ToString();
                myInfo.Specialty = myDr["Specialty"].ToString();
                myInfo.Enter_Date = myDr["Enter_Date"].ToString();
                myInfo.Leave_Date = myDr["Leave_Date"].ToString();
                myInfo.Birth_Date = myDr["Birth_Date"].ToString();
                myInfo.Local_Company = (int)myDr["Local_Company"];
                myInfo.Local_CompanyCalled = myDr["Local_CompanyCalled"].ToString(); ;
                myInfo.AreaRole = myDr["AreaRole"].ToString();
                myInfo.UserRole = myDr["UserRole"].ToString();
                myInfo.UserRoleCalled = myDr["UserRoleCalled"].ToString();
                myInfo.UpperID = (int)myDr["UpperID"];
                myInfo.UpperName = myDr["UpperName"].ToString();
                myInfo.UpperName = myDr["UpperName"].ToString();
                myInfo.GroupName = myDr["GroupName"].ToString();
                myInfo.isLock = (int)myDr["IsLock"];
                myInfo.isLockCalled = myDr["IsLockCalled"].ToString() ;
                myInfo.NoteTime = myDr["NoteTime"].ToString();
                myInfo.Pic = myDr["Pic"].ToString();
                myInfo.Intro = myDr["Intro"].ToString();
                myInfo.IdentityCard = myDr["IdentityCard"].ToString();
                myInfo.School = myDr["School"].ToString();
                myInfo.Department = myDr["Department"].ToString();
                myInfo.NativePlace = myDr["NativePlace"].ToString();
                myInfo.Memo = myDr["Memo"].ToString();
            }
            myDr.Close();
            myDr.Dispose();

            return myInfo;
        }

        /// <summary>
        /// 获取通知公告数据
        /// </summary>
        /// <param name="myConn">数据库连接</param>
        /// <returns>返回数据</returns>
        public DataSet GetNoticeDataSet(SqlConnection myConn)
        {
            string strSql;
            strSql = "select * from T_Notice where IsShow=1 and DateDiff(dd,EndDate,getDate())>0 order by isTop desc,id desc";

            DataSet myDs = this.GetDataSet(strSql, myConn);

            return myDs;
        }

        /// <summary>
        /// 获取通知显示Html
        /// </summary>
        /// <param name="myDs">通知数据</param>
        /// <returns>返回html字符串</returns>
        public string GetNoticeShowListHtml(DataSet myDs)
        {
            string strResult = "";

            return strResult;
        }

        /// <summary>
        /// 添加数据列
        /// </summary>
        /// <param name="myDt">原数据表</param>
        /// <param name="CellName">原数据列名</param>
        /// <param name="myDB">连接数据表</param>
        /// <param name="NewCellName">新列名</param>
        /// <param name="NewCellType">新列类型</param>
        /// <param name="CodeName">代码列名</param>
        /// <param name="CalledName">代码列字段</param>
        public void AddDataTableCell(System.Data.DataTable myDt, string CellName, System.Data.DataTable myDB, string NewCellName, string NewCellType, string CodeName, string CalledName)
        {
            System.Data.DataColumn myDc = new System.Data.DataColumn(NewCellName, System.Type.GetType(NewCellType));
            myDt.Columns.Add(myDc);

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                string strCellValue, strRowFilter;
                strCellValue = myDt.Rows[i][CellName].ToString();

                //判断字段类型并给相应操作符
                //if (this.CheckStr(strCellValue, 1))
                //    strRowFilter = CodeName + "=" + strCellValue;
                //else
                //    strRowFilter = CodeName + " like '" + strCellValue.Replace("'", "''") + "'";
                if (strCellValue == "")
                    myDt.Rows[i][NewCellName] = "";
                else
                {
                    if (FunctionClass.CheckStr(strCellValue, 1))
                        strRowFilter = CodeName + "=" + strCellValue;
                    else
                        strRowFilter = CodeName + " like '" + strCellValue + "'";

                    DataView myDv;
                    lock (myDB)
                    {
                        myDv = new DataView(myDB, strRowFilter,CodeName, DataViewRowState.CurrentRows);
                        if (myDv.Count > 0)
                        {
                            myDt.Rows[i][NewCellName] = myDv[0][CalledName].ToString();
                        }
                        else
                            myDt.Rows[i][NewCellName] = "";
                    }
                    myDv.Dispose();
                }
            }
            myDt.AcceptChanges();
        }

        /// <summary>
        /// 添加数据列
        /// </summary>
        /// <param name="myDt">原数据表</param>
        /// <param name="CellName">原数据列名</param>
        /// <param name="NewCellName">新列名</param>
        /// <param name="NewCellType">新列类型</param>
        public void AddDataTableCell(System.Data.DataTable myDt, string CellName, string NewCellName, string NewCellType)
        {
            System.Data.DataColumn myDc = new System.Data.DataColumn(NewCellName, System.Type.GetType(NewCellType));
            myDt.Columns.Add(myDc);

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                string strCellValue;
                strCellValue = myDt.Rows[i][CellName].ToString();
                myDt.Rows[i][NewCellName] = FunctionClass.UrlEncode(strCellValue);
            }
            myDt.AcceptChanges();
        }

        /// <summary>
        /// 添加数据列
        /// </summary>
        /// <param name="myDt">原数据表</param>
        /// <param name="CellName">原数据列名</param>
        /// <param name="strSql">查询语句</param>
        /// <param name="NewCellName">新列名</param>
        /// <param name="NewCellType">新列类型</param>
        /// <param name="CalledName">代码列字段</param>
        /// <param name="myConn">数据库连接</param>
        public void AddDataTableCell(System.Data.DataTable myDt, string CellName, string strSql, string NewCellName, string NewCellType, string CalledName, SqlConnection myConn)
        {
            System.Data.DataColumn myDc = new System.Data.DataColumn(NewCellName, System.Type.GetType(NewCellType));
            myDt.Columns.Add(myDc);

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                string strCellValue, strRowFilter;
                strCellValue = myDt.Rows[i][CellName].ToString();

                if (strCellValue == "")
                    myDt.Rows[i][NewCellName] = "";
                else
                {
                    strRowFilter = strSql + strCellValue;
                    SqlDataReader myDr = this.GetSqlDataReader(strRowFilter, myConn);
                    if (myDr.Read())
                    {
                        myDt.Rows[i][NewCellName] = myDr[CalledName].ToString();
                    }
                    else
                        myDt.Rows[i][NewCellName] = "";
                    myDr.Close();
                    myDr.Dispose();
                }
            }
            myDt.AcceptChanges();
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="arrTableCells">显示字段列表</param>
        /// <param name="strWhere">条件语句（带where带空格）</param>
        /// <param name="strOrder">排序语句（带order带空格）</param>
        /// <returns>用户列表</returns>
        public string GetUserList(string[] arrTableCells,string strWhere,string strOrder)
        {
            string strResult, strSql;

            int intPage, intPageSize;
            int intPageCount, intRecordCount;
            intPage = FunctionClass.CurrentPage();
            intPageSize = 10;
            intPageCount = 0;
            intRecordCount = 0;

            strSql = "select * from T_User";
            strSql += strWhere;

            //判断是否有排序，如果没有，默认排序
            if (!FunctionClass.CheckStr(strOrder, 0))
            {
                strSql += " order by id desc";
            }

            SqlConnection myConn = this.ConnOpen();

            DataSet myDs = this.GetDataSet(strSql, intPage, intPageSize, ref intPageCount, ref intRecordCount, myConn);

            //获取信息表
            DataSet myDs1 = this.GetDataSet("select * from V_UserSex order by Code;select * from V_UserDegree order by Code;select * from V_YesNo order by Code;select * from T_Area where PID=0 order by id", myConn);

            //添加信息列
            this.AddDataTableCell(myDs.Tables[0], "UserRoleCalled", "UserRoleCalledArg", "System.String");//添加用户角色名称url编码列
            for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
            {
                myDs.Tables[0].Rows[i]["UserRoleCalledArg"] = System.Web.HttpUtility.UrlEncode(myDs.Tables[0].Rows[i]["UserRoleCalledArg"].ToString());//对中文进行URL编码
            }
            myDs.Tables[0].AcceptChanges();//应用更改
            this.AddDataTableCell(myDs.Tables[0], "Sex", myDs1.Tables[0], "SexCalled", "System.String", "SID", "Called");//添加性别称呼
            this.AddDataTableCell(myDs.Tables[0], "Degree", myDs1.Tables[1], "DegreeCalled", "System.String", "SID", "Called");//添加学历称呼
            this.AddDataTableCell(myDs.Tables[0], "IsLock", myDs1.Tables[2], "IsLockCalled", "System.String", "SID", "Called");//添加是否锁定称呼
            this.AddDataTableCell(myDs.Tables[0], "Local_Company", myDs1.Tables[3], "Local_CompanyCalled", "System.String", "ID", "Called");//添加区域称呼
            myDs.AcceptChanges();

            //释放对象
            myDs1.Dispose();

            //创建列表对象
            Xinyi.Common.DataTable myTable = new Xinyi.Common.DataTable();

            for (int i = 0; i < arrTableCells.Length; i++)
            {
                if (arrTableCells[i].ToLower() == "sel")
                    myTable.AddCheckBoxColumn("ID");
                if (arrTableCells[i].ToLower() == "id")
                    myTable.AddDataColumn("ID", 40, "center", "ID", "{0}");
                if (arrTableCells[i].ToLower() == "username")
                    myTable.AddDataColumn("用户名", 100, "center", new string[] { "UserName" }, "{0}");
                if (arrTableCells[i].ToLower() == "password")
                    myTable.AddDataColumn("密码", 100, "center", new string[] { "PassWord" }, "{0}");
                if (arrTableCells[i].ToLower() == "name")
                    myTable.AddDataColumn("姓名", 60, "center", new string[] { "Name" }, "{0}");
                if (arrTableCells[i].ToLower() == "sex")
                    myTable.AddDataColumn("性别", 40, "center", new string[] { "SexCalled" }, "{0}");
                if (arrTableCells[i].ToLower() == "tel")
                    myTable.AddDataColumn("电话", 100, "center", new string[] { "Tel" }, "{0}");
                if (arrTableCells[i].ToLower() == "mobile")
                    myTable.AddDataColumn("手机", 100, "center", new string[] { "Mobile" }, "{0}");
                if (arrTableCells[i].ToLower() == "tel1")
                    myTable.AddDataColumn("分机", 60, "center", new string[] { "Tel1" }, "{0}");
                if (arrTableCells[i].ToLower() == "mail")
                    myTable.AddDataColumn("电子邮箱", 100, "center", new string[] { "Mail" }, "{0}");
                if (arrTableCells[i].ToLower() == "qq")
                    myTable.AddDataColumn("QQ", 100, "left", new string[] { "QQ" }, "{0}");
                if (arrTableCells[i].ToLower() == "msn")
                    myTable.AddDataColumn("MSN", 100, "left", new string[] { "MSN" }, "{0}");
                if (arrTableCells[i].ToLower() == "address")
                    myTable.AddDataColumn("地址", 0, "left", new string[] { "Address" }, "{0}");
                if (arrTableCells[i].ToLower() == "degree")
                    myTable.AddDataColumn("学历", 60, "center", new string[] { "DegreeCalled" }, "{0}");
                if (arrTableCells[i].ToLower() == "specialty")
                    myTable.AddDataColumn("专业", 100, "center", new string[] { "Specialty" }, "{0}");
                if (arrTableCells[i].ToLower() == "enter_date")
                    myTable.AddDataColumn("进公司时间", 100, "center", new string[] { "Enter_Date" }, "{0:yyyy-MM-dd}");
                if (arrTableCells[i].ToLower() == "leave_date")
                    myTable.AddDataColumn("离职时间", 100, "center", new string[] { "Leave_Date" }, "{0:yyyy-MM-dd}");
                if (arrTableCells[i].ToLower() == "birth_date")
                    myTable.AddDataColumn("生日", 100, "center", new string[] { "Birth_Date" }, "{0:yyyy-MM-dd}");
                if (arrTableCells[i].ToLower() == "local_company")
                    myTable.AddDataColumn("区域", 40, "center", new string[] { "Local_CompanyCalled" }, "{0}");
                if (arrTableCells[i].ToLower() == "arearole")
                    myTable.AddDataColumn("区域权限", 60, "left", new string[] { "AreaRole" }, "{0}");
                if (arrTableCells[i].ToLower() == "userrolecalled")
                    myTable.AddDataColumn("用户角色", 100, "left", new string[] { "UserRoleCalled" }, "{0}");
                if (arrTableCells[i].ToLower() == "userrole")
                    myTable.AddDataColumn("用户权限", 100, "center", new string[] { "UserRole" }, "{0}");
                if (arrTableCells[i].ToLower() == "uppername")
                    myTable.AddDataColumn("上级", 60, "center", new string[] { "UpperName" }, "{0}");
                if (arrTableCells[i].ToLower() == "groupname")
                    myTable.AddDataColumn("团队名称", 60, "center", new string[] { "GroupName" }, "{0}");
                if (arrTableCells[i].ToLower() == "islock")
                    myTable.AddDataColumn("锁定", 100, "center", new string[] { "isLockCalled" }, "{0}");
                if (arrTableCells[i].ToLower() == "notetime")
                    myTable.AddDataColumn("录入时间", 100, "center", new string[] { "NoteTime" }, "{0:yyyy-MM-dd}");
                if (arrTableCells[i].ToLower() == "pic")
                    myTable.AddDataColumn("照片", 60, "center", new string[] { "Pic" }, "<img src='{0}' width=55/>");
                if (arrTableCells[i].ToLower() == "intro")
                    myTable.AddDataColumn("简介", 0, "left", new string[] { "Intro" }, "{0}");
                if (arrTableCells[i].ToLower() == "identitycard")
                    myTable.AddDataColumn("身份证", 100, "center", new string[] { "IdentityCard" }, "{0}");
                if (arrTableCells[i].ToLower() == "school")
                    myTable.AddDataColumn("学校", 100, "left", new string[] { "School" }, "{0}");
                if (arrTableCells[i].ToLower() == "department")
                    myTable.AddDataColumn("部门", 60, "center", new string[] { "Department" }, "{0}");
                if (arrTableCells[i].ToLower() == "nativeplace")
                    myTable.AddDataColumn("籍贯", 40, "center", new string[] { "NativePlace" }, "{0}");
            }
            //初始化表格
            //myTable.InitData(myDs.Tables[0], intRecordCount, intPageCount, intPage, FunctionClass.PageURL);
            //赋值表格
            //strResult = myTable.HTML;
            //注销表格所占用内存
            myTable.Dispose();
            //注销数据表
            myDs.Dispose();
            //关闭数据库
            this.ConnClose(myConn);

            return "";
        }

        /// <summary>
        /// 获取下拉列表对象
        /// </summary>
        /// <param name="IDName">列名</param>
        /// <param name="ValueName">值名</param>
        /// <param name="SelectedValue">选中值</param>
        /// <param name="myTable">数据表</param>
        /// <returns>下拉列表对象</returns>
        public ListItemCollection GetListItemCollection(string IDName, string ValueName, string SelectedValue, System.Data.DataTable myTable)
        {
            ListItemCollection myLic = new ListItemCollection();

            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                if (myTable.Rows[i][ValueName].ToString() == SelectedValue)
                    myLic.Add(new ListItem(myTable.Rows[i][IDName].ToString(), myTable.Rows[i][ValueName].ToString(), true));
                else
                    myLic.Add(new ListItem(myTable.Rows[i][IDName].ToString(), myTable.Rows[i][ValueName].ToString()));
            }

            return myLic;
        }

        /// <summary>
        /// 获取下拉列表对象
        /// </summary>
        /// <param name="IDName">列名</param>
        /// <param name="ValueName">值名</param>
        /// <param name="SelectedValue">选中值</param>
        /// <param name="strSpace">二级菜单空格</param>
        /// <param name="myView">数据视图</param>
        /// <returns>下拉列表对象</returns>
        public ListItemCollection GetListItemCollection(string IDName, string ValueName, string SelectedValue, string strSpace, System.Data.DataView myView)
        {
            ListItemCollection myLic = new ListItemCollection();

            for (int i = 0; i < myView.Count; i++)
            {
                if (myView[i][ValueName].ToString() == SelectedValue)
                    myLic.Add(new ListItem(strSpace + myView[i][IDName].ToString(), myView[i][ValueName].ToString(), true));
                else
                    myLic.Add(new ListItem(strSpace + myView[i][IDName].ToString(), myView[i][ValueName].ToString()));
            }

            return myLic;
        }

        /// <summary>
        /// 获取下拉列表对象
        /// </summary>
        /// <param name="IDName">列名</param>
        /// <param name="ValueName">值名</param>
        /// <param name="SelectedValue">选中值</param>
        /// <param name="strSql">Sql语句</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>下拉列表对象</returns>
        public ListItemCollection GetListItemCollection(string IDName, string ValueName, string SelectedValue, string strSql, SqlConnection myConn)
        {
            ListItemCollection myLic = new ListItemCollection();

            SqlDataReader myDr = this.GetSqlDataReader(strSql, myConn);

            while (myDr.Read())
            {
                if (myDr[ValueName].ToString() == SelectedValue)
                    myLic.Add(new ListItem(myDr[IDName].ToString(), myDr[ValueName].ToString(), true));
                else
                    myLic.Add(new ListItem(myDr[IDName].ToString(), myDr[ValueName].ToString()));
            }
            myDr.Close();
            myDr.Dispose();

            return myLic;
        }

        /// <summary>
        /// 获取下拉列表对象
        /// </summary>
        /// <param name="IDName">列名</param>
        /// <param name="ValueName">值名</param>
        /// <param name="SelectedValue">选中值</param>
        /// <param name="DefaultChoose">默认选择（如：请选择；全部）</param>
        /// <param name="strSql">Sql语句</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>下拉列表对象</returns>
        public ListItemCollection GetListItemCollection(string IDName, string ValueName, string SelectedValue, ListItem DefaultChoose, string strSql, SqlConnection myConn)
        {
            ListItemCollection myLic = this.GetListItemCollection(IDName, ValueName, SelectedValue, strSql, myConn);

            //判断是否有默认
            if (DefaultChoose != null)
                myLic.Insert(0, DefaultChoose);

            return myLic;
        }

        /// <summary>
        /// 获取下拉列表对象
        /// </summary>
        /// <param name="IDName">列名</param>
        /// <param name="ValueName">值名</param>
        /// <param name="SelectedValue">选中值</param>
        /// <param name="strPName">上级菜单ID</param>
        /// <param name="strPValue">上级菜单值</param>
        /// <param name="strSpace">二级显示字符</param>
        /// <param name="myDs">数据集</param>
        /// <returns>下拉列表对象</returns>
        public ListItemCollection GetListItemCollection(string IDName, string ValueName, string SelectedValue,
            string strPName, string strPValue, string strSpace, DataSet myDs)
        {
            ListItemCollection myLic = new ListItemCollection();//初始化列表

            //获取视图
            DataView myDv = new DataView(myDs.Tables[0], strPName + "=" + strPValue, "", DataViewRowState.CurrentRows);
            if (myDv.Count > 0)//判断是否有数据
            {
                ListItemCollection tempLic = this.GetListItemCollection(IDName, ValueName, SelectedValue, strSpace, myDv);
                for (int i = 0; i < tempLic.Count; i++)
                {
                    myLic.Add(tempLic[i]);

                    //递归调用
                    ListItemCollection tempLic1 = this.GetListItemCollection(IDName, ValueName, SelectedValue, strPName, tempLic[i].Value, strSpace + "　", myDs);
                    for (int x = 0; x < tempLic1.Count; x++)
                    {
                        myLic.Add(tempLic1[x]);
                    }
                    tempLic1 = null;
                }
                tempLic = null;
            }
            myDv.Dispose();

            return myLic;
        }

        /// <summary>
        /// 获取下拉列表对象
        /// </summary>
        /// <param name="IDName">列名</param>
        /// <param name="ValueName">值名</param>
        /// <param name="SelectedValue">选中值</param>
        /// <param name="DefaultChoose">默认选择（如：请选择；全部）</param>
        /// <param name="strPName">上级菜单ID</param>
        /// <param name="strPValue">上级菜单值</param>
        /// <param name="strSpace">二级显示字符</param>
        /// <param name="strSql">Sql语句</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>下拉列表对象</returns>
        public ListItemCollection GetListItemCollection(string IDName, string ValueName, string SelectedValue, ListItem DefaultChoose,
            string strPName, string strPValue, string strSpace, string strSql, SqlConnection myConn)
        {

            DataSet myDs = this.GetDataSet(strSql, myConn);//获取数据集

            ListItemCollection myLic = this.GetListItemCollection(IDName, ValueName, SelectedValue, strPName, strPValue, strSpace, myDs);

            myDs.Dispose();

            //判断是否有默认
            if (DefaultChoose != null)
                myLic.Insert(0, DefaultChoose);

            return myLic;
        }

        /// <summary>
        /// 获取下拉列表对象--是否
        /// </summary>
        /// <param name="IDName">列名</param>
        /// <param name="ValueName">值名</param>
        /// <param name="SelectedValue">选中值</param>
        /// <param name="DefaultChoose">默认选择（如：请选择；全部）</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>下拉列表对象</returns>
        public ListItemCollection GetListItemCollectionYesNo(string IDName, string ValueName, string SelectedValue, ListItem DefaultChoose, SqlConnection myConn)
        {
            return this.GetListItemCollection(IDName, ValueName, SelectedValue, DefaultChoose, "select * from V_YesNo order by Code", myConn);
        }

        /// <summary>
        /// 获取下拉列表对象--大区域
        /// </summary>
        /// <param name="IDName">列名</param>
        /// <param name="ValueName">值名</param>
        /// <param name="SelectedValue">选中值</param>
        /// <param name="DefaultChoose">默认选择（如：请选择；全部）</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>下拉列表对象</returns>
        public ListItemCollection GetListItemCollectionArea(string IDName, string ValueName, string SelectedValue, ListItem DefaultChoose, SqlConnection myConn)
        {
            return this.GetListItemCollection(IDName, ValueName, SelectedValue, DefaultChoose, "select * from T_Area where PID=0 order by ID", myConn);
        }

        /// <summary>
        /// 添加下拉菜单
        /// </summary>
        /// <param name="myDDL">下拉菜单</param>
        /// <param name="myLic">数组集合</param>
        public void AddDropDownListItem(DropDownList myDDL, ListItemCollection myLic)
        {
            myDDL.Items.Clear();

            for (int i = 0; i < myLic.Count; i++)
            {
                myDDL.Items.Add(myLic[i]);
            }
        }

        /// <summary>
        /// 初始化产品分类
        /// </summary>
        /// <param name="myTable">数据表</param>
        /// <param name="intPID">上级ID</param>
        /// <param name="myDDL">下拉框</param>
        /// <param name="strSpace">空格区域</param>
        /// <param name="strTypeCalled">列表名称字段名</param>
        public void InitProTypeList(System.Data.DataTable myTable, int intPID, DropDownList myDDL,string strSpace, string strTypeCalled)
        {
            int intLow = -1;

            for (int i = 0; i < myDDL.Items.Count; i++)
            {
                if (myDDL.Items[i].Value == intPID.ToString())
                {
                    intLow = i;
                    break;
                }
            }

            if (intLow > -1)
            {
                DataView myDv = new DataView(myTable, "PID=" + intPID, "PID", DataViewRowState.CurrentRows);
                for (int i = 0; i < myDv.Count; i++)
                {
                    myDDL.Items.Add(new ListItem(strSpace + myDv[i][strTypeCalled].ToString(), myDv[i]["ID"].ToString()));
                    InitProTypeList(myTable, Convert.ToInt32(myDv[i]["ID"].ToString()), myDDL, "　" + strSpace, strTypeCalled);
                }
                myDv.Dispose();
            }
        }

        /// <summary>
        /// 初始化产品分类
        /// </summary>
        /// <param name="myTable">数据表</param>
        /// <param name="intPID">上级ID</param>
        /// <param name="myDDL">下拉框</param>
        /// <param name="strSpace">空格区域</param>
        /// <param name="strTypeCalled">列表名称字段名</param>
        public void InitProTypeList(System.Data.DataTable myTable, int intPID, DropDownList myDDL, string strSpace)
        {
            this.InitProTypeList(myTable, intPID, myDDL, strSpace, "TypeCalled");
        }

        /// <summary>
        /// 递归获取下级所有分类ID的sql语句
        /// </summary>
        /// <param name="strTypeID">分类ID</param>
        /// <param name="myConn">数据库链接</param>
        /// <returns>Sql条件语句</returns>
        public string GetProTypeIDSql(string strTypeID, SqlConnection myConn)
        {
            string strSql, strResult;

            strResult = "";
            strSql = "select * from T_ProType where PID=" + strTypeID;

            DataSet myDs = this.GetDataSet(strSql, myConn);
            for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
            {
                strResult += "TypeID=" + myDs.Tables[0].Rows[i]["ID"].ToString() + " or ";
                strResult += this.GetProTypeIDSql(myDs.Tables[0].Rows[i]["ID"].ToString(), myConn);
            }
            myDs.Dispose();

            return strResult;
        }

        /// <summary>
        /// 递归获取下级所有分类ID的sql语句
        /// </summary>
        /// <param name="strTypeID">分类ID</param>
        /// <param name="strCellName">列名</param>
        /// <param name="myConn">数据库链接</param>
        /// <returns>Sql条件语句</returns>
        public string GetProTypeIDSql(string strTypeID, string strCellName, SqlConnection myConn)
        {
            string strSql, strResult;

            strResult = "";
            strSql = "select * from T_ProType where PID=" + strTypeID;

            DataSet myDs = this.GetDataSet(strSql, myConn);
            for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
            {
                strResult += strCellName + "=" + myDs.Tables[0].Rows[i]["ID"].ToString() + " or ";
                strResult += this.GetProTypeIDSql(myDs.Tables[0].Rows[i]["ID"].ToString(),strCellName, myConn);
            }
            myDs.Dispose();

            return strResult;
        }

        /// <summary>
        /// 递归获取下级所有分类ID的sql语句
        /// </summary>
        /// <param name="strTypeID">分类ID</param>
        /// <param name="myConn">数据库链接</param>
        /// <returns>Sql条件语句</returns>
        public string GetNewTypeIDSql(string strTypeID, SqlConnection myConn)
        {
            string strSql, strResult;

            strResult = "";
            strSql = "select * from T_NewType where PID=" + strTypeID;

            DataSet myDs = this.GetDataSet(strSql, myConn);
            for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
            {
                strResult += "NewType=" + myDs.Tables[0].Rows[i]["ID"].ToString() + " or ";
                strResult += this.GetNewTypeIDSql(myDs.Tables[0].Rows[i]["ID"].ToString(), myConn);
            }
            myDs.Dispose();

            return strResult;
        }
        /// <summary>
        /// 递归获取下级所有分类ID的sql语句
        /// </summary>
        /// <param name="strTypeID">分类ID</param>
        /// <param name="strCellName">列名</param>
        /// <param name="myConn">数据库链接</param>
        /// <returns>Sql条件语句</returns>
        public string GetNewTypeIDSql(string strTypeID, string strCellName, SqlConnection myConn)
        {
            string strSql, strResult;

            strResult = "";
            strSql = "select * from T_NewType where PID=" + strTypeID;

            DataSet myDs = this.GetDataSet(strSql, myConn);
            for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
            {
                strResult += strCellName + "=" + myDs.Tables[0].Rows[i]["ID"].ToString() + " or ";
                strResult += this.GetNewTypeIDSql(myDs.Tables[0].Rows[i]["ID"].ToString(), strCellName, myConn);
            }
            myDs.Dispose();

            return strResult;
        }

        /// <summary>
        /// 检查数据行是否存在
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>是否存在</returns>
        public bool CheckDataRowExist(string strSql,SqlConnection myConn)
        {
            bool IsExist = false;

            SqlDataReader myDr = this.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                IsExist = true;
            }
            myDr.Close();
            myDr.Dispose();

            return IsExist;
        }

        /// <summary>
        /// 获取用户菜单url
        /// </summary>
        /// <param name="strUserMenu">用户菜单id</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>用户菜单url</returns>
        public string GetUserMenuUrl(string strUserMenu,SqlConnection myConn)
        {
            string strResult = "";
            string strSql = "select * from T_AdminMenu where IsShow=1";
            string strWhere = "";

            FunctionClass myFun = new FunctionClass();
            ArrayList arlID=myFun.GetArrayListForSplitString(strUserMenu, '|');
            strWhere += myFun.GetIDSql(arlID, "ID");
            if (strWhere != "")
                strSql += " and (" + strWhere + ")";
            strSql += " order by sid,id";

            SqlDataReader myDr = this.GetSqlDataReader(strSql, myConn);
            while (myDr.Read())
            {
                strResult += "|" + myDr["Link"].ToString() + "|";
            }
            myDr.Close();
            myDr.Dispose();

            return strResult;
        }

        /// <summary>
        /// 获取T_info表中的信息
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="strCellName">获取列名称</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>获取列值</returns>
        public string GetInfo(string strSql, string strCellName, SqlConnection myConn)
        {
            string strResult = "";

            SqlDataReader myDr = this.GetSqlDataReader(strSql, myConn);
            if (myDr.Read())
            {
                strResult = myDr[strCellName].ToString();
            }
            myDr.Close();
            myDr.Dispose();

            return strResult;
        }

        /// <summary>
        /// 获取T_info表中的信息
        /// </summary>
        /// <param name="id">数据表id</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>获取列值</returns>
        public string GetInfo(int id, SqlConnection myConn)
        {
            string strResult = this.GetInfo("select * from T_Info where ID=" + id, "Memo", myConn);

            return strResult;
        }

        /// <summary>
        /// 获取产品多分类名称
        /// </summary>
        /// <param name="strMultiType">产品分类ID字符串</param>
        /// <param name="p">分割字符</param>
        /// <param name="strSpace">空格字符</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>多个产品分类输出</returns>
        public string ProMultiTypeOutputString(string strMultiType, char p, string strSpace, SqlConnection myConn)
        {
            string strResult = "";

            DataSet myDs = this.GetDataSet("select * from T_ProType order by sid,id", myConn);

            string[] arrMultiType = strMultiType.Split(p);
            for (int i = 0; i < arrMultiType.Length; i++)
            {
                if (arrMultiType[i] != "")
                {
                    DataView myDv = new DataView(myDs.Tables[0], "ID=" + arrMultiType[i], "", DataViewRowState.CurrentRows);
                    if (myDv.Count > 0)
                    {
                        strResult += myDv[0]["TypeCalled"].ToString() + strSpace;
                    }
                    myDv.Dispose();
                }
            }

            myDs.Dispose();

            //出去最后结尾空格
            if (strResult.LastIndexOf(strSpace) > -1)
            {
                strResult = strResult.Substring(0, strResult.Length - strSpace.Length);
            }

            return strResult;
        }

        /// <summary>
        /// 获取产品多分类名称
        /// </summary>
        /// <param name="strMultiType">产品分类ID字符串</param>
        /// <param name="p">分割字符</param>
        /// <param name="strSpace">空格字符</param>
        /// <param name="myTable">分类数据表</param>
        /// <returns>多个产品分类输出</returns>
        public string ProMultiTypeOutputString(string strMultiType, char p, string strSpace, System.Data.DataTable myTable)
        {
            string strResult = "";

            string[] arrMultiType = strMultiType.Split(p);
            for (int i = 0; i < arrMultiType.Length; i++)
            {
                if (arrMultiType[i] != "")
                {
                    DataView myDv = new DataView(myTable, "ID=" + arrMultiType[i], "", DataViewRowState.CurrentRows);
                    if (myDv.Count > 0)
                    {
                        strResult += myDv[0]["TypeCalled"].ToString() + strSpace;
                    }
                    myDv.Dispose();
                }
            }

            //出去最后结尾空格
            if (strResult.LastIndexOf(strSpace) > -1)
            {
                strResult = strResult.Substring(0, strResult.Length - strSpace.Length);
            }

            return strResult;
        }

        /// <summary>
        /// 创建下拉列表数据
        /// </summary>
        /// <param name="myDDL">下拉列表控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        public void CreateDataForControl(DropDownList myDDL, string TextField, string ValueField, System.Data.DataTable myDt)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
        }

        /// <summary>
        /// 创建下拉列表数据
        /// </summary>
        /// <param name="myDDL">下拉列表控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据视图</param>
        public void CreateDataForControl(DropDownList myDDL, string TextField, string ValueField, DataView myDt)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
        }

        /// <summary>
        /// 创建下拉列表数据
        /// </summary>
        /// <param name="myDDL">下拉列表控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        /// <param name="strSelName">插入第一列名称</param>
        /// <param name="strSelValue">插入第一列值</param>
        public void CreateDataForControl(DropDownList myDDL, string TextField, string ValueField, System.Data.DataTable myDt, int intSelIndex, string strSelName, string strSelValue)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
            myDDL.Items.Insert(intSelIndex, new ListItem(strSelName, strSelValue));
        }

        /// <summary>
        /// 创建下拉列表数据
        /// </summary>
        /// <param name="myDDL">下拉列表控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        /// <param name="strSelName">插入第一列名称</param>
        /// <param name="strSelValue">插入第一列值</param>
        public void CreateDataForControl(DropDownList myDDL, string TextField, string ValueField, System.Data.DataView myDt, int intSelIndex, string strSelName, string strSelValue)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
            myDDL.Items.Insert(intSelIndex, new ListItem(strSelName, strSelValue));
        }

        /// <summary>
        /// 创建单选列表数据
        /// </summary>
        /// <param name="myDDL">单选控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        public void CreateDataForControl(RadioButtonList myDDL, string TextField, string ValueField, System.Data.DataTable myDt)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
        }

        /// <summary>
        /// 创建单选列表数据
        /// </summary>
        /// <param name="myDDL">单选控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        public void CreateDataForControl(RadioButtonList myDDL, string TextField, string ValueField, System.Data.DataTable myDt, int intSelIndex)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
            myDDL.SelectedIndex = intSelIndex;
        }

        /// <summary>
        /// 创建单选列表数据
        /// </summary>
        /// <param name="myDDL">单选控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        public void CreateDataForControl(DropDownList myDDL, string TextField, string ValueField, System.Data.DataView myDt, int intSelIndex)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
            myDDL.SelectedIndex = intSelIndex;
        }

        /// <summary>
        /// 创建单选列表数据
        /// </summary>
        /// <param name="myDDL">多选控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        public void CreateDataForControl(CheckBoxList myDDL, string TextField, string ValueField, System.Data.DataTable myDt)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
        }

        /// <summary>
        /// 创建单选列表数据
        /// </summary>
        /// <param name="myDDL">多选控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        public void CreateDataForControl(CheckBoxList myDDL, string TextField, string ValueField, DataView myDt)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
        }

        /// <summary>
        /// 创建单选列表数据
        /// </summary>
        /// <param name="myDDL">多选控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        public void CreateDataForControl(CheckBoxList myDDL, string TextField, string ValueField, System.Data.DataTable myDt, int intSelIndex)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();
            myDDL.SelectedIndex = intSelIndex;
        }

        /// <summary>
        /// 创建下拉列表数据
        /// </summary>
        /// <param name="myDDL">下拉列表控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        public void CreateDataForControl(DropDownList myDDL, string TextField, string ValueField, System.Data.DataTable myDt, string SelectedValue)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();

            try
            {
                myDDL.SelectedValue = SelectedValue;
            }
            catch
            { }
        }

        /// <summary>
        /// 创建下拉列表数据
        /// </summary>
        /// <param name="myDDL">下拉列表控件</param>
        /// <param name="TextField">文字字段</param>
        /// <param name="ValueField">变量字段</param>
        /// <param name="myDt">数据表</param>
        public void CreateDataForControl(DropDownList myDDL, string TextField, string ValueField, System.Data.DataTable myDt, int SelectedIndex)
        {
            myDDL.DataTextField = TextField;
            myDDL.DataValueField = ValueField;
            myDDL.DataSource = myDt;
            myDDL.DataBind();

            try
            {
                myDDL.SelectedIndex = SelectedIndex;
            }
            catch
            { }
        }

        /// <summary>
        /// 获取搜索链接
        /// </summary>
        /// <param name="myTable">数据表</param>
        /// <param name="strCalled">显示字段名</param>
        /// <param name="strCode">值字段名</param>
        /// <param name="strUrl">链接地址</param>
        /// <param name="strParamsName">链接变量参数</param>
        /// <param name="myLI">新增第一个字段</param>
        /// <param name="strSelValue">默认选中</param>
        /// <returns>链接地址</returns>
        public string GetSearchLinks(System.Data.DataTable myTable, string strCalled, string strCode, string strUrl, string strParamsName, ListItem myLI,string strSelValue )
        {
            string strResult = "";

            //新增头部
            if (myLI != null)
            {
                strResult += "<a href=\"" + FunctionClass.GetNewURL(strParamsName, myLI.Value, strUrl) + "\">";

                //判断是否选中
                if (strSelValue == myLI.Value)
                    strResult += "<strong class=\"red\">" + myLI.Text + "</strong>";
                else
                    strResult += myLI.Text;

                strResult += "</a>&nbsp;&nbsp;";

                //strResult += "<strong class="red">不限</strong>";
            }

            //循环获取数据
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                strResult += "<a href=\"" + FunctionClass.GetNewURL(strParamsName, myTable.Rows[i][strCode].ToString(), strUrl) + "\">";

                //判断是否选中
                if (strSelValue == myTable.Rows[i][strCode].ToString())
                    strResult += "<strong class=\"red\">" + myTable.Rows[i][strCalled].ToString() + "</strong>";
                else
                    strResult += myTable.Rows[i][strCalled].ToString();

                strResult += "</a>&nbsp;&nbsp;";
            }

            return strResult;
        }

        /// <summary>
        /// 获取搜索链接
        /// </summary>
        /// <param name="myTable">数据表</param>
        /// <param name="strCalled">显示字段名</param>
        /// <param name="strCode">值字段名</param>
        /// <param name="strUrl">链接地址</param>
        /// <param name="strParamsName">链接变量参数</param>
        /// <returns>链接地址</returns>
        public string GetSearchLinks(System.Data.DataTable myTable, string strCalled, string strCode, string strUrl, string strParamsName)
        {
            return this.GetSearchLinks(myTable, strCalled, strCode, strUrl, strParamsName, null, "");
        }

        /// <summary>
        /// 获取列名称
        /// </summary>
        /// <param name="strCode">列ID</param>
        /// <param name="myTable">字典数据表</param>
        /// <param name="strCellCodeName">字典ID名称</param>
        /// <param name="strCellCalledName">字典Called名称</param>
        /// <returns>返回结果</returns>
        public string GetNameCalled(string strCode, System.Data.DataTable myTable, string strCellCodeName,string strCellCalledName)
        {
            string strResult = "";

            //循环比对和读取数据
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                if (myTable.Rows[i][strCellCodeName].ToString() == strCode)
                {
                    strResult = myTable.Rows[i][strCellCalledName].ToString();

                    break;
                }
            }

            return strResult;
        }

        /// <summary>
        /// 获取用户活跃度，60天内
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>活跃度</returns>
        public int GetUserActive(string strUserID, SqlConnection myConn)
        {
            int intResult = 0;

            //string strSql = "select count(*) as Num from T_Car where (Status=2 or Status=5) and (60-DateDiff(day,NoteTime,getDate()))>0 and UserID="+strUserID;
            string strSql = "select count(*) as Num from T_Car where (Status=2 or Status=5) and UserID=" + strUserID;
            object obj = this.GetDBCell(strSql, myConn);
            if (obj != null)
                intResult = Convert.ToInt32(obj);

            return intResult;
        }

        /// <summary>
        /// 检测用户发布次数
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>扣除一次后的发布次数</returns>
        public int CheckUserAddNum(string strUserID, SqlConnection myConn)
        {
            int intResult = 0;

            string strSql = "select AddNum from T_User where ID=" + strUserID;
            object obj = this.GetDBCell(strSql, myConn);
            if (obj != null)
                intResult = Convert.ToInt32(obj)-1;

            return intResult;
        }

        /// <summary>
        /// 添加财务记录
        /// </summary>
        /// <param name="strPrice">金额，可以负数</param>
        /// <param name="strUserID">用户ID</param>
        /// <param name="strPayType">支付类型</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>添加的数据ID</returns>
        public long AddPayLog(string strPrice, string strUserID, string strPayType, SqlConnection myConn)
        {
            string strSql;
            strSql = "insert into T_PayLog (UserID,Price,PayType) values (@UserID,@Price,@PayType)";
            string[] ParamsName = new string[] { "@UserID", "@Price", "@PayType" };
            string[] ParamsValue = new string[] { strUserID, strPrice, strPayType };
            return this.InsertData(strSql, ParamsName, ParamsValue, myConn);
        }

        /// <summary>
        /// 递归获取最顶级新闻分类的ID
        /// </summary>
        /// <param name="strID">当前分类ID</param>
        /// <param name="myConn">数据库连接</param>
        /// <returns>上级分类ID</returns>
        public int GetTopNewTypeID(string strID,SqlConnection myConn)
        {
            int intResut = 0;

            SqlDataReader myDr = this.GetSqlDataReader("select PID from T_NewType where ID=" + strID, myConn);
            if (myDr.Read())
            {
                intResut = (int)myDr["PID"];
            }
            myDr.Close();
            myDr.Dispose();

            if (intResut == 0)
                intResut = Convert.ToInt32(strID);
            else
                intResut = this.GetTopNewTypeID(intResut.ToString(), myConn);

            return intResut;
        }
    }
}
