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