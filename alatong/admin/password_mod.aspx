<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="password_mod.aspx.cs" Inherits="web1.admin.password_mod" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>修改管理密码</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return checkPassword(this);"><br/>
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【修改管理密码】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">原始密码：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbOldPassWord" runat="server" Width="400px" 
              TextMode="Password"></asp:TextBox>
        &nbsp;[必填] 请输入老的密码！</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">新 密 码：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbNewPassWord" runat="server" Width="400px" 
              TextMode="Password"></asp:TextBox>
        &nbsp;[必填] 请输入新的密码！</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">确认密码：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbNewPassWord1" runat="server" Width="400px" 
              TextMode="Password"></asp:TextBox>
        &nbsp;[必填] 请输入再输入一次新的密码，保持一致！</td>
    </tr>
    <tr>
      <td align="right" class="forumrow"></td>
      <td class="forumrowhighlight"><asp:Button ID="btSubmit" runat="server" Text="提交" onclick="btSubmit_Click" />
      
      <input name="btBack" type="button" id="btBack" onclick="history.back();" value="返回上一页"> 注意：请在20分钟内完成信息编辑，否则会因为用户登录超时而失败！</td>
    </tr>
</table>    
    </form>
</body>
</html>
