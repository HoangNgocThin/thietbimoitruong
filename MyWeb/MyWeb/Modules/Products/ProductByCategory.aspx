<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="ProductByCategory.aspx.cs" Inherits="MyWeb.Modules.Products.ProductByCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="productList">
        <div class="productList_head">
            <span>
                <asp:Literal ID="ltrTitle" runat="server"></asp:Literal></span>
        </div>
        <div class="productlist_main">
            <asp:Literal ID="ltrProduct" runat="server"></asp:Literal>
        </div>
        <div class="dv_paging">
            <asp:Literal ID="ltrpaging" runat="server"></asp:Literal>
        </div>
    </div>
     
</asp:Content>
