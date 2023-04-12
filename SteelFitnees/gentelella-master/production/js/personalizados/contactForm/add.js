function addContact() {    
    var form = document.getElementById("contactForm");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('nombre');
        onkeyupInputEmtyy('email');
    } else {
        let nombre = document.getElementById("nombre").value;
        let email = document.getElementById("email").value;
        Swal.fire({
            title: 'Revisa tus datos por favor',
            text: 'Nombre: ' + nombre + "   |   Correo: " + email,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: 'Darkgreen',
            cancelButtonColor: 'blue',
            confirmButtonText: '¡ Correcto !'
        }).then((result) => {
            if (result.isConfirmed) {
                var formData = new FormData(document.getElementById("contactForm"));
                submitContac(formData);
                document.getElementById("contactForm").reset();
            }
        })
    }
    form.classList.add('was-validated')
}