<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Right.ascx.cs" Inherits="MyWeb.Controls.Right" %>
<%@ Register src="../Modules/Search/vandon_wuc.ascx" tagname="vandon_wuc" tagprefix="uc1" %>
<%@ Register src="../Modules/Search/lichbay_wuc.ascx" tagname="lichbay_wuc" tagprefix="uc2" %>
<%@ Register src="../Modules/Search/hanghoa_wuc.ascx" tagname="hanghoa_wuc" tagprefix="uc3" %>
<div class="nav">Tra cứu vận đơn</div>
<div class="block-bg"><uc1:vandon_wuc ID="vandon_wuc1" runat="server" /></div>
<div class="nav">Tra cứu chuyến bay</div>
<div class="block-bg"><uc2:lichbay_wuc ID="lichbay_wuc1" runat="server" /></div>
<div class="nav">Tra cứu hàng hóa</div>
<div class="block-bg"><uc3:hanghoa_wuc ID="hanghoa_wuc1" runat="server" /></div>
<asp:Literal ID="ltrAdv" runat="server"></asp:Literal>


