<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="MyWeb.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
 <table>
        <tr id="tr1">
            <td>Link: </td>
            <td>
                <asp:DropDownList ID="DDLLinkType" runat="server">
                    <asp:ListItem Value="0">LinkModule</asp:ListItem>
                    <asp:ListItem Value="1">Text Link</asp:ListItem>
                </asp:DropDownList> </td>
        </tr>
        <tr>
            <td>
               Link type
            </td>
            <td>
             <table>
                    <tr id="linkmodule">
                        <td>
                    <asp:DropDownList ID="DDLLinkModule" runat="server">
                    </asp:DropDownList> </td>
                    </tr>
                    <tr id="textmodule" style="display:none;">
                        <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            ChangeType($('#<%= DDLLinkType.ClientID %>').val());
            $('#<%= DDLLinkType.ClientID  %>').change(function () {
                ChantypeLink(this.value);
            });
            function ChantypeLink(value) {
                if (value == 0) {
                    $('#linkmodule').css("display", "");
                    $('#textmodule').css("display", "none");
                }
                else if (value == 1) {
                    $('#linkmodule').css("display", "none");
                    $('#textmodule').css("display", "");
                }
            }
        });
    </script>
</asp:Content>
