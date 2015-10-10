<%@ Page Title="" Language="C#" Culture="vi-VN" MasterPageFile="~/ThreeMaster.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="MyWeb.Modules.News.NewsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Repeater ID="rpt_newDetails" runat="server">
    <ItemTemplate>
    <div id="news" class="clearfix">
    <div class="news-date"><%#MyWeb.Common.DateTimeClass.DayOfWeek(DataBinder.Eval(Container.DataItem, "Date").ToString())%>, <%#MyWeb.Common.DateTimeClass.ConvertDateTime(DataBinder.Eval(Container.DataItem, "Date").ToString(), "dd/MM/yyyy HH:mm:ss")%></div>
                <h3><%#DataBinder.Eval(Container.DataItem, "Name")%></h3>
                 <div class="news-intro"><%#Convert.ToString(DataBinder.Eval(Container.DataItem, "Content"))%></div>
 <div class="news-content"><%#Convert.ToString(DataBinder.Eval(Container.DataItem, "Detail"))%></div>
                <div class="news-back"><a href="javascript:void(0);" onclick="window.history.go(-1);">[ Trở lại ]</a></div></div>
    </ItemTemplate>
</asp:Repeater>
<asp:Literal ID="ltrNewsRelated" runat="server"></asp:Literal>
<asp:Literal ID="ltrNewsOther" runat="server"></asp:Literal>
</asp:Content>
