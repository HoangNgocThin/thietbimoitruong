<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="True" CodeBehind="EmailRegisters.aspx.cs" Inherits="MyWeb.Admin.EmailRegisters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" > 
<div class="PageName">Quản lý Email đăng ký nhận tin</div>
<asp:Panel ID="pnView" runat="server">
<div class="Control"><ul><li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdEmailRegisters" runat="server" width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="30" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" onitemdatabound="grdEmailRegisters_ItemDataBound" onitemcommand="grdEmailRegisters_ItemCommand" onpageindexchanged="grdEmailRegisters_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" />
<asp:BoundColumn DataField="Email" HeaderText="Email" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="Createdate" HeaderText="Ngày đăng ký" ItemStyle-CssClass="Text" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /></ItemTemplate> </asp:TemplateColumn>
</Columns><PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
<tr> <th> <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label></th><td><asp:TextBox ID="txtEmail" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblCreatedate" runat="server" Text="Ngày đăng ký:"></asp:Label></th><td><asp:TextBox ID="txtCreatedate" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblStatus" runat="server" Text=":"></asp:Label></th><td><asp:TextBox ID="txtStatus" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
</asp:Content>
