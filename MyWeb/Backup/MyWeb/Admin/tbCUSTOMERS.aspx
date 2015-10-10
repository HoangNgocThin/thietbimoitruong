<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="True" CodeBehind="tbCUSTOMERS.aspx.cs" Inherits="MyWeb.Admin.tbCUSTOMERS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" > 
<div class="PageName">Quản lý đơn Hàng</div>
<asp:Panel ID="pnView" runat="server">
<div class="Control"><ul> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdtbCUSTOMERS" runat="server" width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="25" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" onitemdatabound="grdtbCUSTOMERS_ItemDataBound" onitemcommand="grdtbCUSTOMERS_ItemCommand" onpageindexchanged="grdtbCUSTOMERS_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter">
 <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> 
 <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> 
 <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
 <asp:TemplateColumn ItemStyle-CssClass="Text">
    <HeaderTemplate>Họ tên khách hàng</HeaderTemplate>
    <ItemTemplate><%# Format_show(Eval("show").ToString(), Eval("vcusname").ToString())%></ItemTemplate>
</asp:TemplateColumn>
 <asp:TemplateColumn ItemStyle-CssClass="Text">
    <HeaderTemplate>Ngày sinh</HeaderTemplate>
    <ItemTemplate><%# Format_show(Eval("show").ToString(), Eval("dbirthday").ToString())%></ItemTemplate>
</asp:TemplateColumn>
 <asp:TemplateColumn ItemStyle-CssClass="Text">
    <HeaderTemplate>Địa chỉ</HeaderTemplate>
    <ItemTemplate><%# Format_show(Eval("show").ToString(), Eval("vaddress").ToString())%></ItemTemplate>
</asp:TemplateColumn>
 <asp:TemplateColumn ItemStyle-CssClass="Text">
    <HeaderTemplate>Ngày đặt hàng</HeaderTemplate>
    <ItemTemplate><%# Eval("idate") %></ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Text">
    <HeaderTemplate>Tình trạng</HeaderTemplate>
    <ItemTemplate><%# Format_show(Eval("show").ToString(), Trangthai(Eval("state").ToString()))%></ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> 
