<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="MyWeb.Admin.Config"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">Cấu hình hệ thống</div>
<asp:Panel ID="pnView" runat="server">
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdConfig" runat="server" width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="False" onitemdatabound="grdConfig_ItemDataBound" onitemcommand="grdConfig_ItemCommand" onpageindexchanged="grdConfig_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" />
<asp:BoundColumn DataField="Mail_Smtp" HeaderText="" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="Mail_Port" HeaderText="" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="Mail_Info" HeaderText="" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="Mail_Noreply" HeaderText="" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="Mail_Password" HeaderText="" ItemStyle-CssClass="Text" Visible="true" />
<asp:TemplateColumn>
    <HeaderTemplate>
        Location
    </HeaderTemplate>
    <ItemTemplate>
        <%# loadlocation(Eval("Location").ToString()) %>
    </ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /></ItemTemplate> </asp:TemplateColumn>
</Columns></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
    <tr> <th> 
    <asp:Label ID="lblMail_Smtp" runat="server" Text="Máy chủ gửi mail:"></asp:Label></th><td><asp:TextBox ID="txtMail_Smtp" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> 
    <asp:Label ID="lblMail_Port" runat="server" Text="Cổng gửi mail:"></asp:Label></th><td><asp:TextBox ID="txtMail_Port" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> 
    <asp:Label ID="lblMail_Info" runat="server" Text="Mail nhận liên hệ:"></asp:Label></th><td><asp:TextBox ID="txtMail_Info" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> 
    <asp:Label ID="lblMail_Noreply" runat="server" Text="Mail gửi thông tin:"></asp:Label></th><td><asp:TextBox ID="txtMail_Noreply" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> 
    <asp:Label ID="lblMail_Password" runat="server" Text="Mật khẩu mail gửi:"></asp:Label></th><td>
        <asp:TextBox ID="txtMail_Password" runat="server" CssClass="text" 
            TextMode="Password"></asp:TextBox></td></tr>
    <tr>
        <th>
            <asp:Label ID="lblPlaceHead" runat="server" Text="Dán mã phần Head:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtPlaceHead" runat="server" CssClass="text multiline" 
                TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <asp:Label ID="lblGoogleId" runat="server" Text="GoogleAnalytic Id:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtGoogleId" runat="server" CssClass="text"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <asp:Label ID="lblFreeShipping" runat="server" Text="Phí vận chuyển:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtFreeShipping" runat="server" CssClass="CheckBox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            <asp:Label ID="lblPlaceBody" runat="server" Text="Popup trang chủ:"></asp:Label>
        </th>
        <td>
            <FCKeditorV2:FCKeditor ID="fckPlaceBody" runat="server" />
            <%--<asp:TextBox ID="txtPlaceBody" runat="server" CssClass="text multiline" 
                TextMode="MultiLine"></asp:TextBox>--%>
        </td>
    </tr>
    <tr>
        <th>
            <asp:Label ID="Label1" runat="server" Text="Hướng dẫn kích cỡ:"></asp:Label>
        </th>
        <td>
            <FCKeditorV2:FCKeditor ID="fckhelp_size" runat="server"/>
           </td>
    </tr>
    <tr> <th> 
    <asp:Label ID="lblContact" runat="server" Text="Thông tin cơ quan:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckContact" runat="server"/></td></tr><tr> <th> 
    <asp:Label ID="lblDeliveryTerms" runat="server" Text="Điều khoản giao hàng:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckDeliveryTerms" runat="server"/></td></tr><tr> <th> 
    <asp:Label ID="lblPaymentTerms" runat="server" Text="Điều khoản thanh toán:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckPaymentTerms" runat="server"/></td></tr><tr> <th> 
    <asp:Label ID="lblCopyright" runat="server" Text="Thông tin copyright:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckCopyright" runat="server"/></td></tr><tr> <th> 
    <asp:Label ID="lblTitle" runat="server" Text="Title meta:"></asp:Label></th><td><asp:TextBox ID="txtTitle" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> 
    <asp:Label ID="lblDescription" runat="server" Text="Description meta:"></asp:Label></th><td><asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> 
    <asp:Label ID="lblKeyword" runat="server" Text="Keyword meta:"></asp:Label></th><td><asp:TextBox ID="txtKeyword" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr>
    <tr>
        <th> 
            <asp:Label ID="lblLocation" runat="server" Text="Khu vực :"></asp:Label></th>
        <td> 
            <asp:DropDownList ID="DDLLocation" runat="server" Height="22px" Width="137px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
</asp:Content>
