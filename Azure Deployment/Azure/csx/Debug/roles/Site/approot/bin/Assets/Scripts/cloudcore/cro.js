$(document).ready(function(e) {
	var maxWidth = Math.max.apply( null, $( '.cro > div' ).map( function () {
			return $( this ).outerWidth( true );
	}).get() );
	
	$('.cro > div').css('width', maxWidth);
});