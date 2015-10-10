<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="MyWeb.Modules.News.NewsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="newsDetail">
        <div class="newsDetail_span">
            <span>Danh sách tin tức</span>
        </div>
        <div class="newslist_main">
            <asp:Literal ID="ltrDetail" runat="server"></asp:Literal>
        </div>
        <div class="dv_paging">
            <asp:Literal ID="ltrpaging" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
