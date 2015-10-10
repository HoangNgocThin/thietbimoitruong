<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Forex.ascx.cs" Inherits="MyWeb.Modules.Other.Forex" %>
<div class="nav">Tỷ giá</div><div id="exchange"></div>
<script type="text/javascript">
    $(function () {
        $("#exchange").load("/exchange.aspx");
    });
</script>