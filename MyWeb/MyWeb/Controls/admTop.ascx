<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admTop.ascx.cs" Inherits="MyWeb.Controls.admTop" %>
<%@ Import Namespace="MyWeb.Common" %>
<div class="div"><table class="table" cellspacing="0" cellpadding="0">
<tr>
    <td colspan="3" class="logo">ADMIN PAGE MANAGER</td>
</tr>
<tr>
    <td class="left">Wellcome: <strong><%= Session["FullName"]%></strong>&nbsp; <asp:Literal ID="ltrLanguage" runat="server"></asp:Literal> &nbsp; <asp:ImageButton ID="ibtEn" runat="server" ImageUrl="~/App_Themes/Admin/images/flag_en.gif" onclick="ibtEn_Click" ImageAlign="TextTop" /> &nbsp; <asp:ImageButton ID="ibtVi" runat="server" ImageUrl="~/App_Themes/Admin/images/flag_vi.gif" onclick="ibtVi_Click" ImageAlign="TextTop" /> &nbsp; </td>
    <td class="right">[ <a href="<%=GlobalClass.ApplicationPath %>/admin.aspx" target="_blank">Trang quản trị </a> ] &nbsp; [ <a href="<%=GlobalClass.ApplicationPath %>" target="_blank">Trang chủ</a> ] &nbsp; [<a href="<%=GlobalClass.ApplicationPath %>/logout.aspx"> Đăng xuất</a> ]</td>
</tr>
</table>
</div>


