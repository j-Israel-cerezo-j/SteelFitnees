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
        formData.append('imageUploadAut', imageUploadAut);
        catalogosAddUpdateDelete('update', formData);
    }
    form.classList.add('was-validated')
}