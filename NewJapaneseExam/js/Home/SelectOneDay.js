$(".send").click(function () {
    var Date = $('#date').val();
    SendSelectDay(Date);
});

function SendSelectDay(Date) {
    var exam = GetExam();
    if (Date != "") {
        if (exam == "1") {
            var url = "/Exam/SelectOneDayRandom?date=" + Date + "&type=" + GetType();
            window.location.href = url;
        }
        else if (exam == "2") {
            var url = "/Exam/VoiceToChineseSelectOneDayRandom?date=" + Date + "&type=" + GetType();
            window.location.href = url;
        }
    }
}

$("#todayrandom").click(function () {
    var exam = GetExam();
    if (exam == "1") {
        var url = "/exam/todayrandom?type=" + GetType();
        window.location.href = url;
    }
    else if (exam == "2") {
        var url = "/exam/VoiceToChinesetodayrandom?type=" + GetType();
        window.location.href = url;
    }
});

$("#allrandom").click(function () {
    var exam = GetExam();
    if (exam == "1") {
        var url = "/exam/allrandom?type=" + GetType();
        window.location.href = url;
    }
    else if (exam == "2") {
        var url = "/exam/VoiceToChineseallrandom?type=" + GetType();
        window.location.href = url;
    }
});

$('#wordwrong').click(function () {
    var exam = GetExam();
    if (exam == "1") {
        var url = "/exam/ChineseToJapaneseWordWrong?type=" + GetType();
        window.location.href = url;
    }
    else if (exam == "2") {
        var url = "/exam/VoiceToChineseallWordWrong?type=" + GetType();
        window.location.href = url;
    }
});

$('#numberrandom').click(function () {
    var exam = GetExam();
    var num = $("#number").val();
    if (exam == "1") {
        var url = "/Exam/GetWordByTypeAndNumber?type=" + GetType() + "&number=" + num;
        window.location.href = url;
    }
    else if (exam == "2") {
        var url = "/Exam/VoiceToChineseGetWordByTypeAndNumber?type=" + GetType() + "&number=" + num;
        window.location.href = url;
    }
});

function GetType() {
    return type = $('#Type').val();
}

function GetExam() {
    return exam = $('#Exam').val();
}