<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Advertise.aspx.cs" Inherits="MyWeb.Admin.Advertise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" > 
<div class="PageName">Quản lý quảng cáo</div>
<asp:Panel ID="pnView" runat="server">
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdAdvertise" runat="server" width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="30" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" onitemdatabound="grdAdvertise_ItemDataBound" onitemcommand="grdAdvertise_ItemCommand" onpageindexchanged="grdAdvertise_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" /><asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
<asp:BoundColumn DataField="Name" HeaderText="Tên quảng cáo" ItemStyle-CssClass="Text" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="Image"> <HeaderTemplate>Hình ảnh</HeaderTemplate> <ItemTemplate> <script type="text/javascript"> playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script> </ItemTemplate> </asp:TemplateColumn>
<asp:BoundColumn DataField="Width" HeaderText="Độ rộng" ItemStyle-CssClass="Number" Visible="true" />
<asp:BoundColumn DataField="Height" HeaderText="Chiều cao" ItemStyle-CssClass="Number" Visible="true" />
<asp:BoundColumn DataField="Link" HeaderText="Liên kết" ItemStyle-CssClass="Text" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="CheckBox"> <HeaderTemplate>Vị trí</HeaderTemplate> <ItemTemplate> <asp:label id="lblPosition" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowAdvertisePosition(DataBinder.Eval(Container.DataItem, "Position").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:BoundColumn DataField="Ord" HeaderText="Thứ tự" ItemStyle-CssClass="Number" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="CheckBox"> <HeaderTemplate>Kích hoạt</HeaderTemplate> <ItemTemplate> <asp:label id="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate> </asp:TemplateColumn>
</Columns><PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
<tr style="display:none"> <th> <asp:Label ID="lblPageId" runat="server" Text="Trang quảng cáo:"></asp:Label></th><td><asp:DropDownList ID="ddlPage" runat="server"></asp:DropDownList> <%--<asp:RequiredFieldValidator ID="rfvPage" runat="server" ControlToValidate="ddlPage" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"/>--%></td></tr><tr> <th> <asp:Label ID="lblName" runat="server" Text="Tên quảng cáo:"></asp:Label></th><td><asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr>
    <tr>
        <th>
            <asp:Label ID="lblType" runat="server" Text="Kiểu quảng cáo:"></asp:Label>
        </th>
        <td>
            <asp:DropDownList ID="ddlType" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr id="Link"> <th> <asp:Label ID="lblImage" runat="server" Text="Hình ảnh:"></asp:Label></th><td><asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input ID="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>','Advertise');" value="Browse Server" />&nbsp; <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" /></td></tr><tr id="Link1"> <th> <asp:Label ID="lblWidth" runat="server" Text="Độ rộng:"></asp:Label></th><td><asp:TextBox ID="txtWidth" runat="server" CssClass="text number"></asp:TextBox></td></tr><tr id="Link2"> <th> <asp:Label ID="lblHeight" runat="server" Text="Chiều cao:"></asp:Label></th><td><asp:TextBox ID="txtHeight" runat="server" CssClass="text number"></asp:TextBox></td></tr><tr id="Link3"> <th> <asp:Label ID="lblLink" runat="server" Text="Liên kết:"></asp:Label></th><td><asp:TextBox ID="txtLink" runat="server" CssClass="text"></asp:TextBox></td></tr><tr id="Link4"> <th> <asp:Label ID="lblTarget" runat="server" Text="Kiểu liên kết:"></asp:Label></th><td>
    <asp:DropDownList ID="ddlTarget" runat="server">
    </asp:DropDownList>
    </td></tr><tr id="Content"> <th> <asp:Label ID="lblContent" runat="server" Text="Nội dung:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckContent" runat="server"/></td></tr><tr> <th> <asp:Label ID="lblPosition" runat="server" Text="Vị trí:"></asp:Label></th><td>
    <asp:DropDownList ID="ddlPosition" runat="server">
    </asp:DropDownList>
    </td></tr><tr> <th> <asp:Label ID="lblClick" runat="server" Text="Lượt click:"></asp:Label></th><td><asp:TextBox ID="txtClick" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblOrd" runat="server" Text="Thứ tự:"></asp:Label></th><td><asp:TextBox ID="txtOrd" runat="server" CssClass="text number"/><asp:RequiredFieldValidator ID="rfvOrd" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr><tr> <th> <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label></th><td><asp:CheckBox ID="chkActive" runat="server" /></td></tr><tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
<script type="text/javascript">
    $(document).ready(function () {
        ChangeType($("#<%= ddlType.ClientID %>").val());
        $("#<%= ddlType.ClientID %>").change(function () {
            ChangeType(this.value);
        });
        function ChangeType(value) {
            $("#Content, #Content td, #Content iframe").css("height", "320px");
            if (value == 1) {
                $("#Link").css("display", "");
                $("#Link1").css("display", "");
                $("#Link2").css("display", "");
                $("#Link3").css("display", "");
                $("#Link4").css("display", "");
                $("#Content").css("display", "none");
            }
            else {
                $("#Link").css("display", "none");
                $("#Link1").css("display", "none");
                $("#Link2").css("display", "none");
                $("#Link3").css("display", "none");
                $("#Link4").css("display", "none");
                $("#Content").css("display", "");
            }
        }
    });
    </script>
</asp:Content>
