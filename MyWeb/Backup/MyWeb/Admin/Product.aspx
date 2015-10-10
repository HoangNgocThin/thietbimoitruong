<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="MyWeb.Admin.Product1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">Quản trị danh sách sản phẩm</div>
<asp:Panel ID="pnView" runat="server">
<div id="search_block">Nhóm sản phẩm: <asp:DropDownList ID="ddlFilterGroupNews" runat="server"></asp:DropDownList> Tên sản phẩm: 
    <asp:TextBox ID="txtFilterName" runat="server" CssClass="text" Width="145px"></asp:TextBox> 
    &nbsp;Mã sản phẩm: <asp:TextBox ID="txtFilterCode" runat="server" CssClass="CheckBox"></asp:TextBox> <span style="display:none">Thời gian: <asp:TextBox ID="txtFilterDateF" runat="server" CssClass="date"/><asp:MaskedEditExtender ID="meeDateFrom" runat="server" Mask="99/99/9999" MaskType="Date" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtFilterDateF" /> <asp:CalendarExtender ID="cdeDateFrom" runat="server" TargetControlID="txtFilterDateF" /> - <asp:TextBox ID="txtFilterDateT" runat="server" CssClass="date"/><asp:MaskedEditExtender ID="meeDateTo" runat="server" Mask="99/99/9999" MaskType="Date" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtFilterDateT" /> <asp:CalendarExtender ID="cdeDateTo" runat="server" TargetControlID="txtFilterDateT" /></span> Trạng thái: <asp:DropDownList ID="ddlFilterActive" runat="server" CssClass="active"></asp:DropDownList>  <asp:Button ID="Filter" runat="server" onclick="Filter_Click" Text="Lọc" CssClass="filter" /> <asp:Button ID="UnFilter" runat="server" onclick="UnFilter_Click" Text="Bỏ lọc" /></div>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li>
    <asp:LinkButton CssClass="uupdate" ID="lbtUpdateprice" runat="server" 
        onclick="lbtUpdateprice_Click">Cập nhật giá và thứ tự</asp:LinkButton></li> <li> <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
<asp:Datagrid ID="grdProduct" runat="server" width="100%" CssClass="TableView" 
        AutoGenerateColumns="False" AllowPaging="True" 
        PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" 
        onitemdatabound="grdProduct_ItemDataBound" 
        onitemcommand="grdProduct_ItemCommand" 
        onpageindexchanged="grdProduct_PageIndexChanged" BorderStyle="Solid"> <HeaderStyle CssClass="trHeader"></HeaderStyle> <ItemStyle CssClass="trOdd"></ItemStyle> <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle> <Columns>
