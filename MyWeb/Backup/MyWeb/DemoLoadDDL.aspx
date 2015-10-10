<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DemoLoadDDL.aspx.cs" Inherits="MyWeb.DemoLoadDDL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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


    <hr />
    <table>
        <tr>
                <th>
                    <asp:Label ID="lblType" runat="server" Text="Kiểu trang:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server">
                    </asp:DropDownList>
                </td>
        </tr>
        <tr ID="Link">
                <th>
                    <asp:Label ID="lblLink" runat="server" Text="Liên kết:"></asp:Label>
                </th>
                <td>
                    <table border="0" width="100%">
                        <tr>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr ID="LinkInput">
                            <td>
                                <asp:TextBox ID="txtLink" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr ID="Tr2" style="display:none">
                            <td>
                                <asp:DropDownList ID="ddlLink" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
    </table>

      <script type="text/javascript">
          $(document).ready(function () {
              ChangeType($("#<%= ddlType.ClientID %>").val());
              ChangeLinkType($("#<%= ddlLinkType.ClientID %>").val());
              $("#<%= ddlType.ClientID %>").change(function () {
                  ChangeType(this.value);
              });
              $("#<%= ddlLinkType.ClientID %>").change(function () {
                  ChangeLinkType(this.value);
                  ChangeLink("/");
              });
              $("#<%= ddlLink.ClientID %>").change(function () {
                  ChangeLink(this.value);
              });
              function ChangeType(value) {
                  $("#Content, #Content td, #Content iframe").css("height", "320px");
                  if (value == 1) {
                      $("#Link").css("display", "");
                      $("#Content").css("display", "none");
                  }
                  else {
                      $("#Link").css("display", "none");
                      $("#Content").css("display", "");
                  }
              }

              function ChangeLinkType(value) {
                  if (value == 1) {
                      $("#LinkInput").css("display", "");
                      $("#LinkModule").css("display", "none");
                      $("#<%= txtLink.ClientID %>").focus();
                  } else {
                      $("#LinkInput").css("display", "none");
                      $("#LinkModule").css("display", "");
                  }
              }
              function ChangeLink(value) {
                  $("#<%= txtLink.ClientID %>").val(value);
              }
          });
    </script>

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            ChangeType($('#<%= DDLLinkType.ClientID %>').val());
            $('#<%= DDLLinkType.ClientID  %>').change(function{
                ChantypeLink(this.value)
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
