<%@ Page Title="" Language="C#" MasterPageFile="~/ThreeMaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MyWeb.Modules.Search.Search" %>
<%@ Register src="search-block.ascx" tagname="search" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc1:search ID="search2" runat="server" />
<div id="cse-search-results"></div>
<script type="text/javascript">
    var googleSearchIframeName = "cse-search-results";
    var googleSearchFormName = "cse-search-box";
    var googleSearchFrameWidth = 724;
    var googleSearchFrameHeight = 1155;
    var googleSearchDomain = "google.com.vn";
    var googleSearchPath = "/cse";
</script>
<script type="text/javascript" src="http://www.google.com/afsonline/show_afs_search.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#cse-search-results iframe").css("height", "940px");
    });
</script>
</asp:Content>
