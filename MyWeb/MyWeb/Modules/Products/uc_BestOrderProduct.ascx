<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_BestOrderProduct.ascx.cs" Inherits="MyWeb.Modules.Products.uc_BestOrderProduct" %>
<div class="productList">
    <div class="productList_head">
        <span>Sản phẩm bán chạy nhất</span>
    </div>
    <div class="productlist_main">
        <asp:Literal ID="ltrProduct" runat="server"></asp:Literal>
    </div>
</div>
