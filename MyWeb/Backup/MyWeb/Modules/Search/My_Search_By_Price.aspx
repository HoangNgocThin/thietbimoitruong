<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="My_Search_By_Price.aspx.cs" Inherits="MyWeb.Modules.Search.My_Search_By_Price" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
<div class='dv_sp_header'>
<div class="dv_span">
    <span>Các sản phẩm tìm thấy</span>
</div>
<div class='dv_sp'>
    <asp:DataList CssClass="dtlspsanpham" ID="dtlsp_search_by_price" runat="server" RepeatColumns="3">
        <ItemTemplate>
            <table>
                <tr>
                    <td align="center" valign="bottom" class="td_img">
                        <div class="dtl_img"><a href='<%# "/Products/"+Eval("Catid")+"/"+Eval("Id")+"/"+Eval("Tag")+".aspx" %>'><asp:Image ID="img_sp" ImageUrl='<%# Eval("Image") %>' runat="server" /></a></div>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="bottom" class="td_text">
                        <asp:HyperLink ID="hplname_sp_thong_dung" Text='<%# Eval("Name") %>' runat="server"></asp:HyperLink>
                        <h5 style="color: Red;">
                        <asp:HyperLink ID="hplprice_sp_thong_dung" Text='<%# Format_Price(Eval("Price").ToString()) +"VND" %>' runat="server"></asp:HyperLink></h5>
                        <a class="a_datmua" href='<%# "/Products/"+Eval("Catid")+"/"+Eval("Id")+"/"+Eval("Tag")+".aspx"  %>'></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <div class="dv_paging">
            <asp:Literal ID="ltrpaging" runat="server"></asp:Literal>
</div>
</div>

</div>
</asp:Content>
