// JavaScript Document
//交换图象存储
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

//预载入图象
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

//查找对象
function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

//交换图象
function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

//隐藏显示层
function MM_showHideLayers() { //v9.0
    var i, p, v, obj, args = MM_showHideLayers.arguments;
    for (i = 0; i < (args.length - 2); i += 3)
        with (document) if (getElementById && ((obj = getElementById(args[i])) != null)) {
        v = args[i + 2];
        if (obj.style) { obj = obj.style; v = (v == 'show') ? 'visible' : (v == 'hide') ? 'hidden' : v; }
        obj.visibility = v;
    }
}

//隐藏显示层，加强版
function MM_showHideLayers_pro() { //v9.0
    var i, p, v, obj, args = MM_showHideLayers_pro.arguments;
    for (i = 0; i < (args.length - 2); i += 3)
        with (document) if (getElementById && ((obj = getElementById(args[i])) != null)) {
        v = args[i + 2];
        if (obj.style) { obj = obj.style; v = (v == 'show') ? 'block' : (v == 'hide') ? 'none' : v; }
        obj.display = v;
    }
}

//重新获取验证码
function ReGetVerifyCode(myIMG) {
    MM_findObj(myIMG).src = "VerifyCodeImg.aspx?ID=" + MM_GetTime();
}

//检查后台用户登录表单
function checkLogin(theform)
{
	if(theform.username.value=="")
	{
		alert("请填写用户名！");
		theform.username.focus();
		return false;
	}
	if(theform.password.value=="")
	{
		alert("请填写密码！");
		theform.password.focus();
		return false;
	}
	if(theform.code.value=="")
	{
		alert("请填写验证码！");
		theform.code.focus();
		return false;
	}
}

//更换控件的css样式
function ChangeClassName(obj, classname) {
    obj.className = classname;
}

//ASCII字符长度
String.prototype.len = function() {
    return this.replace(/[^x00-xff]/g, "**").length;
}

