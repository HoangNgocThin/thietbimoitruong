<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="MyWeb.Admin.Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">Cấu hình</div>
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
        <asp:DataGrid ID="grdConfig" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdConfig_ItemDataBound" OnItemCommand="grdConfig_ItemCommand" OnPageIndexChanged="grdConfig_PageIndexChanged">
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
                <asp:BoundColumn DataField="PageTitle" HeaderText="Tiêu đề" ItemStyle-CssClass="Text" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="DateTime">
                    <HeaderTemplate>Ngày đăng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDateTime(DataBinder.Eval(Container.DataItem, "ModifiedDate").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                    <HeaderTemplate>Áp dụng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "IsApply").ToString())%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>Chức năng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
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
                <th>
                    <asp:Label ID="lblBanner" runat="server" Text="Banner:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtBanner" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input id="btnImgBanner" type="button" onclick="BrowseServer('<%=txtBanner.ClientID %>','Images');" value="Browse Server" />&nbsp;
                    <asp:Image ID="imgBanner" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblFooter" runat="server" Text="Chân trang:"></asp:Label></th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckFooter" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblPageTitle" runat="server" Text="Title meta:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtPageTitle" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDescription" runat="server" Text="Description meta:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblMetaKeyword" runat="server" Text="Keyword meta:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtMetaKeyword" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblModifiedDate" runat="server" Text="Ngày đăng:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtModifiedDate" runat="server" CssClass="text datetime" />
                    <AjaxControl:MaskedEditExtender ID="meeModifiedDate" runat="server" Mask="99/99/9999 99:99:99" MaskType="DateTime" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtModifiedDate" AcceptAMPM="True" Century="2000" />
                    <AjaxControl:MaskedEditValidator ID="mevModifiedDate" runat="server" ControlExtender="meeModifiedDate" ControlToValidate="txtModifiedDate" Display="Dynamic" EmptyValueBlurredText="Date and time is required" IsValidEmpty="True" InvalidValueBlurredMessage="Date and time is invalid" SetFocusOnError="True" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblIsApply" runat="server" Text="Áp dụng:"></asp:Label></th>
                <td>
                    <asp:CheckBox ID="chkIsApply" runat="server" /></td>
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
