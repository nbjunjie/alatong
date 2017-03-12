<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="web1.admin.left" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>管理导航菜单</title>
<link type="text/css" href="css/Admin_left.css" rel="Stylesheet" />
<script language="javascript" type="text/javascript" src="scripts/prototype.js"></script>
</head>
<body>
<form id="form1" runat="server">
  <TABLE border=0 cellSpacing=0 cellPadding=0 width=180 align=center>
    <TBODY>
      <TR>
        <TD height=44 vAlign=top><IMG 
  src="images/title.gif"></TD>
      </TR>
    </TBODY>
  </TABLE>
  <TABLE cellSpacing=0 cellPadding=0 width=180 align=center>
    <TBODY>
      <TR>
        <TD id=menuTitle0 class=menu_title height=26 
    background=images/title_bg_quit.gif align=middle>　&nbsp;<A 
      href="../index.aspx" target=_blank class="ti">前台首页</A><SPAN class=glow>　|　</SPAN><A 
      href="javascript:if(confirm('是否退出管理后台？')){window.top.location.href='logout.aspx';}" class="ti">退出登录</A> </TD>
      </TR>
      <TR>
        <TD height=97 
    background=images/title_bg_admin.gif><DIV style="WIDTH: 180px">
            <TABLE cellSpacing=0 cellPadding=0 width=130 align=center>
              <TBODY>
                <TR>
                  <TD height=25>用户名称：<asp:Label ID="lbAdmin_UserName" runat="server" Text=""></asp:Label></TD>
                </TR>
                <TR>
                  <TD height=25>用户身份：<asp:Label ID="lbAdmin_UserRoleCalled" runat="server" Text=""></asp:Label></TD>
                </TR>
                <TR>
                  <TD height=20>IP地址：<asp:Label ID="lbIP" runat="server" Text=""></asp:Label></TD>
                </TR>
              </TBODY>
            </TABLE>
          </DIV>
          <DIV style="WIDTH: 167px">
            <TABLE cellSpacing=0 cellPadding=0 width=130 align=center>
              <TBODY>
                <TR>
                  <TD height=20></TD>
                </TR>
              </TBODY>
            </TABLE>
          </DIV></TD>
      </TR>
    </TBODY>
  </TABLE>
  <asp:TextBox ID="tbLeftMenu" runat="server" Visible="false"><TABLE cellSpacing=0 cellPadding=0 width=167 align=center>
    <TBODY>
      <TR>
        <TD style="CURSOR: hand" id="TD$i$" class=menu_title 
    onmouseover="this.className='menu_title2'" 
    onmouseout="this.className='menu_title'" 
    onclick="new Element.toggle('submenu$i$')" height=28 
    background="$link$"><SPAN 
      class=glow>$title$</SPAN></TD>
      </TR>
      <TR>
        <TD style="DISPLAY: none" id="submenu$i$" align=right><DIV style="WIDTH: 165px" class=sec_menu>
            <TABLE cellSpacing=0 cellPadding=0 width=130 align=center>
              <TBODY>
                $submenu$
              </TBODY>
            </TABLE>
          </DIV>
          <DIV style="WIDTH: 167px">
            <TABLE cellSpacing=0 cellPadding=0 width=130 align=center>
              <TBODY>
                <TR>
                  <TD height=5></TD>
                </TR>
              </TBODY>
            </TABLE>
          </DIV></TD>
      </TR>
    </TBODY>
  </TABLE></asp:TextBox>
  <%=strLeftMenu %>
  <TABLE cellSpacing=0 cellPadding=0 width=167 align=center>
    <TBODY>
      <TR>
        <TD id=menuTitle208 class=menu_title 
    onmouseover="this.className='menu_title2'" 
    onmouseout="this.className='menu_title'" height=28 
    background=images/admin_left_14.gif><SPAN>系统信息</SPAN> </TD>
      </TR>
      <TR>
        <TD align=right><DIV style="WIDTH: 165px" class=sec_menu>
            <TABLE cellSpacing=0 cellPadding=0 width=130 align=center>
              <TBODY>
                <TR>
                  <TD height=20><br>
                    技术支持：<A href="http://www.cl-kj.com/" 
            target=_blank>创领科技</A><BR>
                    电话：0574-87993919<BR>
                    传真：0574-87918150
                    <BR><br></TD>
                </TR>
              </TBODY>
            </TABLE>
          </DIV></TD>
      </TR>
    </TBODY>
  </TABLE>
</form>
</body>
</html>
