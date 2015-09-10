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
$(function () {
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

            //$("#contestSelect [value='" + test + "']").attr("selected", "selected");
            $("#contestSelect").val(test);
        }
        else {
            $("#contestSelect").html(defaultList);
            $("#contestSelect").val(test);

        }
    });
}
function Resize() {
    var headerHeight = $('header').height();
    var footerHeight = $('footer').height();
    var pathHeight = $('.path').height();
    var contHeight = $(window).height() - headerHeight - footerHeight - pathHeight;
    $('.content').css('min-height', contHeight);
}
$(document).ready(function () {
    Resize();
    $(window).resize(function () {
        Resize();
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