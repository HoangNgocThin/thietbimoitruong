var x_offset_tooltip=5,y_offset_tooltip=0,ajax_tooltipObj=false,ajax_tooltipObj_iframe=false,ajax_tooltip_MSIE=false;if(navigator.userAgent.indexOf("MSIE")>=0)ajax_tooltip_MSIE=true;function ajax_showTooltip(c,d){if(!ajax_tooltipObj){ajax_tooltipObj=document.createElement("DIV");ajax_tooltipObj.style.position="absolute";ajax_tooltipObj.id="ajax_tooltipObj";document.body.appendChild(ajax_tooltipObj);var b=document.createElement("DIV");b.className="ajax_tooltip_arrow";b.id="ajax_tooltip_arrow";ajax_tooltipObj.appendChild(b);var a=document.createElement("DIV");a.className="ajax_tooltip_content";ajax_tooltipObj.appendChild(a);a.id="ajax_tooltip_content";if(ajax_tooltip_MSIE){ajax_tooltipObj_iframe=document.createElement('<IFRAME frameborder="0" marginleft="0" margintop="0">');ajax_tooltipObj_iframe.style.position="absolute";ajax_tooltipObj_iframe.border="0";ajax_tooltipObj_iframe.frameborder=0;ajax_tooltipObj_iframe.style.backgroundColor="#FFF";ajax_tooltipObj_iframe.src="about:blank";a.appendChild(ajax_tooltipObj_iframe);ajax_tooltipObj_iframe.style.left="0px";ajax_tooltipObj_iframe.style.top="0px"}}ajax_tooltipObj.style.display="block";ajax_loadContent("ajax_tooltip_content",c);if(ajax_tooltip_MSIE){ajax_tooltipObj_iframe.style.width=ajax_tooltipObj.clientWidth+"px";ajax_tooltipObj_iframe.style.height=ajax_tooltipObj.clientHeight+"px"}ajax_positionTooltip(d)}function ajax_positionTooltip(a){var b=ajaxTooltip_getLeftPos(a)+a.offsetWidth,c=ajaxTooltip_getTopPos(a),d=document.getElementById("ajax_tooltip_content").offsetWidth+document.getElementById("ajax_tooltip_arrow").offsetWidth;ajax_tooltipObj.style.left=b+"px";ajax_tooltipObj.style.top=c+"px"}function ajax_hideTooltip(){ajax_tooltipObj.style.display="none"}function ajaxTooltip_getTopPos(a){var b=a.offsetTop;while((a=a.offsetParent)!=null)if(a.tagName!="HTML")b+=a.offsetTop;return b}function ajaxTooltip_getLeftPos(a){var b=a.offsetLeft;while((a=a.offsetParent)!=null)if(a.tagName!="HTML")b+=a.offsetLeft;return b}