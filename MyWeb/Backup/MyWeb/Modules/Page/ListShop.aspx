<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="ListShop.aspx.cs" Inherits="MyWeb.Modules.Page.ListShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
<div class='dv_sp_header'>
<div class="dv_span">
    <span>Danh sách các cửa hàng trực thuộc</span>
</div>
<div class="dv_sp">
    <asp:Literal ID="ltrlistshop" runat="server"></asp:Literal>
</div>
</div>
</asp:Content>
