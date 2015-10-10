<%@ Page Title="" Language="C#" Culture="vi-VN" MasterPageFile="~/ThreeMaster.Master" AutoEventWireup="true" CodeBehind="NewsView.aspx.cs" Inherits="MyWeb.Modules.News.NewsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Literal ID="ltrNews" runat="server"></asp:Literal>
<div class="news-search">
    <asp:Label ID="lblNgay" runat="server"></asp:Label> <asp:DropDownList ID="ddrDate" runat="server"></asp:DropDownList> 
    <asp:Label ID="lblThang" runat="server"></asp:Label> <asp:DropDownList ID="ddrMonth" runat="server"></asp:DropDownList> 
    <asp:Label ID="lblNam" runat="server"></asp:Label> <asp:DropDownList ID="ddrYear" runat="server"></asp:DropDownList> 
    <asp:LinkButton ID="viewDate" runat="server" OnClick="viewDate_Click" CssClass="Linkbutton">Xem theo ngày</asp:LinkButton>
    <%--<asp:Button runat="server" ID="viewDate" Text="Xem theo ngày" OnClick="viewDate_Click" />--%>
</div>
</asp:Content>
