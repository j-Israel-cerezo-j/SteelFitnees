function update() {

    var form = document.getElementById("form1");
    document.getElementById("formFile").removeAttribute("required");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
    } else {
        var id = $("#save").val();
        var formData = new FormData(document.getElementById("form1"));        
        var inputImage = document.getElementById("image");
        var imageUploadAut = inputImage.getAttribute("data-image-uploadAut");       
        formData.append('id', id);
        formData.append('imageUploadAut', imageUploadAut)
        document.getElementById("form1").reset();
        catalogosAddUpdateDelete('update', formData);                

        inputImage.setAttribute('data-image-uploadAut', "");
        document.getElementById("labelMsjAction").innerText = "Agregar producto"
        document.getElementById("save").value = "";
        document.getElementById("formFile").setAttribute("required", "required");
        document.getElementById("image").setAttribute("src", "");
        document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
        
    }
    onkeyupInputEmtyy('product')
    onkeyupInputEmtyy('description')
    onkeyupInputEmtyy('formFile')
    form.classList.add('was-validated')
}