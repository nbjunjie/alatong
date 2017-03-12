<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jm_add.aspx.cs" Inherits="alatong.jm_add" %>

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
			<h1>在线加盟</h1>            
			<h2>Online franchise</h2>
			<h3><span>·</span><a href="index.aspx">首页</a> &gt; <a href="jm.aspx?id=7">加盟中心</a> &gt; <asp:hyperlink id="hyCalled" runat="server"></asp:hyperlink>
            </h3>
		</div>
		<div class="about_text">
            <table width="70%" align="center">
                <tr>
                    <th class="style1">姓名：</th>
                    <td class="style1"><asp:TextBox id="tbUserName" runat="server" Width="100px" />
                    请输入您的姓名！<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="tbUserName" Display="None" ErrorMessage="请输入姓名！" 
            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>手机：</th>
                    <td><asp:TextBox id="tbMobile" runat="server" Width="150px" />
                    请输入您的手机号码！<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="tbMobile" Display="None" ErrorMessage="请输入手机号码！" 
            SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="tbMobile" Display="None" ErrorMessage="手机号码格式错误！" 
            SetFocusOnError="True" ValidationExpression="1[0-9]{10}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <th>情况：</th>
                    <td><asp:TextBox id="tbMemo" runat="server" TextMode="MultiLine" Height="200px" 
                            Width="400px" /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="tbMemo" Display="None" ErrorMessage="请输入情况说明！" 
            SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th><asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                  ShowMessageBox="True" ShowSummary="False" /></th>
                    <td><asp:Button id="btJM" runat="server" Text="立即申请" onclick="btJM_Click" /></td>
                </tr>
            </table>
		</div>
	</div>    
</div>
<uc3:include_bottom ID="include_bottom1" runat="server" />
</form>
<uc4:include_foot ID="include_foot1" runat="server" />