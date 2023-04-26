
function catalogosAddUpdateDelete(typeR, formData) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    var f = $(this);   
    formData.append('typeSubmit', typeR);
    $.ajax({
        url: "Handlers/crudCatalogsController.aspx",
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            swal.close()
            if (resultado.success) {
                if (resultado.data.type == "add") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Agregado con exito.',
                        showConfirmButton: false,
                        timer: 1500
                    })
                } else if (resultado.data.type == "delete") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Eliminado con exito.',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }   
                else if (resultado.data.type == "update") {                    
                    Swal.fire({
                        icon: 'success',
                        title: 'Registro actualizado.',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    dafaultBtnsDisplay();
                }
                switchTablePahe(resultado.data.table, resultado.data.info)
            }
            else {
                if (resultado.error == undefined) {                    
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        text: resultado.error,
                        footer: resultado.data.footeer
                    })
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        title: 'Oops...',
                        text: resultado.error,
                        footer: resultado.data.footeer
                    })                    
                }
            }
        },
        error: function (xhr, error, code) {
            alert("error");
            Swal.fire({
                icon: 'error',
                confirmButtonColor: '#572364',
                title: 'Oops... ¡ Algo salio mal !',
                text: 'Recargar la pagina por favor.'
            })
        }

    });
}

function switchTablePahe(json, info) {
    
    var value = document.getElementById("filterTableBy") == undefined ? "-1" : document.getElementById("filterTableBy").value
    switch (info) {
        case 'dias':

            document.getElementById("save").value = "";
            document.getElementById("form1").reset();
            onkeyupInputEmtyy('dia');
            document.getElementById("labelMsjAction").innerText = "Agregar un dia"
            buildTable(json, true);
            break;

        case 'horas':

            if (value != "" && value != "-1" && value != undefined) {
                requestBuildTableFilterBy();
            } else {
                buildTableHours(json); 
            }            
            document.getElementById("labelMsjAction").innerText = "Agregar horario"
            document.getElementById("save").value = "";
            document.getElementById("form1").reset();
            onkeyupNoSelectInSlc("days")
            onkeyupNoSelectInSlc("branches")
            break;

        case 'productos':

            var inputImage = document.getElementById("image");
            inputImage.setAttribute('data-image-uploadAut', "");
            document.getElementById("labelMsjAction").innerText = "Agregar producto"
            document.getElementById("save").value = "";
            document.getElementById("formFile").setAttribute("required", "required");
            document.getElementById("image").setAttribute("src", "");
            document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
            document.getElementById("form1").reset();
            onkeyupInputEmtyy('product')
            onkeyupInputEmtyy('description')
            onkeyupInputEmtyy('formFile')
            buildTable(json);
            break;

        case 'sucursales':

            document.getElementById("containerImages").innerHTML = ""
            document.getElementById("form1").reset();
            resetArrayFiles();
            document.getElementById("save").value = "";
            buildTable(json);
            break;
            
        case 'productBranche':

            if (value != "" && value != "-1" && value != undefined) {
                requestBuildTableFilterBy();
            } else {
                buildTable(json);
            }
            document.getElementById("labelMsjAction").innerText = "Agrega productos a sucursales"
            document.getElementById("save").value = "";
            document.getElementById("form1").reset();
            onkeyupNoSelectInSlc("products")
            onkeyupNoSelectInSlc("branches")
            onkeyupInputEmtyy("cantidad")
            onkeyupInputEmtyy("precio")
            break;

        case 'aboutUsAdmin':

            document.getElementById("form1").reset();
            document.getElementById("labelMsjAction").innerText = "Sobre nosotros"
            document.getElementById("save").value = "";
            onkeyupInputEmtyy('mision');
            onkeyupInputEmtyy('vision');
            onkeyupInputEmtyy('valores');
            buildTable(json);
            break;

    }

    //$('#tbl-roles input[type=checkbox]').iCheck({
    //    checkboxClass: 'icheckbox_flat-green',
    //    handle: 'checkbox'
    //});
    
}