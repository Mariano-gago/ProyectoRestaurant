$(document).ready(function () {

    const token = $('[id$=token]').val();


    $('#tableRoles').DataTable({
        ajax: {
            url: 'https://localhost:44307/api/Roles/ObtenerRoles',
            dataSrc: '',
            headers: { "Authorization": token }

        },
        columns: [
            { data: 'IdRol', title: 'Id' },
            { data: 'NombreRol', title: 'Nombre' },
            {
                data: function (row) {
                    return row.Activo == true ? "Si" : "No";
                },
                title: 'Activo'
            },                              
            {
                data: function (row) {


                    var buttons =
                        `<td><a href='javascript:EditarRol(${JSON.stringify(row)})'<i class="fa-solid fa-pen-to-square editarRol"></td>` +
                        `<td><a href='javascript:EliminarRol(${JSON.stringify(row.IdRol)})'<i class="fa-solid fa-trash eliminarRol"></td>`;

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


function EditarRol(row) {
    $('#RolesModal').modal();
    $('[id$=btnGuardar]').css('display', 'none');
    $('[id$=btnEditar]').css('display', '');

    $('[id$=idRol]').val(row.IdRol);
    $('[id$=NombreText]').val(row.NombreRol);    
    $('[id$=ActivoRolCheck]').prop("checked", row.Activo);
}



function EliminarRol(id) {

    $('#eliminarRolesModal').modal();
    $('[id$=idRol]').val(id);

}



$('#btnNuevoRol').on('click', function () {
    clearRoles();
    $('#RolesModal').modal();
    $('[id$=btnGuardar]').css('display', '');
    $('[id$=btnEditar]').css('display', 'none');
})


function clearRoles() {

    $('[id$=idRol]').val("");
    $('[id$=NombreText]').val("");
    $('[id$=ActivoRolCheck]').prop("checked", false);
}







