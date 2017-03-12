<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="pro_mod.aspx.cs" Inherits="web1.admin.pro_mod" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>修改产品信息</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
    <script type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return checkProAdd(form1);"><br/>
    <table class="tableborder" width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
    <tr>
      <th height="22" colspan="2" sytle="line-height:150%">【修改产品信息】</th>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">产品分类：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:DropDownList ID="ddlType" 
              runat="server"> </asp:DropDownList>&nbsp;[必选]</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">产品名称：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbProName" runat="server" Width="400px"></asp:TextBox>
        &nbsp;[必填] 请输入产品名称！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">产品型号：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbProModel" runat="server" Width="400px"></asp:TextBox>
        &nbsp;[必填] 多个产品型号用“/”分隔！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">价格：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbPrice" runat="server" Width="100px" Text="0"></asp:TextBox>
        &nbsp;[必填] 请输入产品价格！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">市场价格：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbPrice1" runat="server" Width="100px" Text="0"></asp:TextBox>
        &nbsp;[必填] 请输入产品市场价格！</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">产品图片：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:Image ID="imgProPic" runat="server" Width="200px" />
          <asp:LinkButton ID="lbtDelPic" runat="server" 
              OnClientClick="return confirm('确认删除这张图片？');" onclick="lbtDelPic_Click">删除图片</asp:LinkButton>
          <br />
          <asp:FileUpload ID="fuProPic" runat="server" Width="400px" />
        &nbsp;产品缩略小图，分辨率200×133，容量小于512KB！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">产品图片2：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:Image ID="imgProPic1" runat="server" Width="200px" />
          <asp:LinkButton ID="lbtDelPic1" runat="server" 
              OnClientClick="return confirm('确认删除这张图片？');" onclick="lbtDelPic_Click">删除图片</asp:LinkButton>
          <br />
          <asp:FileUpload ID="fuProPic1" runat="server" Width="400px" />
        &nbsp;产品缩略小图，分辨率404×404，容量小于512KB！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">产品图片3：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:Image ID="imgProPic2" runat="server" Width="200px" />
          <asp:LinkButton ID="lbtDelPic2" runat="server" 
              OnClientClick="return confirm('确认删除这张图片？');" onclick="lbtDelPic_Click">删除图片</asp:LinkButton>
          <br />
          <asp:FileUpload ID="fuProPic2" runat="server" Width="400px" />
        &nbsp;产品缩略小图，分辨率404×404，容量小于512KB！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">产品图片4：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:Image ID="imgProPic3" runat="server" Width="200px" />
          <asp:LinkButton ID="lbtDelPic3" runat="server" 
              OnClientClick="return confirm('确认删除这张图片？');" onclick="lbtDelPic_Click">删除图片</asp:LinkButton>
          <br />
          <asp:FileUpload ID="fuProPic3" runat="server" Width="400px" />
        &nbsp;产品缩略小图，分辨率404×404，容量小于512KB！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">产品图片5：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:Image ID="imgProPic4" runat="server" Width="200px" />
          <br />
          <asp:FileUpload ID="fuProPic4" runat="server" Width="400px" />
        &nbsp;产品缩略小图，分辨率404×404，容量小于512KB！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">规格：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbProGrade" runat="server" Width="400px"></asp:TextBox>
        &nbsp;产品规格！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">适用风格：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbProAreas" runat="server" Width="400px"></asp:TextBox>
        &nbsp;产品的适用风格和范围！</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">使用指南：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbProStorage" runat="server" Width="400px"></asp:TextBox>
        &nbsp;产品使用指南！</td>
    </tr>
    <tr>
      <td width="20%" align="right" class="forumrow">是否发布：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="cblIsShow" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="1">发布</asp:ListItem>
              <asp:ListItem Value="0">不发布</asp:ListItem>
          </asp:RadioButtonList>
        </td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">是否新品：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="rblIsNew" runat="server" 
              RepeatDirection="Horizontal">
              <asp:ListItem Value="1">新品</asp:ListItem>
              <asp:ListItem Selected="True" Value="0">普通</asp:ListItem>
          </asp:RadioButtonList>
        </td>
    </tr>
    <tr >
      <td width="20%" align="right" class="forumrow">推荐到首页：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:RadioButtonList ID="cblIsRecommend" runat="server" 
              RepeatDirection="Horizontal">
              <asp:ListItem Value="1">推荐</asp:ListItem>
              <asp:ListItem Value="0">不推荐</asp:ListItem>
          </asp:RadioButtonList>
        </td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">设计师语录：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbProTip" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
        &nbsp;填写设计师语录！
         
            </td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">关 键 词：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbKeyWords" runat="server" Width="400px" Height="40px" 
              TextMode="MultiLine"></asp:TextBox>
        &nbsp;请用空格或中英文逗号分隔各个关键词</td>
    </tr>
    <tr style="display:none;">
      <td width="20%" align="right" class="forumrow">跳转链接：</td>
      <td width="80%" class="forumrowhighlight">
          <asp:TextBox ID="tbLinks" runat="server" Width="400px"></asp:TextBox>
        &nbsp;跳转链接，不填写为不跳转。</td>
    </tr>
    <tr >
      <td align="right" class="forumrow">产品大图片：</td>
      <td class="forumrowhighlight"><textarea name="Content" id="Content" style="display:none"></textarea>
      <asp:TextBox ID="tbContent" runat="server"   Width="570px" Height="112px" TextMode="MultiLine"></asp:TextBox>
      </td>
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
    <tr >
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
                                                                             }); CKFinder.setupCKEditor(editor, '../ckfinder/');
                                                                         };</script> 注意：请在20分钟内完成信息编辑，否则会因为用户登录超时而失败！</td>
    </tr>
</table>    
    </form>
</body>
</html>