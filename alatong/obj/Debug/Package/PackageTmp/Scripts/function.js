//判断浏览器
var userAgent = navigator.userAgent, isIE = false;
if (userAgent.indexOf('MSIE') != -1) {
    isIE = true;
}

//查找对象
function MM_findObj(n, d) { //v4.0
    var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
        d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
    }
    if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
    for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
    if (!x && document.getElementById) x = document.getElementById(n); return x;
}

//显示隐藏通知层
function MM_showHideLayers() { //v6.0
    var i, p, v, obj, args = MM_showHideLayers.arguments;
    for (i = 0; i < (args.length - 2); i += 3) if ((obj = MM_findObj(args[i])) != null) {
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

//交换图象存储
function MM_swapImgRestore() { //v3.0
    var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
}

//预载入图象
function MM_preloadImages() { //v3.0
    var d = document; if (d.images) {
        if (!d.MM_p) d.MM_p = new Array();
        var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
            if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
    }
}

//交换图象
function MM_swapImage() { //v3.0
    var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
        if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
}

//设置控件的HTML
function SetControlHTML(obj, str) {
    MM_findObj(obj).innerHTML = str;
}

//更换控件的css样式
function ChangeClassName(obj, classname) {
    obj.className = classname;
}

//重新获取验证码
function ReGetVerifyCode(myIMG) {
    MM_findObj(myIMG).src = "/admin/VerifyCodeImg.aspx?ID=" + MM_GetTime();
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

//获取xmlhttp对象
function GetXmlHttpRequest() {
    var oBao;
    if (window.XMLHttpRequest) {
        oBao = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {
        oBao = new ActiveXObject("Microsoft.XMLHTTP");
    }
    else {
        alert("您的浏览器不支持XMLHTTP无刷新技术！");
        return;
    }
    return oBao;
}

//获取时间
function MM_GetTime() {
    var d = new Date();
    return d.getTime();
}

//添加cookie
function addCookie(objName, objValue, objHours) {//添加cookie
    var str = objName + "=" + escape(objValue);
    if (objHours > 0) {//为0时不设定过期时间，浏览器关闭时cookie自动消失
        var date = new Date();
        var ms = objHours * 3600 * 1000;
        date.setTime(date.getTime() + ms);
        str += "; expires=" + date.toGMTString();
    }
    document.cookie = str;
}

//获取指定名称的cookie的值
function getCookie(objName) {
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);
    }
}

//为了删除指定名称的cookie，可以将其过期时间设定为一个过去的时间
function delCookie(name) {
    var date = new Date();
    date.setTime(date.getTime() - 10000);
    document.cookie = name + "=a; expires=" + date.toGMTString();
}

//读取出来所有的cookie字筗串了
function allCookie() {//读取所有保存的cookie字符串
    var str = document.cookie;
    if (str == "") {
        str = "没有保存任何cookie";
    }
    alert(str);
}

//添加收藏
function AddFavorite(sURL, sTitle) {
    try {
        sURL = window.location.href;
        window.external.addFavorite(sURL, sTitle);
    }
    catch (e) {
        try {
            window.external.addToFavoritesBar(sURL, sTitle, 'slice');
        }
        catch (e) {
            try {
                window.sidebar.addPanel(sTitle, sURL, "");
            }
            catch (e) {
                alert("加入收藏失败，请使用Ctrl+D进行添加");
            }
        }
    }
}

//设为首页
function SetHome(obj, vrl) {
    try {
        vrl = window.location.href;
        obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(vrl);
    }
    catch (e) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            }
            catch (e) {
                alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入\"about:config\"并回车\n然后将 [signed.applets.codebase_principal_support]的值设置为'true',双击即可。");
            }
            var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
            prefs.setCharPref('browser.startup.homepage', vrl);
        }
    }
}

//检查用户名
function CheckUserName(source, arguments) {
    var pps = /^[a-zA-Z0-9_\u4e00-\u9fa5]{4,20}$/;
    if (!pps.test(arguments.Value.replace(/[\u4e00-\u9fa5]/g, "11")))
        arguments.IsValid = false;
    else
        arguments.IsValid = true;
}

//检查密码是否一致
function CheckPassWord(source, arguments) {
    if (MM_findObj("tbPassWord").value != arguments.Value)
        arguments.IsValid = false;
    else
        arguments.IsValid = true;
}

//检查单选框是否勾选
function CheckBoxChoose(source, arguments) {
    //检查用户名
    var obj = MM_findObj("cbIsAgree");
    if (obj.checked)
        arguments.IsValid = true;
    else
        arguments.IsValid = false;
}

//检查验证性别
function rbSex_Validation(sender, args) {
    args.IsValid = ($("#rblSex :radio:checked").length > 0);
}

