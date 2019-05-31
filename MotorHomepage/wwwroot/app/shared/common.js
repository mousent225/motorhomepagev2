var common = {
    configs: {
        pageSize: 10,
        pageIndex: 1
    },
    notify: function (feeownTitle, feeownMess, feeownStyle) {
        //STYLE:   smokey, gray, osx, simple    
        //OPTION: autoHide_bool, autoHideDelay_int_ms, classes_array, prepend_bool
        var title = feeownTitle;
        var message = feeownMess;
        var opts = {};
        opts.classes = [feeownStyle]; //style
        opts.prepend = false;
        opts.autoHide = true;
        opts.autoHideDelay = 6000;
        var container = '#freeow-tr';
        opts.classes.push("slide");
        opts.hideStyle = {
            opacity: 0,
            left: "400px"
        };
        opts.showStyle = {
            opacity: 1.5,
            left: 0
        };
        $(container).freeow(title, message, opts);
    },
    confirm: function (message, okCallback) {
        bootbox.confirm({
            message: message,
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result === true) {
                    okCallback();
                }
            }
        });
    },
    dateFormatJson: function (dateTime) {
        if (dateTime === null || dateTime === "")
            return "";
        var newDate = new Date(parseInt(datetime.substr(6)));
        var month = newDate.getMonth() + 1;
        var day = newDate.getDate();
        var year = newDate.getFullYear();

        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;

        return year + "." + month + "." + day;
    },
    dateTimeFormatJson: function (dateTime) {
        if (dateTime === null || dateTime === "")
            return "";
        var newDate = new Date(parseInt(dateTime.substr(6)));
        var month = newDate.getMonth() + 1;
        var day = newDate.getDate();
        var year = newDate.getFullYear();
        var hh = newDate.getHours();
        var mm = newDate.getMinutes();
        var ss = newDate.getSeconds();

        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        if (ss < 10)
            ss = "0" + ss;

        return year + "." + month + "." + day + " " + hh + ":" + mm + ":" + ss; 
    },
    startLoading: function () {
        if ($(".dv-loading").length > 0)
            $(".dv-loading").removeClass("hide");
    },
    stopLoading: function () {
        if ($(".dv-loading").length > 0)
            $(".dv-loading").addClass("hide");
    },
    getStatus: function (status) {
        if (status === 1)
            return "<span class='badge' style='background-color: #4caf50'>Active</span>";
        else
            return "<span class='badge' style='background-color: #f44336'>Block</span>";
    },
    formatNumber: function (number, precision) {
        if (!isFinite(number)) {
            return number.toString();
        }
        var a = number.toFixed(precision).split(".");
        a[0] = a[0].replace(/\d(?=(\d{3})+$)/g, "$&,");
        return a.join(".");
    },
    unflattern: function (arr) {
        var map = {};
        var roots = [];
        for (var i = 0; i < arr.length; i++) {
            var node = arr[i];
            node.children = [];
            map[node.id] = i; //use map to lookup the parents
            if (node.parentId !== null) {
                arr[map[node.parentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    }
}

$(document).ajaxSend(function (e, xhr, options) {
    if (options.type.toUpperCase() === "POST" || options.type.toUpperCase() === "PUT") {
        var token = $("form").find("input[name='__RequestVerificationToken']").val();
        xhr.setRequestHeader("RequestVerificationToken", token);
    }
});