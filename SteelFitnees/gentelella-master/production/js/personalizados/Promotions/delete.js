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
            title: '¿Estas seguro de eliminar ' + checkboxesSeleccionados.length + ' promocion(es)?',
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
                deleteWhithForm('Handlers/promotionsController.aspx?meth=delete', formData, (json) => {
                    document.getElementById("containerImages").innerHTML = "";
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
                            title: 'Promocione(s) eliminada(s).',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    }
                    var idBranch = document.getElementById("filter").value;
                    if (idBranch != "-1") {
                        requestPromotionsByFilterBranch();
                    } else {
                        buildPromotionsOnloadAferPost(json.data.recoverData);
                    }
                });
            }
        })
    }
}