function update() {
    
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
    } else {
        var id = $("#save").val();
        var formData = new FormData(document.getElementById("form1"));        
        formData.append('id', id);
        var inputImage = document.getElementById("containerImages");
        var imageUploadAut = inputImage.getAttribute("data-action-uploadAut");
        var statusDataFinal = imageUploadAut == null ? false : imageUploadAut
        formData.append("statusImajes", statusDataFinal)
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