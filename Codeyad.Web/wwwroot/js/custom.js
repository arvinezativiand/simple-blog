﻿$(document).ready(function () {
    LoadCkEditor4();
    $.ajax({
        url: "/index/PopularPost",
        type: "get"
    }).done(function (data) {
        $("#popular_post").html(data);
    });
});
function LoadCkEditor4() {
    if (!document.getElementById("ckEditor4"))
        return;

    $("body").append("<script src='/ckeditor4/ckeditor/ckeditor.js'></script>");

    CKEDITOR.replace('ckEditor4',
        {
            customConfig: '/ckeditor4/ckeditor/config.js'
        })
};

function changePage(pageId) {
    var url = new URL(window.location.href);
    var search_params = url.searchParams;

    search_params.set("pageId", pageId);
    url.search = search_params.toString();

    var new_url = url.toString();

    window.location.replace(new_url);
}

