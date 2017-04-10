$(document).ready(function () {
    $("#WordType").on("click", function () {
        var val = $('#Type').val();
        $.ajax({
            url: "/Exam/AllwordPartial",
            type: "GET",
            data: {type : val }
        })
        .done(function (partialViewResult) {
            $("#allword").html(partialViewResult);
        });
    });

    $("a").click(function () {
        url = this.id;
        window.location.href = url;
    });
});