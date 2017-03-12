<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paylog_add.aspx.cs" Inherits="webshop.admin.paylog_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加用户支付记录</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server"><br/>
<table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【添加用户支付记录】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">用户：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbUserName" runat="server" Width="200px"></asp:TextBox>
&nbsp;[必填] 
          输入用户名或手机号！<asp:Label ID="lbUserList" runat="server"></asp:Label>
          <asp:TextBox ID="tbUserID" runat="server" style="visibility:hidden;" Text="0"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="tbUserID" Display="None" ErrorMessage="请选择一个用户！" 
                                            InitialValue="0"></asp:RequiredFieldValidator>
          </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">金额：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbPrice" runat="server" Width="70px">0</asp:TextBox>
          &nbsp;[必填] 可以有两位小数！<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="tbPrice" Display="None" ErrorMessage="支付金额不能为0！" 
                                            InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="tbPrice" Display="None" ErrorMessage="请输入支付金额！" 
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">支付类型：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:DropDownList ID="ddlPayType" runat="server">
          </asp:DropDownList>
          &nbsp;[必选] 请选择一种付款类型！<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="ddlPayType" 
              Display="None" ErrorMessage="请选择一个支付方式！" 
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">实际支付：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="cblIsShow" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="1">是</asp:ListItem>
              <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
          </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">备注：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbMemo" runat="server" Width="200px" Height="50px" 
              TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="right" class="forumrow"></td>
      <td class="forumrowhighlight"><asp:Button ID="btSubmit" runat="server" Text="提交" onclick="btSubmit_Click" />
      
      <input name="btBack" type="button" id="btBack" onclick="history.back();" value="返回上一页">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" /> 注意：请在20分钟内完成信息编辑，否则会因为用户登录超时而失败！</td>
    </tr>
</table>
    </form>
</body>
</html>
