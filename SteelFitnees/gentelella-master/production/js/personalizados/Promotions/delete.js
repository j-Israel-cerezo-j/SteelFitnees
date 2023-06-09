function deletePromotion(evt) {
    evt.preventDefault();
    
    var checkboxes = document.getElementsByClassName("checkBoxP");
    var checkboxesArray = Array.from(checkboxes);
    var checkboxesSeleccionados = checkboxesArray.filter(check => { return check.checked });

    if (checkboxesSeleccionados.length == 0) {
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
                var ids = checkboxesSeleccionados.map(check => check.value).join(',');
                var formData = new FormData();
                formData.append('idsToDelete', ids);
                deleteWhithForm('', formData,);
            }
        })
    }
}