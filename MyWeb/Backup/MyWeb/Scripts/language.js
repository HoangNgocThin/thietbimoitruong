$(document).ready(function(){
	$.getScript('/scripts/jquery.translate-1.3.9.min.js');
	$.getScript('/scripts/jquery.cookie.js');	
	var date = new Date();
	date.setTime(date.getTime() + (86400*360));
	$(function(){
		if($.cookie('lang') !=''){
			ChangeLang($.cookie('lang'));
		}
	});	
	function ChangeLang(lang){
		$('body').translate(lang);
		$.cookie('lang', lang, { path: '/', expires: date });
	}
});