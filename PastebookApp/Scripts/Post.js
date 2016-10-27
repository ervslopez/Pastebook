function newPost(ID) {
    var postString = $("#postTxt").val().trim();

    $('#publishPostError').text("");
    if (postString.length > 0) {
        var data = {
            profileOwner:ID,
            postString : postString
        }
        $.ajax({
            url: postUrl,
            data: data,
            success: function (data) {
                SuccessPost(data)
            },
            error: function () {
                $('#publishPostError').text("Something went wrong. Please try again");
            }
        });

        var SuccessPost = function(data){
            $("#postTxt").val("");
            $(".postsPage").load(reloadUrl);
        }

    } else {
        $('#publishPostError').text("Type in your post");
    }
}

function commentOnPost(ID) {
    var comment = $("#"+ID.toString()).val().trim();
    $("#commentOnPostError" + ID.toString()).text("");
  
    if (comment.length > 0) {
        var data = {
            postID: ID,
            comment: comment
        }
        $.ajax({
            url: commentOnPostURL,
            data: data,
            success: function (data) {
                SuccessPost(data)
            },
            error: function () {
                $('#commentOnPostError'+ID.toString()).text("Something went wrong. Please try again.");
            }
        });

        var SuccessPost = function (data) {
            $("#" + ID.toString()).val("");
            $(".postsPage").load(reloadUrl);
        }
    } else {
        $("#commentOnPostError" + ID.toString()).text("Type in your comment.");
    }
}

function likePost(ID){
    var data = {
        postID: ID
    }
    $.ajax({
        url: likePostURL,
        data: data,
        success: function (data) {
            SuccessPost(data)
        },
        error: function () {
            $('#commentOnPostError' + ID.toString()).text("Something went wrong. Please try again.");
        }
    });

    var SuccessPost = function (data) {
        $(".postsPage").load(reloadUrl);
    }
}

function postPreviewComment(ID) {
    var comment = $("#" + ID.toString()).val().trim();
    $("#commentOnPostError" + ID.toString()).text("");

    if (comment.length > 0) {
        var data = {
            postID: ID,
            comment: comment
        }
        $.ajax({
            url: commentOnPostURL,
            data: data,
            success: function (data) {
                SuccessPost(data)
            },
            error: function () {
                $('#commentOnPostError' + ID.toString()).text("Something went wrong. Please try again.");
            }
        });

        var SuccessPost = function (data) {
            $("#" + ID.toString()).val("");
            location.reload();
        }
    } else {
        $("#commentOnPostError" + ID.toString()).text("Type in your comment.");
    }
}

function postPreviewLike(ID) {
    var data = {
        postID: ID
    }
    $.ajax({
        url: likePostURL,
        data: data,
        success: function (data) {
            SuccessPost(data)
        },
        error: function () {
            $('#commentOnPostError' + ID.toString()).text("Something went wrong. Please try again.");
        }
    });

    var SuccessPost = function (data) {
        location.reload();
    }
}