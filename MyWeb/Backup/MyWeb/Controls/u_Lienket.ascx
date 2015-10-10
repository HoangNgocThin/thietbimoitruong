<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_Lienket.ascx.cs" Inherits="MyWeb.Controls.u_Lienket" %>
<div class="head-adv-right"><asp:Literal ID="ltrHead" runat="server"></asp:Literal></div>
<div class="box-adv-right">

    <asp:DropDownList ID="drlLink" CssClass="drop-link" runat="server" 
        style="font-family: Arial, Helvetica, sans-serif; font-size: 12px" 
        AutoPostBack="True" onselectedindexchanged="drlLink_SelectedIndexChanged">
    </asp:DropDownList>

</div>