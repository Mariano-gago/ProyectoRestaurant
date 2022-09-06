$(document).ready(function () {

    const token = $('[id$=token]').val();


    $('#tableBebidas').DataTable({
        ajax: {
            url: 'https://localhost:44307/api/Bebidas/ObtenerBebidas',
            dataSrc: '',
            headers: { "Authorization": token }

        },
        columns: [
            { data: 'IdBebida', title: 'Id' },
            { data: 'NombreBebida', title: 'Nombre' },
            { data: 'PrecioBebida', title: 'Precio' },
            {
                data: 'Imagen',
                render: function (data) {
                    return '<img src="data:image/jpeg;base64,' + data + '"width="100px" heigth="100px" />';
                },
                title: 'Imagen'
            },
            { data: 'Stock', title: 'Stock' },
            {
                data: function (row) {
                    return row.ActivoBebida == true ? "Si" : "No";
                },
                title: 'Activo'
            },
            {
                data: function (row) {


                    var buttons =
                        `<td><a href='javascript:EditarBebida(${JSON.stringify(row)})'<i class="fa-solid fa-pen-to-square editarBebida"></td>` +
                        `<td><a href='javascript:EliminarBebida(${JSON.stringify(row.IdBebida)})'<i class="fa-solid fa-trash eliminarBebida"></td>`;

                    return buttons;

                },
                title: 'Acciones',
                ordenable: false,
                width: '0%'

            }
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
        }
    });
});


function EditarBebida(row) {
    $('#BebidasModal').modal();
    $('[id$=btnGuardar]').css('display', 'none');
    $('[id$=btnEditar]').css('display', '');

    $('[id$=idBebida]').val(row.IdBebida);
    $('[id$=NombreBebidaText]').val(row.NombreBebida);
    $('[id$=PrecioBebidaText]').val(row.PrecioBebida);
    $('[id$=StockBebidaText]').val(row.Stock);
    $('[id$=imagenEditar]').val(row.Imagen);
    $('[id$=ActivoBebidaCheck]').prop("checked", row.ActivoBebida);
}



function EliminarBebida(id) {

    $('#eliminarBebidasModal').modal();
    $('[id$=idBebida]').val(id);

}



$('#btnNuevoBebida').on('click', function () {
    clearBebidas();
    $('#BebidasModal').modal();
    $('[id$=btnGuardar]').css('display', '');
    $('[id$=btnEditar]').css('display', 'none');
})


function clearBebidas() {
    $('[id$=idBebida]').val("");
    $('[id$=NombreBebidaText]').val("");
    $('[id$=PrecioBebidaText]').val("");
    $('[id$=StockBebidasText]').val("");
    $('[id$=ImagenBebidaText]').val("");
    $('[id$=ActivoBebidaCheck]').prop("checked", false);
}
