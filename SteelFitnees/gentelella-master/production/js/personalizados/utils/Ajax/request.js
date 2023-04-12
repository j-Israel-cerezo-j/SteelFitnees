function request(callback, url, showAlert = true) {
    if (showAlert) {
        Swal.fire({
            title: 'Cargando...',
            showConfirmButton: false
        })
    }    
    const table = fetch(url);
    table
        .then((resp) => resp.json())
        .then((resp) => {
            if (showAlert) {
                swal.close()
            }                
            callback(resp.data.recoverData);
        });
}
