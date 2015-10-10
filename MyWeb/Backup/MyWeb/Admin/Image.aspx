<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Image.aspx.cs" Inherits="MyWeb.Admin.Image" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" > 
<div class="PageName">Quản lý danh sách Ảnh</div>
<asp:Panel ID="pnView" runat="server">
<div style="margin-bottom: 5px">
    <asp:DropDownList ID="drlChuyenmuc" runat="server" AutoPostBack="True" 
        onselectedindexchanged="drlChuyenmuc_SelectedIndexChanged">
    </asp:DropDownList>
    </div>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdGroupNews" runat="server" width="100%" AutoGenerateColumns="False"  PagerStyle-HorizontalAlign="Center"  CssClass="TableView" AllowPaging="True" PageSize="30" PagerStyle-Mode="NumericPages" onitemdatabound="grdGroupNews_ItemDataBound" onitemcommand="grdGroupNews_ItemCommand" onpageindexchanged="grdGroupNews_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" /><asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
<asp:TemplateColumn ItemStyle-CssClass="Text"> <HeaderTemplate>Tên ảnh</HeaderTemplate> <ItemTemplate> <asp:label runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name") %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Image"> <HeaderTemplate>Hình ảnh</HeaderTemplate> <ItemTemplate> <script type="text/javascript">playfile('<%#DataBinder.Eval(Container.DataItem, "File").ToString() %>', "95", "80", "false", "", "", "")</script> </ItemTemplate> </asp:TemplateColumn>
<asp:BoundColumn DataField="Ord" HeaderText="Thứ tự" ItemStyle-CssClass="Number" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="Active"> <HeaderTemplate>Kích hoạt</HeaderTemplate> <ItemTemplate> <asp:label id="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate> </asp:TemplateColumn>
</Columns></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
<tr> <th> <asp:Label ID="lblName0" runat="server" Text="Nhóm ảnh:"></asp:Label></th><td>
    <asp:DropDownList ID="drlNhomanh" runat="server">
    </asp:DropDownList>
    </td></tr>
    <tr>
        <th>
            <asp:Label ID="lblName" runat="server" Text="Tên ảnh:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr> <th> <asp:Label ID="lblTitle0" runat="server" Text="File:"></asp:Label></th><td>
            <asp:TextBox ID="txtFile" runat="server" CssClass="text image"></asp:TextBox>
            &nbsp;<input ID="btnImgFile" type="button" onclick="BrowseServer('<% =txtFile.ClientID %>','Files');" value="Browse Server" />&nbsp;&nbsp; <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" />
            </td></tr>
    <tr>
        <th>
            <asp:Label ID="lblTitle" runat="server" Text="Title meta:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="text"></asp:TextBox>
        </td>
    </tr>
    <tr> <th> <asp:Label ID="lblDescription" runat="server" Text="Description meta:"></asp:Label></th><td><asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblKeyword" runat="server" Text="Keyword meta:"></asp:Label></th><td><asp:TextBox ID="txtKeyword" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblOrd" runat="server" Text="Thứ tự:"></asp:Label></th><td><asp:TextBox ID="txtOrd" runat="server" CssClass="text number"/><asp:RequiredFieldValidator ID="rfvOrd" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr><tr> <th> 
    <asp:Label ID="lblActive0" runat="server" Text="Xuất hiện ưu tiên:"></asp:Label></th><td>
        <asp:RadioButtonList ID="rbtUutien" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">Bình thường</asp:ListItem>
            <asp:ListItem Value="1">Xuất hiện trang chủ</asp:ListItem>
        </asp:RadioButtonList>
    </td></tr>
    <tr>
        <th>
            <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label>
        </th>
        <td>
            <asp:CheckBox ID="chkActive" runat="server" />
        </td>
    </tr>
    <tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
</asp:Content>
