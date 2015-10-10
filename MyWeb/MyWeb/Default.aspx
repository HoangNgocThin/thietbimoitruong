<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWeb.Default" %>
<%@ Register src="Controls/ucSlider.ascx" tagname="ucSlider" tagprefix="uc1" %>
<%@ Register src="Controls/ucProductHome.ascx" tagname="ucProductHome" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    
    <uc1:ucSlider ID="ucSlider1" runat="server" />
	<div class="clearBoth"></div>
    <uc2:ucProductHome ID="ucProductHome1" runat="server" />
   
    
</asp:Content>