<asp:TemplateColumn ItemStyle-CssClass="tdCenter"> <HeaderTemplate> <asp:CheckBox id="chkSelectAll" Runat="server" AutoPostBack="False"></asp:CheckBox> </HeaderTemplate> <ItemTemplate> <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> </ItemTemplate> <ItemStyle CssClass="tdCenter"></ItemStyle> </asp:TemplateColumn>
<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" /><asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
<asp:TemplateColumn ItemStyle-CssClass="Text"> <HeaderTemplate>Tên sản phẩm <asp:LinkButton CssClass="sortasc" ID="lbtascName" CommandName="ascName" runat="server" ToolTip="Sắp xếp theo tên tăng dần">s</asp:LinkButton><asp:LinkButton CssClass="sortdesc" ID="lbtdescName" CommandName="descName" runat="server" ToolTip="Sắp xếp theo tên giảm dần">s</asp:LinkButton></HeaderTemplate> <ItemTemplate><%#DataBinder.Eval(Container.DataItem, "Name")%></ItemTemplate> 
    <ItemStyle CssClass="Text" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Image"> <HeaderTemplate>Hình ảnh</HeaderTemplate> <ItemTemplate> <script type="text/javascript">playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script> </ItemTemplate> 
    <ItemStyle CssClass="Image" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="DateTimesmal"> <HeaderTemplate>Ngày đăng <asp:LinkButton CssClass="sortasc" ID="lbtascDate" CommandName="ascDate" runat="server" ToolTip="Sắp xếp theo ngày đăng tăng dần">s</asp:LinkButton><asp:LinkButton CssClass="sortdesc" ID="lbtdescDate" CommandName="descDate" runat="server" ToolTip="Sắp xếp theo ngày đăng giảm dần">s</asp:LinkButton></HeaderTemplate> <ItemTemplate> <asp:label ID="Label1" runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDate(DataBinder.Eval(Container.DataItem, "Date").ToString()) %>'></asp:label> </ItemTemplate> 
    <ItemStyle CssClass="DateTimesmal" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Moneysmall"> <HeaderTemplate>Giá <asp:LinkButton CssClass="sortasc" ID="lbtascPrice" CommandName="ascPrice" runat="server" ToolTip="Sắp xếp theo giá tăng dần">s</asp:LinkButton><asp:LinkButton CssClass="sortdesc" ID="lbtdescPrice" CommandName="descPrice" runat="server" ToolTip="Sắp xếp theo giá giảm dần">s</asp:LinkButton></HeaderTemplate> <ItemTemplate><asp:TextBox ID="txtGia" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Price")%>' Width="80px" style="text-align: right"></asp:TextBox></ItemTemplate> 
    <ItemStyle CssClass="Moneysmall" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="CheckBoxsmall"> <HeaderTemplate>Ưu tiên</HeaderTemplate> <ItemTemplate><asp:Image ID="Image1" runat="server" ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "Priority").ToString())%>' /></ItemTemplate> 
    <ItemStyle CssClass="CheckBoxsmall" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="CheckBoxsmall"> <HeaderTemplate>Trang chủ</HeaderTemplate> <ItemTemplate><asp:Image ID="Image2" runat="server" ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "Index").ToString())%>' /></ItemTemplate> 
    <ItemStyle CssClass="CheckBoxsmall" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Activehead"><HeaderTemplate>Thứ tự <asp:LinkButton CssClass="sortasc" ID="lbtascord" CommandName="ascOrd" runat="server" ToolTip="Sắp xếp theo thứ tự tăng dần">s</asp:LinkButton><asp:LinkButton CssClass="sortdesc" ID="lbtdescord" CommandName="descOrd" runat="server" ToolTip="Sắp xếp theo thứ tự giảm dần">s</asp:LinkButton></HeaderTemplate> <ItemTemplate><asp:TextBox ID="txtOrd" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ord")%>' CssClass="text number" Width="80px" style="text-align: center"></asp:TextBox><asp:RequiredFieldValidator ID="rfvOrdview" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></ItemTemplate>
    <ItemStyle CssClass="Activehead" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Activehead"> <HeaderTemplate>Kích hoạt</HeaderTemplate> <ItemTemplate> <asp:label id="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:label> </ItemTemplate> 
    <ItemStyle CssClass="Activehead" />
        </asp:TemplateColumn>
<asp:TemplateColumn ItemStyle-CssClass="Function"> <HeaderTemplate>Chức năng</HeaderTemplate> <ItemTemplate><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate> 
    <ItemStyle CssClass="Function" />
        </asp:TemplateColumn>
</Columns><PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle></asp:Datagrid>
<div class="Control"><ul><li><asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton></li> <li><asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" onclick="DeleteButton_Click">Xóa</asp:LinkButton></li> <li>
    <asp:LinkButton CssClass="uupdate" ID="lbtUpdatepricebottom" runat="server" 
        onclick="lbtUpdatepricebottom_Click">Cập nhật giá và thứ tự</asp:LinkButton></li> <li><asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" onclick="RefreshButton_Click">Làm mới</asp:LinkButton></li> <li> <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li></ul></div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
