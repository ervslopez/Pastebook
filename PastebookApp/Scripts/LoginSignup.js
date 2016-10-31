
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

    if (email.length > 0) {
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

function CheckPasswordCredentials() {
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
                    updatePasswordInfo()
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

function updatePasswordInfo() {
    var data = {
        email: $('#emailSU').val(),
        password: $('#newPass').val()
    }

    if ($('#newPass').val() == $('#confNewPass').val()) {
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
    else {
        $('#errorMessage2').text("Passwords do not match");
    }
}

//function checkEmailForm() {
//    $("form[name='emailEdit']").validate({
//        // Specify validation rules
//        rules: {
//            // The key name on the left side is the name attribute
//            // of an input field. Validation rules are defined
//            // on the right side
//            email: "required",
//            oldPassword: "required",
//            email: {
//                required: true,
//                email: true
//            },
//            oldPassword: {
//                required: true,
//                minlength: 8
//            }
//        },
//        // Specify validation error messages
//        messages: {
//            password: {
//                required: "Confirm Password field is Required",
//                minlength: "Less than 30 characters only"
//            },
//            email: "Please enter a valid email address"
//        },
//        // Make sure the form is submitted to the destination defined
//        // in the "action" attribute of the form when valid
//        submitHandler: function (form) {
//            return 
//        }
//    });
//}