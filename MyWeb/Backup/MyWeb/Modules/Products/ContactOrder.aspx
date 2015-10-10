<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="ContactOrder.aspx.cs" Inherits="MyWeb.Modules.Products.ContactOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class='dv_sp_header'>
<div class="dv_span">
    <span>Đặt hàng</span>
</div>
<div class='dv_sp'>
    <div id="dv_contact_order">
        <table>
            <tr>
                <td class="td_order">Họ tên :</td>
                <td>
                    <asp:TextBox ID="txthoten" CssClass="txt_short" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td class="td_order">Ngày sinh :</td>
                <td>
                    <asp:TextBox ID="txtngaysinh" CssClass="txt_short" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtngaysinh" 
                        runat="server" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                    <asp:MaskedEditExtender ID="meeNGAY_KHAI_GIANG" runat="server" Mask="99/99/9999" MaskType="Date"
                     UserDateFormat="DayMonthYear"  OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtngaysinh" />
                    </td>
                <td></td>
            </tr>
            <tr>
                <td class="td_order">Tỉnh :</td>
                <td>
                    <asp:TextBox ID="txttinh" CssClass="txt_short" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td class="td_order" valign="top">Địa chỉ :</td>
                <td>
                    <asp:TextBox ID="txtdiachi" CssClass="txt_long" TextMode="MultiLine" runat="server" Height="56px"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtdiachi" ErrorMessage="Địa chỉ không được trống">(*)</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="td_order">Số điện thoại :</td>
                <td>
                    <asp:TextBox ID="txtsodienthoai" CssClass="txt_short" runat="server"></asp:TextBox>
                  <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtsodienthoai" runat="server" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td class="td_order">Di động :</td>
                <td>
                    <asp:TextBox ID="txtdidong" CssClass="txt_short" runat="server"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtdidong" runat="server" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td class="td_order">Email :</td>
                <td>
                    <asp:TextBox ID="txtemail" runat="server" Width="180px" CssClass="txt_long"></asp:TextBox></td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtemail" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ErrorMessage="Email sai định dạng">(*)</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="td_order">Khu vực đặt hàng :</td>
                <td> 
                    <asp:DropDownList ID="ddlkhuvuc" CssClass="txt_long" runat="server" 
                        Height="27px" Width="140px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="ddlkhuvuc" 
                        ErrorMessage="Khu vực đặt hàng không được trống">(*)</asp:RequiredFieldValidator>
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
                    <asp:Button ID="btndathang" CssClass="css_btnsearchprice" runat="server" Text="Đặt hàng" 
                        onclick="btndathang_Click" /></td>
            </tr>
        </table>
    </div>
</div>
</div>
</asp:Content>
