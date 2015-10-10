<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="OrderSuccess.aspx.cs" Inherits="MyWeb.Modules.Products.OrderSuccess" %>
<%--<meta http-equiv="refresh" content="500; URL=Default.aspx">--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta http-equiv="refresh" content="10; URL=Default.aspx" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
    <div class="dv_order_success">
        <table>
        <tr>
            <td align="center"><p>
                <asp:Literal ID="ltrmessage" runat="server"></asp:Literal>
        </p></td>
        </tr>
        </table>

    </div>
</asp:Content>
