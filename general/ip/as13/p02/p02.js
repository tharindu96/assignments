var slideCount = 3;
var slide = 0;

function updateHeights() {
    var height = $(window).height();
    
    $('.images').css('height', height);
}

function runSlide() {
    i = slide;
    var j = (i + 1) % slideCount;
    $('.images:nth-of-type('+(i+1)+')').fadeOut("slow", function() {
        $('.images:nth-of-type('+(j+1)+')').fadeIn("slow");
    });
    slide = j;
}

function runSlideShow() {
    setInterval(runSlide, 5000);
}

$(document).ready(function(e) {
    updateHeights();
    runSlideShow();
});

$(window).on('resize', function() {
    updateHeights();
});