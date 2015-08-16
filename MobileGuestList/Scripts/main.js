$(function () {
    // Menu button - Navigation slide toggle
    $('#main header .menu-button').on('click', function () {
        var $nav = $('#navigation'),
            $main = $('#main'),
            navOpenedClass = 'opened',
            slideValue = $nav.hasClass(navOpenedClass) ? '-=' + $nav.outerWidth() : '+=' + $nav.outerWidth();
        $main.finish().animate({
            right: slideValue
        });
        $nav.finish().animate({
            right: slideValue
        }, function () {
            $nav.toggleClass(navOpenedClass);
        });
    });
});
