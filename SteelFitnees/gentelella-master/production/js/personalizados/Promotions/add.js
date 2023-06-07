function addPromotion(formData) {
    post('Handlers/promotionsController.aspx?meth=add', formData, (json) => {
        if (!json.success) {
            Swal.fire({
                icon: 'error',
                confirmButtonColor: '#572364',
                text: json.error,
                footer: json.data.footeer
            })
        }
        else {
            Swal.fire({
                icon: 'success',
                title: 'Promociones agregadas.',
                showConfirmButton: false,
                timer: 1500
            })
        }
        console.log(json)
    });
}