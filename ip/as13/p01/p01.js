var toggles = {};

function getBlockID(link) {
    var n = link;
    n = n.substr("#link-".length);
    n = "#block-" + n;
    return n;
}

$("a[href^='#link-']").on('click', function(e) {
    e.preventDefault();
    var n = $(this).attr('href');
    n = getBlockID(n);
    if (!(n in toggles)) {
        toggles[n] = false;
    }
    toggles[n] = !toggles[n];
    if (toggles[n]) {
        $(n).css('display', 'inline-block');
    } else {
        $(n).hide();
    }
});

$("a[href^='#link-']").on('mouseenter', function(e) {
    e.preventDefault();
    var n = $(this).attr('href');
    n = getBlockID(n);
    // $('.blocks').hide();
    $(n).css('display', 'inline-block');
});

$("a[href^='#link-']").on('mouseleave', function(e) {
    e.preventDefault();
    var n = $(this).attr('href');
    n = getBlockID(n);
    if (toggles[n])
        return;
    $(n).hide();
});