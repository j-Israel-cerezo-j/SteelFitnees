function addAboutUs() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('mision');
        onkeyupInputEmtyy('vision');
        onkeyupInputEmtyy('valores');
    } else {
        var formData = new FormData(document.getElementById("form1"));
        catalogosAddUpdateDelete('add', formData)
        $("#resert").click();
    }

    form.classList.add('was-validated')
}