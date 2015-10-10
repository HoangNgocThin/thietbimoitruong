//SETTING UP OUR POPUP
//0 means disabled; 1 means enabled;
var popupStatus = 0;

//loading popup with jQuery magic!
function loadPopup() {
    //loads popup only if it is disabled
    if (popupStatus == 0) {
        $("#PopupBackground").css({
            "opacity": "0.7"
            //"opacity": "0"
        });
        $("#PopupBackground").fadeIn("slow");
        $("#popupDiv").fadeIn("slow");
        popupStatus = 1;
    }
}

//disabling popup with jQuery magic!
function disablePopup() {
    //disables popup only if it is enabled
    if (popupStatus == 1) {
        $("#PopupBackground").fadeOut("slow");
        $("#popupDiv").fadeOut("slow");
        popupStatus = 0;
    }
}

//centering popup
function centerPopup() {
    //request data for centering
    var windowWidth = document.documentElement.clientWidth;
    var windowHeight = document.documentElement.clientHeight;
    var popupHeight = $("#popupDiv").height();
    var popupWidth = $("#popupDiv").width();
    //centering
    $("#popupDiv").css({
        "position": "absolute",
        "top": windowHeight / 2 - popupHeight / 2,
        //"top": 80,
        "left": windowWidth / 2 - popupWidth / 2
    });
    //only need force for IE6

    $("#PopupBackground").css({
        "height": windowHeight
    });

}


//CONTROLLING EVENTS IN jQuery
$(document).ready(function() {

    //LOADING POPUP
    //centering with css
    centerPopup();
    //load popup
    loadPopup();
    //Click the button event!
    $("#button").click(function() {
        //centering with css
        centerPopup();
        //load popup
        loadPopup();
    });

    //CLOSING POPUP
    //Click the x event!
    $("#popupDivClose").click(function() {
        disablePopup();
    });
    //Click out event!
    $("#PopupBackground").click(function() {
        disablePopup();
    });
    //Press Escape event!
    $(document).keypress(function(e) {
        if (e.keyCode == 27 && popupStatus == 1) {
            disablePopup();
        }
    });

});