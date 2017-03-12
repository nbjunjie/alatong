using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xinyi.Common;

namespace nb_xy.admin
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Admin_UserID"] = null;
            Session["Admin_UserName"] = null;
            Session["Admin_PassWord"] = null;
            Session["Admin_UserRole"] = null;
            Session["Admin_UserRoleCalled"] = null;
            Session["Admin_UserMenu"] = null;
            Session["Admin_UserMenuUrl"] = null;

            FunctionClass.ShowMsgBox("已经安全退出！", "index.aspx", true);
            Response.End();
        }
    }
}
