function EditProfile() {
    $('#editProfileModal').modal('show');
}

$("#EditImagePath").on('change', function () {
    if (typeof (FileReader) != "undefined") {
        var size = parseFloat($("#EditImagePath")[0].files[0].size / (1024 * 1024)).toFixed(2);
        var ext = $('#EditImagePath').val().split('.').pop().toLowerCase();
        $('#errorValidation').text("");
        if ($.inArray(ext, ['png', 'jpg', 'jpeg']) != -1) {
            if (size <= 2) {
                var image_holder = $("#EditImageHolder");
                image_holder.empty();

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imagePreview').attr('src', e.target.result);
                }
                reader.readAsDataURL($(this)[0].files[0]);
            } else {
                $('#imagePreview').attr('src', '');
                $('#errorValidation').text("Image should not exceed 2MB!");
            }
        } else {
            $('#imagePreview').attr('src', '');
            $('#errorValidation').text("Invalid Image Format");
        }
    } else {
        $('#imagePreview').attr('src', '');
        $('#errorValidation').text("Something went wrong.");
    }
});

function CreateFriendRequest() {
    $.ajax({
        url: createFriendRequestURL,
        success: function (data) {
            location.reload();
        }
    });
}

function RespondToFriendRequest(ID, accept) {
    var data = {
        friendID : ID,
        accept : accept
    }
    $.ajax({
        url: respondToFriendRequestURL,
        data:data,
        success: function (data) {
            location.reload();
        }
    });
}
