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
    public partial class pro_add : System.Web.UI.Page
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

            strSql = "select * from T_ProType where  IsShow=1 order by PID,SID";

            ddlType.Items.Add(new ListItem("请选择", "0"));

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            DataSet myDs = myData.GetDataSet(strSql, myConn);
            myData.InitProTypeList(myDs.Tables[0], 0, ddlType, "");
            myDs.Dispose();

            myData.ConnClose(myConn);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string strSql, strTypeID, strProName, strProModel, strProTip, strProPic, strIsShow, strIsRecommend, strContent, strKeyWords;
            string strSeo_Title, strSeo_Keywords, strSeo_Description, strSeo_Author, strLinks, strIsNew;
            string strPrice, strPrice1, strProPic1, strProPic2, strProPic3, strProPic4;
            string strProGrade, strProAreas, strProStorage;

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

            strSql = "insert into T_Products (TypeID,ProName,ProModel,ProTip,ProPic,ProPic1,ProPic2,ProPic3,ProPic4,IsShow,IsRecommend,[Content],KeyWords,Seo_Title,Seo_Keywords,Seo_Description,"
                + "Seo_Author,Links,Price,Price1,IsNew,ProGrade,ProAreas,ProStorage) values (@TypeID,@ProName,@ProModel,@ProTip,@ProPic,@ProPic1,@ProPic2,@ProPic3,@ProPic4,@IsShow,@IsRecommend,@Content,@KeyWords,@Seo_Title,@Seo_Keywords,@Seo_Description,"
                + "@Seo_Author,@Links,@Price,@Price1,@IsNew,@ProGrade,@ProAreas,@ProStorage)";
            string[] ParamsName = new string[] { "@TypeID","@ProName","@ProModel","@ProTip","@ProPic","@IsShow","@IsRecommend","@Content","@KeyWords", 
                "@Seo_Title", "@Seo_Keywords", "@Seo_Description", "@Seo_Author","@Links","@Price","@Price1","@ProPic1","@ProPic2",
                "@ProPic3","@ProPic4" ,"@IsNew","@ProGrade","@ProAreas","@ProStorage"};
            string[] ParamsValue = new string[] { strTypeID, strProName,strProModel,strProTip,strProPic,strIsShow,strIsRecommend,strContent,strKeyWords,
                strSeo_Title,strSeo_Keywords,strSeo_Description,strSeo_Author,strLinks ,strPrice,strPrice1,strProPic1,strProPic2,
                strProPic3,strProPic4, strIsNew,strProGrade,strProAreas,strProStorage};

            DataClass myData = new DataClass();
            SqlConnection myConn = myData.ConnOpen();

            myData.InsertData(strSql, ParamsName, ParamsValue, myConn);

            myData.ConnClose(myConn);

            FunctionClass.ShowMsgBox("添加成功！", "");
            Response.End();
        }

        
    }
}
