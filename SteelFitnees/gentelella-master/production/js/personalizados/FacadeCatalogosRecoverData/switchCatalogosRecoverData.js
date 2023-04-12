function switchCatalogosRecoverData(json, catalogo) {
    switch (catalogo) {
        case 'horas':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("branches").value = json[i].fkSucursal;
                document.getElementById("days").value = json[i].fkDia;
                document.getElementById("horaInicio").value = json[i].horaInicio;
                document.getElementById("horaTermino").value = json[i].horaCierre;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'productBranche':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("branches").value = json[i].fkSucursal;
                document.getElementById("products").value = json[i].fkProducto;
                document.getElementById("precio").value = json[i].precio;
                document.getElementById("cantidad").value = json[i].cantidad;
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'dias':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("dia").value = json[i].dia;                
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'sucursales':
            for (var i = 0; i < json.length; i++) {
                document.getElementById("nombre").value = json[i].Nombre;
                document.getElementById("description").value = json[i].Descripcion;
                document.getElementById("ubicacion").value = json[i].ubicacion;
                document.getElementById("save").value = json[i].id;
                
                document.getElementById("formFile").removeAttribute("required");

                var actionUpdateData = document.getElementById("containerImages");
                actionUpdateData.setAttribute('data-action-uploadAut',false);

                var myModal = new bootstrap.Modal(document.getElementById('exampleModal'))
                myModal.show()

                request(buildCardsImage, 'Handlers/imagesController.aspx?id=' + json[i].id,);


            }
            break;
        case 'productos':
            console.log(json);
            for (var i = 0; i < json.length; i++) {
                document.getElementById("product").value = json[i].Nombre;
                document.getElementById("description").value = json[i].Descripcion;

                document.getElementById("image").setAttribute("src", json[i].imagen);
                if (json[i].image == "") {
                    document.getElementById("msjImagenCargadaAutomatica").innerHTML = "<h4><b><i>Producto sin imagen.</i></b></h4>"
                } else {
                    document.getElementById("msjImagenCargadaAutomatica").innerHTML = "<h4><b><i>Imagen cargada automaticamente.</i></b></h4>"
                }

                var inputImage = document.getElementById("image");
                var path = json[i].imagen == "" ? "..." : json[i].imagen
                inputImage.setAttribute('data-image-uploadAut', path);
                
                document.getElementById("save").value = json[i].id;
            }
            break;
        case 'aboutUsAdmin':
            console.log(json);
            for (var i = 0; i < json.length; i++) {
                document.getElementById("mision").value = json[i].mision;
                document.getElementById("vision").value = json[i].vision;                
                document.getElementById("valores").value = json[i].valores;

                document.getElementById("save").value = json[i].id;
            }
            break;
    }
}

