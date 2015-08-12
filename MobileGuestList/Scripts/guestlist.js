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

//$(document).ready(function Hide() {
//    $('#myonoffswitch').change(function () {        
//        if ($(this).prop('checked'))
//            $('.selectbox input:checked').each(function () {
//                $(this).closest(".checkbox_row").fadeOut('slow');
//            });
//        else
//            $('.selectbox input:checked').each(function () {
//                $(this).closest(".checkbox_row").fadeIn('slow');
//            });
//    });
//});
$(document).ready(function () {
    $('#myonoffswitch').change(function () {
        ShowOrHide();
    });
    $('.selectbox input').change(function () {
        ShowOrHide();
        calculateChekboxesNum();
    });
    ShowOrHide();
    calculateChekboxesNum();
});

function ShowOrHide() {

    if ($('#myonoffswitch').prop('checked'))
        $('.selectbox input:checked').each(function () {
            $(this).closest(".checkbox_row").fadeOut('slow');
        });
    else
        $('.selectbox input:checked').each(function () {
            $(this).closest(".checkbox_row").fadeIn('slow');
        });

}
function calculateChekboxesNum() {
    var wrapper = document.getElementsByClassName("guests");
    var inputs = wrapper[0].getElementsByTagName("input");
    var cbs = [];
    var checked = [];
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox") {
            cbs.push(inputs[i]);
            if (inputs[i].checked) {
                checked.push(inputs[i]);
            }
        }
    }
    var total = cbs.length;
    var attended = checked.length;

    document.getElementById('nums').innerHTML = total;
    document.getElementById('checked_nums').innerHTML = attended;
}