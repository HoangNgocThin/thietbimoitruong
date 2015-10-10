<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_Top.ascx.cs" Inherits="MyWeb.MyControls.My_U_Top" %>
<div id="dv_banner">
    <div class="top_banner">
        <div class="dv_logo_top">
            <asp:Literal ID="ltrlogo" runat="server"></asp:Literal>
        </div>
        <div class="dv_banner_top">
            <asp:Literal ID="ltrbanner" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="clear"></div>
    <%--<OBJECT CLASSID="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000000000"
               CODEBASE="http://active.macromedia.com/ flash5/cabs/swflash.cab#version=5,0,0,0" style="width: 1010px; height: 150px">
               <PARAM NAME="MOVIE" VALUE="/Uploads/flash/Baner.swf">
               <PARAM NAME="PLAY" VALUE="true">
               <PARAM NAME="LOOP" VALUE="true">
               <PARAM NAME="WMODE" VALUE="opaque">
               <PARAM NAME="QUALITY" VALUE="high">
               <EMBED SRC="/Uploads/flash/Baner.swf" width="1010px" height="150px" PLAY="true" LOOP="true" WMODE="opaque" QUALITY="high"
               PLUGINSPAGE="http://www.macromedia.com/shockwave/ download/index.cgi?P1_Prod_Version=ShockwaveFlash"></EMBED>
   </OBJECT>--%>
</div>

<div class="clearfix">
<div id="dv_left"></div>
<div id="ddtopmenubar" class="mattblackmenu">
<ul>
<asp:Literal ID="ltrmain" runat="server"></asp:Literal>
    <asp:Literal ID="ltrcartinfor" runat="server"></asp:Literal>
</ul>
</div>
<div id="dv_right"></div>
<script type="text/javascript">
    ddlevelsmenu.setup("ddtopmenubar", "topbar") 
</script>
<asp:Literal ID="ltrsub" runat="server"></asp:Literal>
</div>

