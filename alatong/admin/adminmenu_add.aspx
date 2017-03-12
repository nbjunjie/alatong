<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminmenu_add.aspx.cs" Inherits="nb_xy.admin.adminmenu_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加管理菜单</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return checkAdminMenuAdd(form1);"><br/>
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【添加管理菜单】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">上级菜单：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:DropDownList ID="ddlPID" 
              runat="server"> </asp:DropDownList>&nbsp;[必选]</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">查看用户：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:CheckBoxList ID="cblAdminUser" runat="server" RepeatDirection="Horizontal" 
              RepeatLayout="Flow">
          </asp:CheckBoxList>
          </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">菜单名称：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbTitle" runat="server" Width="400px"></asp:TextBox>
        &nbsp;[必填] 请输入菜单名称！</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">菜单链接：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbLink" runat="server" Width="400px"></asp:TextBox>
        &nbsp;[<a href="javascript:MM_showHideLayers_pro('selectMenuBgDiv','','show');">背景图片选择</a>] 请输入链接地址！
        <div id="selectMenuBgDiv" class="selectMenuBg">
            <ul>
                <li><img src="images/Admin_left_01.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_02.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_03.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_04.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_05.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_06.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_07.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_08.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_09.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_10.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_11.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_12.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_13.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
                <li><img src="images/Admin_left_14.gif" onclick="SelectAdminMenuBg('tbLink',this.src);" /></li>
            </ul>
        </div></td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">是否发布：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="cblIsShow" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Selected="True" Value="1">发布</asp:ListItem>
              <asp:ListItem Value="0">不发布</asp:ListItem>
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