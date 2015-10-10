<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchProduct.ascx.cs" Inherits="MyWeb.Modules.Search.SearchProduct" %>
<div class="nav">Tìm kiếm sản phẩm</div>
<asp:RadioButtonList ID="RadioButtonList1" runat="server">
    <asp:ListItem Value="0">Dưới 50000</asp:ListItem>
    <asp:ListItem Value="1">50000 - 100000</asp:ListItem>
    <asp:ListItem Value="2">100.000 - 150.000</asp:ListItem>
    <asp:ListItem Value="3">150.000 - 200.000</asp:ListItem>
    <asp:ListItem Value="4">200.000 - 300.000</asp:ListItem>
</asp:RadioButtonList>

