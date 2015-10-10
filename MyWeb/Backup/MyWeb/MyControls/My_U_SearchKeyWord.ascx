<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_SearchKeyWord.ascx.cs" Inherits="MyWeb.MyControls.My_U_SearchKeyWord" %>
<div id="dv_search_keyword">
    <div class="dv_top">
        <span>Tìm kiếm</span>
    </div>
    <div class="dv_middle2">
        <div id="dv_textbox">
            <asp:Panel ID="Panel1" runat="server" DefaultButton="imgbtn">
                <asp:TextBox ID="txtkeyword" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgbtn" CausesValidation="false"
                    runat="server" ImageUrl="~/App_Themes/Default/img/btn_tiemkiem.png" 
                    onclick="imgbtn_Click" />
            </asp:Panel>
        </div>
    </div>
</div>