<ItemTemplate>
<asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Xem đơn hàng" CommandName="Edit" CssClass="Edit" ToolTip="Xem đơn hàng" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"billid")%>' />
<asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"billid")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
</ItemTemplate> 
</asp:TemplateColumn>
</Columns><PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle>
</asp:Datagrid>
<div class="Control"><ul> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control"><ul><li>
    <asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Đã giao hàng</asp:LinkButton></li> 
    <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
    <tr> 
   <td><div class="PageName">Thông tin khách hàng<asp:TextBox ID="txtIdbill" 
           runat="server" Visible="False"></asp:TextBox>
       </div></td>
   </tr>
   <tr><td>
    <asp:Datagrid ID="grdtbCUSTOMERSinfo" runat="server" width="100%" 
        AutoGenerateColumns="False" ShowHeader="False" CssClass="TableView">
    <Columns>
    <asp:TemplateColumn>
        <ItemTemplate>
        <table border="0">
            <tr> <th> Họ tên:</th><td><%# Eval("vcusname").ToString()%></td></tr>
            <tr> <th> Ngày sinh</th><td><%# Eval("dbirthday").ToString()%></td></tr>
            <tr> <th> Địa chỉ:</th><td><%# Eval("vaddress").ToString()%></td></tr>
            <tr> <th> Điện thoại:</th><td><%# Eval("vmobile").ToString()%></td></tr>
            <tr> <th> Email:</th><td><%# Eval("vemail").ToString()%></td></tr>
            <tr> <th> Tỉnh/Thành phố:</th><td><%# Eval("vprovince").ToString()%></td></tr>
        </table>
            </ItemTemplate>
    </asp:TemplateColumn>
    </Columns>
    </asp:Datagrid>
    </td></tr>
     <tr> 
        <td><div class="PageName">Thông tin người nhận hàng</div></td>
   </tr>
   <tr><td>
    <asp:Datagrid ID="grdRecipient" runat="server" width="100%" 
        AutoGenerateColumns="False" ShowHeader="False" CssClass="TableView">
    <Columns>
    <asp:TemplateColumn>
        <ItemTemplate>
        <table border="0">
        <tr> <th> Họ tên:</th><td><%# Eval("vcusname").ToString()%></td></tr>
        <tr> <th> Ngày sinh</th><td><%# Eval("dbirthday").ToString()%></td></tr>
        <tr> <th> Địa chỉ:</th><td><%# Eval("vaddress").ToString()%></td></tr>
        <tr> <th> Điện thoại:</th><td><%# Eval("vmobile").ToString()%></td></tr>
        <tr> <th> Email:</th><td><%# Eval("vemail").ToString()%></td></tr>
        <tr> <th> Tỉnh/Thành phố:</th><td><%# Eval("vprovince").ToString()%></td></tr>
        </table>
            </ItemTemplate>
    </asp:TemplateColumn>
    </Columns>
    </asp:Datagrid>
    </td></tr>
    <tr> 
   <td><div class="PageName">Thông tin đơn hàng</div></td>
   </tr>
   <tr>
       <td>
        <asp:DataGrid ID="grdshopcard" runat="server" AutoGenerateColumns="False" 
            CellPadding="10" Width="100%">
            <Columns>
                <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Sản phẩm</HeaderTemplate>
                    <ItemTemplate><asp:TextBox ID="txtproid" runat="server" Visible="false" Text='<%# Eval("proid").ToString() %>'></asp:TextBox>
                        <%#Tensanpham( Eval("proid").ToString())%><br />
                    </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateColumn>
                 <asp:TemplateColumn ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Số lượng</HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("quantity").ToString()%>
                    </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                </asp:TemplateColumn>
                 <asp:TemplateColumn ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Giá bán</HeaderTemplate>
                    <ItemTemplate>
                        <%# Format_Price(Eval("bilprice").ToString())%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                </asp:TemplateColumn>
                 <asp:TemplateColumn ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Thành tiền(VNĐ)</HeaderTemplate>
                    <ItemTemplate>
                        <%#Format_Price(Eval("bilmoney").ToString())%>
                    </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Right" Width="150px"></ItemStyle>
                </asp:TemplateColumn>
            </Columns>
            <HeaderStyle BackColor="#E8E8E8" BorderColor="#B3B3B3" BorderStyle="Solid" 
                BorderWidth="1px" Font-Bold="True" Height="30px" />
            <ItemStyle BorderColor="#B3B3B3" BorderStyle="Solid" BorderWidth="1px" />
        </asp:DataGrid>
        <table width="100%"  border="0" cellspacing="0" cellpadding="3" style="background:#E8E8E8;border-collapse:collapse">
          <tr style="border:1px solid #FFF;height:30px">
            <td align="right" style="border-left:1px solid #B3B3B3; font-weight:bold">
                &nbsp;</td>
            <td style="text-align:right">&nbsp;</td>
            <td style="border-right:1px solid #B3B3B3; text-align:right; padding-right:20px">&nbsp;</td>
          </tr>
          <tr style="border:1px solid #FFF;height:30px">
            <td width="57%" align="right" style="border-left:1px solid #B3B3B3;border-bottom:1px solid #B3B3B3">
                <asp:Label ID="lblsum" runat="server" Text="Tổng số tiền" Font-Bold="True"></asp:Label>
              </td>
            <td width="3%" style="border-bottom:1px solid #B3B3B3">&nbsp;</td>
            <td width="20%" 
                  style="border-right:1px solid #B3B3B3;border-bottom:1px solid #B3B3B3;padding-right:20px" 
                  align="right">
                <asp:Label ID="lblsumpay" runat="server"></asp:Label>
              </td>
          </tr>
         </table>
    </td>
    </tr>
    <tr> 
   <td class="Control">
    <ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Đã giao hàng</asp:LinkButton></li>
     <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
    </table>
</asp:Panel>
</asp:Content>
