var cadastros = function () {
    var excluir = function (controller, id) {
        if (id != undefined && id != null) {

            Swal.fire({
                title: "Tem certeza?",
                text: "Você não poderá reverter esta ação!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#02a499",
                cancelButtonColor: "#ec4561",
                confirmButtonText: "Sim",
                cancelButtonText: "Não"
            }).then(function (result) {
                if (result.value) {
                    doDelete(controller, id);
                }
            });
        }
    }

    function doDelete(controller, id) {
        $.ajax({
            url: "/" + controller + "/Delete",
            type: "GET",
            datatype: 'json',
            data: {
                id: id
            },
            success: function (data) {
                if (data.success == true) {
                    Swal.fire("Excluído!", "Registro removido com sucesso.", "success")
                        .then(function (result) {
                            if (result.value) {
                                location.reload();
                            }
                        });
                }
            }
        });
    }

    return {
        excluir: excluir
    }
}()