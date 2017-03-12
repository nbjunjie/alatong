<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_add.aspx.cs" Inherits="webshop.admin.user_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加会员用户</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server"><br/>
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【添加会员用户】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">真实姓名：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbUserName" runat="server" Width="200px"></asp:TextBox>
          &nbsp;[必填] 请输入真是姓名！<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="tbUserName" Display="None" ErrorMessage="请填写您的真实姓名！" 
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">手机号码：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbMobile" runat="server" Width="200px"></asp:TextBox>
          &nbsp;[必填] 请输入手机号码/登录ID！<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="tbMobile" Display="None" 
                                            ErrorMessage="请填写您正在使用的手机号码！务必真实有效！" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:regularexpressionvalidator id="RegularExpressionValidator8" runat="server" ControlToValidate="tbMobile"
										Display="None" ErrorMessage="手机号码只能为11位的半角数字！请关闭中文输入法。" ValidationExpression="[0-9]{11}" 
                                            SetFocusOnError="True"></asp:regularexpressionvalidator></td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">登录密码：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbPassWord" runat="server" Width="200px"></asp:TextBox>
          &nbsp;[必填] 请输入用户的密码！<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="tbPassWord" Display="None" 
                                            ErrorMessage="请设定一个登录密码！" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">固定电话：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbTel" runat="server" Width="200px"></asp:TextBox>
          &nbsp;用户固定电话！
                                        <asp:regularexpressionvalidator id="RegularExpressionValidator7" runat="server" 
                                            ControlToValidate="tbTel" Display="none"
										ErrorMessage="电话号码只能为数字" ValidationExpression="[0-9-]*" SetFocusOnError="True"></asp:regularexpressionvalidator>
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">传真号码：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbFax" runat="server" Width="200px"></asp:TextBox>
          &nbsp;用户传真号码！
                                        <asp:regularexpressionvalidator id="RegularExpressionValidator9" runat="server" 
                                            ControlToValidate="tbFax" Display="none"
										ErrorMessage="传真号码只能为数字" ValidationExpression="[0-9-]*" SetFocusOnError="True"></asp:regularexpressionvalidator>
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">电子邮箱：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbEMail" runat="server" Width="200px"></asp:TextBox>
          &nbsp;用户电子邮箱！
                                        <asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" 
                                            ControlToValidate="tbEMail" Display="None"
										ErrorMessage="电子邮件格式错误" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                            SetFocusOnError="True"></asp:regularexpressionvalidator>
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">QQ：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbQQ" runat="server" Width="200px"></asp:TextBox>
          &nbsp;QQ！
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">公司名称：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbCompany" runat="server" Width="200px"></asp:TextBox>
          &nbsp;用户公司名称！
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">用户类型：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:DropDownList ID="ddlUserType" runat="server">
          </asp:DropDownList>      
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">通讯地址：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbAddress" runat="server" Width="500px"></asp:TextBox>
          &nbsp;用户的通讯地址！
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">其他信息：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbMemo" runat="server" Width="500px" Height="50px"></asp:TextBox>
          &nbsp;
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">是否锁定：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="cblIsLock" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="1">锁定</asp:ListItem>
              <asp:ListItem Selected="True" Value="0">不锁定</asp:ListItem>
          </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
      <td align="right" class="forumrow"></td>
      <td class="forumrowhighlight"><asp:Button ID="btSubmit" runat="server" Text="提交" onclick="btSubmit_Click" />
      
      <input name="btBack" type="button" id="btBack" onclick="history.back();" value="返回上一页"> 注意：请在20分钟内完成信息编辑，否则会因为用户登录超时而失败！<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" /></td>
    </tr>
</table>    
    </form>
</body>
</html>
