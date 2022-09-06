
let btn1 = document.querySelector("#btn1");
btn1.addEventListener("click", function () {

    let productos = document.querySelector('#productos');

    console.log(productos);
    let divCard = document.createElement("div");
    divCard.innerHTML = `<div class="col-lg-4 col-md-4 box">                                          
                                           <img class="image-drink" src="#" />
                                           <h3>Nombre</h3>
                                           <p>Precio: 100</p>
                                           <p id:"stock" >Stock: </p>

                                        <div class="quantity">
                                            <button class="btn-menos" id="btn-menos" type="button" >-</button>
                                            <input  id="b" type="text" class="input-qty"  value="1"/>
                                            <button class="btn-mas" id="btn-mas" type="button" >+</button>

                                        </div>
                                        
                                    </div>`;
    productos.appendChild(divCard);
})





   
$('#btnBebida').on('click', function () {
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
            {
                data: function (row) {


                    var buttons =
                        `<td><a href='javascript:EditarBebida(${JSON.stringify(row)})'<i class="fa-solid fa-pen-to-square editarBebida"></td>` +
                        `<td><a href='javascript:EliminarBebida(${JSON.stringify(row.IdBebida)})'<i class="fa-solid fa-trash eliminarBebida"></td>
                           <td><a href='javascript:GuardarBebida(${JSON.stringify(row.IdBebida)})'<i class="fa-solid fa-trash "></td>`;

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


$('#btnEntrada').on('click', function (e) {
    e.preventDefault;
    console.log(e)
    const token = $('[id$=token]').val();
    $('#tableEntradas').DataTable({
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







/*

$(document).ready(function () {

    const token = $('[id$=token]').val();
    $.ajax({
        url: 'https://localhost:44307/api/Bebidas/ObtenerBebidas',
        type: 'GET',
        dataType: 'Json',
        headers: {"Authorization": token },
        success: function (data) {
            JSON.stringify(data);
            console.log(data);
            
            



            
            let id = document.querySelector("#drinks");

            for (const bebida of data) {
                
                let divCard = document.createElement("div");
                divCard.innerHTML = `<div class="col-lg-4 col-md-4 box">
                                           
                                           <img class="image-drink" src="${bebida.Imagen}" />
                                           <h3>${bebida.NombreBebida}</h3>
                                           <p>Precio: $${bebida.PrecioBebida}</p>
                                           <p id:"stock" >Stock: ${bebida.Stock}</p>

                                        <div class="quantity">
                                            <button class="btn-menos" id="btn-menos" type="button" onclick="quantity(${bebida.IdBebida},0, ${bebida.Stock})">-</button>
                                            <input  id="${bebida.IdBebida}" type="text" class="input-qty"  value="1"/>
                                            <button class="btn-mas" id="btn-mas" type="button" onclick="quantity(${bebida.IdBebida}, 1,${bebida.Stock})">+</button>

                                        </div>
                                        <div>
                                            
                                            <button onclick="guardar(${bebida});" class="btn btn-success btn-guardar" type="button">Guardar</button>
                                        </div>
                                    </div>`;
                id.appendChild(divCard);
            }
            
        }

        
    });
});


$(document).ready(function () {
    const url = "https://localhost:44307/api/Bebidas/ObtenerBebidas";
    const token = $('[id$=token]').val();

    const options = {
        method: "GET",
        headers: { "Authorization": token }
    }
    fetch(url, options)

        .then(function (response) {
            response.json().then(function (data) {
                console.log(data)
            });
        }) 
        .catch(error => console.log(error))
});






function quantity(idBebida, operacion, stock) {
    console.log(idBebida, operacion);
    let num = $('#' + idBebida).val();
    let numStock = stock;
    
    if (operacion === 1) {
        num++;
        numStock--;

    } else if (operacion === 0 && num > 0){
        num--;
        numStock++;
    }
    $('#' + idBebida).val(num);
    $('#stock').val(numStock);  
};*/