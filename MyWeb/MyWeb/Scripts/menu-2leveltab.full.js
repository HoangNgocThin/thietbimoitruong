var mastertabvar=new Object()
mastertabvar.baseopacity=0
mastertabvar.browserdetect=""
 
function showsubmenu(masterid, id){	
	if (typeof highlighting!="undefined")
	clearInterval(highlighting)
	submenuobject=document.getElementById(id)
	if(submenuobject.filters)
	mastertabvar.browserdetect=submenuobject.filters? "ie" : typeof submenuobject.style.MozOpacity=="string"? "mozilla" : ""
	hidesubmenus(mastertabvar[masterid],submenuobject)
	//submenuobject.style.display="block"
	instantset(mastertabvar.baseopacity)
	highlighting=setInterval("gradualfade(submenuobject)",50)
}

function callhidesubmenu(masterid){
	if (typeof highlighting!="undefined")
	clearInterval(highlighting)
	var submenuarray=mastertabvar[masterid]
	if(submenuarray!=null){
 		for (var i=0; i<submenuarray.length; i++){
	        document.getElementById(submenuarray[i]).style.display="none";
     	}
 	}
}

function callhideAllDiv(tabid){
	var divitems=document.getElementById(tabid).getElementsByTagName("div");
    if(divitems!=null && divitems.length>0){
	    for (var i=0; i<divitems.length; i++){
	    	if (divitems[i].parentNode.className=="menu_div1"){
				 divitems[i].parentNode.className="menu_div3";
            }
			if (divitems[i].className=="menu_div2"){
				 divitems[i].className="menu_div4";
            }
         }
    }
}

function hidesubmenus(submenuarray,obj){
	if(submenuarray!=null){
 		for (var i=0; i<submenuarray.length; i++){
			var _obj=document.getElementById(submenuarray[i]);
           	if(obj!=_obj){
            	_obj.style.display="none";
           	}
           	else if(obj.style.display!="block"){
              obj.style.display="block";
           	}
       	}
    }
}

function instantset(degree){
    if (mastertabvar.browserdetect=="mozilla")
    submenuobject.style.MozOpacity=degree/100
    //else if (mastertabvar.browserdetect=="ie")
    //submenuobject.filters.alpha.opacity=degree
}

function gradualfade(cur2){
	if (mastertabvar.browserdetect=="mozilla" && cur2.style.MozOpacity<1)
		cur2.style.MozOpacity=Math.min(parseFloat(cur2.style.MozOpacity)+0.1, 0.99)
	//else if (mastertabvar.browserdetect=="ie" && cur2.filters.alpha.opacity<100)
	//cur2.filters.alpha.opacity+=10
	else if (typeof highlighting!="undefined") //fading animation over
		clearInterval(highlighting)
}

function initalizetab(tabid){
	mastertabvar[tabid]=new Array()
    var menuitems=document.getElementById(tabid).getElementsByTagName("div");
	var submenuitems=document.getElementById("submenu").getElementsByTagName("div");
	if(menuitems!=null && menuitems.length>0){		
		//set class for menu
		for (var i=0; i<menuitems.length; i++){
			menuitems[i].parentNode.className="menu_div3";
			menuitems[i].className="menu_div4";
		}
		//set class for submenu
		for (var i=0; i<submenuitems.length; i++){
			submenuitems[i].className="submenu";
			if (i<2){submenuitems[i].className="submenu left";}
			if (i>4){submenuitems[i].className="submenu right";}
		}
			  
        for (var i=0; i<menuitems.length; i++){
			if (menuitems[i].getAttribute("rel")){
                menuitems[i].setAttribute("rev", tabid) //associate this submenu with main tab
                mastertabvar[tabid][mastertabvar[tabid].length]=menuitems[i].getAttribute("rel") //store ids of submenus of tab menu
				if(menuitems[i].getAttribute("cur")){
					callhideAllDiv(tabid);
					menuitems[i].parentNode.className="menu_div1";
					menuitems[i].className="menu_div2";
					showsubmenu(tabid, menuitems[i].getAttribute("rel"))
				}
				//Set thuoc thinh onmouseover
                menuitems[i].getElementsByTagName("a")[0].onmouseover=function(){
					callhideAllDiv(tabid);
                    this.parentNode.parentNode.className="menu_div1";
					this.parentNode.className="menu_div2";
					showsubmenu(this.parentNode.getAttribute("rev"),this.parentNode.getAttribute("rel"))
				}
			}
		}   
	}
}



