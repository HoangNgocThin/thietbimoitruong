<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="MyWeb.Modules.Products.ProductDetail" %>
<%@ Register src="My_U_References.ascx" tagname="My_U_References" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<div class='dv_sp_header'>
<div class="dv_span">
    <span>
        <asp:Label ID="lblheader" runat="server" Text=""></asp:Label>
    </span>
</div>
<div class='dv_sp'>
    <table class="tbl_product_detail" cellpadding="0" cellspacing="0" style="width: 548px;">
        <tr>
            <td colspan="2" class="td_lblname">
                <span id="sp_name"><asp:Label ID="lblname" runat="server" Text=""></asp:Label></span></td>
        </tr>
        <tr>
            <td class="td_ltrimg" style="width: 304px;" align="left">
                <asp:Literal ID="ltrimg" runat="server"></asp:Literal>
            </td>
            <td valign="top" style="padding-top: 10px;" align="left" class="td_info">
                <div>
                    <span style="font-weight: bold; color:Black;">Mã sản phẩm :</span>
                    <span style="font-weight:normal; color: black;"><asp:Label ID="lblmasanpham" runat="server" Text=""></asp:Label></span>
                </div>
                <div>
                    <span style="font-weight: bold; color:Black;">Trọng lượng :</span>
                    <span style="font-weight:normal; color: black;"><asp:Label ID="lbltrongluong" runat="server" Text=""></asp:Label></span>
                </div>
                <div>
                    <span style="font-weight: bold; color:Black;">Giá thị trường :</span>
                    <span style="font-weight:normal; color: black;"><asp:Label ID="lblgiathitruong" runat="server" Text=""></asp:Label></span>
                </div>
                <div>
                    <span style="font-weight: bold; color:Black;">Giá bán :</span>
                    <span style="font-weight:normal; color: black;"><asp:Label ID="lblgialienhe" runat="server" Text="liên hệ"></asp:Label></span>
                </div>
                <div>
                    <span style="font-weight: bold; color:Black;">Đặt hàng :</span>
                    <span style="font-weight:normal; color: black;"><asp:TextBox ID="txtsoluong" runat="server" Height="20px" Width="57px"></asp:TextBox><asp:FilteredTextBoxExtender
                            ID="FilteredTextBoxExtender1" FilterType="Numbers" TargetControlID="txtsoluong" runat="server">
                        </asp:FilteredTextBoxExtender>
                    </span>
                </div>
                <div>
                    <asp:ImageButton ID="imgbtndatmua" runat="server" Height="19px" 
                        ImageUrl="~/App_Themes/Default/img/btn_datmua.png" Width="71px" 
                        onclick="imgbtndatmua_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td_ltrdetail">
                <asp:Literal ID="ltrdetail" runat="server"></asp:Literal></td>
        </tr>
    </table>
</div>
</div>
    <uc1:My_U_References ID="My_U_References1" runat="server" />
    <br />
</asp:Content>
