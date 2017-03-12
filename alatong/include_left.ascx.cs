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

namespace alatong
{
    public partial class include_left : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }

        /// <summary>
        /// 读取或绑定数据
        /// </summary>
        private void BindData()
        {
            //定义变量
            string strSql, strTypeID, strFileName, strID;

            //获取本页面文件名称
            strFileName = Request.Url.AbsolutePath.ToLower();
            strFileName = System.IO.Path.GetFileName(strFileName);

            if (strFileName.ToLower().IndexOf("pro") > -1)
                pl1.Visible = true;
            else if (strFileName.ToLower().IndexOf("jm") > -1)
                pl2.Visible = true;
            else
                pl3.Visible = true;

            //赋值变量
            strTypeID = Request.QueryString["TypeID"];
            strID=Request.QueryString["ID"];
            strSql="select * from T_ProType where isShow=1 order by sid,ID";

            //判断变量
            if (!FunctionClass.CheckStr(strTypeID, 1))
                strTypeID = "";
            if(!FunctionClass.CheckStr(strID,1))
                strID="";

            //打开数据库连接
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            
            DataSet myDs=myData.GetDataSet(strSql,myConn);
            
            //产品分类
            DataView myDv=new DataView(myDs.Tables[0],"","",DataViewRowState.CurrentRows);
            for (int i = 0; i < myDv.Count; i++)
            {
                lbPro.Text += "<li";

                if (strTypeID == myDv[i]["ID"].ToString())
                    lbPro.Text += " class=\"curr\"";

                lbPro.Text += "><a href=\"products.aspx?TypeID=" + myDv[i]["ID"].ToString()
                    + "\">" + myDv[i]["TypeCalled"].ToString() + "</a></li>";
            }
            myDv.Dispose();

            myDs.Dispose();

            //关于我们菜单
            lbAbout.Text = "<li";
            if(strID=="3")lbAbout.Text+=" class=\"curr\"";
            lbAbout.Text += "><a href=\"about.aspx?id=3\">关于我们</a></li><li";
            if (strID == "13") lbAbout.Text += " class=\"curr\"";
            lbAbout.Text += "><a href=\"about.aspx?id=13\">店铺风采</a></li><li";
            if(strFileName.IndexOf("new")>-1)lbAbout.Text+=" class=\"curr\"";
            lbAbout.Text+="><a href=\"news.aspx\">新闻动态</a></li><li";
            if(strID=="4")lbAbout.Text+=" class=\"curr\"";
            lbAbout.Text += "><a href=\"about.aspx?id=4\">联系我们</a></li>";

            //加盟菜单
            lbJM.Text = "<li";
            if(strID=="7")lbJM.Text+=" class=\"curr\"";
            lbJM.Text+="><a href=\"jm.aspx?id=7\">加盟条件</a></li><li";
            if(strID=="8")lbJM.Text+=" class=\"curr\"";
            lbJM.Text+="><a href=\"jm.aspx?id=8\">投资预算</a></li><li";
            if(strID=="9")lbJM.Text+=" class=\"curr\"";
            lbJM.Text+="><a href=\"jm.aspx?id=9\">加盟流程</a></li><li";
            if(strID=="10")lbJM.Text+=" class=\"curr\"";
            lbJM.Text+="><a href=\"jm.aspx?id=10\">加盟支持</a></li><li";
            if(strFileName.IndexOf("book")>-1)lbJM.Text+=" class=\"curr\"";
            lbJM.Text += "><a href=\"jm.aspx?id=11\">加盟问答</a></li><li";
            if (strFileName.IndexOf("add") > -1) lbJM.Text += " class=\"curr\"";
            lbJM.Text += "><a href=\"jm_add.aspx\">在线申请</a></li>";

            //关闭数据库连接
            myData.ConnClose(myConn);            
        }
    }
}