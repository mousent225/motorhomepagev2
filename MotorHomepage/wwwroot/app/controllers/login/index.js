var loginController = function () {

    this.initialize = function () {
        registerEvents();
    };

    var registerEvents = function () {

        $("#frmLogin").validate({
            errorClass: "red",
            ignore: [],
            lang: "en",
            rules: [
                username = {
                    required: true
                },
                password = {
                    required: true
                }
            ]
        });

        $("#btnLogin").on("click", function (e) {
            if ($("#frmLogin").valid()) {
                e.preventDefault();
                var user = $("#txtUserName").val();
                var pass = $("#txtPassword").val();
                login(user, pass);
            }
        });
    };

    var login = function (user, pass) {
        $.ajax({
            type: "POST",
            data: {
                UserName: user, Password: pass
            },
            dataType: "json",
            url: "/admin/login/authen",
            success: function (res) {
                if (res.Success) {
                    window.location.href = "/Admin/Home/Index";
                } else {
                    common.notify("Hyosung Motor", "PLease check your user name and password again!!!", "gray error");
                }
            }
        });
    };

};