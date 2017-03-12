<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="info.aspx.cs" Inherits="web1.admin.info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>页面信息管理</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
</head>
<body>
    <form id="form1" runat="server"><br />
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【编辑页面信息】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">信息分类：</td>
      <td width="80%" class="forumrowhighlight"><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlType_SelectedIndexChanged"> </asp:DropDownList></td>
    </tr>
    <tr>
      <td align="right" class="forumrow">信息内容：</td>
      <td class="forumrowhighlight"><textarea name="Content" id="Content" style="display:none"></textarea>
      <asp:TextBox ID="tbMemo" runat="server" 
                Width="570px" Height="112px" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="right" class="forumrow"></td>
      <td class="forumrowhighlight"><asp:Button ID="btSubmit" runat="server" Text="提交" onclick="btSubmit_Click" />
      
      <input name="btBack" type="button" id="btBack" onclick="history.back();" value="返回上一页"><asp:Literal ID="laMeno1" runat="server"></asp:Literal><script type="text/javascript">                                                                         window.onload = function() {
                                                                             var editor = CKEDITOR.replace('tbMemo', {
                                                                             skin: "office2003", height: 300
                                                                             }); CKFinder.setupCKEditor(editor, '../ckfinder/');
                                                                         };</script><asp:Literal ID="laMeno2" runat="server"></asp:Literal>注意：请在20分钟内完成信息编辑，否则会因为用户登录超时而失败！</td>
    </tr>
</table>    
</form>
</body>
</html>
