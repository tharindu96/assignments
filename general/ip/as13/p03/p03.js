$('.image').on('mouseenter', function() {
    $('.image').animate({
        width: "50%",
        'margin-left': "300px",
    }, 3000);
});

$('.image').on('mouseleave', function() {
    $('.image').animate({
        width: "20%",
        'margin-left': "0",
    }, 3000);
});