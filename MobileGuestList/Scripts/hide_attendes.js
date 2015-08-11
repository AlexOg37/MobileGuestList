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