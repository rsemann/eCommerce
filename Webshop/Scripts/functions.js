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
            showalert(error.statusText, "error");
        }
    });
}

function addCart(id, quantity) {
    if (quantity <= 0)
        showalert("Quantity must be 1 or more.", "warning");
    else {
        showalert("Article addded", "success");
        //$("#cartArticles").val($("#cartArticles").val() + 1);
        //$("#cartArticles").text($("#cartArticles").val() + 1);
    }
}


function showalert(message, type) {
    toastr[type](message);
    toastr.options = {
        "closeButton": true,
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