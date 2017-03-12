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
    public partial class new_add : System.Web.UI.Page
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
            string strNewType, strSql;

            strSql = "select * from T_NewType order by sid,id desc";

            ddlNewType.Items.Add( new ListItem("请选择新闻分类", "0"));

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            DataSet myDs = myData.GetDataSet(strSql, myConn);
            myData.InitProTypeList(myDs.Tables[0], 0, ddlNewType, "");
            myDs.Dispose();
            myData.ConnClose(myConn);

            //判断是否有传入参数
            strNewType = Request.QueryString["NewType"];
            if (FunctionClass.CheckStr(strNewType, 1))
            {
                ddlNewType.SelectedValue = strNewType;
            }
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strNewType, strTitle, strAuthor, strOrigin, strIsRecommend, strIsShow, strKeyWords, strContent, strNewPic;
            string strSeo_Title, strSeo_Keywords, strSeo_Description, strSeo_Author;
            string strSql, strNewTip;

            strNewType = ddlNewType.SelectedValue;
            strTitle = tbTitle.Text;
         
            strAuthor = tbAuthor.Text;
            strOrigin = tbOrigin.Text;
            strIsRecommend = cblIsRecommend.SelectedValue;
            strIsShow = cblIsShow.SelectedValue;
            strKeyWords = tbKeyWords.Text;
            strContent = tbContent.Text;
            strNewTip = tbNewTip.Text;

            //SEO选项
            strSeo_Title = tbSeo_Title.Text;
            strSeo_Keywords = tbSeo_Keywords.Text;
            strSeo_Description = tbSeo_Description.Text;
            strSeo_Author = tbSeo_Author.Text;

            //判断title是否为空
            if (strSeo_Title == "")
                strSeo_Title = strTitle;

            FunctionClass myFun = new FunctionClass();

            strNewPic = myFun.UploadFile(fuProPic, "../upload/", "jpg|png|gif|doc|xls|txt|docx|xlsx", 512*10);


            strSql = "insert into T_News (NewType,Title,Author,Origin,IsRecommend,IsShow,KeyWords,[Content],NewPic,NewTip,Seo_Title,Seo_Keywords,Seo_Description,Seo_Author"
                + ") values (@NewType,@Title,@Author,@Origin,@IsRecommend,@IsShow,@KeyWords,@Content,@NewPic,@NewTip,@Seo_Title,@Seo_Keywords,@Seo_Description,@Seo_Author)";

            string[] ParamName = new string[] { "@NewType", "@Title", "@Author", "@Origin", "@IsRecommend", "@IsShow", "@KeyWords", "@Content", "@NewPic", "@NewTip", 
                "@Seo_Title", "@Seo_Keywords", "@Seo_Description", "@Seo_Author" };
            string[] ParamValue = new string[] { strNewType, strTitle, strAuthor, strOrigin, strIsRecommend, strIsShow, strKeyWords, strContent,strNewPic, strNewTip,
                strSeo_Title,strSeo_Keywords,strSeo_Description,strSeo_Author};

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            myData.InsertData(strSql, ParamName, ParamValue, myConn);
            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();

        }
    }
}
