var load = false;
TranslateThis({
    //onClick: function () { Refresh(); },
//    onLoad: function () { load = true; }, // Callback function
    onClick: function () { RefreshFlash(); },
//    onComplete: function () { load = false; },
    fromLang: 'vi', // Native language of your site
    ddLangs: [ // Languages in the dropdown
        'vi',
		'en',
        'fr',
        'it',
        'ru',
        'zh-CN',
        'ja',
        'ko'
    ],
    btnImg: '/App_Themes/Default/images/tt-btn1.png',
    bgImg: '/App_Themes/Default/images/language.png'
});
function RefreshFlash() {
    var lang = "";
    if (readCookie("tt-lang") != 'vi' || readCookie("tt-lang") != '') {
        var lang = "_en";
    }
    var top_banner = "<embed name=\"FlashContent\" src=\"/uploads/images/banner" + lang +".swf\" quality=\"high\" flashvars=\"\" allowfullscreen=\"true\" allowscriptaccess=\"always\" wmode=\"transparent\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"645\" height=\"118\">";
    var banner = "<embed name=\"FlashContent\" src=\"/banner" + lang + ".swf\" quality=\"high\" flashvars=\"\" allowfullscreen=\"true\" allowscriptaccess=\"always\" wmode=\"transparent\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"970\" height=\"240\"></embed>";
    $("#banner").html(banner);
    $("#top-banner").html(top_banner);
};