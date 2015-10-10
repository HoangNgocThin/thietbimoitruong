<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="MyWeb.Modules.Products.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="productList">
        <div class="productList_head">
            <span>Sản phẩm theo phân loại</span>
        </div>
        <div class="productlist_main">
            <asp:Literal ID="ltrProduct" runat="server"></asp:Literal>
        </div>
         <div class="dv_paging">
            <asp:Literal ID="ltrpaging" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
