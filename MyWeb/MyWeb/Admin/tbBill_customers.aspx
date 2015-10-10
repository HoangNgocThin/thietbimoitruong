<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="tbBill_customers.aspx.cs" Inherits="MyWeb.Admin.tbBill_customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main-zone-wrapper" runat="server">
    <div class="PageName">Đơn đặt hàng</div>
    <asp:Panel ID="pnView" runat="server">
        <div class="Control">
            <ul>
                <asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li>
            </ul>
        </div>
        <asp:DataGrid ID="grdtbBill_customers" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdtbBill_customers_ItemDataBound" OnItemCommand="grdtbBill_customers_ItemCommand" OnPageIndexChanged="grdtbBill_customers_PageIndexChanged">
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
                <asp:BoundColumn DataField="billid" HeaderText="billid" Visible="False" />
                <asp:TemplateColumn ItemStyle-CssClass="text">
                    <HeaderTemplate>Khách hàng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerName").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="totalmoney" HeaderText="Tổng tiền" ItemStyle-CssClass="Text" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="DateTime">
                    <HeaderTemplate>Ngày đặt hàng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDateTime(DataBinder.Eval(Container.DataItem, "idate").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="active">
                    <HeaderTemplate>Tình trạng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal runat="server" Text='  <%# ConvertState(DataBinder.Eval(Container.DataItem, "state").ToString()) %>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>Chức năng</HeaderTemplate>
                    <ItemTemplate>
                       <asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "state").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "state").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "state").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"billid")%>' />&nbsp;&nbsp;
                        <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Xem đơn hàng" CommandName="View" CssClass="Edit" ToolTip="Xem đơn hàng" ImageUrl="/App_Themes/Admin/images/view3.jpg" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"billid")%>' />&nbsp;&nbsp;
                        <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa đơn hàng" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"billid")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>
        <div class="Control">
            <ul>

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
                <td class="Control">
                    <ul>
                       
                        <li>
                            <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" OnClick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lblCustomerName" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lblBirthDate" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lblMobile" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lblAddress" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lblEmail" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblTotalAmount" Font-Bold="True" ForeColor="Red" /></td>
                            <td style="padding-left: 10px">
                                <asp:Button ID="btn" runat="server"  Text="Đã giao hàng" OnClick="btn_Click" /></td>
                        </tr>
                    </table>
                    <asp:DataGrid ID="grdDetail" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" >
                        <HeaderStyle CssClass="trHeader"></HeaderStyle>
                        <ItemStyle CssClass="trOdd"></ItemStyle>
                        <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
                        <Columns>
                            <asp:TemplateColumn ItemStyle-CssClass="Image">
                                <HeaderTemplate>Hình ảnh</HeaderTemplate>
                                <ItemTemplate>
                                    <script type="text/javascript"> playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="ProductName" HeaderText="Tên sản phẩm" ItemStyle-CssClass="Text" Visible="true" />
                            <asp:BoundColumn DataField="Quantity" HeaderText="Số lượng" ItemStyle-CssClass="number" Visible="true" />
                            <asp:TemplateColumn HeaderText="Giá" ItemStyle-CssClass="MoneyVND" Visible="true" >
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Format_Price(DataBinder.Eval(Container.DataItem, "bilprice").ToString())+ " VND" %>' />
                                    
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn  HeaderText="Thành tiền" ItemStyle-CssClass="MoneyVND" Visible="true">
                                 <ItemTemplate>
                                     <asp:Label  runat="server" Text='<%# Format_Price(DataBinder.Eval(Container.DataItem, "bilprice").ToString()) + " VND" %>' />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                       
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td class="Control">
                    <ul>
                       
                        <li>
                            <asp:LinkButton CssClass="uback" ID="LinkButton2" runat="server" OnClick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
        </table>

    </asp:Panel>
</asp:Content>
