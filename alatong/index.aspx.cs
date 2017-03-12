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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }

        /// <summary>
        /// 绑定和读取数据
        /// </summary>
        private void BindData()
        {
            //定义变量
            string strSql;

            //赋值变量
            strSql = "select * from T_Info where ID=5 or ID=6;"
                + "select top 5 * from T_News where NewType=1 and isShow=1 and IsRecommend=1 order by sid,id desc;"
                + "select top 2 * from T_Book where isShow=1 and isRecommend=1 order by sid,id desc;"
                + "select * from T_Products where isShow=1 and isRecommend=1 order by sid,id desc";

            //判断变量

            //打开数据库连接
            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);

            //关于我们
            DataView myDv = new DataView(myDs.Tables[0], "", "", DataViewRowState.CurrentRows);
            for (int i = 0; i < myDv.Count; i++)
            {
                if (myDv[i]["ID"].ToString() == "5")
                    lbInfo5.Text = myDv[i]["Memo"].ToString();
                else
                    lbInfo6.Text = myDv[i]["Memo"].ToString();
            }
            myDv.Dispose();

            //新闻
            myDv = new DataView(myDs.Tables[1], "", "", DataViewRowState.CurrentRows);
            for (int i = 0; i < myDv.Count; i++)
            {
                lbNews1.Text += "<li class=\"textHidden\"><span>·</span><a href=\"newinfo.aspx?id=" + myDv[i]["ID"].ToString()
                    + "\" target=\"_blank\">" + myDv[i]["Title"].ToString() + "</a>";

                TimeSpan myTs = DateTime.Now - DateTime.Parse(myDv[i]["NoteTime"].ToString());
                if (myTs.Days <= 7)
                    lbNews1.Text += "<img src=\"images/index_17.jpg\" width=\"20\" height=\"11\" alt=\"new\" />";

                lbNews1.Text += "</li>";
            }
            myDv.Dispose();

            //问答
            myDv = new DataView(myDs.Tables[2], "", "", DataViewRowState.CurrentRows);
            for (int i = 0; i < myDv.Count; i++)
            {
                lbBook.Text += "<dl><dt>" + myDv[i]["Title"].ToString() + "</dt>"
                    + "<dd>" + FunctionClass.LeftString(myDv[i]["Memo"].ToString(), 50, "...") + "</dd></dl>";
            }
            myDv.Dispose();

            //产品
            myDv = new DataView(myDs.Tables[3], "", "", DataViewRowState.CurrentRows);
            for (int i = 0; i < myDv.Count; i++)
            {
                lbProducts.Text += "<li><a href="+ FunctionClass.GetImgUrl(myDv[i]["Content"].ToString())
                    + " rel=\"lightbox-my\" title=\"" + myDv[i]["ProName"].ToString()
                    + "\"><img src=\"" + FunctionClass.GetUploadFileRelativeURL(myDv[i]["ProPic"].ToString())
                    +"\" width=\"200\" height=\"133\" alt=\""+myDv[i]["ProName"].ToString()+"\" /></a></li>";
            }
            myDv.Dispose();

            myDs.Dispose();
            //关闭数据库连接
            myData.ConnClose(myConn);
        }
    }
}