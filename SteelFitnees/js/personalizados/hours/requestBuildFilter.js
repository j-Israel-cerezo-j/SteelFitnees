function requestBuildFilter() {    
    var select = document.getElementById("filter")
    var value = select.value
    if (value == "fullRecords") {
        var filterTableBySlc = document.getElementById("filterTableBy")
        document.getElementById("filterTableBy").innerHTML=""
        var optionSelection = document.createElement("option");
        optionSelection.value = "";
        optionSelection.text = "Selecciona un tipo de filtro";
        filterTableBySlc.appendChild(optionSelection);
        document.getElementById("filterByLbl").innerHTML = 'Filtrar por..';
        buildTableOnload()
        
    } else {        
        request(buildFilterBySlc, 'Handlers/filterByController.aspx?filterByValue=' + value + '&action=filterBy');
    }   
    var text = select.options[select.selectedIndex].innerText; //El texto de la opción seleccionada
    document.getElementById("filterByLbl").innerHTML = text;
}