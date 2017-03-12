using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xinyi.Common;

namespace web1.admin
{
    public partial class SysInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FunctionClass.CheckAdminLogin(0);
            BindData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            try
            {
                lbServerIP.Text = Request.ServerVariables.Get("Local_Addr").ToString();
                lbServerScript.Text = Environment.Version.ToString();
                lbServerURL.Text = Request.PhysicalApplicationPath;
                lbServerOS.Text = Environment.OSVersion.ToString();
                lbServerFileSize.Text = FunctionClass.FormatFileSize(FunctionClass.GetDirectoryLength(Request.PhysicalApplicationPath), 2);
            }
            catch
            {

            }
        }
    }
}
