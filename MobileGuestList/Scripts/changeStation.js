function changeStation(item) {
    $.post('/Home/ChangeStation?stationId=' + $(item).attr('data-station-id'), function (result) {
        $("#contestSelect").html("");
        $("#contestSelect").append("<option selected='selected' value='' data-sort='no'>Pick Your Contest</option>");
        $(result).each(function (index, item) {
            var string1 = "<option value='" + item.Id + "' data-sort='yes'>" + item.Name + "</option>";
            $("#contestSelect").append(string1);
        });
        InitSorting();
    });
    $('#toggler').toggle("slow");

    $('#station_call').text($(item).text());

}