
function requestTablesAjax(callback) {
    var catalogo = document.getElementById("catalogo").value;
    const table = fetch('Handlers/tablesController.aspx?catalogo=' + catalogo);
    table
        .then((resp) => resp.json())
        .then((resp) => {
            callback(resp.data.recoverTable);
        });    
}
