// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
    new bootstrap.Tab($('#Tabs button[data-bs-target="#' + tabName + '"]')).show();
    $("#Tabs button").click(function () {
        $("[id*=TabName]").val($(this).attr("data-bs-target").replace("#", ""));
    });
});