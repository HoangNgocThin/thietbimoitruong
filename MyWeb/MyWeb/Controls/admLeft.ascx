<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="admLeft.ascx.cs" Inherits="MyWeb.Controls.admLeft" %>
<table class="table" cellspacing="0" cellpadding="0">
<tr>
    <td class="left"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td>
    <td>Quản lý </td>
    <td class="image"><img alt="" id="imgdiv1" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div1');"/></td>
    <td class="right"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td>
</tr>
</table>
<asp:Panel ID="div1" CssClass="content" ClientIDMode="Static" runat="server">
<ul>
        <li><img alt="" src="/App_Themes/admin/images/icon_system.jpg"/><asp:LinkButton 
                ID="lbtConfig" CausesValidation="false" runat="server" onclick="LinkButton_Click">Cấu hình</asp:LinkButton></li>
        <li><img alt="" src="/App_Themes/admin/images/icon_user.jpg"/><asp:LinkButton 
                ID="lbtUser" CausesValidation="false" runat="server" onclick="LinkButton_Click">Người dùng</asp:LinkButton></li>
		<li><img alt="" src="/App_Themes/admin/images/icon_page.jpg"/>
            <asp:LinkButton 
                ID="lbtPageLink" CausesValidation="false" runat="server" onclick="LinkButton_Click">Danh mục trang</asp:LinkButton></li>
		
		<li><img alt="" src="/App_Themes/admin/images/icon_adv.jpg"/><asp:LinkButton 
    ID="lbtAdvertise" CausesValidation="false" runat="server" onclick="LinkButton_Click">Liên kết, quảng cáo</asp:LinkButton></li>
        <li><img alt="" src="/App_Themes/admin/images/icon_user.jpg"/><asp:LinkButton 
                ID="lbttbBill_customers" CausesValidation="false" runat="server" onclick="LinkButton_Click">Đơn đặt hàng</asp:LinkButton></li>
    </ul>
</asp:Panel>
	<%--<table class="table" cellspacing="0" cellpadding="0"><tr><td class="left"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td><td>Tin tức </td><td class="image"><img alt="" id="imgdiv10" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div10');"/></td><td class="right"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td></tr></table>--%><%--<asp:Panel ID="div10" CssClass="content" ClientIDMode="Static" runat="server"><ul> <li><img alt="" src="/App_Themes/admin/images/icon_gpro.jpg"/><asp:LinkButton 
    ID="lbtGroupNews" runat="server" onclick="LinkButton_Click">Nhóm tin</asp:LinkButton></li> <li><img alt="" src="/App_Themes/admin/images/icon_pro.jpg"/><asp:LinkButton 
        ID="lbtNews" runat="server" onclick="LinkButton_Click">Danh sách tin</asp:LinkButton></li> </ul></asp:Panel>--%>
	
	<table class="table" cellspacing="0" cellpadding="0">
    <tr>
    <td class="left"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td>
    <td>Sản phẩm</td><td class="image"><img alt="" id="imgdiv9" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div9');"/></td>
    <td class="right"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td>
    </tr>
    </table>
    <asp:Panel ID="div9" CssClass="content" ClientIDMode="Static" runat="server"><ul><li><img alt="" src="/App_Themes/admin/images/icon_gpro.jpg"/><asp:LinkButton 
    ID="lbtProductCategory" CausesValidation="false" runat="server" onclick="LinkButton_Click">Nhóm sản phẩm</asp:LinkButton></li> 
    <li>
        <img src="/App_Themes/admin/images/icon_pro.jpg"/ alt="">
        <asp:LinkButton 
        ID="lbtProduct" CausesValidation="false" runat="server" onclick="LinkButton_Click">Danh sách sản phẩm</asp:LinkButton></li>
    <li><img src="/App_Themes/admin/images/icon_gpro.jpg"/ alt=""><asp:LinkButton 
        ID="lbtNewsCategory" CausesValidation="false" runat="server" onclick="LinkButton_Click">Nhóm tin tức</asp:LinkButton></li>
    <li><img src="/App_Themes/admin/images/icon_pro.jpg"/ alt=""><asp:LinkButton 
        ID="lbtNews" CausesValidation="false" runat="server" onclick="LinkButton_Click">Tin tức</asp:LinkButton></li>
        </ul>
     
     </asp:Panel>
	

	<%--<table class="table" cellspacing="0" cellpadding="0"><tr><td class="left"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td><td>Quản lý thành viên</td><td class="image"><img alt="" id="imgdiv7" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div7');"/></td><td class="right"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td></tr></table>--%><%--<asp:Panel ID="div7" CssClass="content" ClientIDMode="Static" runat="server"><ul><li><img alt="" src="/App_Themes/admin/images/icon_gpro.jpg"/><asp:LinkButton ID="lbtGroupMember" runat="server" onclick="LinkButton_Click">Nhóm người dùng</asp:LinkButton></li> <li><img alt="" src="/App_Themes/admin/images/icon_pro.jpg"/><asp:LinkButton ID="lbtMember" runat="server" onclick="LinkButton_Click">Người dùng</asp:LinkButton></li></ul></asp:Panel>--%>
    <div class="powered_by">powered by : by : <a href="http://vmms.vn" target="_blank"><b>VMMS</b></a></div>