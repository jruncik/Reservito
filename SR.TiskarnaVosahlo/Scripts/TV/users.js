function login(urlAction, username, password) {
    $.ajax({
        cache: false,
        type: "POST",
        async: false,
        url: urlAction
            + "/?username=" + username
            + "&password=" + password,
        dataType: "json",
        success: function (data) {
            if (data.result == "Redirect") {
                window.location.href = data.url;

            } else if (data.result == "Error") {
                alert(data.message);
            }
        }
    });
}

function logout(urlAction) {
    $.ajax({
        cache: false,
        type: "POST",
        async: false,
        url: urlAction,
        dataType: "json",
        success: function (data) {
            if (data.result == "Redirect") {
                window.location.href = data.url;

            } else if (data.result == "Error") {
                alert(data.message);
            }
        }
    });
}

function changeUrl(url) {
    window.location.href = url;
}

function getUserJsonDef(username, password, roles)
{
    var userDef = { "UserName": username, "Password": password, "Roles": roles };
    return JSON.stringify(userDef);
}

function getCheckboxValues(containerDiv, className)
{
    var containerDiv = document.getElementById(containerDiv);
    var innerDivs = containerDiv.getElementsByTagName("div");
    for (var i = 0; i < innerDivs.length; i++)
    {
        var innerDiv = innerDivs[i];
        if (innerDiv.className == '.checkbox') {
            alert(innerDiv.getElementsByTagName("label").getElementsByTagName("input").val);
        }
    }

    return "ahoj";
}

function addUser(urlAction, newUser) {
    $.ajax({
        cache: false,
        type: "POST",
        async: false,
        url: urlAction,
        dataType: "json",
        success: function (data) {
            if (data.result == "Redirect") {
                window.location.href = data.url;

            } else if (data.result == "Error") {
                alert(data.message);
            }
        }
    });
}

function checkPasswordMatch()
{
    var password = $("#password").val();
    var confirmPassword = $("#confirmPassword").val();
    var checkResultDiv = document.getElementById("checkResult");

    if (password != confirmPassword) {
        checkResultDiv.className="form-group has-feedback has-error";
    } else {
        checkResultDiv.className="form-group has-feedback has-success";
    }
}