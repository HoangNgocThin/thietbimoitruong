<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="MyWeb.Controls.Top" %>
<%@ Register src="Language.ascx" tagname="Language" tagprefix="uc1" %>
<div class="topbanner">
<div class="Logotop"><asp:Literal ID="ltrAdv" runat="server"></asp:Literal></div>
<div class="tool">
    <table width="100%"  border="0" cellspacing="0" cellpadding="3" style="border-collapse:collapse;border-color:White">
      <tr class="support_lang">
        <td style="width:1px"></td>
        <td><asp:Literal ID="ltr_help" runat="server" Text="Trợ giúp: 0989 868 999"></asp:Literal></td>
        <td><uc1:Language ID="Language1" runat="server" /></td>
      </tr>
      <tr class="search">
        <td style="width:1px;padding-right:10px"><img src="/images/icon_giohang.gif" align="middle" /></td>
        <td><asp:Label ID="lblsp" runat="server" Text="Sản phẩm"></asp:Label>(<asp:Label ID="lblNumpro" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label>) <asp:Label ID="lbltitlemoney" runat="server" Text="Số tiền"></asp:Label>:<asp:Label ID="lblMoney" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label>
            <div class="viewcard">
                <asp:LinkButton ID="lbtviewcard" runat="server" Text="Xem giỏ hàng" 
                    onclick="lbtviewcard_Click"></asp:LinkButton>|<asp:LinkButton ID="lbtpay" runat="server" Text="Thanh toán"></asp:LinkButton>
            </div>
        </td>
        <td class="textsearch">
        <asp:Panel ID="pnsearch" runat="server" DefaultButton="ibtsearch">
         <table width="1"  border="0" cellspacing="0" cellpadding="0" style="border-collapse:collapse" align="right">
          <tr>
            <td style="width:1px">
                <asp:Image ID="imglefttext" runat="server" ImageUrl ="~/images/bg_left_text.gif" ImageAlign="Middle" />
            </td><td style="width:1px">
                <asp:TextBox ID="txtsearch" runat="server" BackColor="#9F9F9F" Text="Tìm kiếm sản phẩm" value="Tìm kiếm sản phẩm" onBlur="if (this.value=='')this.value='Tìm kiếm sản phẩm';" onFocus="if (this.value=='Tìm kiếm sản phẩm') this.value='';" onKeyUp="telexingVietUC(this,event);"
                      BorderStyle="Solid"></asp:TextBox>
                       <asp:TextBox ID="txtearchen" runat="server" BackColor="#9F9F9F" Text="Search Products" value="Search Products" onBlur="if (this.value=='')this.value='Search Products';" onFocus="if (this.value=='Search Products') this.value='';" onKeyUp="telexingVietUC(this,event);"
                      BorderStyle="Solid" Visible="false"></asp:TextBox>
             </td><td style="width:1px">
            <asp:ImageButton ID="ibtsearch" runat="server" ImageUrl="~/images/bg_btnseach.gif" ImageAlign="Middle"/>
            </td>
            </tr>
            </table>
            </asp:Panel>
        </td>
      </tr>
    </table>
</div>
</div>
<div id="menu"><asp:Literal ID="ltrMenu" runat="server"></asp:Literal></div>
<script type="text/javascript">
$(document).ready(function($){
    $('#mega-menu').dcMegaMenu({
		rowItems: '3',
		speed: 'fast',
		effect: 'slide'
    });
});
</script>