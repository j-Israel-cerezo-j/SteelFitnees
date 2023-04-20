function switchCatalogosRecoverData(json, catalogo) {
        switch (catalogo) {
        case 'horas':
                for (var i = 0; i < json.length; i++) {

                    const scheduleOpen = json[i].horaInicio;
                    var [hora, minutos] = scheduleOpen.split(":").map(num => parseInt(num));
                    if (scheduleOpen.includes("p. m.")) {
                        hora =12;
                    }
                    const fomatCorrectHoraInputIni = `${hora.toString().padStart(2, "0")}:${minutos.toString().padStart(2, "0")}`;

                    const scheduleClose = json[i].horaCierre;
                    var [horaClose, minutosClose] = scheduleClose.split(":").map(num => parseInt(num));
                    if (scheduleClose.includes("p. m.")) {
                        horaClose = 12;
                    }
                    console.log(json[i].horaInicio)
                    const fomatCorrectHoraInputEnd = `${horaClose.toString().padStart(2, "0")}:${minutosClose.toString().padStart(2, "0")}`;

                    document.getElementById("branches").value = json[i].fkSucursal;
                    document.getElementById("days").value = json[i].fkDia;
                    document.getElementById("horaInicio").value = fomatCorrectHoraInputIni;
                    document.getElementById("horaTermino").value = fomatCorrectHoraInputEnd;
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

                $("#exampleModal").modal("show");

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

