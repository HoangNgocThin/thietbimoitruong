<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="MyWeb.Modules.Page.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
 <div class='dv_sp_header'>
<div class="dv_span">
    <span>
        <asp:Label ID="lblheader" runat="server" Text=""></asp:Label></span>
</div>
    <div class="dv_page">
     <asp:Literal ID="ltrpage" runat="server"></asp:Literal>
    </div>
</div>
</asp:Content>
