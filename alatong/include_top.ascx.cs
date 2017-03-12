using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace alatong
{
    public partial class include_top : System.Web.UI.UserControl
    {
        public string strMenu = "menu";
        public string strIndex = "index";
        public string strMainCss = "top_main1";
        public string strBg = " style='background-image:url(images/index1_11.jpg);'";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定或读取数据
        /// </summary>
        private void BindData()
        {
            //定义变量
            string strFileName;

            //获取本页面文件名称
            strFileName = Request.Url.AbsolutePath.ToLower();
            strFileName = System.IO.Path.GetFileName(strFileName);

            if (strFileName.IndexOf("index.aspx") > -1)
            { 
                strMenu = "menu";
                strIndex = "index";
                strMainCss = "top_main1";
                strBg = "";
            }
            else
            {
                strMenu = "menu1";
                strIndex = "index1";
                strMainCss = "top_main2";

                if (strFileName.IndexOf("about.aspx?id=3") > -1)
                {
                    strBg = " style='background-image:url(images/index1_11.jpg);'";
                }

                if (strFileName.IndexOf("pro") > -1)
                {
                    strBg = " style='background-image:url(images/probg_03.jpg);'";
                }

                if (strFileName.IndexOf("jm") > -1)
                {
                    strBg = " style='background-image:url(images/jmbg_03.jpg);'";
                }

                if (strFileName.IndexOf("new") > -1)
                {
                    strBg = " style='background-image:url(images/newsbg_03.jpg);'";
                }

                if (strFileName.IndexOf("about.aspx?id=4") > -1)
                {
                    strBg = " style='background-image:url(images/contactbg_03.jpg);'";
                }
            }
        }
    }
}