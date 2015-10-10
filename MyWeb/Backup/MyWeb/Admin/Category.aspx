<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="MyWeb.Admin.Category1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">Quản trị NHÓM SẢN PHẨM</div>
<asp:Panel ID="pnView" runat="server">
<div id="search_block"> Tên nhóm sản phẩm: <asp:TextBox ID="txtFilterName" runat="server" CssClass="text"></asp:TextBox> Trạng thái: <asp:DropDownList ID="ddlFilterActive" runat="server" CssClass="active"></asp:DropDownList>
    <asp:DropDownList ID="drlNhomtrangchu" runat="server" CssClass="active" 
        Visible="False"></asp:DropDownList>  Nhóm ưu tiên: <asp:DropDownList ID="drlNhomuutien" runat="server" CssClass="active"></asp:DropDownList> <asp:Button ID="Filter" runat="server" onclick="Filter_Click" Text="Lọc" CssClass="filter" /> <asp:Button ID="UnFilter" runat="server" onclick="UnFilter_Click" Text="Bỏ lọc" /></div>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li>
    <asp:LinkButton CssClass="uupdate" ID="lbtUpdateOrd" runat="server" 
        onclick="lbtUpdateOrd_Click">Cập nhật thứ tự</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdCategory" runat="server" width="100%" CssClass="TableView" 
        AutoGenerateColumns="False" AllowPaging="True" 
        PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" 
        onitemdatabound="grdCategory_ItemDataBound" 
        onitemcommand="grdCategory_ItemCommand" 
        onpageindexchanged="grdCategory_PageIndexChanged" AllowSorting="True"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" /><asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
<asp:TemplateColumn ItemStyle-CssClass="Text"> <HeaderTemplate>Tên nhóm <asp:LinkButton CssClass="sortasc" ID="lbtascname" CommandName="ascname" runat="server" ToolTip="Sắp xếp theo tên tăng dần">s</asp:LinkButton><asp:LinkButton CssClass="sortdesc" ID="lbtdescname" CommandName="descname" runat="server" ToolTip="Sắp xếp theo tên giảm dần">s</asp:LinkButton></HeaderTemplate> <ItemTemplate> <asp:label ID="Label1" runat="server" Text='<%# MyWeb.Common.StringClass.ShowNameLevel(DataBinder.Eval(Container.DataItem, "Name").ToString(), DataBinder.Eval(Container.DataItem, "Level").ToString()) %>'></asp:label> </ItemTemplate> 
    <ItemStyle CssClass="Text" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Image"> <HeaderTemplate>Hình ảnh</HeaderTemplate> <ItemTemplate> <script type="text/javascript">playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script> </ItemTemplate> 
    <ItemStyle CssClass="Image" />
        </asp:TemplateColumn>
<%--<asp:TemplateColumn ItemStyle-CssClass="CheckBox"> <HeaderTemplate>Nhóm ưu tiên <asp:LinkButton CssClass="sortasc" ID="lbtascpriority" CommandName="ascpriority" runat="server" ToolTip="Sắp xếp theo nhóm ưu tiên tăng dần">s</asp:LinkButton><asp:LinkButton CssClass="sortdesc" ID="lbtdescpriority" CommandName="descpriority" runat="server" ToolTip="Sắp xếp theo nhóm ưu tiên giảm dần">s</asp:LinkButton></HeaderTemplate> <ItemTemplate><asp:Image ID="Image1" runat="server" ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "Priority").ToString())%>' /></ItemTemplate> </asp:TemplateColumn>--%>

