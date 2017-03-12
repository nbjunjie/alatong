<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="web1.admin.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>后台头部</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_top.css" />
<script language="JavaScript" type="text/JavaScript">
function preloadImg(src) {
  var img=new Image();
  img.src=src
}
preloadImg("Images/admin_top_open.gif");

var displayBar=true;
function switchBar(obj) {
  if (displayBar) {
    parent.frame.cols="0,*";
    displayBar=false;
    obj.src="Images/admin_top_open.gif";
    obj.title="打开左边管理导航菜单";
  } else {
    parent.frame.cols="200,*";
    displayBar=true;
    obj.src="Images/admin_top_close.gif";
    obj.title="关闭左边管理导航菜单";
  }
}
</script>
    <script type="text/javascript" language="javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<TABLE border=0 cellSpacing=0 cellPadding=0 width="100%">
  <TBODY>
  <TR vAlign=center>
    <TD width=60 background="images/admin_top_bg.gif"><IMG style="CURSOR: hand" title="" onclick=switchBar(this) src="images/admin_top_close.gif"></TD>
    <TD align=left valign="top" background="images/admin_top_bg.gif" class=spa><div style="color:White; height:24px; line-height:24px; vertical-align:middle;display:none;">请注意：本网站采用静态页面生成技术，修改数据后请手动生成静态页面！否则前台不会更新！生成时请不要切换和关闭本页面！</div>
    <div align="center" style="float:left;display:none;"><input type="button" style="font-size:12px;height:20px;BORDER-RIGHT-WIDTH: 1px; BORDER-TOP-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; FONT-SIZE: 12px; BORDER-LEFT-WIDTH: 1px;" id="doWriteHtml" name="doWriteHtml" value="生成静态页面" onclick="GetWriteHtmlResult('dv1');this.value='正在生成，需要一段时间，请不要切换和关闭本页面！';this.disabled=true;" /></div>
    <div align="center" id="dv1" style="float:left"></div></TD>
    <TD align=right background="images/admin_top_bg.gif" class=spa>Xinyi Ver 2010 Build1125</TD>
  </TR></TBODY></TABLE>
    </form>
</body>
</html>