<table class="TableUpdate" border="1">
<tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr>
<tr> <th> <asp:Label ID="lblName0" runat="server" Text="Nhóm sản phẩm:"></asp:Label></th><td>
    <asp:DropDownList ID="drlCatIdAdd" runat="server">
    </asp:DropDownList>
    <asp:HiddenField ID="txtId" runat="server" />
    </td></tr>
    <tr>
        <th>
            <asp:Label ID="lblName1" runat="server" Text="Mã sản phẩm:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtCode" runat="server" CssClass="text"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName0" runat="server" 
                ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <th>
            <asp:Label ID="lblName" runat="server" Text="Tên sản phẩm:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr> <th> <asp:Label ID="lblContent" runat="server" Text="Tóm tắt sản phẩm:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckContent" runat="server"/></td></tr><tr> <th> <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label></th><td><FCKeditorV2:FCKeditor ID="fckDetail" runat="server"/></td></tr><tr> <th> 
    <asp:Label ID="lblPrice" runat="server" Text="Giá sản phẩm:"></asp:Label></th><td><asp:TextBox ID="txtPrice" runat="server" CssClass="text number"/><asp:MaskedEditExtender ID="meePrice" runat="server" Mask="9,999,999.99" MaskType="Number" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtPrice" /> <asp:MaskedEditValidator ID="mevPrice" runat="server" ControlExtender="meePrice" ControlToValidate="txtPrice" Display="Dynamic" EmptyValueBlurredText="Number is required" IsValidEmpty="True" SetFocusOnError="True"/></td></tr>
    <tr>
        <th>
            <asp:Label ID="lblPrice0" runat="server" Text="Giá sản phẩm cũ:"></asp:Label>
        </th>
        <td>
            <asp:TextBox ID="txtPricecu" runat="server" CssClass="text number" />
            <asp:MaskedEditExtender ID="txtPricecu_MaskedEditExtender" runat="server" 
                Mask="9,999,999.99" MaskType="Number" OnFocusCssClass="MaskedEditFocus" 
                OnInvalidCssClass="MaskedEditError" TargetControlID="txtPricecu" />
            <asp:MaskedEditValidator ID="mevPricecu" runat="server" 
                ControlExtender="meePrice" ControlToValidate="txtPrice" Display="Dynamic" 
                EmptyValueBlurredText="Number is required" IsValidEmpty="True" 
                SetFocusOnError="True" />
        </td>
    </tr>
    <tr> <th> <asp:Label ID="lblImage" runat="server" Text="Hình ảnh đại diện:"></asp:Label></th><td><asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input ID="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>','Images');" value="Browse Server" />&nbsp; <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" /></td></tr>
    <tr > <th> <asp:Label ID="Label2" runat="server" Text="Hình ảnh:" Visible="False"></asp:Label></th><td>
        <asp:TextBox ID="txtImage1" runat="server" CssClass="text image" 
            Visible="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Image ID="imgImage1" 
            runat="server" ImageAlign="Middle" Width="100px" Visible="False" /></td></tr>
    <tr> <th> <asp:Label ID="Label3" runat="server" Text="Hình ảnh:" Visible="False"></asp:Label></th><td>
        <asp:TextBox ID="txtImage2" runat="server" CssClass="text image" 
            Visible="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Image ID="imgImage2" 
            runat="server" ImageAlign="Middle" Width="100px" Visible="False" /></td></tr>
    <tr> <th> <asp:Label ID="Label4" runat="server" Text="Hình ảnh:" Visible="False"></asp:Label></th><td>
        <asp:TextBox ID="txtImage3" runat="server" CssClass="text image" 
            Visible="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Image ID="imgImage3" 
            runat="server" ImageAlign="Middle" Width="100px" Visible="False" /></td></tr>
    <tr> <th> <asp:Label ID="Label5" runat="server" Text="Hình ảnh:" Visible="False"></asp:Label></th><td>
        <asp:TextBox ID="txtImage4" runat="server" CssClass="text image" 
            Visible="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Image ID="imgImage4" 
            runat="server" ImageAlign="Middle" Width="100px" Visible="False" /></td></tr>
    <tr> <th> <asp:Label ID="Label6" runat="server" Text="Hình ảnh:" Visible="False"></asp:Label></th><td>
        <asp:TextBox ID="txtImage5" runat="server" CssClass="text image" 
            Visible="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Image ID="imgImage5" 
            runat="server" ImageAlign="Middle" Width="100px" Visible="False" /></td></tr><tr> <th> <asp:Label ID="lblDate" runat="server" Text="Ngày đăng:"></asp:Label></th><td><asp:TextBox ID="txtDate" runat="server" CssClass="text datetime"/><asp:MaskedEditExtender ID="meeDate" runat="server" Mask="99/99/9999 99:99:99" MaskType="DateTime" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate" AcceptAMPM="True" Century="2000"/> <asp:MaskedEditValidator ID="mevDate" runat="server" ControlExtender="meeDate" ControlToValidate="txtDate" Display="Dynamic" EmptyValueBlurredText="Date and time is required" IsValidEmpty="True" InvalidValueBlurredMessage="Date and time is invalid" SetFocusOnError="True"/></td></tr>
    <tr>
        <th>
            <asp:Label ID="lblDate0" runat="server" Text="Thương hiệu:" Visible="False"></asp:Label>
        </th>
        <td>
            <asp:CheckBoxList ID="chkbrands" runat="server" CellPadding="10" 
                RepeatDirection="Horizontal" Visible="False"></asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <th>
            <asp:Label ID="lblDate1" runat="server" Text="Kích thước:" Visible="False"></asp:Label>
        </th>
        <td>
            <asp:CheckBoxList ID="chklistSizes" runat="server" CellPadding="10" 
                RepeatDirection="Horizontal" Visible="False">
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <th>
            <asp:Label ID="lblDate2" runat="server" Text="Màu sắc:" Visible="False"></asp:Label>
        </th>
        <td>
            <asp:CheckBoxList ID="chklistColors" runat="server" CellPadding="10" 
                RepeatDirection="Horizontal" Visible="False">
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr> <th> <asp:Label ID="lblTitle" runat="server" Text="Title meta:"></asp:Label></th><td><asp:TextBox ID="txtTitle" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblDescription" runat="server" Text="Description meta:"></asp:Label></th><td><asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblKeyword" runat="server" Text="Keyword meta:"></asp:Label></th><td><asp:TextBox ID="txtKeyword" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td></tr><tr> <th> 
    <asp:Label ID="lblPriority" runat="server" Text="Sản phẩm thông dụng: "></asp:Label>
    </th><td>
        <asp:CheckBox ID="chkPriority" runat="server" />
    </td></tr>
    <tr>
        <th>
            <asp:Label ID="lblIndex" runat="server" Text="Sản phẩm trang chủ:"></asp:Label>
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
    <tr> <th> <asp:Label ID="lblOrd" runat="server" Text="Thứ tự:"></asp:Label></th><td><asp:TextBox ID="txtOrd" runat="server" CssClass="text number"/><asp:RequiredFieldValidator ID="rfvOrd" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr><tr> <td class="Control" colspan="2"><ul><li><asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" onclick="Update_Click">Ghi lại</asp:LinkButton></li> <li> <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server"  onclick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li> </ul></td> </tr></table>
</asp:Panel>
<script type="text/javascript">
    $(document).ready(function () {
        var strName = '<%=ListName%>'.split("|");
        var strCode = '<%=ListCode%>'.split("|");
        $("#<%= txtFilterName.ClientID %>").autocomplete({ source: strName });
        $("#<%= txtFilterCode.ClientID %>").autocomplete({ source: strCode });
    });
</script>
</asp:Content>
