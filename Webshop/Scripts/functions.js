"use strict";

function showModal(self, id) {
    $.ajax(
    {
        url: $(self).data("url") + "?id=" + id,
        type: "GET",
        cache: false,
        success: function (result) {
            showalert("oi", "error");
            var div = document.createElement("div");
            document.body.appendChild(div);
            $(div).html(result);
            $(div).modal("show");
        },
        error: function (error) {
            showalert(error.statusText, "error");
        }
    });
}

function addCart(self, id) {
    showalert("Article addded", "success");
}


function showalert(message, type) {
    toastr[type](message);
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

$(".nextPage").click(function (evt) {
    var pageindex = $(evt.target).data("pageindex");
    $("#pageIndex").val(pageindex);
    evt.preventDefault();
    $("form").submit();
});