function addB(formData) {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('nombre');
        onkeyupInputEmtyy('description');
        onkeyupInputEmtyy('ubicacion');
        
    } else {
        catalogosAddUpdateDelete('add', formData)
    }
    document.getElementById("containerImages").innerHTML = ""
    document.getElementById("form1").reset();
    resetArrayFiles();
    form.classList.add('was-validated')
}