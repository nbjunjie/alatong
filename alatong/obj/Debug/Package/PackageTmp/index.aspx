<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="alatong.index" %>

<%@ Register src="include_head.ascx" tagname="include_head" tagprefix="uc1" %>
<%@ Register src="include_top.ascx" tagname="include_top" tagprefix="uc2" %>
<%@ Register src="include_bottom.ascx" tagname="include_bottom" tagprefix="uc3" %>
<%@ Register src="include_foot.ascx" tagname="include_foot" tagprefix="uc4" %>

<uc1:include_head ID="include_head1" runat="server" />
<form id="form1" runat="server">
<uc2:include_top ID="include_top1" runat="server" />
<div class="main clearfix floatcenter">
	<div class="main_t1">
		<div class="clearfix"><a href="about.aspx"><img src="images/index_12.jpg" width="400" height="47" alt="关于阿拉桐" /></a></div>
		<div class="main_t11 clearfix">
			<dl>
				<dt><asp:literal id="lbInfo5" runat="server"/></dt>
				<dd>
					<span>阿拉桐简介</span><asp:literal id="lbInfo6" runat="server"/>
				</dd>
			</dl>
		</div>
	</div>
	<div class="main_t2">
		<div class="clearfix"><a href="news.aspx"><img src="images/index_13.jpg" width="350" height="47" alt="阿拉桐咨询" /></a></div>
		<ul>
			<asp:literal id="lbNews1" runat="server" />
		</ul>
	</div>
	<div class="main_t3"><a href="jm_add.aspx"><img src="images/index_14.jpg" width="253" height="175" alt="加盟热线：4000-0574-18" /></a></div>
	<div class="clearfix"><a href="jm_add.aspx"><img src="images/index_23.jpg" width="1003" height="180" alt="加盟" /></a></div>
	<div class="main_t4">
		<div class="clearfix"><a href="jm_book.aspx"><img src="images/index_24.jpg" width="489" height="41" alt="阿拉桐问答" /></a></div>
		<div class="main_t44">
            <asp:literal id="lbBook" runat="server" />
		</div>
	</div>
	<div class="main_t5">
		<div class="clearfix"><a href="about.aspx?id=13"><img src="images/index_25.jpg" width="514" height="41" alt="店铺风采" /></a></div>
		<div class="main_t55"><a href="about.aspx?id=13"><img src="images/index_27.jpg" width="514" height="196" /></a></div>
	</div>
	<div class="clearfix"><a href="products.aspx"><img src="images/index_28.jpg" width="1003" height="36" alt="主打美食" /></a></div>
	<div class="main_t6">
		<dl>
			<dt class="pre_btn"><img src="images/spacer.gif" /></dt>
			<dd id="pic_box">
				<ul>
					<asp:literal id="lbProducts" runat="server" />
				</ul>
			</dd>
			<dt class="next_btn"><img src="images/spacer.gif" /></dt>
		</dl>
	</div>
</div>
<uc3:include_bottom ID="include_bottom1" runat="server" />
<script type="text/javascript">
    $(function () {
        $("#pic_box").jCarouselLite({
            btnNext: ".pre_btn",
            btnPrev: ".next_btn",
            visible: 4,
            speed: 2000,
            auto: 1
        });
    });
    $(function () {
        $("#pic_box a").lightbox();
    });
</script>
</form>
<uc4:include_foot ID="include_foot1" runat="server" />