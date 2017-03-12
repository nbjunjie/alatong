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
    public partial class pro_mod : System.Web.UI.Page
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

            strSql = "select * from T_ProType order  by PID,SID;select * from T_Products where ID=" + strID;

            ddlType.Items.Add(new ListItem("请选择", "0"));

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            myData.InitProTypeList(myDs.Tables[0], 0, ddlType, "");

            if (myDs.Tables[1].Rows.Count > 0)
            {
                ddlType.SelectedValue = myDs.Tables[1].Rows[0]["TypeID"].ToString();
                tbProName.Text = myDs.Tables[1].Rows[0]["ProName"].ToString();
                tbProModel.Text = myDs.Tables[1].Rows[0]["ProModel"].ToString();
                tbProTip.Text = myDs.Tables[1].Rows[0]["ProTip"].ToString();
                tbKeyWords.Text = myDs.Tables[1].Rows[0]["KeyWords"].ToString();
                tbContent.Text = myDs.Tables[1].Rows[0]["Content"].ToString();
                imgProPic.ImageUrl = myDs.Tables[1].Rows[0]["ProPic"].ToString();
                if (myDs.Tables[1].Rows[0]["ProPic"].ToString() == "")
                    imgProPic.Visible = false;
                imgProPic1.ImageUrl = myDs.Tables[1].Rows[0]["ProPic1"].ToString();
                if (myDs.Tables[1].Rows[0]["ProPic1"].ToString() == "")
                    imgProPic1.Visible = false;
                imgProPic2.ImageUrl = myDs.Tables[1].Rows[0]["ProPic2"].ToString();
                if (myDs.Tables[1].Rows[0]["ProPic2"].ToString() == "")
                    imgProPic2.Visible = false;
                imgProPic3.ImageUrl = myDs.Tables[1].Rows[0]["ProPic3"].ToString();
                if (myDs.Tables[1].Rows[0]["ProPic3"].ToString() == "")
                    imgProPic3.Visible = false;
                imgProPic4.ImageUrl = myDs.Tables[1].Rows[0]["ProPic4"].ToString();
                if (myDs.Tables[1].Rows[0]["ProPic4"].ToString() == "")
                    imgProPic4.Visible = false;

                lbtDelPic.ToolTip = "1|" + myDs.Tables[1].Rows[0]["ProPic"].ToString();
                lbtDelPic1.ToolTip = "2|" + myDs.Tables[1].Rows[0]["ProPic1"].ToString();
                lbtDelPic2.ToolTip = "3|" + myDs.Tables[1].Rows[0]["ProPic2"].ToString();
                lbtDelPic3.ToolTip = "4|" + myDs.Tables[1].Rows[0]["ProPic3"].ToString();

                if (myDs.Tables[1].Rows[0]["IsShow"].ToString() == "1")
                    cblIsShow.SelectedValue = "1";
                else
                    cblIsShow.SelectedValue = "0";
                if (myDs.Tables[1].Rows[0]["IsRecommend"].ToString() == "1")
                    cblIsRecommend.SelectedValue = "1";
                else
                    cblIsRecommend.SelectedValue = "0";
                if (myDs.Tables[1].Rows[0]["IsNew"].ToString() == "1")
                    rblIsNew.SelectedValue = "1";
                else
                    rblIsNew.SelectedValue = "0";

                tbSeo_Title.Text = myDs.Tables[1].Rows[0]["Seo_Title"].ToString();
                tbSeo_Keywords.Text = myDs.Tables[1].Rows[0]["Seo_Keywords"].ToString();
                tbSeo_Description.Text = myDs.Tables[1].Rows[0]["Seo_Description"].ToString();
                tbSeo_Author.Text = myDs.Tables[1].Rows[0]["Seo_Author"].ToString();
                tbLinks.Text = myDs.Tables[1].Rows[0]["Links"].ToString();
                tbPrice.Text = myDs.Tables[1].Rows[0]["Price"].ToString();
                tbPrice1.Text = myDs.Tables[1].Rows[0]["Price1"].ToString();
                tbProGrade.Text = myDs.Tables[1].Rows[0]["ProGrade"].ToString();
                tbProAreas.Text = myDs.Tables[1].Rows[0]["ProAreas"].ToString();
                tbProStorage.Text = myDs.Tables[1].Rows[0]["ProStorage"].ToString();
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
            string strSql, strTypeID, strProName, strProModel, strProTip, strProPic, strIsShow, strIsRecommend, strContent, strKeyWords;
            string strSeo_Title, strSeo_Keywords, strSeo_Description, strSeo_Author, strIsNew;
            string strID, strLinks, strPrice, strPrice1, strProPic1, strProPic2, strProPic3, strProPic4;
            string strProGrade, strProAreas, strProStorage;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            strTypeID = ddlType.SelectedValue;
            strProName = tbProName.Text;
            strProModel = tbProModel.Text;
            strProTip = tbProTip.Text;
            strIsShow = cblIsShow.SelectedValue;
            strIsRecommend = cblIsRecommend.SelectedValue;
            strContent = tbContent.Text;
            strKeyWords = tbKeyWords.Text;
            strLinks = tbLinks.Text;
            strPrice = tbPrice.Text;
            strPrice1 = tbPrice1.Text;
            strIsNew = rblIsNew.SelectedValue;
            strProGrade = tbProGrade.Text;
            strProAreas = tbProAreas.Text;
            strProStorage = tbProStorage.Text;

            //SEO选项
            strSeo_Title = tbSeo_Title.Text;
            strSeo_Keywords = tbSeo_Keywords.Text;
            strSeo_Description = tbSeo_Description.Text;
            strSeo_Author = tbSeo_Author.Text;

            //判断title是否为空
            if (strSeo_Title == "")
                strSeo_Title = strProName;

            FunctionClass myFun = new FunctionClass();

            strProPic = myFun.UploadFile(fuProPic, "../upload/", "jpg|png|gif", 512);
            strProPic1 = myFun.UploadFile(fuProPic1, "../upload/", "jpg|png|gif", 512);
            strProPic2 = myFun.UploadFile(fuProPic2, "../upload/", "jpg|png|gif", 512);
            strProPic3 = myFun.UploadFile(fuProPic3, "../upload/", "jpg|png|gif", 512);
            strProPic4 = myFun.UploadFile(fuProPic4, "../upload/", "jpg|png|gif", 512);

            strSql = "update T_Products set TypeID=@TypeID,ProName=@ProName,ProModel=@ProModel,ProTip=@ProTip,IsShow=@IsShow,IsRecommend=@IsRecommend,"
                +"[Content]=@Content,KeyWords=@KeyWords,Seo_Title=@Seo_Title,Seo_Keywords=@Seo_Keywords,"
                + "Seo_Description=@Seo_Description,Seo_Author=@Seo_Author,Links=@Links,Price=@Price,Price1=@Price1,"
                + "IsNew=@IsNew,ProGrade=@ProGrade,"
                + "ProAreas=@ProAreas,ProStorage=@ProStorage where ID=@ID";
            string[] ParamsName = new string[] { "@TypeID", "@ProName", "@ProModel", "@ProTip", "@IsShow", "@IsRecommend", "@Content", "@KeyWords" ,"@ID", 
                "@Seo_Title", "@Seo_Keywords", "@Seo_Description", "@Seo_Author" ,"@Links","@Price","@Price1","@IsNew","@ProGrade","@ProAreas","@ProStorage"};
            string[] ParamsValue = new string[] { strTypeID, strProName, strProModel, strProTip, strIsShow, strIsRecommend, strContent, strKeyWords, strID,
                strSeo_Title,strSeo_Keywords,strSeo_Description,strSeo_Author,strLinks,strPrice,strPrice1, strIsNew,strProGrade,strProAreas,strProStorage};

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            //判断是否更新图片
            if (strProPic != "")
                myData.ExecuteSql("update T_Products set ProPic='" + strProPic + "' where ID=" + strID, myConn);
            if (strProPic1 != "")
                myData.ExecuteSql("update T_Products set ProPic1='" + strProPic1 + "' where ID=" + strID, myConn);
            if (strProPic2 != "")
                myData.ExecuteSql("update T_Products set ProPic2='" + strProPic2 + "' where ID=" + strID, myConn);
            if (strProPic3 != "")
                myData.ExecuteSql("update T_Products set ProPic3='" + strProPic3 + "' where ID=" + strID, myConn);
            if (strProPic4 != "")
                myData.ExecuteSql("update T_Products set ProPic4='" + strProPic4 + "' where ID=" + strID, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("修改成功！", "");
            Response.End();
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtDelPic_Click(object sender, EventArgs e)
        {
            string strSql, strID;

            strID = Request.QueryString["ID"];
            if (!FunctionClass.CheckStr(strID, 1))
            {
                FunctionClass.ShowMsgBox("URL错误！");
                Response.End();
            }

            string[] arrTs = ((LinkButton)sender).ToolTip.Split('|');

            if (arrTs.Length == 2)
            {
                strSql = "update T_Products set ProPic";
                if (arrTs[0] == "2")
                    strSql += "1";
                else if (arrTs[0] == "3")
                    strSql += "2";
                else if (arrTs[0] == "4")
                    strSql += "3";

                strSql += "='' where ID=" + strID;

                //更新数据
                DataClass myData = new DataClass();
                SqlConnection myConn = myData.ConnOpen();

                myData.ExecuteSql(strSql, myConn);

                myData.ConnClose(myConn);

                //删除文件
                if (arrTs[1].ToString().Trim() != "")
                { 
                    string strFilePath=Server.MapPath("../"+FunctionClass.GetUploadFileRelativeURL(arrTs[1]));
                    if (System.IO.File.Exists(strFilePath))
                    {
                        System.IO.File.Delete(strFilePath);
                    }
                }

                FunctionClass.ShowMsgBox("删除成功！", "pro_mod.aspx?id=" + strID);
            }
        }
        
    }
}
