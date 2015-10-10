<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="MyWeb.Admin.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main-zone-wrapper" runat="server">
    <div class="PageName">Sản phẩm</div>
        <table>
    <tr>
        <td>Tên sản phẩm :&nbsp; </td>
        <td>
            <asp:TextBox ID="txtSearch" runat="server" Width="250px"></asp:TextBox></td>
       
        <td>Loại sản phẩm</td>
        <td>
            <asp:DropDownList ID="ddlProductCategorySearch" runat="server"></asp:DropDownList></td>
         <td>
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click"  /></td>
    </tr>
    </table>
    <asp:Panel ID="pnView" runat="server">
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li>
            </ul>
        </div>
        <asp:DataGrid ID="grdProduct" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdProduct_ItemDataBound" OnItemCommand="grdProduct_ItemCommand" OnPageIndexChanged="grdProduct_PageIndexChanged">
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <ItemStyle CssClass="trOdd"></ItemStyle>
            <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
            <Columns>
                <asp:TemplateColumn ItemStyle-CssClass="tdCenter">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="tdCenter"></ItemStyle>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="False" />
                <asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
                <asp:BoundColumn DataField="ProductCode" HeaderText="Mã sản phẩm" ItemStyle-CssClass="Text" Visible="true" />
                <asp:BoundColumn DataField="Name" HeaderText="Tên sản phẩm" ItemStyle-CssClass="Text" Visible="true" />
            
                <asp:TemplateColumn ItemStyle-CssClass="Active">
                    <HeaderTemplate>Kích hoạt</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Giá bán" ItemStyle-CssClass="MoneyUSD" Visible="true" >
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Format_Price(DataBinder.Eval(Container.DataItem, "SalePrice").ToString()) %>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <%--<asp:BoundColumn DataField="UnitPrice" HeaderText="Giá thị trường" ItemStyle-CssClass="MoneyUSD" Visible="true" />--%>
                <asp:TemplateColumn ItemStyle-CssClass="Image">
                    <HeaderTemplate>Hình ảnh</HeaderTemplate>
                    <ItemTemplate>
                        <script type="text/javascript"> playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script>
                    </ItemTemplate>
                </asp:TemplateColumn>


                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>Chức năng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' /></ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li>
            </ul>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnUpdate" runat="server" Visible="False">
        <table class="TableUpdate" border="1">
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" OnClick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblProductCategoryID" runat="server" Text="Loại sản phẩm:"></asp:Label></th>
                <td>
                    <asp:DropDownList ID="ddlProductCategory" runat="server" Width="200px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProductCategory" runat="server" ControlToValidate="ddlProductCategory" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblProductCode" runat="server" Text="Mã sản phẩm:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtProductCode" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblName" runat="server" Text="Tên sản phẩm:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblTitle" runat="server" Text="Tiêu đề:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblContent" runat="server" Text="Tóm tắt:"></asp:Label></th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckContent" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label></th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckDetail" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDecription" runat="server" Text="Decription:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtDecription" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblMetaKeyword" runat="server" Text="Keyword meta:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtMetaKeyword" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label></th>
                <td>
                    <asp:CheckBox ID="chkActive" runat="server" /></td>
            </tr>
              <tr>
                <th>
                    <asp:Label ID="Label1" runat="server" Text="Đơn vị tính"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtUnit" runat="server" CssClass="text" />
                   </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblSalePrice" runat="server" Text="Giá bán:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtSalePrice" runat="server" CssClass="text number" /><AjaxControl:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtSalePrice" runat="server" FilterType="Numbers">
                            </AjaxControl:FilteredTextBoxExtender>
                   </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblUnitPrice" runat="server" Text="Giá thị trường:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="text number" /><AjaxControl:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtUnitPrice" runat="server" FilterType="Numbers">
                            </AjaxControl:FilteredTextBoxExtender>
                   </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblImage" runat="server" Text="Hình ảnh:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input id="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>','Images');" value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
           
            <tr>
                <th>
                    <asp:Label ID="lblImage1" runat="server" Text="Hình ảnh 1:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtImage1" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input id="btnImgImage1" type="button" onclick="    BrowseServer('<% =txtImage1.ClientID %>','Images');" value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage1" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblImage2" runat="server" Text="Hình ảnh 2:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtImage2" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input id="btnImgImage2" type="button" onclick="    BrowseServer('<% =txtImage2.ClientID %>','Images');" value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage2" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblImage3" runat="server" Text="Hình ảnh 3:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtImage3" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input id="btnImgImage3" type="button" onclick="    BrowseServer('<% =txtImage3.ClientID %>','Images');" value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage3" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblImage4" runat="server" Text="Hình ảnh 4:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtImage4" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input id="btnImgImage4" type="button" onclick="    BrowseServer('<% =txtImage4.ClientID %>','Images');" value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage4" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblImage5" runat="server" Text="Hình ảnh 5:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtImage5" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input id="btnImgImage5" type="button" onclick="    BrowseServer('<% =txtImage5.ClientID %>','Images');" value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage5" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
            
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server" OnClick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
