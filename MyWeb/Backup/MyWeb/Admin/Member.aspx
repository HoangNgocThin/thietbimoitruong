<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="True" CodeBehind="Member.aspx.cs" Inherits="MyWeb.Admin.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" > 
<div class="PageName">Quản lý người dùng</div>
<asp:Panel ID="pnView" runat="server">
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdMember" runat="server" width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="False" onitemdatabound="grdMember_ItemDataBound" onitemcommand="grdMember_ItemCommand" onpageindexchanged="grdMember_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" /><asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
<asp:BoundColumn DataField="Name" HeaderText="Tên người dùng" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="Username" HeaderText="Tên đăng nhập" ItemStyle-CssClass="Text" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="CheckBox"> <HeaderTemplate>Kích hoạt</HeaderTemplate> <ItemTemplate> <asp:label id="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate> </asp:TemplateColumn>
</Columns></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
<tr style="display:none"> <th> <asp:Label ID="lblGroupMemberId" runat="server" Text="Nhóm người dùng:"></asp:Label></th><td><asp:DropDownList ID="ddlGroupMember" runat="server"></asp:DropDownList> <%--<asp:RequiredFieldValidator ID="rfvGroupMember" runat="server" ControlToValidate="ddlGroupMember" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"/>--%></td></tr><tr> <th> <asp:Label ID="lblName" runat="server" Text="Tên người dùng:"></asp:Label></th><td><asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr>
    <tr>
        <th>
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="text"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                ControlToValidate="txtEmail" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr> <th> <asp:Label ID="lblUsername" runat="server" Text="Tên đăng nhập:"></asp:Label></th><td><asp:TextBox ID="txtUsername" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr><tr> <th> <asp:Label ID="lblPassword" runat="server" Text="Mật khẩu:"></asp:Label></th><td><asp:TextBox ID="txtPassword" runat="server" CssClass="datetime"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label></th><td><asp:CheckBox ID="chkActive" runat="server" /></td></tr><tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
</asp:Content>
