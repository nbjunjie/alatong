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
    public partial class new_mod : System.Web.UI.Page
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
                FunctionClass.ShowMsgBox("URL参数错误！");
                Response.End();
            }

            strSql = "select * from T_NewType order by sid;select * from V_News where ID=" + strID;

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            DataSet myDs = myData.GetDataSet(strSql, myConn);

            ddlNewType.Items.Add( new ListItem("请选择新闻分类", "0"));
            myData.InitProTypeList(myDs.Tables[0], 0, ddlNewType, "");

            if (myDs.Tables[1].Rows.Count > 0)
            {
                ddlNewType.SelectedValue = myDs.Tables[1].Rows[0]["NewType"].ToString();
                tbTitle.Text = myDs.Tables[1].Rows[0]["Title"].ToString();
                tbAuthor.Text = myDs.Tables[1].Rows[0]["Author"].ToString();
                tbOrigin.Text = myDs.Tables[1].Rows[0]["Origin"].ToString();
                if (myDs.Tables[1].Rows[0]["IsShow"].ToString() == "1")
                    cblIsShow.SelectedValue = "1";
                else
                    cblIsShow.SelectedValue = "0";
                if (myDs.Tables[1].Rows[0]["IsRecommend"].ToString() == "1")
                    cblIsRecommend.SelectedValue = "1";
                else
                    cblIsRecommend.SelectedValue = "0";
                tbKeyWords.Text = myDs.Tables[1].Rows[0]["KeyWords"].ToString();
                tbContent.Text = myDs.Tables[1].Rows[0]["Content"].ToString();
                imgProPic.ImageUrl = "../" + myDs.Tables[1].Rows[0]["NewPic"].ToString();
                lbDoc.Text = myDs.Tables[1].Rows[0]["NewPic"].ToString();
                if (myDs.Tables[1].Rows[0]["NewPic"].ToString() == "")
                    imgProPic.Visible = false;
                tbNewTip.Text = myDs.Tables[1].Rows[0]["NewTip"].ToString();
                if (imgProPic.ImageUrl == "")
                    imgProPic.Width = 10;
                else
                    imgProPic.Width = 100;

                tbSeo_Title.Text = myDs.Tables[1].Rows[0]["Seo_Title"].ToString();
                tbSeo_Keywords.Text = myDs.Tables[1].Rows[0]["Seo_Keywords"].ToString();
                tbSeo_Description.Text = myDs.Tables[1].Rows[0]["Seo_Description"].ToString();
                tbSeo_Author.Text = myDs.Tables[1].Rows[0]["Seo_Author"].ToString();
            }
            else
            {
                FunctionClass.ShowMsgBox("没有找到这条信息！", "");
                myDs.Dispose();
                myData.ConnClose(myConn);
                Response.End();
            }

            myDs.Dispose();
            myData.ConnClose(myConn);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strNewType, strTitle, strAuthor, strOrigin, strIsRecommend, strIsShow, strKeyWords, strContent, strNewPic;
            string strSeo_Title, strSeo_Keywords, strSeo_Description, strSeo_Author;
            string strSql, strID, strNewTip;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL参数错误！");
                Response.End();
            }

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

            strNewPic = myFun.UploadFile(fuProPic, "../upload/", "jpg|png|gif|doc|xls|txt|docx|xlsx", 512 * 10);


            strSql = "update T_News set NewType=@NewType,Title=@Title,Author=@Author,Origin=@Origin,IsRecommend=@IsRecommend,IsShow=@IsShow,"
                +"KeyWords=@KeyWords,[Content]=@Content,NoteTime=getDate(),NewTip=@NewTip,Seo_Title=@Seo_Title,Seo_Keywords=@Seo_Keywords,"
                + "Seo_Description=@Seo_Description,Seo_Author=@Seo_Author where ID=@ID";

            string[] ParamName = new string[] { "@NewType", "@Title", "@Author", "@Origin", "@IsRecommend", "@IsShow", "@KeyWords", "@Content","@ID","@NewTip", 
                "@Seo_Title", "@Seo_Keywords", "@Seo_Description", "@Seo_Author" };
            string[] ParamValue = new string[] { strNewType, strTitle, strAuthor, strOrigin, strIsRecommend, strIsShow, strKeyWords, strContent,strID,strNewTip,
                strSeo_Title,strSeo_Keywords,strSeo_Description,strSeo_Author };

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();
            myData.InsertData(strSql, ParamName, ParamValue, myConn);

            //判断是否更新图片
            if (strNewPic != "")
                myData.ExecuteSql("update T_News set NewPic='" + strNewPic + "' where ID=" + strID, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();

        }
    }
}
