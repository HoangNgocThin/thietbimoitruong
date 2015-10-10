<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_SP_Banchay.ascx.cs" Inherits="MyWeb.Modules.Products.My_U_SP_Banchay" %>
<div class='dv_sp_header'>
<div class="dv_span">
    <span>Sản phẩm bán chạy nhất</span>
</div>
<div class='dv_sp'>
    <asp:DataList CssClass="dtlspsanpham" ID="dtlspbanchay" runat="server" RepeatColumns="3" 
        onitemdatabound="dtlspbanchay_ItemDataBound">
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
                            <asp:HyperLink ID="hplprice_sp" Text='<%# Format_Price(Eval("Price").ToString()) +" VND" %>' runat="server"></asp:HyperLink></h5>
                        <a class="a_datmua" href='<%# "/Products/"+Eval("Catid")+"/"+Eval("Id")+"/"+Eval("Tag")+".aspx"  %>'></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</div>
</div>