//检查验证性别
function rbDefault_Validation(sender, args) {
    args.IsValid = ($("#rblIsDefault :radio:checked").length > 0);
}

//-----------------------AJAX-----------------------------

//判断用户名是否存在
function CheckUserNameExists(plObj, strSelValue) {

    if (strSelValue.trim() == "")
        SetControlHTML(plObj, "请输入用户名！");
    else {
        try {
            var oBao = GetXmlHttpRequest();
            oBao.open("POST", "AjaxData.aspx", true);
            oBao.onreadystatechange = function () {
                if (oBao.readyState == 4) {
                    if (oBao.status == 200) {
                        strText = oBao.responseText;
                        oBao.abort();

                        if (strText == "1") {
                            SetControlHTML(plObj, "该用户名已经被注册！请选择一个另外的用户名！");
                            MM_showHideLayers_pro(plObj, "", "show");
                        }
                        else {
                            SetControlHTML(plObj, "");
                            MM_showHideLayers_pro(plObj, "", "hide");
                        }
                    }
                }
            }
            oBao.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            oBao.send("Action=CheckUserName&SelValue=" + escape(strSelValue));
        }
        catch (ex)
	    { }
    }
}




//判断是否有母页面，做跳转或关闭
function BackAndClose() {
    //    if (window.opener == null) {
    //        if (window.parent == null)
    //            document.write("<a href='javascript:window.close();'>关闭</a>");
    //        else
    //            document.write("<a href=\"javascript:window.location.href='"+window.parent.location.href+"';\">返回</a>");
    //    }
    //    else {
    //        document.write("<a href=\"javascript:window.location.href='" + window.opener.location.href + "';\">返回</a>");
    //    }
    if (window.opener == null)
        document.write("<a href='javascript:histroy.back();'>返回</a>");
    else
        document.write("<a href='javascript:window.close();'>关闭</a>");
}

//图片切换
function ChangeBigPic(disObj, obj) {
    MM_findObj(disObj).src = obj.src;
}

//小图片滚动
function ScrollPics(objName, strType) {
    if (strType == 1)
        $(objName).scrollLeft($(objName).scrollLeft() - 70);
    else
        $(objName).scrollLeft($(objName).scrollLeft() + 70);
}

//判断email格式是否正确
function checkEmail(strEmail) {
    if (strEmail.trim().indexOf('@') == "-1" || strEmail.trim().indexOf('.') == "-1") {
        return false;
    }
    else
        return true;
}

//显示星期几
function ShowDateTime()
{
	 var dt=new Date();
	 var arr_week=new Array("星期日","星期一","星期二","星期三","星期四","星期五","星期六");
	 var strWeek=arr_week[dt.getDay()];
	 var strHour=dt.getHours();
	 var strMinutes=dt.getMinutes();
	 var strSeconds=dt.getSeconds();
	 if (strMinutes<10) strMinutes="0"+strMinutes;
	 if (strSeconds<10) strSeconds="0"+strSeconds;
	 var strYear=dt.getFullYear()+"年";
	 var strMonth=(dt.getMonth()+1)+"月";
	 var strDay=dt.getDate()+"日";
	 var strTime=strHour+":"+strMinutes+":"+strSeconds;
	 document.write(strYear+strMonth+strDay+"  "+strWeek); 
}

//菜单切换
function ChangeMenu(objName,n)
{
	for(var i=0;i<10;i++)
	{
	    var obj1 = MM_findObj(objName + i);
	    if (obj1 == null)
	        break;
	    else {
	        //obj1.style.marginLeft = "px";
	        MM_showHideLayers_pro(objName + i, '', 'hide');
	    }
	}

	var obj = MM_findObj(objName + n);
    if(n==0)
        obj.style.marginLeft = "56px";
    else if (n == 1)
        obj.style.marginLeft = "138px";
    else if (n == 2)
        obj.style.marginLeft = "265px";
    else if (n == 3)
        obj.style.marginLeft = "360px";
    else if (n == 4)
        obj.style.marginLeft = "380px";
    else if (n == 5)
        obj.style.marginLeft = "447px";
	MM_showHideLayers_pro(objName+n, '', 'show');
}

//线路标签切换
function ChangeProMemoTab(selIndex) {
    for (var i = 1; i < 9; i++) {
        if (i == 4 || i == 6)
        { }
        else {
            MM_showHideLayers_pro("Memo" + i, "", "hide");
            if (selIndex > 0)
                MM_findObj("s_menu" + i).className = "";
        }
    }

    MM_showHideLayers_pro("Memo" + selIndex, "", "show");
    if (selIndex > 0)
        MM_findObj("s_menu" + selIndex).className = "right4_5_8_o";
}

