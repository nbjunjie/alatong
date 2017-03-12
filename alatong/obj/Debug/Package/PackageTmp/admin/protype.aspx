<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="protype.aspx.cs" Inherits="web1.admin.protype" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>产品分类管理</title>
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
      height=18>&nbsp;<STRONG>产品分类：添加，修改产品分类相关的内容</STRONG></FONT></TD></TR>
  <TR>
    <TD bgColor=#ebf2f9 height=24 noWrap align=left>　<A href="protype_add.aspx">添加产品分类</A><FONT 
      color=#0000ff></TD>
   <td bgColor=#ebf2f9 height=24 noWrap align="middle" width="300" valign="middle">快速搜索：<asp:TextBox ID="tbKeyWord" runat="server"></asp:TextBox>
       <input type="button" id="btSearch" name="btSearch" name="btSearch" value="搜索" onclick="window.location.href='protype.aspx?keyword='+MM_findObj('tbKeyWord').value" />
      </td>   
   </TR></TBODY></TABLE><BR><asp:Table ID="tableMain" runat="server" 
        BackColor="#6298E1" BorderWidth="0px" CellPadding="3" CellSpacing="1" 
        Width="95%" HorizontalAlign="Center">
        <asp:TableRow ID="TableRow1" runat="server" BackColor="#8DB5E9" Font-Bold="True" 
            ForeColor="White">
            <asp:TableCell ID="TableCell1" runat="server" Width="20">ID</asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server" Width="30">发布</asp:TableCell>
            <asp:TableCell ID="TableCell4" runat="server" Width="80">父级ID</asp:TableCell>
            <asp:TableCell ID="TableCell5" runat="server">分类名称</asp:TableCell>
            <asp:TableCell ID="TableCell7" runat="server" Width="50">排序</asp:TableCell>
            <asp:TableCell ID="TableCell8" runat="server" ColumnSpan="2">操作 <INPUT style="WIDTH: 16px; HEIGHT: 18px" id=Button1 class=button onclick=CheckAll() value=全 type=button name=buttonAllSelect> 
<INPUT style="WIDTH: 16px; HEIGHT: 18px" id=Button2 class=button onclick=CheckOthers() value=反 type=button name=buttonOtherSelect></asp:TableCell>
        </asp:TableRow>
      </asp:Table>
<br />
    </form>
</body>
</html>