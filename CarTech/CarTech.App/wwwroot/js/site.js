// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    if (window.location.href.indexOf('categoria') != 0) {
        var baseCategorias = 'https://localhost:44378/api/categorias'

        $('#datatable').DataTable({
            serverSide: true,
            crossDomain: true,
            ajax: baseCategorias
        });
    }
});
