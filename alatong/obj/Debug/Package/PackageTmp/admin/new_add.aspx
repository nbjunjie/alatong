<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="new_add.aspx.cs" Inherits="web1.admin.new_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加新闻信息</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return checkNewAdd(form1);"><br/>
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【添加新闻信息】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">新闻分类：</td>
      <td width="80%" class="forumrowhighlight"><asp:DropDownList ID="ddlNewType" 
              runat="server"> </asp:DropDownList>&nbsp;[必选]</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">新闻标题：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbTitle" runat="server" Width="400px"></asp:TextBox>
        &nbsp;[必填] 请输入新闻的标题文字！</td>
    </tr>
    
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">新闻图片：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:FileUpload ID="fuProPic" runat="server" Width="400px" />
        &nbsp;缩略图，文字新闻无需添加！新闻143×96，证书76×110，容量小于512KB！</td>
    </tr>
    <tr >
      <td width="20%" align="right" class="forumrow">作者：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbAuthor" runat="server" Width="400px"></asp:TextBox>
        &nbsp;文章作者名称，如不知道可不填写！</td>
    </tr>
    <tr >
      <td width="20%" align="right" class="forumrow">来源：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbOrigin" runat="server" Width="400px"></asp:TextBox>
        &nbsp;如果需要来源的，请填写！</td>
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
      <td width="20%" align="right" class="forumrow">是否推荐：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="cblIsRecommend" runat="server" 
              RepeatDirection="Horizontal">
              <asp:ListItem Value="1">推荐</asp:ListItem>
              <asp:ListItem Selected="True" Value="0">不推荐</asp:ListItem>
          </asp:RadioButtonList>
        </td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">文章简介：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbNewTip" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
          &nbsp;没有简介的新闻可以不填写！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">关 键 词：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbKeyWords" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
        &nbsp;请用空格或中英文逗号分隔各个关键词</td>
    </tr>
    <tr>
      <td align="right" class="forumrow">新闻内容：<br />
          <a href="javascript:objEditor.insertHtml(templateContent1);">【内容模板A】</a><br />
          <a href="javascript:objEditor.insertHtml(templateContent2);">【内容模板B】</a></td>
      <td class="forumrowhighlight"><textarea name="Content" id="Content" style="display:none"></textarea>
      <asp:TextBox ID="tbContent" runat="server" 
                Width="570px" Height="112px" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">SEO Title：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbSeo_Title" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
        &nbsp;SEO优化选项，如果为空，那么与产品名称一致！</td>
    </tr>
    <tr >
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
    <tr >
      <td width="20%" align="right" class="forumrow">SEO Author：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbSeo_Author" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
        &nbsp;SEO优化选项，作者。</td>
    </tr>
    <tr>
      <td align="right" class="forumrow"></td>
      <td class="forumrowhighlight"><asp:Button ID="btSubmit" runat="server" Text="提交" onclick="btSubmit_Click" />
      
      <input name="btBack" type="button" id="btBack" onclick="history.back();" value="返回上一页"><script type="text/javascript">                                                                         window.onload = function() {
                                                                             var editor = CKEDITOR.replace('tbContent', {
                                                                             skin: "office2003", height: 300
                                                                         }); objEditor = editor; CKFinder.setupCKEditor(editor, '../ckfinder/');
                                                                         };</script> 注意：请在20分钟内完成信息编辑，否则会因为用户登录超时而失败！</td>
    </tr>
</table>    
    </form>
</body>
</html>
