<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seo_add.aspx.cs" Inherits="nb_xy.admin.seo_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加SEO信息</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server"><br/>
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【添加SEO信息】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">页面名称：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbPageName" runat="server" Width="400px"></asp:TextBox>
          &nbsp;对应文件名称，如：index.html</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">中文名称：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbPageNameCalled" runat="server" Width="400px"></asp:TextBox>
          &nbsp;对应文件中文名称，如：首页</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">SEO Title：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbSeo_Title" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
        &nbsp;SEO优化选项，如果为空，那么与产品名称一致！</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">SEO Keywords：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbSeo_Keywords" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
        &nbsp;SEO优化选项，关键词。</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">SEO Description：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbSeo_Description" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
        &nbsp;SEO优化选项，描述。</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">SEO Author：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbSeo_Author" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
        &nbsp;SEO优化选项，作者。</td>
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
