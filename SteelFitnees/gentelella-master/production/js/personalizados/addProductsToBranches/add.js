function addP() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupNoSelectInSlc("products")
        onkeyupNoSelectInSlc("branches")
        onkeyupInputEmtyy("cantidad")
        onkeyupInputEmtyy("precio")
    } else {
        var formData = new FormData(document.getElementById("form1"));
        catalogosAddUpdateDelete('add', formData)
    }
    form.classList.add('was-validated')
}