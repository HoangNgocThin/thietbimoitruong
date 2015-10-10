<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="MyWeb.Admin.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">Tin tức</div>
    <table>
    <tr>
        <td>Tin tức :&nbsp; </td>
        <td>
            <asp:TextBox ID="txtSearch" runat="server" Width="300px"></asp:TextBox></td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" /></td>
    </tr>
    </table>

    <asp:Panel ID="pnView" runat="server">
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li>
            </ul>
        </div>
        <asp:DataGrid ID="grdNews" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdNews_ItemDataBound" OnItemCommand="grdNews_ItemCommand" OnPageIndexChanged="grdNews_PageIndexChanged">
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <ItemStyle CssClass="trOdd"></ItemStyle>
            <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
            <Columns>
                <asp:TemplateColumn ItemStyle-CssClass="tdCenter">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="tdCenter"></ItemStyle>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" />
                <asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
                <asp:BoundColumn DataField="Name" HeaderText="Tiêu đề" ItemStyle-CssClass="Text" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="Image">
                    <HeaderTemplate>Hình ảnh</HeaderTemplate>
                    <ItemTemplate>
                        <script type="text/javascript"> playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="DateTime">
                    <HeaderTemplate>Ngày đăng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDateTime(DataBinder.Eval(Container.DataItem, "PostedDate").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                    <HeaderTemplate>Ưu tiên</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "Priority").ToString())%>' /></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                    <HeaderTemplate>Là chỉ mục</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "Index").ToString())%>' /></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Active">
                    <HeaderTemplate>Kích hoạt</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                    <HeaderTemplate>Là tin hot</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image3" runat="server" ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "IsHotNews").ToString())%>' /></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>Chức năng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li>
            </ul>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnUpdate" runat="server" Visible="False">
        <table class="TableUpdate" border="1">
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" OnClick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblNewsCategoryID" runat="server" Text="Nhóm tin tức:"></asp:Label></th>
                <td>
                    <asp:DropDownList ID="ddlNewsCategory" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvNewsCategory" runat="server" ControlToValidate="ddlNewsCategory" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblName" runat="server" Text="Tên bài viết:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <th>
                    <asp:Label ID="lblTitle" runat="server" Text="Tiêu đề:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblImage" runat="server" Text="Hình ảnh:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input id="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>','Images');" value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblContent" runat="server" Text="Tóm tắt:"></asp:Label></th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckContent" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label></th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckDetail" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDescription" runat="server" Text="Description meta:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblKeyword" runat="server" Text="Keyword meta:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblPriority" runat="server" Text="Ưu tiên:"></asp:Label></th>
                <td>
                    <asp:CheckBox ID="chkPriority" runat="server" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblIndex" runat="server" Text="Là chỉ mục:"></asp:Label></th>
                <td>
                    <asp:CheckBox ID="chkIndex" runat="server" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label></th>
                <td>
                    <asp:CheckBox ID="chkActive" runat="server" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblIsHotNews" runat="server" Text="Là tin hot:"></asp:Label></th>
                <td>
                    <asp:CheckBox ID="chkIsHotNews" runat="server" /></td>
            </tr>
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server" OnClick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
