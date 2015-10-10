<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="MyWeb.Modules.Products.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main-zone-wrapper" runat="server">
    <div class="productList">
        <div class="productList_head">
            <span>Giỏ hàng</span>
        </div>
        <div class="productlist_main">
            <table class="TableOrder">
                <tr class="trHeader">
                    <th></th>
                    <th class="tdright">Hình ảnh</th>
                    <th class="tdright">Tên sản phẩm</th>
                    <th class="tdright">Giá</th>
                    <th class="tdright">Số lượng</th>
                    <th class="tdright">Thành tiền</th>
                    <th class="tdfuction">Chức năng</th>
                </tr>
                <asp:Repeater ID="rpt" runat="server" OnItemCommand="rpt_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblproductid" Visible="false" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label></td>
                            <td class="tdright" style="width: 130px; padding: 5px 0px 5px 0px;">
                                <img width="120px" src='<%# DataBinder.Eval(Container.DataItem, "Image").ToString() %>' /></td>
                            <td class="tdright" style="width: 210px"><%#DataBinder.Eval(Container.DataItem, "ProductName").ToString() %></td>
                            <td class="tdright" style="width: 120px">
                                <asp:Label ID="lblprice" runat="server" Text='<%# Format_Price(Eval("Price").ToString()) +" VND" %>'></asp:Label></td>
                            <td class="tdright" style="width: 80px">
                                <asp:TextBox ID="txtquantity" Width="50px" Text='<%# Eval("Quantity")%>' runat="server"></asp:TextBox>
                                <AjaxControl:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtquantity" runat="server" FilterType="Numbers">
                                </AjaxControl:FilteredTextBoxExtender>
                            </td>
                            <td class="tdright" style="width: 130px">
                                <asp:Label ID="lbltotal" runat="server" Text='<%# Format_Price(Eval("Total").ToString()) +" VND" %>'></asp:Label></td>
                            <td class="tdfuction" style="width: 100px">

                                <asp:ImageButton ID="imgbtncapnhat" ToolTip="Cập nhật" ImageUrl="~/App_Themes/Admin/images/refresh.png" CommandArgument='<%# Eval("ProductID") %>' CommandName="Update" runat="server" />
                                <asp:ImageButton ID="imgbtnremove" ToolTip="Hủy bỏ" ImageUrl="~/App_Themes/Admin/images/delete.png" CommandArgument='<%# Eval("ProductID") %>' CommandName="Delete" runat="server" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <table style="margin-top: 20px;">
            <tr>
                <td colspan="3" style="padding-bottom: 20px;">
                    <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnContinue" CssClass="cssOrder" runat="server" Text="Mua tiếp" OnClick="btnContinue_Click" /></td>
                <td>
                    <asp:Button ID="btncapnhat" CssClass="cssOrder" runat="server" Text="Cập nhật" OnClick="btncapnhat_Click" /></td>
                <td>
                    <asp:Button ID="btnUpdate" CssClass="cssOrder" runat="server" Text="Đặt hàng" OnClick="btnUpdate_Click" /></td>
                
            </tr>
        </table>
    </div>
</asp:Content>