<asp:TemplateColumn ItemStyle-CssClass="Activehead"> <HeaderTemplate>Kích hoạt <asp:LinkButton CssClass="sortasc" ID="lbtascactive" CommandName="ascactive" runat="server" ToolTip="Sắp xếp theo kích hoạt tăng dần">s</asp:LinkButton><asp:LinkButton CssClass="sortdesc" ID="lbtdescactive" CommandName="descactive" runat="server" ToolTip="Sắp xếp theo kích hoạt giảm dần">s</asp:LinkButton></HeaderTemplate> <ItemTemplate> <asp:label id="lblStatus" style="padding-left: 10px" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:label> </ItemTemplate> 
    <ItemStyle CssClass="Activehead" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Activehead"><HeaderTemplate>Thứ tự <asp:LinkButton CssClass="sortasc" ID="lbtascord" CommandName="ascord" runat="server" ToolTip="Sắp xếp theo thứ tự tăng dần">s</asp:LinkButton><asp:LinkButton CssClass="sortdesc" ID="lbtdescord" CommandName="descord" runat="server" ToolTip="Sắp xếp theo thứ tự giảm dần">s</asp:LinkButton></HeaderTemplate> <ItemTemplate><asp:TextBox ID="txtOrd" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ord")%>' CssClass="text number" Width="80px" style="text-align: center"></asp:TextBox><asp:RequiredFieldValidator ID="rfvOrdview" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></ItemTemplate>
    <ItemStyle CssClass="Activehead" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate> 
    <ItemStyle CssClass="Function" />
        </asp:TemplateColumn>
</Columns><PagerStyle HorizontalAlign="Center" CssClass="Paging" 
        NextPageText="Previous" PrevPageText="Next"></PagerStyle></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li>
    <asp:LinkButton CssClass="uupdate" ID="lbtUpdateOrdBottom" runat="server" 
        onclick="lbtUpdateOrdBottom_Click">Cập nhật thứ tự</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
    <tr> <th> <asp:Label ID="lblName" runat="server" Text="Tên nhóm:"></asp:Label></th><td><asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:HiddenField ID="txtId" runat="server" />
        </td></tr><tr> <th> <asp:Label ID="lblContent" runat="server" Text="Diễn giải:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckContent" runat="server"/></td></tr><tr> <th> 
    <asp:Label ID="lblImage" runat="server" Text="Hình ảnh to:"></asp:Label></th><td><asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input ID="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>','Images');" value="Browse Server" />&nbsp; <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" /></td></tr>
    <tr>
        <th>
            <asp:Label ID="lblImage2" runat="server" Text="Hình ảnh nhỏ:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtImage2" runat="server" CssClass="text image"></asp:TextBox>
            &nbsp;<input ID="btnImgImage2" 
                type="button" onclick="BrowseServer('<% =txtImage2.ClientID %>','Images');" 
                value="Browse Server" />&nbsp;
            <asp:Image ID="imgImage2" runat="server" ImageAlign="Middle" Width="100px" />
        </td>
    </tr>
    <tr> <th> <asp:Label ID="lblTitle" runat="server" Text="Title meta:"></asp:Label></th><td><asp:TextBox ID="txtTitle" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblDescription" runat="server" Text="Description meta:"></asp:Label></th><td><asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblKeyword" runat="server" Text="Keyword meta:"></asp:Label></th><td><asp:TextBox ID="txtKeyword" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr style="display:none"> 
    <th class="style1"> <asp:Label ID="lblPriority" runat="server" Text="Nhóm ưu tiên:"></asp:Label></th>
    <td class="style1"><asp:CheckBox ID="chkPriority" runat="server" /></td></tr><tr> <th> 
    <asp:Label ID="lblIndex" runat="server" Text="Nhóm trang chủ:" Visible="False"></asp:Label></th><td>
        <asp:CheckBox ID="chkIndex" runat="server" Visible="False" /></td></tr><tr> <th> <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label></th><td><asp:CheckBox ID="chkActive" runat="server" /></td></tr><tr> <th> <asp:Label ID="lblOrd" runat="server" Text="Thứ tự:"></asp:Label></th><td><asp:TextBox ID="txtOrd" runat="server" CssClass="text number"/><asp:RequiredFieldValidator ID="rfvOrd" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr><tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
<script type="text/javascript">
    $(document).ready(function () {
        var strName = '<%=ListName%>'.split("|");
        $("#<%= txtFilterName.ClientID %>").autocomplete({ source: strName });
    });
</script>
</asp:Content>
