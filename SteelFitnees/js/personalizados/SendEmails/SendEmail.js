function send() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('asunto');
    } else {
        Swal.fire({
            title: '¿Estas seguro de tus datos?',
            text: 'Presiona Correcto si son correctos',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: 'Darkgreen',
            cancelButtonColor: 'blue',
            confirmButtonText: '¡ Correcto !',
            cancelButtonText: 'Regresar'
        }).then((result) => {
            if (result.isConfirmed) {
                var formData = new FormData(document.getElementById("form1"));
                sendAjax(formData);
            }
        })
    }  
    form.classList.add('was-validated')
}