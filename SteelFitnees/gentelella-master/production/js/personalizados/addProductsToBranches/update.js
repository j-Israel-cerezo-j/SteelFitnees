function update() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()

    } else {
        var id = $("#save").val();
        var formData = new FormData(document.getElementById("form1"));
        formData.append('id', id)
        catalogosAddUpdateDelete('update', formData)
        document.getElementById("labelMsjAction").innerText = "Agrega productos a sucursales"
        document.getElementById("save").value = "";
        document.getElementById("form1").reset();
    }
    onkeyupNoSelectInSlc("products")
    onkeyupNoSelectInSlc("branches")
    onkeyupInputEmtyy("cantidad")
    onkeyupInputEmtyy("precio")
    form.classList.add('was-validated')
}