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

function getArticles(pageIndex, pageCount) {
    $.ajax(
    {
        url: "./Article/Page" + "?pageindex=" + pageIndex + "&pageCount=" + pageCount,
        type: "GET",
        cache: false,
        success: function (result) {
            $("#articlesGrid > tbody").html(result);
            $("[id^=page-]").removeClass("btn-info").addClass("btn-default");
            $("#page-" + pageIndex).removeClass("btn-default").addClass("btn-info");
        },
        error: function (error) {
            showalert(error.statusText, "error");
        }
    });
}

function getOrders(pageIndex, pageCount) {
    $.ajax(
    {
        url: "./Order/Page" + "?pageindex=" + pageIndex + "&pageCount=" + pageCount,
        type: "GET",
        cache: false,
        success: function (result) {
            $("#ordersGrid > tbody").html(result);
            $("[id^=page-]").removeClass("btn-info").addClass("btn-default");
            $("#page-" + pageIndex).removeClass("btn-default").addClass("btn-info");
        },
        error: function (error) {
            showalert(error.statusText, "error");
        }
    });
}

function addCart(self, articleId, detail) {
    var quantity;
    if (detail)
        quantity = $("#article-detail-" + articleId).val();
    else
        quantity = $("#article-" + articleId).val();
    $.ajax(
    {
        url: $(self).data("url") + "?id=" + articleId + "&quantity=" + quantity,
        type: "GET",
        traditional: true,
        contentType: "application/json",
        cache: false,
        success: function (result) {
            showalert(result.Message, result.TypeMessage);
            totalCart();
        },
        error: function (error) {
            showalert(error.statusText, "error");
        }
    });
}

function removeCart(self, articleId) {
    $.ajax(
    {
        url: $(self).data("url") + "?id=" + articleId,
        type: "GET",
        traditional: true,
        contentType: "application/json",
        cache: false,
        success: function (result) {
            showalert("Article removed!", "success");
            $("#articlesCart > tbody").html(result);
            totalCart();
        },
        error: function (error) {
            showalert(error.statusText, "error");
        }
    });
}


function totalCart() {
    $.ajax(
    {
        url: "./../Cart/TotalArticlesCart",
        type: "GET",
        cache: false,
        success: function (result) {
            $("#cartArticles").html(result);
        },
        error: function (error) {
            showalert(error.statusText, "error");
        }
    });
}

function showalert(message, type) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
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
    toastr[type](message);
}

totalCart();