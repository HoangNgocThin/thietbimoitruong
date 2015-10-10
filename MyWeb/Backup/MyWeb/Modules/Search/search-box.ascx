<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="search-box.ascx.cs" Inherits="MyWeb.Modules.Search.search_box" %>
    <input type="text" name="q" id="query" class="text" onblur="if(this.value=='') this.value='Tìm kiếm';" onfocus="if(this.value=='Tìm kiếm') this.value='';" value="Tìm kiếm"/>
    <input type="button" name="sa" id="search" value="" class="submit" />
<script type="text/javascript">
    $(function () {
        $('#search').click(function () {
            SearchSubmit();
        });
        $('#query').keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                SearchSubmit();
            }
        });
        function SearchSubmit() {
            var q = $("#query").val()
            if (q != "") {
                var cx = "017772635447232899350:ov_wpiloet8";
                var cof = "FORID:11";
                var url = "/search.aspx?cx=" + cx + "&cof=" + cof + "&q=" + q;
                $(window.location).attr('href', url);
            }
        }
    });
</script>

