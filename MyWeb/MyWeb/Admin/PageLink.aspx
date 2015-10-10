<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PageLink.aspx.cs" Inherits="MyWeb.Admin.PageLink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main-zone-wrapper" runat="server" > 
    <div class="PageName">Quản lý danh mục trang</div>
<asp:Panel ID="pnView" runat="server">
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdPage" runat="server" width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="False" onitemdatabound="grdPage_ItemDataBound" onitemcommand="grdPage_ItemCommand" onpageindexchanged="grdPage_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" /><asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
<asp:TemplateColumn ItemStyle-CssClass="Text"> <HeaderTemplate>Tên trang</HeaderTemplate> <ItemTemplate> <asp:label ID="Label1" runat="server" Text='<%# MyWeb.Common.StringClass.ShowNameLevel(DataBinder.Eval(Container.DataItem, "Name").ToString(), DataBinder.Eval(Container.DataItem, "Level").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TextShort"> <HeaderTemplate>Kiểu trang</HeaderTemplate> <ItemTemplate> <asp:label ID="Label2" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowPageType(DataBinder.Eval(Container.DataItem, "Type").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:BoundColumn DataField="Link" HeaderText="Liên kết" ItemStyle-CssClass="Text" Visible="true" />
<asp:BoundColumn DataField="Target" HeaderText="Kiểu liên kết" ItemStyle-CssClass="TextShort" Visible="true" />
<asp:BoundColumn DataField="Ord" HeaderText="Thứ tự" ItemStyle-CssClass="Number" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="TextShort"> <HeaderTemplate>Trạng thái</HeaderTemplate> <ItemTemplate> <asp:label id="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdAddSub" runat="server" AlternateText="Thêm cấp con" CommandName="AddSub" CssClass="Add" ToolTip="Thêm cấp con" ImageUrl="/App_Themes/Admin/images/add.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Level")%>'/><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate> </asp:TemplateColumn>
</Columns></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
    <asp:Panel ID="pnUpdate" runat="server" Visible="False">
        <table border="1" class="TableUpdate">
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton ID="lbtUpdateT" runat="server" CssClass="uupdate" 
                                onclick="Update_Click">Ghi lại</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lbtBackT" runat="server" CausesValidation="False" 
                                CssClass="uback" onclick="Back_Click">Trở về</asp:LinkButton>
                        </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblName" runat="server" Text="Tên trang:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                        ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="txtId" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblType" runat="server" Text="Kiểu trang:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr ID="Link">
                <th>
                    <asp:Label ID="lblLink" runat="server" Text="Liên kết:"></asp:Label>
                </th>
                <td>
                    <table border="0" width="100%">
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlLinkType" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr ID="LinkInput">
                            <td>
                                <asp:TextBox ID="txtLink" runat="server" CssClass="text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr ID="LinkModule" style="display:none">
                            <td>
                                <asp:DropDownList ID="ddlLink" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblTarget" runat="server" Text="Kiểu hiển thị:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlTarget" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblContent" runat="server" Text="Mô tả:"></asp:Label>
                </th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckContent" runat="server" />
                </td>
            </tr>
            <tr id="Content">
                <th>
                    <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label>
                </th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckDetail" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblTitle" runat="server" Text="Title meta:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDescription" runat="server" Text="Description meta:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblKeyword" runat="server" Text="Keyword meta:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="text multiline" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblPosition" runat="server" Text="Vị trí hiển thị:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlPosition" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblOrd" runat="server" Text="Thứ tự:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtOrd" runat="server" CssClass="text number" />
                    <asp:RequiredFieldValidator ID="rfvOrd" runat="server" 
                        ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblIndex" runat="server" Text="Trang chủ:"></asp:Label>
                </th>
                <td>
                    <asp:CheckBox ID="chkIndex" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label>
                </th>
                <td>
                    <asp:CheckBox ID="chkActive" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton ID="lbtUpdateB" runat="server" CssClass="uupdate" 
                                onclick="Update_Click">Ghi lại</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lbtBackB" runat="server" CausesValidation="False" 
                                CssClass="uback" onclick="Back_Click">Trở về</asp:LinkButton>
                        </li>
                    </ul>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        $(document).ready(function () {
            ChangeType($("#<%= ddlType.ClientID %>").val());
            ChangeLinkType($("#<%= ddlLinkType.ClientID %>").val());
            $("#<%= ddlType.ClientID %>").change(function () {
                ChangeType(this.value);
            });
            $("#<%= ddlLinkType.ClientID %>").change(function () {
                ChangeLinkType(this.value);
                ChangeLink("/");
            });
            $("#<%= ddlLink.ClientID %>").change(function () {
                ChangeLink(this.value);
            });
            function ChangeType(value) {
                $("#Content, #Content td, #Content iframe").css("height", "320px");
                if (value == 1) {
                    $("#Link").css("display", "");
                    $("#Content").css("display", "none");
                }
                else {
                    $("#Link").css("display", "none");
                    $("#Content").css("display", "");
                }
            }

            function ChangeLinkType(value) {
                if (value == 1) {
                    $("#LinkInput").css("display", "");
                    $("#LinkModule").css("display", "none");
                    $("#<%= txtLink.ClientID %>").focus();
                } else {
                    $("#LinkInput").css("display", "none");
                    $("#LinkModule").css("display", "");
                }
            }
            function ChangeLink(value) {
                $("#<%= txtLink.ClientID %>").val(value);
            }
        });
    </script>
</asp:Content>
