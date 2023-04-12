function SwitchTableOnkeyup(catalogo, json, jsonOnkeyp = true) {
    switch (catalogo) {               
        case 'sucursales':
            buildTable(json, jsonOnkeyp);
            break;
        case 'dias':
            buildTable(json, jsonOnkeyp);
        case 'horas':
            buildTableHours(json, jsonOnkeyp);
            break;
        case 'productos':
            buildTable(json, jsonOnkeyp);
        case 'productBranche':
            buildTable(json, jsonOnkeyp);
            break;
        case 'commentsCharacteres':
            buildCardsComments(json, jsonOnkeyp);
            break;
        case 'productsByBrancheAndCharacteres':
            buildProductById(json, jsonOnkeyp);
            break;
        case 'actionSearchubmit':
            redirect(json);
    }
}