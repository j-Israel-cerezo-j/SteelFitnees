function requestFilterByDates() {
    var selectBranches = document.getElementById("branches")
    var branchesvalue = selectBranches.value
    var weekSlc = document.getElementById("weeks")    
    var valueWeek = weekSlc.value
    var textWeeks = weekSlc.options[weekSlc.selectedIndex].innerText; //El texto de la opción seleccionada
    document.getElementById("weekSelectedText").innerHTML = textWeeks;
    request(buildCardsComments, 'Handlers/filterByController.aspx?filterByValue=' + valueWeek + '&action=weeks&filterBy=weeks&id=' + branchesvalue);

}