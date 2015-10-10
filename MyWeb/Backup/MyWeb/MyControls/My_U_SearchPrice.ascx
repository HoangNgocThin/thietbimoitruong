<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_SearchPrice.ascx.cs" Inherits="MyWeb.MyControls.My_U_SearchPrice" %>
<div id="dv_searchprice">
    <div class="dv_top2">
        <span>Tìm kiếm sản phẩm</span>
    </div>
    <div class="dv_middle2">
        <div id="dv_list_search">
            <asp:RadioButtonList ID="rdobtnprice" runat="server">
                <asp:ListItem Value="0">Dưới 50.000</asp:ListItem>
                <asp:ListItem Value="1">50.000 - 100.000</asp:ListItem>
                <asp:ListItem Value="2">100.000 - 150.000</asp:ListItem>
                <asp:ListItem Value="3">150.000 - 200.000</asp:ListItem>
                <asp:ListItem Value="4">200.000 - 300.000</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="btnsearchprice" CssClass="css_btnsearchprice" runat="server" Text="Tìm kiếm"  CausesValidation="false"
                onclick="btnsearchprice_Click" />
        </div>
    </div>
</div>
