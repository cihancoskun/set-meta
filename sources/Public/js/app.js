$(function () {
    $("input#btnSaveFeedback").click(function (x) {
        var info = $("textarea#txtFeedback").val();
        if (info.length < 1) return;

        var email = $("input#feedbackEmail").val();
        $("div#wrnFeedback").html('');

        $.ajax({
            url: "/Feedback/New",
            type: "POST",
            data: "info=" + info + "&email=" + email + "&__RequestVerificationToken=" + $('input[name="__RequestVerificationToken"]').val(),
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

    $('#modalFeedback').on('hidden.bs.modal', function () { $("div#wrnFeedback").html(''); $("textarea#txtFeedback").val(''); });
});