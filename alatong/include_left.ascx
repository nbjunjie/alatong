<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="include_left.ascx.cs" Inherits="alatong.include_left" %>
<asp:Panel ID="pl1" runat="server" CssClass="about_left" Visible="false">
        <h1>美食推荐</h1>
		<ul>
			<asp:Literal ID="lbPro" runat="server" />
		</ul>
</asp:Panel>
<asp:Panel ID="pl2" runat="server" CssClass="about_left" Visible="false">
    <h1>加盟中心</h1>
    <ul>
        <asp:Literal ID="lbJM" runat="server"></asp:Literal>
    </ul>
</asp:Panel>
<asp:Panel ID="pl3" runat="server" CssClass="about_left" Visible="false">
		<h1>关于阿拉桐</h1>
		<ul>
			<asp:Literal ID="lbAbout" runat="server"></asp:Literal>
		</ul>
	</asp:Panel>