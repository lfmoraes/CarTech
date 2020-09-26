var categoria = function () {
    var open = function (id) {
        $.ajax({
            url: "/Categoria/Create",
            data: {
                id: id
            },
            success: function (result) {
                $("#contentBody").html(result);
                $("#mdlCadCategoria").modal('show');
            }
        });
    }

    return {    
        open: open
    }
}()