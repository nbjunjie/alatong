using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using Xinyi.Common;

namespace web1.admin
{
    public partial class VerifyCodeImg : System.Web.UI.Page
    {
        #region 验证码长度(默认5个验证码的长度)
        public int length = 5;
        #endregion

        #region 验证码字体大小(默认10像素)
        public int fontSize = 11;
        #endregion

        #region 边框补(默认1像素)
        public int padding = 1;
        #endregion

        #region 是否输出燥点(默认输出)
        public bool chaos = true;
        #endregion

        #region 输出燥点的颜色(默认灰色)
        public Color chaosColor = FunctionClass.ConvertColor("#B2CCE2");
        #endregion

        #region 自定义背景色(默认白色)
        public Color backgroundColor = Color.White;
        #endregion

        #region 自定义随机颜色数组
        public Color[] colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
        #endregion

        #region 自定义字体数组
        public string[] fonts = { "Verdana" };
        #endregion

        #region 自定义随机码字符串序列(使用逗号分隔)
        public string codeSerial = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //禁用客户端缓存
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";

            VerifyCode v = new VerifyCode();

            v.Length = this.length;

            v.FontSize = this.fontSize;

            v.Chaos = this.chaos;

            v.BackgroundColor = this.backgroundColor;

            v.ChaosColor = this.chaosColor;

            v.CodeSerial = this.codeSerial;

            v.Colors = this.colors;

            v.Fonts = this.fonts;

            v.Padding = this.padding;

            string code = v.CreateVerifyCode();                //取随机码

            v.CreateImageOnPage(code, this.Context);        // 输出图片

            Session["CheckVerifyCode"] = code.ToLower();            // 使用Session["CheckCode"]取验证码的值
            //Response.Cookies.Add(new HttpCookie("VerifyCode", code.ToLower()));// 使用Cookies取验证码的值
        }
    }
}
