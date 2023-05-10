function update(formData) {
    
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()        
    } else {
        var id = $("#save").val();
        formData.append('id', id);
        var inputImage = document.getElementById("containerImages");
        var imageUploadAut = inputImage.getAttribute("data-action-uploadAut");
        var statusDataFinal = imageUploadAut == null ? false : imageUploadAut
        //al recuperar las imagenes en para actuzliazar,poner un boton
        //si quiere quitar las imagenes recuperadas, y si da click.limpiar los data-image
        //de no ser asi, que mande las imagenes guardadas mas las recien subidas, y volverlas a pintar
        formData.append("statusImajes", statusDataFinal)

     

        const divCoinatinerImg = document.querySelector('#containerImages'); // selecciona el div
        const imgTags = divCoinatinerImg.querySelectorAll('img');

        var arrayImgPath = []
        for (var i = 0; i < imgTags.length; i++) {
            var dataImage = imgTags[i].dataset["imageUploadaut"]
            if (dataImage != "" && dataImage!= undefined) {
                arrayImgPath.push(dataImage);
            }            
        }
        formData.append("arrayParhImgs", arrayImgPath);
        catalogosAddUpdateDelete('update', formData);
        
        document.getElementById("labelMsjAction").innerText = "Agregar sucursal"

    }
    form.classList.add('was-validated')
}