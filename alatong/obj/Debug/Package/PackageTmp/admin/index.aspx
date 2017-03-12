<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="web1.admin.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>后台用户登录</title>
<script src="scripts/function.js" type="text/javascript"></script>
<link href="css/index.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="login" runat="server" onsubmit="return checkLogin(this)">
<div id="zmain">
    <div class="Login">
        <table width="223" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td height="7"></td>
      </tr>
      <tr>
        <td height="31" align="left" valign="middle"><asp:TextBox runat="server" ID="username" TextMode="SingleLine" MaxLength="50" style="width:210px; font-family:微软雅黑; font-size:14px; height:26px; line-height:26px; border:0px; background-color:Transparent;"></asp:TextBox></td>
      </tr>
      <tr>
        <td height="27" align="left" valign="top"></td>
      </tr>
      <tr>
        <td height="31" align="left" valign="middle"><asp:TextBox runat="server" ID="password" TextMode="Password" MaxLength="50" style="width:210px; font-family:微软雅黑; font-size:14px; height:26px; line-height:26px; border:0px; background-color:Transparent;"></asp:TextBox></td>
      </tr>
      <tr>
        <td height="29" align="left" valign="top"></td>
      </tr>
      <tr>
        <td height="31" align="left" valign="middle">
        <div style="float:left;width:145px;"><asp:TextBox runat="server" ID="code" TextMode="SingleLine" MaxLength="5" style="width:135px; font-family:微软雅黑; font-size:14px; height:26px; line-height:26px; border:0px; background-color:Transparent;" /></div>
        <div style="float:left;width:66px; padding-top:2px;"><a href="#" onclick="ReGetVerifyCode('picCode');"><img src="VerifyCodeImg.aspx" alt="看不清楚请点击这里！" name="picCode" border="0" align="absmiddle" id="picCode" /></a></div></td>
      </tr>
    </table>
    </div>
    <div class="Login_bt"><asp:ImageButton runat="server" 
                  ID="ibtLogin" ImageUrl="images/Darshboard-Login_03.png" onclick="ibtLogin_Click" /></div>
</div>


<div id="footer">

	<div id="bottomInfo" style="width:953px; height:58px; text-align:center; padding-top:20px;">
    TEL:0574-87993919&nbsp;&nbsp;QQ:<a href="http://wpa.qq.com/msgrd?v=3&amp;uin=2247448040&amp;site=qq&amp;menu=yes" target="_blank"><img align="absMiddle" alt="点击这里给我发消息" border="0" src="http://wpa.qq.com/pa?p=2:2247448040:41" title="点击这里给我发消息" /></a>
    <br/>Power By&nbsp;<a href="http://www.innoleader.cn" target="_blank">www.innoleader.cn</a>
    </div>

</div>
</form>
</body>
</html>
