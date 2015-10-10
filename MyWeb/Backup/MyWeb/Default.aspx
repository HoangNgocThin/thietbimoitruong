<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWeb.Default" %>
<%@ Register src="Modules/Products/My_U_SP_Banchay.ascx" tagname="My_U_SP_Banchay" tagprefix="uc1" %>
<%@ Register src="Modules/Products/My_U_Sp_Thong_Dung.ascx" tagname="My_U_Sp_Thong_Dung" tagprefix="uc2" %>
<%@ Register src="Modules/Products/My_U_Sp_Moi.ascx" tagname="My_U_Sp_Moi" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
    <asp:Label ID="lbluser" runat="server" Text="" Visible="true"></asp:Label>
    <uc1:My_U_SP_Banchay ID="My_U_SP_Banchay1" runat="server" />
<uc2:My_U_Sp_Thong_Dung ID="My_U_Sp_Thong_Dung1" runat="server" />
<uc3:My_U_Sp_Moi ID="My_U_Sp_Moi1" runat="server" />
    </asp:Content>
