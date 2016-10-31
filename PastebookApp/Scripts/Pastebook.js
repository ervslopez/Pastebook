function showNotif() {
    $("#notifDropdown").load(notifUrl);
}
function checkInput() {
    var input = $('#searchTxt').val();
    if (input.length <= 0) {
        $('#searchUserError').text('Invalid name to search for');
    }
}
function showBadge() {
    $.ajax({
        url: notifCountURL,
        data: null,
        success: function (data) {
            SuccessPost(data)
        }
    });

    var SuccessPost = function (data) {
        if (data.Status > 0) {
            $("#notifBadge").text(data.Status);
        }
    }
}
