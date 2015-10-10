<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_Slide.ascx.cs" Inherits="MyWeb.MyControls.My_U_Slide" %>
<asp:Literal ID="ltrslide" runat="server"></asp:Literal>
  <script type="text/javascript">
      function theRotator() {
          //Set the opacity of all images to 0
          $('div#rotator ul li').css({ opacity: 0.0 });

          //Get the first image and display it (gets set to full opacity)
          $('div#rotator ul li:first').css({ opacity: 1.0 });

          //Call the rotator function to run the slideshow, 6000 = change to next image after 6 seconds
          setInterval('rotate()', 3000);
      }

      function rotate() {
          //Get the first image
          var current = ($('div#rotator ul li.show') ? $('div#rotator ul li.show') : $('div#rotator ul li:first'));

          //Get next image, when it reaches the end, rotate it back to the first image
          var next = ((current.next().length) ? ((current.next().hasClass('show')) ? $('div#rotator ul li:first') : current.next()) : $('div#rotator ul li:first'));

          //Set the fade in effect for the next image, the show class has higher z-index
          next.css({ opacity: 0.0 })
	.addClass('show')
	.animate({ opacity: 1.0 }, 1500);

          //Hide the current image
          current.animate({ opacity: 0.0 }, 1000)
	.removeClass('show');

      };

      $(document).ready(function () {
          //Load the slideshow
          theRotator();
      });

</script>
<%--<OBJECT CLASSID="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
               CODEBASE="http://active.macromedia.com/ flash5/cabs/swflash.cab#version=5,0,0,0" style="width: 588px; height: 300px">
               <PARAM NAME="MOVIE" VALUE="/Uploads/flash/Slide_baner.swf">
               <PARAM NAME="PLAY" VALUE="true">
               <PARAM NAME="LOOP" VALUE="true">
               <PARAM NAME="WMODE" VALUE="opaque">
               <PARAM NAME="QUALITY" VALUE="high">
               <EMBED SRC="/Uploads/flash/Slide_baner.swf" width= "588px" height= "300px" PLAY="true" LOOP="true" WMODE="opaque" QUALITY="high"
               PLUGINSPAGE="http://www.macromedia.com/shockwave/ download/index.cgi?P1_Prod_Version=ShockwaveFlash"></EMBED>
   </OBJECT>--%>