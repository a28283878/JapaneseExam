$(document).ready(function () {
    msg = new SpeechSynthesisUtterance();
    var voices = speechSynthesis.getVoices(); //It needs to call getVoices() once.
});

$(".voice").click(function (event) {
    var japanese = $(this).data("word");
    msg.voice = speechSynthesis.getVoices().filter(function (voice) { return voice.name === "Google 日本語"; })[0];
    msg.volume = 1;
    msg.rate = 0.9;
    msg.pitch = 1;
    msg.lang = "ja-JP";
    msg.text = japanese;
    speechSynthesis.speak(msg);
})

$(".send").click(function (event) {
    var id = event.target.id;
    var correct_answer = $(this).data('value');
    var wrongpoint = $(this).data('wrong');
    var user_answer = $('#chinese' + id).val();

    var correct_sign = $('#correct' + id);
    var wrong_sign = $('#wrong' + id);

    if (correct_answer.indexOf(user_answer) !== -1) {
        wrong_sign.removeClass("wrong");
        wrong_sign.addClass("ready");
        correct_sign.removeClass("ready");
        correct_sign.addClass("correct");
        if (wrongpoint > 0) {
            $.ajax({
                type: "POST",
                url: "/Exam/AddorMinusVoiceToChineseWrongPoint",
                data: { id: id, point: -1 },
                datatype: "json",
                success: function (data) {
                },
                error: function (xhr, statusText, errorThrown) {

                }
            });
        }
    }
    else {
        $(".sweet-alert").remove();
        correct_sign.removeClass("correct");
        correct_sign.addClass("ready");
        wrong_sign.removeClass("ready");
        wrong_sign.addClass("wrong");
        $.ajax({
            type: "POST",
            url: "/Exam/AddorMinusVoiceToChineseWrongPoint",
            data: { id: id, point: 2 },
            datatype: "json",
            success: function (data) {
                swal({ title: "残念です～", timer: 500, showConfirmButton: false });
            },
            error: function (xhr, statusText, errorThrown) {

            }
        });
    }
});