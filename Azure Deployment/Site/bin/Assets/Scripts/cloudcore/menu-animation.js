$(document).ready(function() {
  

	$("ul.nav > li > a.menu-item-active").click(function() {
		
		$(this).parent("li").toggleClass("active");
		
		$(".sub-menu-container").slideToggle(400);
		$(".hide-submenu").slideToggle(400);
		
		if($("body").hasClass("sub-menu-visible")) {
	
			$("body").animate({
				"padding-top": "50px"	
			},400).removeClass("sub-menu-visible");
	
		} else {
			
			$("body").animate({
				"padding-top": "100px"	
			},400).addClass("sub-menu-visible");
		}

		if($(".sidebar").hasClass("sidebar-down")) {
	
			$(".sidebar").animate({	
				"top": "45px"	
			},400).removeClass("sidebar-down");
	
		} else {
	
			$(".sidebar").animate({
				"top": "100px"	
			},400).addClass("sidebar-down");
		}
		
	});
	
	$(".hide-submenu").click(function(){
		
		$(".menu-item-active").parent("li").toggleClass("active");
		
		$(".sub-menu-container").slideToggle( 400);
		$(".hide-submenu").slideToggle(400);
		
		if($("body").hasClass("sub-menu-visible")) {
	
			$("body").animate({
				"padding-top": "50px"	
			},400).removeClass("sub-menu-visible");
	
		} else {
			
			$("body").animate({
				"padding-top": "100px"	
			},400).addClass("sub-menu-visible");
		}

		if($(".sidebar").hasClass("sidebar-down")) {
	
			$(".sidebar").animate({	
				"top": "45px"	
			},400).removeClass("sidebar-down");
	
		} else {
	
			$(".sidebar").animate({
				"top": "100px"	
			},400).addClass("sidebar-down");
		}
		
	});
	
	$("#menu-search").click(function() {
		$(".search-menu-input").toggleClass("hidden");
		
		$("input.search-menu-input").hideseek({
				nodata:         "Oops! We can't seem find the menu item you are looking for...",
				attribute:      "text",
				highlight:      true,
				navigation:     true,
				ignore_accents: true
			
		});
		
		$(".main").click(function() {
			
			if(!$(".search-menu-input").hasClass("hidden")) {
				 $(".search-menu-input").addClass("hidden");
			} 
				
		});
		
	});

});