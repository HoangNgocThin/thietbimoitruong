﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="MyWeb.Admin.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="PageName">Quản lý khách hàng</div>
<asp:Panel ID="pnView" runat="server">
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdtbCUSTOMERS" runat="server" width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="25" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" onitemdatabound="grdtbCUSTOMERS_ItemDataBound" onitemcommand="grdtbCUSTOMERS_ItemCommand" onpageindexchanged="grdtbCUSTOMERS_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="iusid" HeaderText="iusid" Visible="False" />
<asp:BoundColumn DataField="vcusname" HeaderText="Họ tên" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="dbirthday" HeaderText="Ngày sinh" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="vprovince" HeaderText="Tỉnh" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="vaddress" HeaderText="Địa chỉ" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="vmobile" HeaderText="Điện thoại" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="vemail" HeaderText="Email" ItemStyle-CssClass="Text" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"iusid")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"iusid")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /></ItemTemplate> </asp:TemplateColumn>
</Columns><PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
    <tr> <th> <asp:Label ID="lblvpassword" runat="server" Text="Mật khẩu:"></asp:Label></th><td><asp:TextBox ID="txtvpassword" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblvcusname" runat="server" Text="Họ tên:"></asp:Label></th><td><asp:TextBox ID="txtvcusname" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lbldbirthday" runat="server" Text="Ngày sinh:"></asp:Label></th><td><asp:TextBox ID="txtdbirthday" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblvprovince" runat="server" Text="Tỉnh:"></asp:Label></th><td><asp:TextBox ID="txtvprovince" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblvaddress" runat="server" Text="Địa chỉ:"></asp:Label></th><td><asp:TextBox ID="txtvaddress" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblvmobile" runat="server" Text="Điện thoại:"></asp:Label></th><td><asp:TextBox ID="txtvmobile" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblvemail" runat="server" Text="Email:"></asp:Label></th><td><asp:TextBox ID="txtvemail" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
</asp:Content>