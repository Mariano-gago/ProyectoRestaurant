$('#btnEntrada').on('click', function () {
    const token = $('[id$=token]').val();
    $('#table').DataTable({
        destroy: true,
        ajax: {
            url: 'https://localhost:44307/api/Entradas/ObtenerEntradas',
            dataSrc: '',
            headers: { "Authorization": token }
            
        },
        columns: [
            { data: 'IdEntrada', title: 'Id' },
            { data: 'NombreEntrada', title: 'Nombre' },
            { data: 'PrecioEntrada', title: 'Precio' },
            { data: 'ImagenEntrada', title: 'Imagen' },
            {
                data: function (row) {
                    return row.ActivoEntrada == true ? "Si" : "No";
                },
                title: 'Activo'
            },
            {
                data: function (row) {


                    var buttons =
                        `<td><a href='javascript:EditarEntrada(${JSON.stringify(row)})'<i class="fa-solid fa-pen-to-square editarEntrada"></td>` +
                        `<td><a href='javascript:EliminarEntrada(${JSON.stringify(row.IdEntrada)})'<i class="fa-solid fa-trash eliminarEntrada"></td>`;

                    return buttons;

                },
                title: 'Acciones',
                ordenable: false,
                width: '0%'

            }
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
        },
        
    }); 
    
});


function EditarEntrada(row) {
    $('#EntradasModal').modal();
    $('[id$=btnGuardar]').css('display', 'none');
    $('[id$=btnEditar]').css('display', '');

    $('[id$=idEntrada]').val(row.IdEntrada);
    $('[id$=NombreEntradaText]').val(row.NombreEntrada);    
    $('[id$=PrecioNumber]').val(row.PrecioEntrada);    
    $('[id$=ImagenEntrada]').val(row.ImagenEntrada);    
    $('[id$=ActivoEntradaCheck]').prop("checked", row.ActivoEntrada);
}



function EliminarEntrada(id) {

    $('#eliminarEntradasModal').modal();
    $('[id$=idEntrada]').val(id);

}



$('#btnNuevoEntrada').on('click', function () {
    clearEntradas();
    $('#EntradasModal').modal();
    $('[id$=btnGuardar]').css('display', '');
    $('[id$=btnEditar]').css('display', 'none');
})


function clearEntradas() {

    $('[id$=idEntrada]').val("");
    $('[id$=NombreEntradaText]').val("");
    $('[id$=PrecioNumber]').val("");
    $('[id$=ImagenEntrada]').val("");
    $('[id$=ActivoEntradaCheck]').prop("checked", false);
}







