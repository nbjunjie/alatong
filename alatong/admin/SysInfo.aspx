<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysInfo.aspx.cs" Inherits="web1.admin.SysInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统概况</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script type="text/javascript" language="javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server"><br/>
<TABLE class="tableborder" border=0 cellSpacing=1 cellPadding=5 width="95%" align=center>
  <TBODY>
  <TR>
    <TH height=22 colSpan=2 sytle="line-height:150%">【服务器信息】</TH></TR>
  <TR>
    <TD class=forumrow width="47%">服务器IP地址：<asp:Label ID="lbServerIP" runat="server"></asp:Label>      </TD>
    <TD class=forumrowhighlight width="53%">.Net框架版本：<asp:Label ID="lbServerScript" 
            runat="server"></asp:Label>      </TD></TR>
  <TR>
    <TD 
    class=forumrow>站点物理路径：<asp:Label ID="lbServerURL" runat="server"></asp:Label>      </TD>
    <TD class=forumrowhighlight>限定使用空间：100MB</TD></TR>
  <TR>
    <TD class=forumrow>已经使用空间：<asp:Label ID="lbServerFileSize" runat="server"></asp:Label>      </TD>
    <TD class=forumrowhighlight>使用数据库：MS SQL SERVER 2005</TD></TR>
  <TR>
    <TD class=forumrow>服务器操作系统：<asp:Label ID="lbServerOS" runat="server"></asp:Label>      </TD>
    <TD class=forumrowhighlight>服务器提供的网站运行端口：80      </TD></TR></TBODY></TABLE>
<BR>
<TABLE class=tableborder border=0 cellSpacing=1 cellPadding=5 width="95%" 
align=center>
  <TBODY>
  <TR class="tableborder">
    <TH height=22 colSpan=2 sytle="line-height:150%">【系统信息】</TH></TR>
  <TR>
    <TD class=forumrow width="47%">创领科技网站管理系统 Ver 2014 Build1125</TD>
    <TD class=forumrowhighlight width="53%">程序开发：创领科技技术部</TD>
  </TR></TBODY></TABLE>
<!--
<BR>
<TABLE class=tableborder border=0 cellSpacing=1 cellPadding=5 width="95%" 
align=center>
  <TBODY>
  <TR class="tableborder">
    <TH height=22 colSpan=2 sytle="line-height:150%">【静态页面生成】</TH></TR>
  <TR>
    <TD class=forumrow colspan="2"><font color="red">请注意：本网站采用静态页面生成技术，修改数据后请手动生成静态页面！否则前台不会更新！生成时请不要切换和关闭本页面！</font><br>
    <div align="center" id="dv1"></div>
    <div align="center"><input type="button" id="doWriteHtml" name="doWriteHtml" value="生成静态页面" onclick="GetWriteHtmlResult('dv1');this.value='正在生成，需要一段时间，请不要切换和关闭本页面！';this.disabled=true;" /></div>
    </TD>
  </TR></TBODY></TABLE>
-->
<BR>
<TABLE border=0 cellSpacing=0 cellPadding=0 width="95%" align=center>
  <TBODY>
  <TR>
    <TD align=middle>Copyright &copy; 2010 <A title="" href="http://www.cl-kj.com/" target=_blank><FONT size=1 
      face="Verdana, arial, helvetica, sans-serif"><B>www.cl-kj<FONT 
      color=#cc0000>.com</FONT></B></FONT></A> All Rights 
Reserved.</TD>
  </TR></TBODY></TABLE>
    </form>
</body>
</html>