//去掉字符串头部和尾部的空格
String.prototype.trim = function() {
    //   用正则表达式将前后空格   
    //   用空字符串替代。   
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

//截取字符串前面几个字符（按英文字节算、带省略号）
String.prototype.sub = function(n) {
    var r = /[^\x00-\xff]/g;
    if (this.replace(r, "mm").length <= n) return this;
    // n = n - 3;     
    var m = Math.floor(n / 2);
    for (var i = m; i < this.length; i++) {
        if (this.substr(0, i).replace(r, "mm").length >= n) {
            return this.substr(0, i) + "...";
        }
    } return this;
};

//获取时间
function MM_GetTime() {
    var d = new Date();
    return d.getTime();
}

//判断浏览器
var userAgent=navigator.userAgent,isIE=false;
if (userAgent.indexOf('MSIE') != -1)
{
	isIE=true;
}

if(!isIE){ //firefox innerText define
   HTMLElement.prototype.__defineGetter__(     "innerText",
    function(){
     var anyString = "";
     var childS = this.childNodes;
     for(var i=0; i<childS.length; i++) {
      if(childS[i].nodeType==1)
       anyString += childS[i].tagName=="BR" ? '\n' : childS[i].innerText;
      else if(childS[i].nodeType==3)
       anyString += childS[i].nodeValue;
     }
     return anyString;
    }
   );
   HTMLElement.prototype.__defineSetter__(     "innerText",
    function(sText){
     this.textContent=sText;
    }
   );
}

//验证新闻表单
function checkNewAdd(theform)
{
	if(theform.ddlNewType.selectedIndex==0)
	{
		alert("请选择新闻类型！");
		theform.ddlNewType.focus();
		return false;
	}
	if(theform.tbTitle.value.trim()=="")
	{
		alert("请填写新闻标题！");
		theform.tbTitle.focus();
		return false;
	}
}

//全选
function CheckAll()
{
	var checkbox=document.all.tags("input");
	for(var i=0;i<checkbox.length;i++)
	{
		if(checkbox[i].type=="checkbox")
		{
			if(checkbox[i].name.indexOf("cbSel")>-1)
			{
				if(!checkbox[i].checked)
				checkbox[i].click();
			}
		}
	}
}

//反选
function CheckOthers()
{
	var checkbox=document.all.tags("input");
	for(var i=0;i<checkbox.length;i++)
	{
		if(checkbox[i].type=="checkbox")
		{
			if(checkbox[i].name.indexOf("cbSel")>-1)
				checkbox[i].click();
		}
	}
}

//跳转地址
function GotoPage(url,objName)
{
	obj=MM_findObj(objName);
	url=url.replace("page=","page="+obj.value)
	window.location.href=url;
}

//验证产品分类表单
function checkProTypeAdd(theform)
{
	if(theform.tbTypeCalled.value.trim()=="")
	{
		alert("请填写产品分类名称！");
		theform.tbTypeCalled.focus();
		return false;
	}
}

//验证产品表单
function checkProAdd(theform)
{	
	if(theform.ddlType.selectedIndex==0)
	{
		alert("请选择产品分类！");
		theform.ddlType.focus();
		return false;
	}
	if(theform.tbProName.value.trim()=="")
	{
		alert("请填写产品名称！");
		theform.tbProName.focus();
		return false;
	}
}

//验证链接表单
function checkLinkAdd(theform)
{	
	if(theform.ddlType.selectedIndex==0)
	{
		alert("请选择链接分类！");
		theform.ddlType.focus();
		return false;
	}
	if(theform.tbCalled.value.trim()=="")
	{
		alert("请填写链接名称！");
		theform.tbCalled.focus();
		return false;
	}
	if(theform.tbLink.value.trim()=="")
	{
		alert("请填写链接地址！");
		theform.tbLink.focus();
		return false;
	}
}

//验证新增管理菜单
function checkAdminMenuAdd(theform)
{
	if(theform.tbTitle.value.trim()=="")
	{
		alert("请填写菜单名称！");
		theform.tbTitle.focus();
		return false;
	}
}

//验证新增管理菜单
function checkAdminAdd(theform) {
    if (theform.tbUserName.value.trim() == "") {
        alert("请填写用户名！");
        theform.tbUserName.focus();
        return false;
    }
    else {
        var re = new RegExp(/^\w+$/);
        if (!re.test(theform.tbUserName.value)) {
            alert("用户名必须是，英文、数字或下划线！");
            theform.tbUserName.focus();
            return false;
        }
    }
    if (theform.tbPassWord.value.trim() == "") {
        alert("请填写密码！");
        theform.tbPassWord.focus();
        return false;
    }
    if (theform.tbUserRole.value.trim() == "") {
        alert("请填写用户权限！");
        theform.tbUserRole.focus();
        return false;
    }
    else {
        var re = new RegExp(/^(?:0|[1-9][0-9]?|255)$/);
        if (!re.test(theform.tbUserRole.value)) {
            alert("数字必须是0-255之间的正整数！");
            theform.tbUserRole.focus();
            return false;
        }
    }
    if (theform.tbUserRoleCalled.value.trim() == "") {
        alert("请填写用户称呼！");
        theform.tbUserRoleCalled.focus();
        return false;
    }
}

//验证新增管理菜单
function checkAdminMod(theform) {
    if (theform.tbUserName.value.trim() == "") {
        alert("请填写用户名！");
        theform.tbUserName.focus();
        return false;
    }
    else {
        var re = new RegExp(/^\w+$/);
        if (!re.test(theform.tbUserName.value)) {
            alert("用户名必须是，英文、数字或下划线！");
            theform.tbUserName.focus();
            return false;
        }
    }
    if (theform.tbUserRole.value.trim() == "") {
        alert("请填写用户权限！");
        theform.tbUserRole.focus();
        return false;
    }
    else {
        var re = new RegExp(/^(?:0|[1-9][0-9]?|255)$/);
        if (!re.test(theform.tbUserRole.value)) {
            alert("数字必须是0-255之间的正整数！");
            theform.tbUserRole.focus();
            return false;
        }
    }
    if (theform.tbUserRoleCalled.value.trim() == "") {
        alert("请填写用户称呼！");
        theform.tbUserRoleCalled.focus();
        return false;
    }
}

//验证修改密码表单
function checkPassword(theform) {

    if (theform.tbOldPassWord.value.trim() == "") {
        alert("请填写原始密码！");
        theform.tbOldPassWord.focus();
        return false;
    }
    if (theform.tbNewPassWord.value.trim() == "") {
        alert("请填写新的密码！");
        theform.tbNewPassWord.focus();
        return false;
    }
    if (theform.tbNewPassWord1.value.trim() == "") {
        alert("请再输入一次新的密码！");
        theform.tbNewPassWord1.focus();
        return false;
    }
    if (theform.tbNewPassWord1.value.trim() != theform.tbNewPassWord.value.trim()) {
        alert("两次输入的密码不一致，请确认！");
        theform.tbNewPassWord1.focus();
        return false;
    }
}

//生成静态页面
function GetWriteHtmlResult(plobj)
{
    try
	{
	    SetControlHTML(plobj,"正在生成静态页面，请稍候.....");
    
	    var oBao=GetXmlHttpRequest();
	    oBao.open("GET","../index.aspx?writehtml=1&ssss="+MM_GetTime(),true);
		oBao.onreadystatechange=function()
		{
		    if(oBao.readyState==4)
		    {
		        if(oBao.status==200)
		        {
		            strText=oBao.responseText;
    		            
		            SetControlHTML(plobj,strText);
		            oBao.abort();
					
					MM_findObj("doWriteHtml").value="生成静态页面";
					MM_findObj("doWriteHtml").disabled=false;//解放屏蔽的按钮
		        }
		    }
		}
		oBao.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		oBao.send("");
	}
	catch(ex)
	{}
}

//设置显示或不显示数据
function SetShowOrFalse(plobj,TypeID,v,id)
{
    try {
        //SetControlHTML(plobj, "正在生成静态页面，请稍候.....");

        var oBao = GetXmlHttpRequest();
        oBao.open("POST", "UpdateData.aspx", true);
        oBao.onreadystatechange = function() {
            if (oBao.readyState == 4) {
                if (oBao.status == 200) {
                    strText = oBao.responseText;

                    if (strText == "0") {
                        plobj.innerHTML = "<FONT color=red>×</FONT>";
                        plobj.onclick = function() { SetShowOrFalse(plobj, TypeID, strText, id) };
                    }
                    else {
                        plobj.innerHTML = "<FONT color=blue>√</FONT>";
                        plobj.onclick = function() { SetShowOrFalse(plobj, TypeID, strText, id) };
                    }
                    oBao.abort();
                }
            }
        }
        oBao.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        oBao.send("Action=SetShowOrFalse&typeid=" + escape(TypeID) + "&v=" + escape(v) + "&id=" + id+"&ssss=" + MM_GetTime());
    }
    catch (ex)
	{ }
}

//设置显示或不显示数据
function GetUserList(plobj, v) {
    try {
        if (v.length > 1) {
            SetControlHTML(plobj, "正在获取用户列表，请稍后……");

            var oBao = GetXmlHttpRequest();
            oBao.open("POST", "UpdateData.aspx", true);
            oBao.onreadystatechange = function() {
                if (oBao.readyState == 4) {
                    if (oBao.status == 200) {
                        strText = oBao.responseText;
                        SetControlHTML(plobj, strText);
                        oBao.abort();
                    }
                }
            }
            oBao.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            oBao.send("Action=GetUserList&username=" + escape(v) + "&ssss=" + MM_GetTime());
        }
    }
    catch (ex)
	{ }
}

//设置用户ID
function SetUserID(v,s) {
    MM_findObj("tbUserID").value = v;
    MM_findObj("tbUserName").value = s;
}

//设置控件的HTML
function SetControlHTML(obj,str)
{
    MM_findObj(obj).innerHTML=str;
}

//获取xmlhttp对象
function GetXmlHttpRequest()
{
    var oBao;
    if(window.XMLHttpRequest)
	{
	    oBao=new XMLHttpRequest();
	}
	else if(window.ActiveXObject)
	{
	    oBao=new ActiveXObject("Microsoft.XMLHTTP");
	}
	else
	{
	    alert("您的浏览器不支持XMLHTTP无刷新技术！");
	    return;
	}
	return oBao;
}

//选中菜单背景
function SelectAdminMenuBg(str, strUrl) {
    MM_findObj(str).value = strUrl.substr(strUrl.indexOf("images"), strUrl.length - strUrl.indexOf("images")); 
    MM_showHideLayers_pro('selectMenuBgDiv', '', 'hide');
}

var objEditor = null; //编辑器赋值对象
//模板对象
var templateContent1 = "";

var templateContent2 = "";
