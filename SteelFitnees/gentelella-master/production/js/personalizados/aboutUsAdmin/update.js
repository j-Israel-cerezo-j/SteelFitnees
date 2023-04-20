function update() {

    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
    } else {
        var id = $("#save").val();
        var formData = new FormData(document.getElementById("form1"));
        formData.append('id', id);
        document.getElementById("form1").reset();
        catalogosAddUpdateDelete('update', formData);
        
        document.getElementById("labelMsjAction").innerText = "Sobre nosotros"
        document.getElementById("save").value = "";

    }
    onkeyupInputEmtyy('mision');
    onkeyupInputEmtyy('vision');
    onkeyupInputEmtyy('valores');
    form.classList.add('was-validated')
}