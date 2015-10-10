<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="True" CodeBehind="Document.aspx.cs" Inherits="MyWeb.Admin.Document" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" > 
<div class="PageName">Quản lý văn bản</div>
<asp:Panel ID="pnView" runat="server">
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdDocument" runat="server" width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="50" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" onitemdatabound="grdDocument_ItemDataBound" onitemcommand="grdDocument_ItemCommand" onpageindexchanged="grdDocument_PageIndexChanged"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" /><asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
<asp:BoundColumn DataField="Code" HeaderText="Mã văn bản" ItemStyle-CssClass="Date" Visible="true" />
<asp:BoundColumn DataField="Name" HeaderText="Tên văn bản" ItemStyle-CssClass="Text" Visible="true" />
<asp:TemplateColumn ItemStyle-CssClass="Date"> <HeaderTemplate>Ngày ban hành</HeaderTemplate> <ItemTemplate> <asp:label runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDate(DataBinder.Eval(Container.DataItem, "CreateDate").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Date"> <HeaderTemplate>Ngày hiệu lực</HeaderTemplate> <ItemTemplate> <asp:label runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDate(DataBinder.Eval(Container.DataItem, "EffectiveDate").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="CheckBox"> <HeaderTemplate>Kích hoạt</HeaderTemplate> <ItemTemplate> <asp:label id="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:label> </ItemTemplate> </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate> </asp:TemplateColumn>
</Columns><PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
<tr> <th> <asp:Label ID="lblTypeId" runat="server" Text="Loại văn bản:"></asp:Label></th><td><asp:DropDownList ID="ddlDocumentType" runat="server"></asp:DropDownList> <asp:RequiredFieldValidator ID="rfvDocumentType" runat="server" ControlToValidate="ddlDocumentType" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"/></td></tr><tr> <th> <asp:Label ID="lblCode" runat="server" Text="Mã văn bản:"></asp:Label></th><td><asp:TextBox ID="txtCode" runat="server" CssClass="text"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCode" runat="server" 
        ControlToValidate="txtCode" Display="Dynamic" ErrorMessage="*" 
        SetFocusOnError="True" />
    </td></tr><tr> <th> <asp:Label ID="lblName" runat="server" Text="Tên văn bản:"></asp:Label></th><td><asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr><tr> <th> <asp:Label ID="lblCreateDate" runat="server" Text="Ngày ban hành:"></asp:Label></th><td><asp:TextBox ID="txtCreateDate" runat="server" CssClass="text date"/><asp:MaskedEditExtender ID="meeCreateDate" runat="server" Mask="99/99/9999" MaskType="Date" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtCreateDate" /> <asp:CalendarExtender ID="cdeCreateDate" runat="server" PopupButtonID="ibtCreateDate" TargetControlID="txtCreateDate" /> <asp:ImageButton ID="ibtCreateDate" runat="server" CausesValidation="False" ImageUrl="/App_Themes/Admin/images/calendar.png" /> <asp:MaskedEditValidator ID="mevCreateDate" runat="server" ControlExtender="meeCreateDate" ControlToValidate="txtCreateDate" Display="Dynamic" EmptyValueBlurredText="Date is required" IsValidEmpty="True" InvalidValueBlurredMessage="Date is invalid" SetFocusOnError="True"/></td></tr><tr> <th> <asp:Label ID="lblEffectiveDate" runat="server" Text="Ngày hiệu lực:"></asp:Label></th><td><asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="text date"/><asp:MaskedEditExtender ID="meeEffectiveDate" runat="server" Mask="99/99/9999" MaskType="Date" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEffectiveDate" /> <asp:CalendarExtender ID="cdeEffectiveDate" runat="server" PopupButtonID="ibtEffectiveDate" TargetControlID="txtEffectiveDate" /> <asp:ImageButton ID="ibtEffectiveDate" runat="server" CausesValidation="False" ImageUrl="/App_Themes/Admin/images/calendar.png" /> <asp:MaskedEditValidator ID="mevEffectiveDate" runat="server" ControlExtender="meeEffectiveDate" ControlToValidate="txtEffectiveDate" Display="Dynamic" EmptyValueBlurredText="Date is required" IsValidEmpty="True" InvalidValueBlurredMessage="Date is invalid" SetFocusOnError="True"/></td></tr><tr> <th> <asp:Label ID="lblInfo" runat="server" Text="Trích yếu:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckInfo" runat="server"/></td></tr><tr> <th> <asp:Label ID="lblFile" runat="server" Text="File đính kèm:"></asp:Label></th><td><asp:TextBox ID="txtFile" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input ID="btnImgFile" type="button" onclick="BrowseServer('<% =txtFile.ClientID %>','Files');" value="Browse Server" />&nbsp; </td></tr><tr> <th> <asp:Label ID="lblPriority" runat="server" Text="Ưu tiên:"></asp:Label></th><td><asp:CheckBox ID="chkPriority" runat="server" /></td></tr>
    <tr>
        <th>Permission:</th>
        <td valign="top">
            <asp:DropDownList ID="ddlMember" runat="server">
            </asp:DropDownList>
            <br />
            <table id="listMember">
              <tr>
                <td><asp:ListBox ID="lstMemberView" runat="server" Height="160px" Width="250px" 
                        ClientIDMode="Static"></asp:ListBox>
                </td>
                <td><asp:Button ID="add" runat="server" Text=">" CssClass="buttom" /><br /><asp:Button ID="addAll" runat="server" Text=">>" CssClass="buttom" /><br />
                    <asp:Button ID="remove" runat="server" Text="<" CssClass="buttom" /><br /><asp:Button ID="removeAll" runat="server" Text="<<" CssClass="buttom" /><br /></td>
                <td><asp:ListBox ID="lstMemberSelect" runat="server" Height="160px" Width="250px" 
                        ClientIDMode="Static"></asp:ListBox></td>
              </tr>
            </table>
            
            &nbsp;
            &nbsp;
            <br />
        </td>
    </tr>
    <tr> <th> <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label></th><td><asp:CheckBox ID="chkActive" runat="server" /></td></tr><tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
<script type="text/javascript">
    $(document).ready(function () {
        ChangeMember($("#<%= ddlMember.ClientID %>").val());
        $("#<%= ddlMember.ClientID %>").change(function () {
            ChangeMember(this.value);
        });
        $("#<%= add.ClientID %>").click(function () {
            $("#lstMemberView  option:selected").appendTo("#lstMemberSelect");
        });
        $("#<%= addAll.ClientID %>").click(function () {
            $("#lstMemberView option").appendTo("#lstMemberSelect");
        });
        $("#<%= remove.ClientID %>").click(function () {
            $("#lstMemberSelect option:selected").appendTo("#lstMemberView");
        });
        $("#<%= removeAll.ClientID %>").click(function () {
            $("#lstMemberSelect option").appendTo("#lstMemberView");
        });
        function ChangeMember(value) {
            if (value == -1) {
                $("#listMember").css("display", "none");
            }
            else {
                $("#listMember").css("display", "");
            }
        }
    });
    </script>
</asp:Content>
