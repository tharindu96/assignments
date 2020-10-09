

function resizeCarouselImages() {
    var navbarHeight = $('#main-navbar').height();
    var windowHeight = $(window).height();

    var carouselHeight = windowHeight - navbarHeight;
    if (carouselHeight < 100)
        carouselHeight = 100;
    
    $('#main-carousel .carousel-inner .carousel-item img').css('height', carouselHeight);
}

$(document).ready(function() {
    resizeCarouselImages();
});

$(window).on('resize', function() {
    resizeCarouselImages();
});

$('#contact-form').submit(function(e){
    e.preventDefault();

    var name = $('#txtName').val().trim();
    var email = $('#txtEmail').val().trim();
    var phone = $('#txtPhone').val().trim();
    var msg = $('#txtMsg').val().trim();

    if (name.length == 0 || email.length == 0 || phone.length == 0 || msg.length == 0) {
        alert("Fill all fields!");
        return;
    }

    $.ajax({
        url: $('#contact-form').attr('action'),
        method: 'POST',
        data: {
            name: name,
            email: email,
            phone: phone,
            msg: msg
        },
        success: function(data) {
            if (data['status'] == 0) {
                $('#txtName').val("");
                $('#txtEmail').val("");
                $('#txtPhone').val("");
                $('#txtMsg').val("");
                alert("Message Received!");
            } else {
                alert("An error occured!");
            }
        }
    })

    return false;
});
