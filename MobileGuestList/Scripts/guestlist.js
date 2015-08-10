$('.guests input').change(function () {
    var id = $(this).closest(".checkbox_row").children('.contWinId').text();
    if ($(this).prop("checked")) {
        ChangeGuestState(id, true);
        $(this).closest(".checkbox_row").addClass("highlight");
    }
    else {
        ChangeGuestState(id, false);
        $(this).closest(".checkbox_row").removeClass("highlight");
    }
});

function ChangeGuestState(id, doMark) {
    debugger;
    $.ajax({
        url: '/Guest/UpdateGuestState',
        type: 'POST',
        data: JSON.stringify({
            contWinId: id,
            bMark: doMark
        }),
        contentType: 'application/json'
    });
}