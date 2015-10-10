<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyWeb.Modules.Page.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContents" runat="server">
<%--<script type="text/javascript">
    function Validate(source, args) {
        var fckBody = FCKeditorAPI.GetInstance('<%=fckDetail.ClientID %>');
        args.IsValid = fckBody.GetXHTML(true) != "";
    }
</script>--%>
<div class='dv_sp_header'>
<div class="dv_span">
    <span>Liên hệ</span>
</div>
<table class="tcontact">
<tr><td colspan="2"><asp:Literal ID="ltrContact" runat="server"></asp:Literal></td></tr>
<tr> <th> <asp:Label ID="lblName" runat="server" Text="Họ tên:"></asp:Label><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></th><td><asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblCompany" runat="server" Text="Công ty:"></asp:Label></th><td><asp:TextBox ID="txtCompany" runat="server" CssClass="multiline"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblAddress" runat="server" Text="Địa chỉ:"></asp:Label></th><td><asp:TextBox ID="txtAddress" runat="server" CssClass="multiline"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblTel" runat="server" Text="Điện thoại:"></asp:Label></th><td><asp:TextBox ID="txtTel" runat="server" CssClass="date"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblMail" runat="server" Text="Mail:"></asp:Label>
    <asp:RegularExpressionValidator ID="revEmail" runat="server" 
        ControlToValidate="txtMail" ErrorMessage="*" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    </th><td><asp:TextBox ID="txtMail" runat="server" CssClass="datetime"></asp:TextBox></td></tr><tr> <th> <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label>
    <%--<asp:RequiredFieldValidator ID="rfvDetail" runat="server" 
        ControlToValidate="fckDetail" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>--%><asp:CustomValidator runat="server" ID="cvBody" SetFocusOnError="true" Display="dynamic" Text="*" ClientValidationFunction="Validate"></asp:CustomValidator></th><td>
        <asp:TextBox ID="txtcontents" runat="server" Height="142px" 
            TextMode="MultiLine" Width="366px"></asp:TextBox>
    </td></tr><tr><td>&nbsp;</td> <td valign="middle" class="control">
        <asp:Button ID="btnContact" runat="server" Text="Gửi" CssClass="css_btncontact" 
            onclick="btnContact_Click" />
        &nbsp;<asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
        </td> </tr></table>
</div>
</asp:Content>