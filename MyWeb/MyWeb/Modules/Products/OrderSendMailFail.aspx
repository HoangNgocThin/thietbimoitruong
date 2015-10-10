<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="OrderSendMailFail.aspx.cs" Inherits="MyWeb.Modules.Products.OrderSendMailFail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px;">
        <asp:Literal ID="ltrMessage" Text="Hệ thống đã nhận đặt hàng của bạn nhưng đã có lỗi xẩy ra khi gửi mail cho ban quản trị !!" runat="server"></asp:Literal>
    </div>
</asp:Content>
