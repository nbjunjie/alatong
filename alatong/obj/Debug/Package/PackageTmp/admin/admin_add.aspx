<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_add.aspx.cs" Inherits="nb_xy.admin.admin_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加管理员用户</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return checkAdminAdd(form1);"><br/>
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【添加管理员用户】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">用户名：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbUserName" runat="server" Width="200px"></asp:TextBox>
          &nbsp;[必填] 请输入用户称呼！</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">密码：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbPassWord" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
          &nbsp;[必填] 请输入用户的密码！</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">权限：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbUserRole" runat="server" Width="200px">0</asp:TextBox>
          &nbsp;[必填] 请输入用户权限0-255，数字越大，表示权限越大！
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">用户称呼：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbUserRoleCalled" runat="server" Width="200px"></asp:TextBox>
          &nbsp;[必填] 请输入用户称呼！
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">后台菜单：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:CheckBoxList ID="cblUserMenu" runat="server" RepeatDirection="Horizontal" 
              RepeatLayout="Flow">
          </asp:CheckBoxList>
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
      
      <input name="btBack" type="button" id="btBack" onclick="history.back();" value="返回上一页"> 注意：请在20分钟内完成信息编辑，否则会因为用户登录超时而失败！</td>
    </tr>
</table>    
    </form>
</body>
</html>