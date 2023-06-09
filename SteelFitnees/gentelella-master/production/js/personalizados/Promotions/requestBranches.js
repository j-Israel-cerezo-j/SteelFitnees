function requestBranches() {
    return new Promise((resolve,reject) => {
        request(json => {
            var htmlSlcBranche = `<option value="-1" selected>Solo página de inicio</option>`;
            json.forEach(item => {
                htmlSlcBranche += `<option value="${item.id}">${item.Nombre}</option>`
            });
            resolve(htmlSlcBranche);
        }, 'Handlers/sucursalesController.aspx', false);
    });    
}