$(".send").click(function (event) {
    var id = event.target.id;
    var correct_answer = $(this).data('value');
    var wrongpoint = $(this).data('wrong');
    var user_answer = $('#japanese' + id).val();

    var correct_sign = $('#correct' + id);
    var wrong_sign = $('#wrong' + id);

    if (correct_answer == user_answer) {
        wrong_sign.removeClass("wrong");
        wrong_sign.addClass("ready");
        correct_sign.removeClass("ready");
        correct_sign.addClass("correct");
        if (wrongpoint > 0) {
            $.ajax({
                type: "POST",
                url: "/Exam/AddorMinusChineseToJapaneseWrongPoint",
                data: { id : id,point: -1 },
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
            url: "/Exam/AddorMinusChineseToJapaneseWrongPoint",
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