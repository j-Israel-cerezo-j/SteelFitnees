function requestComments() {
    var select = document.getElementById("branches")
    var value = select.value
    var text = select.options[select.selectedIndex].innerText; //El texto de la opción seleccionada
    request(buildCardsComments, 'Handlers/sucursalesController.aspx?meth=commentsByBranche&id=' + value);
    if (value != -1) {
        document.getElementById("nameBranche").innerHTML = text;
    }
}