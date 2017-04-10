$("#send").click(function () {
    var type = $('#Type').val();
    SendNewWord(type);
});

$(document).keypress(function (e) {
    if (e.which == 13) {
        if ($('#chinese').val().length != 0 && $('#japanese').val().length != 0) {
            var type = $('#Type').val();
            SendNewWord(type);
            $('#japanese').focus();
        }
    }
});

function SendNewWord(type) {
    $.ajax({
        type: "POST",
        url: "/Exam/Send",
        data: { chinese: $('#chinese').val(), japanese: $('#japanese').val() ,type: type},
        datatype: "json",
        success: function (data) {
            $('#chinese').val("");
            $('#japanese').val("");
            $('#status').text("Success");
        },
        error: function (xhr, statusText, errorThrown) {
            $('#status').text("Duplicated");
        }
    });
}