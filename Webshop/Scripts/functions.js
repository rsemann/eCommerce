"use strict";

function showModal(self, id) {
    $.ajax(
    {
        url: $(self).data("url") + "?id=" + id,
        type: "GET",
        cache: false,
        success: function (result) {
            var div = document.createElement("div");
            document.body.appendChild(div);
            $(div).html(result);
            $(div).modal("show");
        },
        error: function (error) {
            showalert(error.statusText, "alert-danger");
        }
    });
}

function showalert(message, type) {

    $("#showalert")
        .append('</br><div id="alert" class="alert ' +
            type +
            '"><a class="close" data-dismiss="alert">×</a><span>' +
            message +
            "</span></div>");

    setTimeout(function () {
        $("#alert").remove();
    },
        5000);
}