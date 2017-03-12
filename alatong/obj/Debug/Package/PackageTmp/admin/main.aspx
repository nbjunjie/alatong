<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="web1.admin.main" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>网站信息管理系统 Ver 2010 Build1125</title>
<script language="javascript" type="text/javascript">
    if (top != self)top.location.href = "index.aspx"; 
    </script>
</head>
<FRAMESET id=frame 
frameSpacing=0 border=false cols=200,* frameBorder=0 rows=* 
scrolling="yes">
  <FRAME marginHeight=0 src="left.aspx" 
name=left marginWidth=0 scrolling=yes>
  <FRAMESET frameSpacing=0 border=false 
cols=* frameBorder=0 rows=53,* scrolling="yes">
    <FRAME 
src="top.aspx" name=top scrolling=no>
    <FRAME 
src="SysInfo.aspx" name=main>
  </FRAMESET>
</FRAMESET>
<noframes>
您的浏览器不支持框架显示！
</noframes>
</html>
