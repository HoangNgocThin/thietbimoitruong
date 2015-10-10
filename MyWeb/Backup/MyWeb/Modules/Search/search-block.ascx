<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="search-block.ascx.cs" Inherits="MyWeb.Modules.Search.search_block" %>
<div id="search-page">
    <input type="text" name="q" id="query2" class="text" />
    <input type="button" name="sa" id="btnsearch" value="Tìm kiếm" class="submit" />
</div>
<script type="text/javascript">
    $(function () {
        $('#btnsearch').click(function () {
            var q2 = $("#query2").val()
            if (q2 != "") {
                var cx2 = "017772635447232899350:ov_wpiloet8";
                var cof2 = "FORID:11";
                var url2 = "/search.aspx?cx=" + cx2 + "&cof=" + cof2 + "&q=" + q2;
                $(window.location).attr('href', url2);
            }
        });
    });
</script>

