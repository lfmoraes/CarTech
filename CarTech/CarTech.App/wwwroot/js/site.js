var modal = function () {
    var open = function (controller, id) {
        var url = "/" + controller + "/Create";
        var mdl = "#mdlCad" + controller;

        $.ajax({
            url: url,
            data: {
                id: id
            },
            success: function (result) {
                $("#contentBody").html(result);
                $(mdl).modal('show');
            }
        });
    }

    return {    
        open: open
    }
}()
