function requestAllProducts() {
    request(buildAllProduct, 'Handlers/productsController.aspx?action=all');
}
function requestAllProductsInitRange() {
    request(iniRange, 'Handlers/productsController.aspx?action=all');
}