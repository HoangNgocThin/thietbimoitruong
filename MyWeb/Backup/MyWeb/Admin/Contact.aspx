﻿<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="True" CodeBehind="Contact.aspx.cs" Inherits="MyWeb.Admin.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" > 
<div class="PageName">Quản lý liên hệ, phản hồi</div>
<asp:Panel ID="pnView" runat="server">
<div class="Control"><ul><li><%--<asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton>--%></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdContact" runat="server" width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="50" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" onitemdatabound="grdContact_ItemDataBound" onitemcommand="grdContact_ItemCommand" onpageindexchanged="grdContact_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" /><asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
<asp:BoundColumn DataField="Name" HeaderText="Họ tên" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="Company" HeaderText="Công ty" ItemStyle-CssClass="MultiLine" Visible="true" />
<asp:BoundColumn DataField="Address" HeaderText="Địa chỉ" ItemStyle-CssClass="MultiLine" Visible="true" />
<asp:BoundColumn DataField="Tel" HeaderText="Điện thoại" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="Mail" HeaderText="Mail" ItemStyle-CssClass="Text" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="DateTime"> <HeaderTemplate>Ngày đăng</HeaderTemplate> <ItemTemplate> <asp:label runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDateTime(DataBinder.Eval(Container.DataItem, "Date").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Active"> <HeaderTemplate>Chưa xem</HeaderTemplate> <ItemTemplate> <asp:label id="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate> </asp:TemplateColumn>
</Columns><PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle></asp:Datagrid>
<div class="Control"><ul><li><%--<asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton>--%></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
<tr> <th> <asp:Label ID="lblName" runat="server" Text="Họ tên:"></asp:Label></th><td><asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr><tr> <th> <asp:Label ID="lblCompany" runat="server" Text="Công ty:"></asp:Label></th><td><asp:TextBox ID="txtCompany" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblAddress" runat="server" Text="Địa chỉ:"></asp:Label></th><td><asp:TextBox ID="txtAddress" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblTel" runat="server" Text="Điện thoại:"></asp:Label></th><td><asp:TextBox ID="txtTel" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblMail" runat="server" Text="Mail:"></asp:Label></th><td><asp:TextBox ID="txtMail" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckDetail" runat="server"/></td></tr><tr> <th> <asp:Label ID="lblDate" runat="server" Text="Ngày đăng:"></asp:Label></th><td><asp:TextBox ID="txtDate" runat="server" CssClass="text datetime"/><asp:MaskedEditExtender ID="meeDate" runat="server" Mask="99/99/9999 99:99:99" MaskType="DateTime" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate" AcceptAMPM="True" Century="2000"/> <asp:MaskedEditValidator ID="mevDate" runat="server" ControlExtender="meeDate" ControlToValidate="txtDate" Display="Dynamic" EmptyValueBlurredText="Date and time is required" IsValidEmpty="True" InvalidValueBlurredMessage="Date and time is invalid" SetFocusOnError="True"/></td></tr><tr> <th> <asp:Label ID="lblActive" runat="server" Text="Chưa xem:"></asp:Label></th><td><asp:CheckBox ID="chkActive" runat="server" /></td></tr><tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
</asp:Content>
