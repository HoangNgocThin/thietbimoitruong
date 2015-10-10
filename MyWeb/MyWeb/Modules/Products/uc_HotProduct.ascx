<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_HotProduct.ascx.cs" Inherits="MyWeb.Modules.Products.uc_HotProduct" %>
<div class="productList">
    <div class="productList_head">
        <span>Sản phẩm mới nhất</span>
    </div>
    <div class="productlist_main">
        <asp:Literal ID="ltrProduct" runat="server"></asp:Literal>
    </div>
</div>
