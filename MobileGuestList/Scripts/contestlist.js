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

function HideMenu(link) {
    $('body').toggleClass('navOpened');
    window.location.href = link;
}

function PositionFooter() {
    var headerHeight = $('header').height();
    var footerHeight = $('footer').height();
    var pathHeight = $('.path').height();
    var contHeight = $(window).height() - headerHeight - footerHeight - pathHeight;
    $('.content').css('min-height', contHeight);
    $('footer').css('opacity', 1);
}

$(document).ready(function () {
    PositionFooter();
    $(window).resize(function () {
        PositionFooter();
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
            $("#contestSelect").val(test);
        }
        else {
            $("#contestSelect").html(defaultList);
            $("#contestSelect").val(test);
        }
    });
});
