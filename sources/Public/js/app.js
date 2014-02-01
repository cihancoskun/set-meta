var textBtnDanger = "btn-danger";
var textBtnWarning = "btn-warning";
var textBtnSuccess = "btn-success";
var textId = "id";
var textIsActive = "isactive";

$(function () {
    $("button.btnAction").click(function () {
        var textBtn = "button#btnModalAction";

        var id = $(this).data(textId);
        var isActive = $(this).data(textIsActive);

        $(textBtn).data(textId, id).data(textIsActive, isActive);
    });

    $("button#btnSaveFeedback").click(function () {
        console.log('asd');
        var info = $("textarea#Feedback").val();
        console.log(info);
        if (info.length < 1) { $("textarea#Feedback").parent().append('<label class="error">*</label>'); return; }

        var email = $("input#FeedBackEmail").val();
        $("div#wrnFeedback").html('');

        
        console.log(email);

        $.ajax({
            url: "/Feedback/New",
            type: "GET",
            data: "info=" + info + "&email=" + email,
            success: function (r) {
                if (r && r.IsOk) {
                    $("#modalFeedback").modal('hide');
                } else {
                    $("div#wrnFeedback").append('<div class="alert alert-warning alert-dismissable">' +
                        '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' +
                        '<strong>Ups! </strong> ' + r.Msg + '</div>');
                }
            }
        });
    });

    $('#modalFeedback').on('hidden.bs.modal', function () { $("div#wrnFeedback").html(''); $("textarea#Feedback").val(''); $("label.error").remove(); });
});