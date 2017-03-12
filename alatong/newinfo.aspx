<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newinfo.aspx.cs" Inherits="alatong.newinfo" %>

<%@ Register src="include_head.ascx" tagname="include_head" tagprefix="uc1" %>
<%@ Register src="include_top.ascx" tagname="include_top" tagprefix="uc2" %>
<%@ Register src="include_bottom.ascx" tagname="include_bottom" tagprefix="uc3" %>
<%@ Register src="include_foot.ascx" tagname="include_foot" tagprefix="uc4" %>
<%@ Register src="include_left.ascx" tagname="include_left" tagprefix="uc5" %>

<uc1:include_head ID="include_head1" runat="server" />
<form id="form1" runat="server">
<uc2:include_top ID="include_top1" runat="server" />
<div class="main clearfix floatcenter">
	<uc5:include_left ID="include_left1" runat="server" />
	<div class="about_right">
		<div class="about_right1 clearfix">
			<h1><asp:literal id="lbCalled" runat="server"></asp:literal></h1>            
			<h2><asp:literal id="lbCalled1" runat="server"></asp:literal></h2>
			<h3><span>·</span><a href="index.aspx">首页</a> &gt; <a href="about.aspx">关于阿拉桐</a> &gt; <asp:hyperlink id="hyCalled" runat="server"></asp:hyperlink>
            </h3>
		</div>
		<div class="newinfo">
			<h1><asp:literal id="lbTitle" runat="server" /></h1>
			<span>录入时间：<asp:Literal id="lbNoteTime" runat="server" />&nbsp;&nbsp;&nbsp;作者：<asp:Literal id="lbAuthor" runat="server" />&nbsp;&nbsp;&nbsp;来源：<asp:Literal id="lbOrigin" runat="server" /></span>
			<div>
                <asp:literal id="lbContent" runat="server" />
            </div>
		</div>
	</div>    
</div>
<uc3:include_bottom ID="include_bottom1" runat="server" />
</form>
<uc4:include_foot ID="include_foot1" runat="server" />