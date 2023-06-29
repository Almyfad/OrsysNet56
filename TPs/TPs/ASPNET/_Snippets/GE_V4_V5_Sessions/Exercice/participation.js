$(function() {
    "use strict";
    $("input[data-idev]").click(participation);
});

function participation() {
    var idev = $(this).attr("data-idev");
    var idpa = $(this).attr("data-idpa");

    $.ajax({
        url: "/api/evenements/participation/" + idev + "/" + idpa,
        type: "POST",
        dataType: "text",
        contentType: 'application/x-www-form-urlencoded',
        success:
            function (data) {
                window.location.replace("/participants/details/" + idpa);
            },
        error: function (xhr, status, error) {
           $("#divMsg").text("Cette participation existe déjà !");
        }
    });
}