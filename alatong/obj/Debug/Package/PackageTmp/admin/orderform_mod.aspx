<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderform_mod.aspx.cs" Inherits="webshop.admin.orderform_mod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改订单</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server"><br/>
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【修改订单】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">订单状态：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:DropDownList ID="ddlStatus" 
              runat="server"> </asp:DropDownList>&nbsp;[必选]</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">订单金额：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbPrice" runat="server" Width="100px">0</asp:TextBox>
        &nbsp;[必填] 价格！<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="tbPrice" Display="None" ErrorMessage="订单金额不能为0！" 
                                            InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="tbPrice" Display="None" ErrorMessage="请输入订单金额！" 
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">实际支付：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbPayPrice" runat="server" Width="100px">0</asp:TextBox>
        &nbsp;[必填] 
          <asp:CheckBox ID="cbIsAddPayLog" runat="server" Text="新增扣款记录" />
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="tbPayPrice" 
              Display="None" ErrorMessage="请输入支付金额！" 
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">是否开票：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="cblIsBilling" runat="server" 
              RepeatDirection="Horizontal">
              <asp:ListItem Selected="True" Value="1">开票</asp:ListItem>
              <asp:ListItem Value="0">不开票</asp:ListItem>
          </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">订购详情：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:Label ID="lbProName" runat="server"></asp:Label>
          <asp:Label ID="lbPro" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">订购用户：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:Label ID="lbUserName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">手机：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbMobile" runat="server" Width="400px"></asp:TextBox>
          &nbsp;<asp:regularexpressionvalidator id="RegularExpressionValidator8" runat="server" ControlToValidate="tbMobile"
										Display="None" ErrorMessage="手机号码只能为11位的半角数字！请关闭中文输入法。" ValidationExpression="[0-9]{11}" 
                                            SetFocusOnError="True"></asp:regularexpressionvalidator></td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">固定电话：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbTel" runat="server" Width="400px"></asp:TextBox>
          &nbsp;<asp:regularexpressionvalidator id="RegularExpressionValidator7" runat="server" 
                                            ControlToValidate="tbTel" Display="none"
										ErrorMessage="电话号码只能为数字" ValidationExpression="[0-9-]*" SetFocusOnError="True"></asp:regularexpressionvalidator></td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">传真：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbFax" runat="server" Width="400px"></asp:TextBox>
          &nbsp;<asp:regularexpressionvalidator id="RegularExpressionValidator9" runat="server" 
                                            ControlToValidate="tbFax" Display="none"
										ErrorMessage="传真号码只能为数字" ValidationExpression="[0-9-]*" SetFocusOnError="True"></asp:regularexpressionvalidator></td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">地址：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbAddress" runat="server" Width="400px"></asp:TextBox>
          &nbsp;<asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" 
                                            ControlToValidate="tbEMail" Display="None"
										ErrorMessage="电子邮件格式错误" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                            SetFocusOnError="True"></asp:regularexpressionvalidator></td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">E-Mail：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbEMail" runat="server" Width="400px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">公司名称：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbCompany" runat="server" Width="400px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">备注：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbMemo" runat="server" Width="400px" Height="50px" 
              TextMode="MultiLine"></asp:TextBox><asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" /></td>
    </tr>
    <tr>
      <td align="right" class="forumrow"></td>
      <td class="forumrowhighlight"><asp:Button ID="btSubmit" runat="server" Text="提交" onclick="btSubmit_Click" />
      
      <input name="btBack" type="button" id="btBack" onclick="history.back();" value="返回上一页"> 注意：请在20分钟内完成信息编辑，否则会因为用户登录超时而失败！</td>
    </tr>
</table><br />
    </form>
</body>
</html>
