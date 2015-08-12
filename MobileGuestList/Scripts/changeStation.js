function changeStation() {
    console.log("test");
    var Id = $('#stationSelect').val();
    console.log("test1");

    $.ajax({
        url: '/Home/ChangeStation?stationId=' + Id,
        type: 'POST',
        async: false,
    })

    location.reload();

}