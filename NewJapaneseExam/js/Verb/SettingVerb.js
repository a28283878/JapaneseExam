$("#send").click(function () {
    UpdateVerb();
});

function UpdateVerb() {
    $.ajax({
        type: "POST",
        url: "/Exam/UpdateVerb",
        data: { id: id ,chinese: $('#chinese').val(), japanese: $('#japanese').val() , note: $('#note').val()},
        datatype: "json",
        success: function (data) {
            $('#status').text("Succes");
        },
        error: function (xhr, statusText, errorThrown) {
            $('#status').text("Fail");
        }
    });
}