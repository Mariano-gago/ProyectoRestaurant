$(document).ready(function () {

    const token = $('[id$=token]').val();


    $('#tableEmpleados').DataTable({
        ajax: {
            url: 'https://localhost:44307/api/Empleados/ObtenerEmpleados',
            dataSrc: '',
            headers: { "Authorization": token }

        },
        columns: [
            { data: 'IdEmpleado', title: 'Id' },
            { data: 'NombreEmpleado', title: 'Nombre' },
            { data: 'ApellidoEmpleado', title: 'Apellido' },
            { data: 'Mail', title: 'Mail' },
            {
                data: function (row) {
                    return row.Activo == true ? "Si" : "No";
                },
                title: 'Activo'
            },
            { data: 'Roles.NombreRol', title: 'Rol' },                              
            {
                data: function (row) {


                    var buttons =
                        `<td><a href='javascript:EditarEmpleado(${JSON.stringify(row)})'<i class="fa-solid fa-pen-to-square editarUsuario"></td>` +
                        `<td><a href='javascript:EliminarEmpleado(${JSON.stringify(row.IdEmpleado)})'<i class="fa-solid fa-trash eliminarUsuario"></td>`;

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


function EditarEmpleado(row) {
    $('#empleadosModal').modal();
    $('[id$=btnGuardar]').css('display', 'none');
    $('[id$=btnEditar]').css('display', '');

    $('[id$=idEmpleado]').val(row.IdEmpleado);
    $('[id$=NombreText]').val(row.NombreEmpleado);
    $('[id$=ApellidoText]').val(row.ApellidoEmpleado)
    $('[id$=MailText]').val(row.Mail);
    $('[id$=PasswordText]').val(row.Password);
    $('[id$=ActivoCheck]').prop("checked", row.Activo);
    $('[id$=RolDrop]').val(row.Rol_Id);



}



function EliminarEmpleado(id) {

    $('#eliminarEmpleadosModal').modal();
    $('[id$=idEmpleado]').val(id);

}



$('#btnNuevoEmpleado').on('click', function () {
    clearEmpleados();
    $('#empleadosModal').modal();
    $('[id$=btnGuardar]').css('display', '');
    $('[id$=btnEditar]').css('display', 'none');
})


function clearEmpleados() {

    $('[id$=idEmpleado]').val("");
    $('[id$=NombreText]').val("");
    $('[id$=ApellidoText]').val("");
    $('[id$=MailText]').val("");
    $('[id$=PasswordText]').val("");
    $('[id$=ActivoCheck]').prop("checked", false);
    $('[id$=RolDrop]').val("");
}







