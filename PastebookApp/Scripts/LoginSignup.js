
function Login() {
    var data = {
        email: $('#loginEmail').val(),
        password: $('#loginPassword').val()
    }
    $.ajax({
        url: LoginAccountUrl,
        data: data,
        success: function (data) {
            SuccessPost(data)
        },
        error: function () {
            $('#loginPasswordError').text('An error occurred');
        }
    });
    var SuccessPost = function (data) {
        if (data.Status) {
            window.location.href = HomeUrl;
        }
        else {
            $('#loginPasswordError').text('Invalid Email or Password');
        }
    }
}

$('#txtConfirmPass').on('blur', function () {
    
    var pass = $("#txtPass").val();
    var conPass = $("#txtConfirmPass").val();

    if (pass != conPass) {
        $('#validationConPass2').text('');
        $('#validationConPass').text('Passwords do not match');
    } else {
        $('#validationConPass2').text('Passwords match!');
        $('#validationConPass').text('');
    }
});

function EditEmailPassword() {
    $('#editEmailPassModal').modal('show');
}

function CheckCredentials() {
    var oldPassword = $('#oldPassword').val();

    if (oldPassword.length > 0) {
        var data = {
            password: oldPassword
        }
        $.ajax({
            url: checkOldPasswordUrl,
            data: data,
            success: function (data) {
                if (data.Status) {
                    updateInfo()()
                } else {
                    $('#errorMessage').text("Password is incorrect");
                }
            },
            error: function () {
                $('#errorMessage').text("Something went wrong");
            }
        });

    } else {
        $('#errorMessage').text("Old password is a required field!");
    }
}

function updateInfo() {
    var data = {
        email: $('#emailSU').val(),
        password: $('#newPass').val()
        }

if ($('#newPass').val() == $('#confNewPass').val())
{
    $.ajax({
        url: EditAccountInfoUrl,
        data: data,
        success: function (data) {
            location.reload();
        },
        error: function () {
            $('#errorMessage').text("Something went wrong");
        }
    });
}
else
{
    $('#errorMessage2').text("Passwords do not match");
}
}