function addB() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('nombre');
        onkeyupInputEmtyy('description');
        onkeyupInputEmtyy('ubicacion');
        
    } else {
        var formData = new FormData(document.getElementById("form1"));
        catalogosAddUpdateDelete('add', formData)
    }
    document.getElementById("containerImages").innerHTML = ""
    document.getElementById("form1").reset();
    form.classList.add('was-validated')
}