<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="MyWeb.Modules.Products.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<div class='dv_sp_header'>
<div class="dv_span">
    <span>Giỏ hàng</span>
</div>
<div class='dv_sp'>
    <div class="dv_order">
        <div class="dv_product_order">
            <table cellpadding="0px" cellspacing="0px" class="TableView">
                <tr class="trHeader">
                    <th></th>
                    <th class="tdright">Tên sản phẩm</th>
                    <th class="tdright">Giá</th>
                    <th class="tdright">Số lượng</th>
                    <th class="tdright">Thành tiền</th>
                    <th>Chức năng</th>
                </tr>
                <asp:Repeater ID="rpt" runat="server" onitemcommand="rpt_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblproductid" Visible="false" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label></td>
                            <td class="tdright"><%# Eval("ProductName") %></td>
                            <td class="tdright">
                                <asp:Label ID="lblprice" runat="server" Text='<%# Format_Price(Eval("Price").ToString()) +" VND" %>'></asp:Label></td>
                            <td align="center" class="tdright">
                                <asp:TextBox ID="txtquantity" Width="50px" Text='<%# Eval("Quantity")%>' runat="server"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtquantity" runat="server" FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td class="tdright">
                                <asp:Label ID="lbltotal" runat="server" Text='<%# Format_Price(Eval("Total").ToString()) +" VND" %>'></asp:Label>
                            </td>
                            <td align="center" class="trOdd">
                                <asp:ImageButton ID="imgbtncapnhat" ToolTip="Cập nhật" ImageUrl="~/App_Themes/Admin/images/refresh.png" CommandArgument='<%# Eval("ProductID") %>' CommandName="Update" runat="server" />
                                <asp:ImageButton ID="imgbtnremove" ToolTip="Hủy bỏ" ImageUrl="~/App_Themes/Admin/images/delete.png" CommandArgument='<%# Eval("ProductID") %>' CommandName="Delete" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="dv_tinhtien">
            <asp:Label ID="lbltongtien" runat="server" Text=""></asp:Label></div>
        <div class="dv_control">
            <asp:Button ID="btnmuatiep" runat="server" Text="Mua tiếp" 
                onclick="btnmuatiep_Click" />
            <asp:Button ID="btndathang" runat="server" Text="Đặt hàng" 
                onclick="btndathang_Click" />
            <asp:Button ID="btnthanhtoan" runat="server" Text="Tính tiền" 
                onclick="btnthanhtoan_Click" />
        </div>
    </div>
</div>
</div>
</asp:Content>
