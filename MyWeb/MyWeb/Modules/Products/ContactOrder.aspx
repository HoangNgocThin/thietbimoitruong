<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="ContactOrder.aspx.cs" Inherits="MyWeb.Modules.Products.ContactOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .txt_long {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main-zone-wrapper" runat="server">
    <div class="productList">
        <div class="productList_head">
            <span>Liên hệ đặt hàng</span>
        </div>
        <div class="productlist_main">
            <div id="dv_contact_order">
                <table>
                    <tr>
                        <td class="td_order">Họ tên :</td>
                        <td>
                            <asp:TextBox ID="txthoten" CssClass="txt_short" runat="server"></asp:TextBox>
                        </td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txthoten" ErrorMessage="Họ tên không được trống">(*)</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="td_order">Số điện thoại :</td>
                        <td>
                            <asp:TextBox ID="txtsodienthoai" CssClass="txt_short" runat="server"></asp:TextBox>
                            
                            <AjaxControl:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtsodienthoai" runat="server" FilterType="Numbers">
                            </AjaxControl:FilteredTextBoxExtender>
                        </td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtsodienthoai" ErrorMessage="Điện thoại không được trống">(*)</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="td_order" valign="top">Địa chỉ :</td>
                        <td>
                            <asp:TextBox ID="txtdiachi" CssClass="txt_long" TextMode="MultiLine" runat="server" Height="56px" Width="345px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtdiachi" ErrorMessage="Địa chỉ không được trống">(*)</asp:RequiredFieldValidator></td>
                    </tr>
                    
                 
                    <tr>
                        <td class="td_order">Email :</td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" Width="345px" CssClass="txt_long"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtemail" ErrorMessage="Email không được trống">(*)</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtemail"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ErrorMessage="Email sai định dạng">(*)</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                Font-Size="13px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btndathang" CssClass="cssOrder" runat="server" Text="Đặt hàng"
                                OnClick="btndathang_Click" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
