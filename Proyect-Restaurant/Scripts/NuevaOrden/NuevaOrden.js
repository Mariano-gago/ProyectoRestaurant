


// Objeto de pedido

let cliente = {
    mesa: "",
    pedido:[]
};




// Productos bebidas
$('#btnBebidas').on('click', function () {
    const token = $('[id$=token]').val();
    $.ajax({
        url: 'https://localhost:44307/api/Bebidas/ObtenerBebidas',
        type: 'GET',
        dataType: 'Json',
        headers: { "Authorization": token },
        success: function (data) {
            JSON.stringify(data);
           // console.log(data);
           // obtenerCantidad(data);


            mostrarProductos(data);

            
        }


    });
});



function mostrarProductos(data) {

    const productos = document.querySelector('#productos .contenido');
    productos.innerHTML = "";
    data.forEach(data => {

        const div = document.createElement('DIV');
        div.classList.add('col-lg-4', 'col-md-4', 'box');
        
          
        const image = document.createElement('IMG');
        image.classList.add('image-drink');
        image.src = data.imagen;

        const nombre = document.createElement('h3');
        nombre.textContent = data.NombreBebida;

        const precio = document.createElement('p');
        precio.classList.add('fw-bold');
        precio.textContent = `$${data.PrecioBebida}`;

        const stock = document.createElement('p');
        stock.textContent = `Stock: ${data.Stock} `;


        const inputCantidad = document.createElement('input');
        inputCantidad.type = 'number';
        inputCantidad.min = 0;
        inputCantidad.value = 0;
        inputCantidad.id = `producto-${data.IdBebida}`;
        inputCantidad.classList.add('form-control', 'input-qty');
        
        const divInput = document.createElement('DIV');
        div.classList.add('inputCantidad');

        divInput.appendChild(inputCantidad);
        

        const inputAgregar = document.createElement('input');
        inputAgregar.classList.add('btn', 'btn-success');
        inputAgregar.value = "Agregar";
        inputAgregar.onclick = function () {

            const cantidad = parseInt(inputCantidad.value);
           
            agregarPedido({ ...data, cantidad });
        };
       
        divInput.appendChild(inputAgregar);

     
        div.appendChild(image);
        div.appendChild(nombre);
        
        div.appendChild(precio);
        div.appendChild(stock);
        div.appendChild(divInput);
        
        productos.appendChild(div);
    });
    
}



function agregarPedido(producto) {

    //Destructuring
    let { pedido } = cliente;


    if (producto.cantidad > 0) {

        //metodo some devuelve true o false
        if (pedido.some(articulo => articulo.IdBebida === producto.IdBebida)) {

            //map devulve un nuevo array con la cantidad actualizada
            const pedidoActualizado = pedido.map(articulo => {

                if (articulo.IdBebida === producto.IdBebida) {
                    articulo.cantidad = producto.cantidad;
                }
                return articulo;
            });


            cliente.pedido = [...pedidoActualizado]

        } else {
            cliente.pedido = [...pedido, producto];
        }

    } else {
        const resultado = pedido.filter(articulo => articulo.IdBebida !== producto.IdBebida);
        cliente.pedido = [...resultado];
        
    }

    //Limpia html previo

    clearHtml();

    console.log(cliente.pedido)
    resumenPedido();
}


function resumenPedido() {


    const agregarPedido = document.querySelector('#pedido .contenido');


    //Informacion de la mesa
    const mesaNumero = document.querySelector('.inputMesa');

    console.log(mesaNumero.value);
    const resumen = document.createElement('div');
    resumen.classList.add('col-md-6');

    const mesa = document.createElement('p');
    mesa.textContent = 'Mesa: ' + mesaNumero.value;

    const heading = document.createElement('h5');
    heading.textContent = 'Bebida Selccionada';
    heading.classList.add('my-4', 'text-center');


    //Itera sobre el array

    const pedidoTotal = document.createElement('div');


    const { pedido } = cliente;
    pedido.forEach(producto => {
        //Destructuring extraigo cada elemento del objeto producto
        const {NombreBebida, PrecioBebida, cantidad } = producto;

        //Funcion para calcular el precio Total de cada producto
        let precioTotal = calcularPrecio(cantidad, PrecioBebida);



        let divCard = document.createElement("div");
        divCard.innerHTML = `
                                           <h3>Bebidas: ${NombreBebida}</h3>
                                           <p>Precio: $${precioTotal}</p>
                                           <p id:"stock"> Cantidad: ${cantidad}</p> `;
       
        pedidoTotal.appendChild(divCard);

        
    })

    resumen.appendChild(mesa);
    resumen.appendChild(heading);
    resumen.appendChild(pedidoTotal);
    agregarPedido.appendChild(resumen);


    precioFinal(pedido);
}

function clearHtml() {
    const contenido = document.querySelector('#pedido .contenido');

    while (contenido.firstChild) {
        contenido.removeChild(contenido.firstChild);
    }
}




