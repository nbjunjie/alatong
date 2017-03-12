<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paytype_mod.aspx.cs" ValidateRequest="false" Inherits="webshop.admin.paytype_mod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改支付类型</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server"><br/>
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【修改支付类型】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">类型名称：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbTypeCalled" runat="server"></asp:TextBox>
          &nbsp;[必填] 请输入分类名！<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
              runat="server" ControlToValidate="tbTypeCalled" Display="None" 
              ErrorMessage="请输入支付类型！" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">分类简介：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbTip" runat="server" Width="400px"></asp:TextBox>
        &nbsp;[必填] 请输入简介！<asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
              runat="server" ControlToValidate="tbTip" Display="None" ErrorMessage="请输入简介！" 
              SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
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
      <td align="right" class="forumrow">内容介绍：</td>
      <td class="forumrowhighlight">
      <asp:TextBox ID="tbMemo" runat="server" 
                Width="570px" Height="112px" TextMode="MultiLine"></asp:TextBox>
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
              ShowMessageBox="True" ShowSummary="False" />
        </td>
    </tr>
    <tr>
      <td align="right" class="forumrow"></td>
      <td class="forumrowhighlight"><asp:Button ID="btSubmit" runat="server" Text="提交" onclick="btSubmit_Click" />
      
      <input name="btBack" type="button" id="btBack" onclick="history.back();" value="返回上一页"><script type="text/javascript">                                                                                                 window.onload = function() {
                                                                                                     var editor = CKEDITOR.replace('tbMemo', {
                                                                                                         skin: "office2003", height: 300
                                                                                                     }); objEditor = editor; CKFinder.setupCKEditor(editor, '../ckfinder/');
                                                                                                 };</script> 注意：请在20分钟内完成信息编辑，否则会因为用户登录超时而失败！</td>
    </tr>
</table><br />
    </form>
</body>
</html>
