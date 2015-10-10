<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MyWeb.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <meta http-equiv="refresh" content="2;url=Default.aspx" />--%>
    <link href="ddlevelsmenu-base.css" rel="stylesheet" type="text/css" />
    <link href="ddlevelsmenu-sideba.css" rel="stylesheet" type="text/css" />
    <link href="ddlevelsmenu-topbar.css" rel="stylesheet" type="text/css" />
    <link href="style_index.css" rel="stylesheet" type="text/css" />
    <script src="ddlevelsmenu.js" type="text/javascript"></script>
    <style type="text/css">

.sidebarmenu ul{
margin: 0;
padding: 0;
list-style-type: none;
font: bold 13px Verdana;
width: 180px; /* Main Menu Item widths */
border-bottom: 1px solid #ccc;
}
 
.sidebarmenu ul li{
position: relative;
}

/* Top level menu links style */
.sidebarmenu ul li a{
display: block;
overflow: auto; /*force hasLayout in IE7 */
color: white;
text-decoration: none;
padding: 6px;
border-bottom: 1px solid #778;
border-right: 1px solid #778;
}

.sidebarmenu ul li a.a_hover:link, .sidebarmenu ul li a.a_hover:visited, .sidebarmenu ul li a.a_hover:active{
background-color: #012D58; /*background of tabs (default state)*/
}

.sidebarmenu ul li a.a_hover:visited{
color: white;
}

.sidebarmenu ul li a.a_hover:hover{
background-color: black;
}

/*Sub level menu items */
.sidebarmenu ul li ul{
position: absolute;
width: 170px; /*Sub Menu Items width */
top: 0;
visibility: hidden;
}

.sidebarmenu a.subfolderstyle{
background: url(right.gif) no-repeat 97% 50%;
}

 
/* Holly Hack for IE \*/
* html .sidebarmenu ul li { float: left; height: 1%; }
* html .sidebarmenu ul li a { height: 1%; }
/* End */

</style>

<script type="text/javascript">

    //Nested Side Bar Menu (Mar 20th, 09)
    //By Dynamic Drive: http://www.dynamicdrive.com/style/

    var menuids = ["sidebarmenu1"] //Enter id(s) of each Side Bar Menu's main UL, separated by commas

    function initsidebarmenu() {
        for (var i = 0; i < menuids.length; i++) {
            var ultags = document.getElementById(menuids[i]).getElementsByTagName("ul")
            for (var t = 0; t < ultags.length; t++) {
                ultags[t].parentNode.getElementsByTagName("a")[0].className += " subfolderstyle"
                if (ultags[t].parentNode.parentNode.id == menuids[i]) //if this is a first level submenu
                    ultags[t].style.left = ultags[t].parentNode.offsetWidth + "px" //dynamically position first level submenus to be width of main menu item
                else //else if this is a sub level submenu (ul)
                    ultags[t].style.left = ultags[t - 1].getElementsByTagName("a")[0].offsetWidth + "px" //position menu to the right of menu item that activated it
                ultags[t].parentNode.onmouseover = function () {
                    this.getElementsByTagName("ul")[0].style.display = "block"
                    this.getElementsByTagName("a")[0].style.background = "Black"
                }
                ultags[t].parentNode.onmouseout = function () {
                    this.getElementsByTagName("ul")[0].style.display = "none"
                    this.getElementsByTagName("a")[0].style.background = "#012D58"
                }
            }
            for (var t = ultags.length - 1; t > -1; t--) { //loop through all sub menus again, and use "display:none" to hide menus (to prevent possible page scrollbars
                ultags[t].style.visibility = "visible"
                ultags[t].style.display = "none"
            }
        }
    }

    if (window.addEventListener)
        window.addEventListener("load", initsidebarmenu, false)
    else if (window.attachEvent)
        window.attachEvent("onload", initsidebarmenu)

</script>

</head>
<body>
    <form id="form1" runat="server">
   <div id="wrapper" style="width: 1000px;">
    <div id="head" style="">
        
    </div>
    <div id="contents">
        <div id="left_content" style="float: left; width: 200px;">
        
        </div>
        <div id="right_contents" style=" float: left; width: 300px;">
        
        </div>
        <div id="dv3" style="float: right; width: 100px;">
        
        </div>
    </div>
    <div class="clear" style="clear: both;"></div>
    <div id="footer">
    
    </div>
   </div>
    </form>
</body>
</html>
