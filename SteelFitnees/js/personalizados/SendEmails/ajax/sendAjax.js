
function sendAjax(formData) {
    console.log("hola mubdo")
    Swal.fire({
        title: 'Enviando...',
        showConfirmButton: false
    })
    var f = $(this);
    $.ajax({
        url: "Handlers/emailController.aspx",
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            swal.close()
            if (resultado.success) {
                if (resultado.data.type == "send") {
                    Swal.fire('Correo enviado a los contactos registrados')
                    document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
                    document.getElementById("form1").reset();
                    document.getElementById("image").setAttribute("src", "");
                    document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
                    onkeyupInputEmtyy('asunto');
                    onkeyupInputEmtyy('senderMail');
                    onkeyupInputEmtyy('senderPassword');
                    onkeyupInputEmtyy('formFile');
                    onkeyupInputEmtyy('info');
                }
            }
            else {
                if (resultado.error == undefined) {
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        text: resultado.error,
                        footer: resultado.data.footeer
                    })
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        confirmButtonColor: '#572364',
                        title: 'Oops...',
                        text: resultado.error,
                        footer: resultado.data.footeer
                    })
                }
            }
        },
        error: function (xhr, error, code) {
            alert("error");
            Swal.fire({
                icon: 'error',
                confirmButtonColor: '#572364',
                title: 'Oops... ¡ Algo salio mal !',
                text: 'Recargar la pagina por favor.'
            })
        }

    });
}