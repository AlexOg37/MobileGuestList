/*constructor for ContestList*/
ContestList = function (settings) {
}

function OnCurrentContestChanged() {
    var id = $('#contestSelect').val();
    $.ajax({
        url: '/Contest/UpdateContestSelection',
        type: 'POST',
        data: JSON.stringify({
            contestId: id
        }),
        contentType: 'application/json'
    });
}

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
$(document).ready(function () {
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