<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_phanloaisanpham.ascx.cs" Inherits="MyWeb.Controls.uc_phanloaisanpham" %>
<div class="left_box_branch_head">
    <span>Hãng sản xuất</span>
</div>
<div class="left_box_branch_main">
    <asp:RadioButtonList ID="rdBranch" runat="server" CellPadding="5" CellSpacing="5" AutoPostBack="True" OnSelectedIndexChanged="rdBranch_SelectedIndexChanged">
    </asp:RadioButtonList>
</div>
<div class="left_box_branch_head">
    <span>Dung tích</span>
</div>
<div class="left_box_branch_main">
    <asp:RadioButtonList ID="rdCapacity" runat="server" CellPadding="5" CellSpacing="5" AutoPostBack="True" OnSelectedIndexChanged="rdCapacity_SelectedIndexChanged">
    </asp:RadioButtonList>
</div>
