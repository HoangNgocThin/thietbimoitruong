<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Search_By_Address.aspx.cs" Inherits="MyWeb.Modules.Search.Search_By_Address" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
<div class='dv_sp_header'>
<div class="dv_span">
    <span>Các cửa hàng trực thuộc</span>
</div>
   <div class='dv_shop'>
       <asp:Literal ID="ltrshop" runat="server"></asp:Literal>
   </div>
</div>
</asp:Content>
