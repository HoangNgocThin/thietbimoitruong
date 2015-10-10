<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_Deliver.ascx.cs" Inherits="MyWeb.MyControls.My_U_Deliver" %>
<div id='dv_deliver'>
<div class="dv_top1">
    <span>Hệ thống phân phối</span>
</div>
<div class="dv_middle1">
<asp:Literal ID="ltrdeliver" runat="server"></asp:Literal>
<div id="dv_search_refer">
    <h5>Các cửa hàng trực thuộc</h5>
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right">
                <asp:DropDownList ID="ddlprovince" runat="server" CssClass="ddl_province">
                </asp:DropDownList>
            </td>
            <td align="left">
                <asp:ImageButton ID="imgbtnsearchrefer" runat="server" CausesValidation="false"
                ImageUrl="~/App_Themes/Default/img/btngo.jpg" CssClass="css_btnsearch" 
                    onclick="imgbtnsearchrefer_Click" />
            </td>
        </tr>
    </table>  
</div>
</div>
</div>