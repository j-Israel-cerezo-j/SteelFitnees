function update() {
    
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        removeAllFiles();
    } else {
        var id = $("#save").val();
        var formData = new FormData(document.getElementById("form1"));        
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
        console.log(imgTags)
        for (var i = 0; i < imgTags.length - 1; i++) {
            arrayImgPath.push(imgTags[i].dataset["imageUploadaut"]);
        }
        formData.append("arrayParhImgs", arrayImgPath);
        document.getElementById("form1").reset();
        catalogosAddUpdateDelete('update', formData);
        
        document.getElementById("labelMsjAction").innerText = "Agregar sucursal"
        document.getElementById("formFile").setAttribute("required", "required");
        document.getElementById("containerImages").innerHTML=""
        document.getElementById("save").value = "";

    }
    onkeyupInputEmtyy('nombre')
    onkeyupInputEmtyy('description')
    onkeyupInputEmtyy('ubicacion')
    form.classList.add('was-validated')
}