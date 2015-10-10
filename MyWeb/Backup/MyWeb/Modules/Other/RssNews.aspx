<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RssNews.aspx.cs" Inherits="MyWeb.Modules.Other.RssNews" %>
<div class="news-tab">
<marquee onmouseover="this.stop();" onmouseout="this.start();" scrollamount="1" scrolldelay="1" direction="up" style="height:185px;">
<ul><asp:repeater ID="rptRss" runat="server">
    <ItemTemplate><li><a href='<%# DataBinder.Eval(Container.DataItem, "link").ToString().Trim() %>' title='<%# Eval("title") %>' target="_blank"><%# Eval("title")%></a></li></ItemTemplate>
</asp:repeater></ul>
</marquee>
</div>

