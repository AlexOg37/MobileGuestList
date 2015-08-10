$('.guests input').change(function () {

    if ($(this).prop("checked")) {

        $(this).closest(".checkbox_row").addClass("highlight");
    }
    else {

        $(this).closest(".checkbox_row").removeClass("highlight");
    }
});
