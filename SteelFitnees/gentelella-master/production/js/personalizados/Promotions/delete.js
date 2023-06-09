function deletePromotion(evt) {
    evt.preventDefault();
    var promotionsCheck = $("#containerImages input:checked");
    if (promotionsCheck.length == 0) {
        Swal.fire
            ({
                icon: 'error',
                title: 'Alto...',
                confirmButtonColor: '#572364',
                text: 'Selecciona una casilla para eliminar.',
            })
    } else {
        Swal.fire({
            title: '¿Estas seguro de eliminar?',
            text: "¡Ya no podras revertir el cambio!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: 'Darkgreen',
            cancelButtonColor: 'blue',
            confirmButtonText: '¡ Acepto !'
        }).then((result) => {
            if (result.isConfirmed) {
                var ids = Array.from(promotionsCheck).map(check => check.value).join(',');
                var formData = new FormData();
                formData.append('idsToDelete', ids);

                console.log("ids",ids)
            }
        })
    }
}