function showNotif() {
    $("#notifDropdown").load(notifUrl);
}
function checkInput() {
    var input = $('#searchTxt').val().trim();
    if (input.length == 0) {
        $('#searchUserError').text('Invalid name to search for');
        $("#searchUserError").fadeTo(3000, 900).slideUp(900, function () {
            $("#searchUserError").slideUp(900);
        });
        
    } else {
        location.href = Url.Action("SearchUsers", "Pastebook", new {name : input});
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
