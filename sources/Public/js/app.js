$(function () {
    $("button#btnSaveFeedback").click(function () {
        var info = $("textarea#txtFeedback").val();
        if (info.length < 1) return;

        var email = $("input#feedbackEmail").val();
        $("div#wrnFeedback").html('');

        $.ajax({
            url: "/Feedback/New",
            type: "GET",
            data: "info=" + info + "&email=" + email,
            success: function (r) {

                console.log(r);

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