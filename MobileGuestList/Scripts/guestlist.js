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

$('.checkbox_row').ready(function () {
    var i,
        rows = document.getElementsByClassName("checkbox_row"),
        total = rows.length;
    for (i = 0; i < total; i++) {
        if (rows[i].getElementsByTagName("input")[0].checked) {
            rows[i].className = rows[i].className + " highlight";
        }
    }
})

$(document).ready(function () {
    $('#myonoffswitch').change(function () {
        console.log('hello');
        if ($(this).prop('checked'))
            $('.selectbox input:checked').each(function () {
                $(this).closest(".checkbox_row").fadeOut('slow');
            });
        else
            $('.selectbox input:checked').each(function () {
                $(this).closest(".checkbox_row").fadeIn('slow');
            });
    });
});