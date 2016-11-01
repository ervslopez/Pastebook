
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

function EditEmail() {
    $('#errorMessage').text("");
    $('#editEmailModal').modal('show');
}

function EditPassword() {
    $('#editPassModal').modal('show');
}

function CheckEmailCredentials() {
    var oldPassword = $('#oldPassword').val();
    var email = email = $('#emailSU').val();

    if (email.length > 0 && /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$/.test(email)) {
        $('#errorMessage').text("");
        if (oldPassword.length > 0) {
            var data = {
                password: oldPassword
            }
            $.ajax({
                url: checkOldPasswordUrl,
                data: data,
                success: function (data) {
                    if (data.Status) {
                        updateEmailInfo()
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
    } else {
        $('#errorMessage').text("Invalid Email!");
    }
}

function updateEmailInfo() {
    var data = {
        email: $('#emailSU').val(),
        password: $('#oldPassword').val()
    }

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

function CheckPasswordCredentials() {
    var oldPassword = $('#oldPassword2').val();
    var newPass = $('#newPass').val();
    var confNewPass = $('#confNewPass').val();
    if (newPass.length > 0) {
        $('#errorNewPass').text(""); 
        if (confNewPass == newPass) {
            $('#errorConfPass').text(""); 
            if (oldPassword.length > 0) {
                $('#errorOldPass').text("");
                var data = {
                    password: oldPassword
                }
                $.ajax({
                    url: checkOldPasswordUrl,
                    data: data,
                    success: function (data) {
                        if (data.Status) {
                            updatePasswordInfo()
                        } else {
                            $('#errorOldPass').text("Old Password is incorrect");
                        }
                    },
                    error: function () {
                        $('#errorOldPass').text("Something went wrong");
                    }
                });

            } else {
                $('#errorOldPass').text("Old Password is a required field!");
            }
        }
        else {
            $('#errorConfPass').text("Confirm Password not matched");
        }
    } else {
        $('#errorNewPass').text("New Password is a required field");
        if (confNewPass.length == 0) {
            $('#errorConfPass').text("Confirm Password is a required field");
        }
        if (oldPassword.length == 0) {
            $('#errorOldPass').text("Old Password is a required field");
        }
    }
}

function updatePasswordInfo() {
    var data = {
        email: null,
        password: $('#newPass').val()
    }

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
