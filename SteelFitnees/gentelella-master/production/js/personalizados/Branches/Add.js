function addB(formData) {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('nombre');
        onkeyupInputEmtyy('description');
        onkeyupInputEmtyy('ubicacion');
        onkeyupInputEmtyy('telephone');
        
    } else {
        catalogosAddUpdateDelete('add', formData)
    }
    form.classList.add('was-validated')
}