<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="MyWeb.Modules.Products.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main-zone-wrapper" runat="server">
    <div style="padding: 20px 0px 10px 10px"><asp:Literal runat="server" ID="ltrNavigate" /></div>
    <div class="clear"></div>
    <table style="margin:0px 0px 0px 20px;">
        <tr>
            <td>
                <asp:Literal ID="ltrLike" runat="server"></asp:Literal>  
            </td>
            <td style="padding-left: 5px;">
                <asp:Literal ID="ltrShare" runat="server"></asp:Literal></td>
            <td  style="padding-left: 5px;">
                <asp:Literal ID="ltrGoogle" runat="server"></asp:Literal></td>

        </tr>
    </table>
    <div class="productDetail">
        <div class="productDetail_img">
            <asp:Literal ID="ltrimg" runat="server"></asp:Literal>
        </div>
        <div class="productDetail_Detail">
            <p>
                <asp:Label ID="lblTitle" runat="server" Font-Size="18px" Font-Bold="true" Text=""></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblProductcode" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblCreatedDate" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblUnit" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblUnitPrice" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblSalePrice" runat="server" Text=""></asp:Label>
            </p>
            <table style="margin-top: 5px;">
                <tr>
                    <td>Số lượng: </td>
                    <td style="padding-left: 5px;">
                        <asp:TextBox ID="txtquantity" Width="60px" Height="26px" Text="1" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnOrder" CssClass="lnkorder" runat="server" Text="Đặt mua" OnClick="btnOrder_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear"></div>
        <div class="productDetail_Detail_content">
            <asp:Literal ID="ltrDetail" runat="server"></asp:Literal>
        </div>
        <div class="comment">
            <asp:Literal runat="server" ID="ltrComment" />
        </div>
      
    </div>
    <div style="margin-top: 10px;"></div>
      <div class="productList">
            <div class="productList_head">
                <span>Các sản phẩm liên quan</span>
            </div>
            <div class="productlist_main">
                <asp:Literal ID="ltrProduct" runat="server"></asp:Literal>
            </div>
        </div>
</asp:Content>
