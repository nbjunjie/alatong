<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="book_mod.aspx.cs" Inherits="webshop.admin.book_mod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改问答信息</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【修改问答信息】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">问答时间：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:Label ID="lbNoteTime" runat="server"></asp:Label>
          &nbsp;</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">姓名：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbRealName" runat="server" Width="500px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">Tel：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbTel" runat="server" Width="500px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">E-Mail：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbEMail" runat="server" Width="500px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">推荐到首页：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="rblIsRecommend" runat="server" 
              RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="1">有</asp:ListItem>
              <asp:ListItem Value="0">无</asp:ListItem>
          </asp:RadioButtonList>
          &nbsp;</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">所在地：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbAddress" runat="server" Width="500px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">QQ：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbQQ" runat="server" Width="500px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">是否显示：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="cblIsShow" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="1">显示</asp:ListItem>
              <asp:ListItem Selected="True" Value="0">不显示</asp:ListItem>
          </asp:RadioButtonList>
        </td>
    </tr>
   
    <tr>
      <td width="20%" align="right" class="forumrow">问题：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbTitle" runat="server" Width="500px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">答案：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbMemo" runat="server" Width="500px" Height="100px" 
              TextMode="MultiLine"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">回覆时间：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbReplyTime" runat="server" Width="500px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">回覆内容：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbReply" runat="server" Width="500px" Height="100px" 
              TextMode="MultiLine"></asp:TextBox>
          &nbsp;</td>
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
