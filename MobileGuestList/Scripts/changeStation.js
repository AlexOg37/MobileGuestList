function changeStation() {
    var item = this;
    var actionUrl = $("#toggler").attr("data-action");
    $.post(actionUrl + '?stationId=' + $(item).attr('data-station-id'), function (result) {
        $("#contestSelect").html("");
        $("#contestSelect").append("<option selected='selected' value='' data-sort='no'>Pick Your Contest</option>");
        $(result).each(function (index, item) {
            var string1 = "<option value='" + item.Id + "' data-sort='yes'>" + item.Name + "</option>";
            $("#contestSelect").append(string1);
        });
        InitSorting();
    });
    $('#toggler').toggle("slow");
    $('#toggler div').show();
    $(item).hide();
    $('#station_call').text($(item).text());
}

$(document).ready(function () {
    $("#toggler>div").click(changeStation);
});
