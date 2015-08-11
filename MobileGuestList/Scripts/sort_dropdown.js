var defaultList = null;
$(document).ready(function () {
    defaultList = $("#contestSelect").html();
    $('#myonoffswitch').change(function () {
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

        }
        else {
            $("#contestSelect").html(defaultList);
        }
    });
});