//判断是否选中协议同意
function CheckAgree(source, arguments) {
    var tempObj = MM_findObj("cbIsAgree");
    if (tempObj.checked)
        arguments.IsValid = true;
    else
        arguments.IsValid = false;
}

//检查密码是否一致
function CheckPassWord(source, arguments) {
    if (MM_findObj("tbPassWord").value != arguments.Value)
        arguments.IsValid = false;
    else
        arguments.IsValid = true;
}

var VisaMan=1;

//添加签证人数
function AddVisaMan() {
    var obj = $("#addUser");
    VisaMan++;
    obj.html(obj.html() + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"5\" id=\"user_"+VisaMan+"\">"
                      + "<tr>"
                        + "<td width=\"12%\" rowspan=\"2\" align=\"center\" valign=\"middle\">第 " + VisaMan + " 位</td>"
                        + "<td width=\"24%\">姓名：<input id=\"RealName_" + VisaMan + "\" name=\"RealName_" + VisaMan + "\" style=\"width:100px;\" /></td>"
                        + "<td width=\"27%\">性别：<input id=\"Sex_" + VisaMan + "\" name=\"Sex_" + VisaMan + "\" style=\"width:100px;\" /></td>"
                        + "<td width=\"26%\">联系电话：<input id=\"Tel_" + VisaMan + "\" name=\"Tel_" + VisaMan + "\" style=\"width:100px;\" /></td>"
                        + "<td width=\"11%\" rowspan=\"2\" align=\"center\" valign=\"middle\"><a href=\"javascript:DelVisaMan('#user_"
                        +VisaMan+"')\">删除</a></td>"
                      +"</tr>"
                      + "<tr>"
                        + "<td>证件类型：<input id=\"IDType_" + VisaMan + "\" name=\"IDType_" + VisaMan + "\" style=\"width:100px;\" /></td>"
                        + "<td>证件号码：<input id=\"IDCode_" + VisaMan + "\" name=\"IDCode_" + VisaMan + "\" style=\"width:100px;\" /></td>"
                        +"<td>有效期：<input id=\"IDValidity_"+VisaMan+"\" name=\"IDValidity_"+VisaMan+"\" style=\"width:100px;\" /> </td>"
                      +"</tr>"
                      +"<tr>"
                        +"<td colspan=\"5\" align=\"center\" valign=\"middle\"><div class=\"visa5\"></div></td>"
                      + "</tr>"
                      +"</table>");
}
//删除签证人数
function DelVisaMan(objName) {
    $(objName).replaceWith('');
}

//检测留言
function CheckFeedback(formname) {
    var theform = MM_findObj(formname);
    if (theform.tbRealName.value.trim() == "") {
        alert("请输入姓名！");
        theform.tbRealName.focus();
        return false;
    }
    if (theform.tbTel.value.trim() == "") {
        alert("请输入电话号码！");
        theform.tbTel.focus();
        return false;
    }
    if (theform.tbEMail.value.trim() == "") {
        alert("请输入电子邮箱地址！");
        theform.tbEMail.focus();
       return false;
    }
    else {
        if (!checkEmail(theform.tbEMail.value)) {
            alert("电子邮箱格式错误！");
            theform.tbEMail.focus();
            return false;
        }
    }
    if (theform.s1.selectedIndex == 0) {
        alert("请选择所在地区！");
        theform.s1.focus();
        return false;
    }
    if (theform.tbMemo.value.trim() == "") {
        alert("请输入内容！");
        theform.tbMemo.focus();
        return false;
    }
}

//获取留言信息列表
function GetTanker(plobj, strSelValue, page,strTypeID) {
    try {
        $.ajax({
            type: "POST",
            url: "AjaxData.aspx",
            data: "Action=GetTanker&SelValue=" + strSelValue + "&page=" + page + "&TypeID=" + strTypeID + "&ttt=" + MM_GetTime(),
            success: function (strText) {
                $(plobj).html(strText);
            }
        });
    }
    catch (ex)
	{ }
}


//检查单选框是否勾选
function CheckBoxChoose(source, arguments) {
    //检查用户名
    var obj = MM_findObj("cbIsAgree");
    if (obj.checked)
        arguments.IsValid = true;
    else
        arguments.IsValid = false;
}

//显示隐藏菜单
function ShowHideLeftMenu(objName) {
    var obj = MM_findObj(objName);
    if (obj.style.display == "none")
        MM_showHideLayers_pro(objName, '', 'show');
    else
        MM_showHideLayers_pro(objName, '', 'hide');
}

//选中支付方式显示说明
function SelectedPayType(obj, id) {
    for (var i = 0; i < 10; i++) {
        var o = MM_findObj("plPayType_" + i);
        if (o != null) {
            o.style.display = "none";
        }
    }

    if (obj.checked) {
        MM_findObj("plPayType_" + id).style.display = "block";
    }
}