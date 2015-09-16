    /*constructor for ContestList*/
ContestList = function (settings) {
}
function AlertSorry() {
    alert('Sorry, there are no listeners on this guest list');
}
    function Alert() {
        alert('You must first select a contest');
    }
function OnCurrentContestChanged() {
    var id = $('#contestSelect').val();
    $.ajax({
        url: UpdateContestSelectionAction,
        type: 'POST',
        data: JSON.stringify({
            contestId: id
        }),
        contentType: 'application/json'
    });
}

$(document).click(function (event) {
    if ($(event.target).closest("#toggler").length)
        return;
    $("#toggler").slideUp("slow");
    event.stopPropagation();
});
$('#toggle-link').click(function () {
    $(this).siblings("#toggler").slideToggle("slow");
    return false;
});

function InitSorting() {
    defaultList = $("#contestSelect").html();
    $('#myonoffswitch').change(function () {
        var test = $("#contestSelect").val();

        if ($(this).prop("checked")) {
            var my_options = $("#contestSelect option");
            var sortData = my_options.filter('[data-sort="yes"]');

            sortData.sort(function (a, b) {

                if (a.text > b.text) return 1;
                else if (a.text < b.text) return -1;
                else return 0
            });
            var noSortData = my_options.filter('[data-sort="no"]');
            $("#contestSelect").empty().append(noSortData).append(sortData);

            $("#contestSelect").val(test);
        }
        else {
            $("#contestSelect").html(defaultList);
            $("#contestSelect").val(test);

        }
    });
}

var navRight, mainRight;

function PosFooter() {
    var headerHeight = $('header').height();
    var footerHeight = $('footer').height();
    var pathHeight = $('.path').height();
    var contHeight = $(window).height() - headerHeight - footerHeight - pathHeight;
    $('.content').css('min-height', contHeight);
}

//function Resize() {
//    var $nav = $('#navigation');
//    var $main = $('#main');

//    $main.css("right", "0px");
//    $nav.css("right", "");
   
//    var navOpenedClass = 'opened',
//      slideValue = !$nav.hasClass(navOpenedClass) ? '-=' + $nav.outerWidth() : '+=' + $nav.outerWidth();     
//    if ($nav.hasClass(navOpenedClass)) {
//        $nav.css('right', '0px');
//        $main.css({
//            right: slideValue
//        });
//    }
//}
$(document).ready(function () {
    PosFooter();
    $(window).resize(function () {
        PosFooter();
    });

    var defaultList = null;
    defaultList = $("#contestSelect").html();
    $('#myonoffswitch').change(function () {
        var test = $("#contestSelect").val();

        if ($(this).prop("checked")) {
            var my_options = $("#contestSelect option");
            var sortData = my_options.filter('[data-sort="yes"]');

            sortData.sort(function (a, b) {

                if (a.text > b.text) return 1;
                else if (a.text < b.text) return -1;
                else return 0
            });
            var noSortData = my_options.filter('[data-sort="no"]');
            $("#contestSelect").empty().append(noSortData).append(sortData);

            //$("#contestSelect [value='" + test + "']").attr("selected", "selected");
            $("#contestSelect").val(test);
        }
        else {
            $("#contestSelect").html(defaultList);
            $("#contestSelect").val(test);

        }
    });
});
