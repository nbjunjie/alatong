using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Xinyi.Common;

namespace alatong
{
    public partial class jm_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 发邮箱信息
        /// </summary>
        /// <param name="strFrom">用户名</param>
        /// <param name="strFromPass">密码</param>
        /// <param name="strto">邮箱地址</param>
        /// <param name="strSubject">邮件标题</param>
        /// <param name="strBody">邮件内容</param>
        public void SendSMTPEMail(string strto, string strSubject, string strBody)
        {

            string MailProtocol = "smtp.exmail.qq.com";
            string MailNum = "orderform@e-etires.com";
            string MailPwd = "lijie995966";
            System.Net.Mail.SmtpClient client = new SmtpClient(MailProtocol);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(MailNum, MailPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            System.Net.Mail.MailMessage message = new MailMessage(MailNum, strto, strSubject, strBody);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            client.Send(message);
        }

        /// <summary>
        /// 发送到邮箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btJM_Click(object sender, EventArgs e)
        {
            string _MailAddress = "ala_tong@sina.com"; ;
            string MailBody = string.Format("<html><body>姓名:{0}</br></br>"
                + "手机：{1}<br/><br/>"
                + "情况说明：{2}"
                + "</body><html>", tbUserName.Text, tbMobile.Text, tbMemo.Text);
            string MailTitle = "阿拉桐加盟申请";
            this.SendSMTPEMail(_MailAddress, MailTitle, MailBody);

            FunctionClass.ShowMsgBox("已经申请成功，我们会在3个工作日内联系您！", "jm_add.aspx");
        }
    }
}