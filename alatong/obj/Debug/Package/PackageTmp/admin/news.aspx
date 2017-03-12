<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="web1.admin.news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>新闻信息管理</title>
    <link type="text/css" rel="Stylesheet" href="css/Admin_style.css" />
    <script language="javascript" type="text/javascript" src="scripts/function.js"></script>
</head>
<body>
    <form id="form1" runat="server"><br />
<TABLE border=0 cellSpacing=1 cellPadding=3 width="95%" bgColor=#6298e1 align="center">
  <TBODY>
  <TR>
    <TD height=24 noWrap colspan="2"><FONT color=#ffffff><IMG border=0 align=absMiddle 
      src="images/Explain.gif" width=18 
      height=18>&nbsp;<STRONG>新闻信息：添加，修改新闻相关的内容</STRONG></FONT></TD></TR>
  <TR>
    <TD bgColor=#ebf2f9 height=24 noWrap align=left>　<A href="newtype.aspx">管理新闻分类</A><FONT 
      color=#0000ff>&nbsp;|&nbsp;</FONT><A href="new_add.aspx?NewType=<%=strNewTp %>">添加新闻</A></TD>
   <td bgColor=#ebf2f9 height=24 noWrap align="middle" width="490" valign="middle">新闻分类：<asp:DropDownList 
           ID="ddlNewType" runat="server">
       </asp:DropDownList>　快速搜索：<asp:TextBox ID="tbKeyWord" runat="server"></asp:TextBox>
       <input type="button" id="btSearch" name="btSearch"  value="搜索" onclick="window.location.href='news.aspx?NewType='+form1.ddlNewType.options[ddlNewType.selectedIndex].value+'&keyword='+MM_findObj('tbKeyWord').value" />
      </td>   
   </TR></TBODY></TABLE><BR><asp:Table ID="tableMain" runat="server" 
        BackColor="#6298E1" BorderWidth="0px" CellPadding="3" CellSpacing="1" 
        Width="95%" HorizontalAlign="Center">
        <asp:TableRow runat="server" BackColor="#8DB5E9" Font-Bold="True" 
            ForeColor="White">
            <asp:TableCell runat="server" Width="20">ID</asp:TableCell>
            <asp:TableCell runat="server" Width="30">发布</asp:TableCell>
            <asp:TableCell runat="server" Width="30">推荐</asp:TableCell>
            <asp:TableCell runat="server" Width="80">新闻类型</asp:TableCell>
            <asp:TableCell runat="server">新闻标题</asp:TableCell>
            <asp:TableCell runat="server" Width="120">发布时间</asp:TableCell>
            <asp:TableCell runat="server" Width="50">排序</asp:TableCell>
            <asp:TableCell runat="server" ColumnSpan="2">操作 <INPUT style="WIDTH: 16px; HEIGHT: 18px" id=Button1 class=button onclick=CheckAll() value=全 type=button name=buttonAllSelect> 
<INPUT style="WIDTH: 16px; HEIGHT: 18px" id=Button2 class=button onclick=CheckOthers() value=反 type=button name=buttonOtherSelect></asp:TableCell>
        </asp:TableRow>
      </asp:Table>
<br />
    </form>
</body>
</html>
