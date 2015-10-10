<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Advertise.aspx.cs" Inherits="MyWeb.Admin.Advertise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main-zone-wrapper" runat="server">
    <div class="PageName">Quảng cáo</div>
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
        <asp:DataGrid ID="grdAdvertise" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdAdvertise_ItemDataBound" OnItemCommand="grdAdvertise_ItemCommand" OnPageIndexChanged="grdAdvertise_PageIndexChanged">
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
                <asp:BoundColumn DataField="Name" HeaderText="Tên quảng cáo" ItemStyle-CssClass="Text" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="Image">
                    <HeaderTemplate>Hình ảnh</HeaderTemplate>
                    <ItemTemplate>
                        <script type="text/javascript"> playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Link" HeaderText="Liên kết" ItemStyle-CssClass="Text" Visible="true" />
                <asp:TemplateColumn HeaderText="Vị trí" ItemStyle-CssClass="Text" Visible="true">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# positionValue(DataBinder.Eval(Container.DataItem, "Position").ToString()) %>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Ord" HeaderText="Thứ tự" ItemStyle-CssClass="Number" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="Active">
                    <HeaderTemplate>Kích hoạt</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>Chức năng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' />
                    </ItemTemplate>
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
                <td>
                    <asp:Label ID="lblPageLinkId" runat="server" Text="Liên kết tới trang:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlPageLink" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvPageLink" runat="server" ControlToValidate="ddlPageLink" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" /></td>
            </tr>
            <tr>
                <td>Tên quảng cáo:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Hình ảnh:</td>
                <td>
                    <asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>&nbsp;
                    <input id="btnImgImage" type="button" onclick="BrowseServer('<%= txtImage.ClientID %>','Images');" value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
            <tr>
                <td>Độ rộng:</td>
                <td>
                    <asp:TextBox ID="txtWidth" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Chiều cao:</td>
                <td>
                    <asp:TextBox ID="txtHeight" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Liên kết:</td>
                <td>
                    <asp:TextBox ID="txtLink" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Kiểu liên kết:</td>
                <td>
                    <asp:TextBox ID="txtTarget" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nội dung:</td>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckContent" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPosition" runat="server" Text="Vị trí:"></asp:Label>
                </td>
                <td>
                    <AjaxControl:ComboBox ID="cboPosition" runat="server" Width="100px">
                        <asp:ListItem Value="0" Text="Menu trái"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Menu trên"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Slide"></asp:ListItem>
                    </AjaxControl:ComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblClick" runat="server" Text="Click:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtClick" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblOrd" runat="server" Text="Thứ tự:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtOrd" runat="server" CssClass="text number" /><asp:RequiredFieldValidator ID="rfvOrd" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label></td>
                <td>
                    <asp:CheckBox ID="chkActive" runat="server" /></td>
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