function calcularPrecio(cantidad, precio) {

    let precioTotal = cantidad * precio;

    return precioTotal;
}

function precioFinal(producto) {
    console.log(producto)
    
}
/*
function mostrarProductos(data) {
    let id = document.querySelector("#productos");
    id.innerHTML = "";
    for (const bebida of data) {
        let divCard = document.createElement("div");
        divCard.innerHTML = `<div class="col-lg-4 col-md-4 box">
                                           
                                           <img class="image-drink" src="${bebida.Imagen}" />
                                           <h3>${bebida.NombreBebida}</h3>
                                           <p>Precio: $${bebida.PrecioBebida}</p>
                                           <p id:"stock" >Stock: ${bebida.Stock}</p>

                                        <div class="quantity">
                                            <button class="btn-menos" id="btn-menos" type="button" onclick="quantity(${bebida.IdBebida},0, ${bebida.Stock})">-</button>
                                            <input  id="${bebida.IdBebida}" type="text" class="input-qty"  value="0"/>
                                            <button class="btn-mas" id="btn-mas" type="button" onclick="quantity(${bebida.IdBebida}, 1,${bebida.Stock})">+</button>

                                        </div>
                                        <div>
                                            
                                            <button onclick="agregarPedido(${bebida.IdBebida});" class="btn btn-success btn-guardar" type="button">Guardar</button>
                                        </div>
                                    </div>`;
        id.appendChild(divCard);
    }
}

function quantity(idBebida, operacion, stock) {
    //console.log(idBebida);
    let num = $('#' + idBebida).val();
    let numStock = stock;

    if (operacion === 1) {
        num++;
        numStock--;

    } else if (operacion === 0 && num > 0) {
        num--;
        numStock++;
    }
    $('#' + idBebida).val(num);
    $('#stock').val(numStock);

    //obtenerCantidad(idBebida, num);
    
};


function agregarPedido(id) {
    const cantidad = divCard;
    console.log(cantidad);
    console.log("agregando", id);
}*/











//Productos Entradas
$('#btnEntradas').on('click', function () {
    const token = $('[id$=token]').val();
    $.ajax({
        url: 'https://localhost:44307/api/Entradas/ObtenerEntradas',
        type: 'GET',
        dataType: 'Json',
        headers: { "Authorization": token },
        success: function (data) {
            JSON.stringify(data);
            console.log(data);



            const productos = document.querySelector('#productos .contenido');
            productos.innerHTML = "";
            data.forEach(data => {

                const div = document.createElement('DIV');
                div.classList.add('col-lg-4', 'col-md-4', 'box');


                const image = document.createElement('IMG');
                image.classList.add('image-drink');
                image.src = data.ImagenEntrada;

                const nombre = document.createElement('h3');
                nombre.textContent = data.NombreEntrada;

                const precio = document.createElement('p');
                precio.classList.add('fw-bold');
                precio.textContent = `$${data.PrecioEntrada}`;

                


                const inputCantidad = document.createElement('input');
                inputCantidad.type = 'number';
                inputCantidad.min = 0;
                inputCantidad.value = 0;
                inputCantidad.id = `producto-${data.IdEntrada}`;
                inputCantidad.classList.add('form-control', 'input-qty');

                const divInput = document.createElement('DIV');
                div.classList.add('inputCantidad');

                divInput.appendChild(inputCantidad);


                const inputAgregar = document.createElement('input');
                inputAgregar.classList.add('btn', 'btn-success');
                inputAgregar.value = "Agregar";
                inputAgregar.onclick = function () {

                    const cantidad = parseInt(inputCantidad.value);

                    agregarPedido({ ...data, cantidad });
                };

                divInput.appendChild(inputAgregar);


                div.appendChild(image);
                div.appendChild(nombre);

                div.appendChild(precio);
                
                div.appendChild(divInput);

                productos.appendChild(div);
            });




            /*
            let id = document.querySelector("#productos");
            id.innerHTML = "";
            for (const entrada of data) {

                let divCard = document.createElement("div");



                divCard.innerHTML = `<div class="col-lg-4 col-md-4 box">
                                           
                                           <img class="image-drink" src="${entrada.ImagenEntrada}" />
                                           <h3>${entrada.NombreEntrada}</h3>
                                           <p>Precio: $${entrada.PrecioEntrada}</p>
                                           

                                        <div class="quantity">
                                            <button class="btn-menos" id="btn-menos" type="button" onclick="quantity(${entrada.IdEntrada},0)">-</button>
                                            <input  id="${entrada.IdEntrada}" type="text" class="input-qty"  value="0"/>
                                            <button class="btn-mas" id="btn-mas" type="button" onclick="quantity(${entrada.IdBebida}, 1)">+</button>

                                        </div>
                                        <div>
                                            
                                            <button onclick="guardar();" class="btn btn-success btn-guardar" type="button">Guardar</button>
                                        </div>
                                    </div>`;
                id.appendChild(divCard);
            }*/

        }


    });
});
