<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Promotion.aspx.cs" Inherits="MyWeb.Modules.Products.Promotion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
    <div class='dv_sp_header'>
<div class="dv_span">
    <span>Sản phẩm khuyến mãi</span>
</div>
<div class='dv_sp'>
    <asp:DataList CssClass="dtlspsanpham" ID="dtlspkhuyenmai" runat="server" RepeatColumns="3" >
        <ItemTemplate>
            <table>
                <tr>
                    <td align="center" valign="bottom" class="td_img">
                        <div class="dtl_img"><a href='<%# "/Products/"+Eval("Catid")+"/"+Eval("Id")+"/"+Eval("Tag")+".aspx" %>'><asp:Image ID="img_sp" ImageUrl='<%# Eval("Image") %>' runat="server" /></a></div>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="bottom" class="td_text">
                        <asp:HyperLink ID="hplname_sp" Text='<%# Eval("Name") %>' runat="server"></asp:HyperLink>
                        <h5 style="color: Red;">
                            <asp:HyperLink ID="hplprice_sp" Text='<%# "Giá mới :"+ Format_Price(Eval("Price").ToString()) +" VND" %>' runat="server"></asp:HyperLink>
                        </h5>
                        <h5 style="color: Red;" class="h_priceold">
                           <a class="a_priceold"><%# "Giá cũ :"+ Format_Price(Eval("PiceOld").ToString()) +" VND" %></a>
                        </h5>
                        <a class="a_datmua" href='<%# "/Products/"+Eval("Catid")+"/"+Eval("Id")+"/"+Eval("Tag")+".aspx"  %>'></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</div>
<div class="dv_paging">
            <asp:Literal ID="ltrpaging" runat="server"></asp:Literal>
</div>
</div>
</asp:Content>
