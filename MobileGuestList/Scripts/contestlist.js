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