function requestBuildTableFilterBy() {
    var selectFilter = document.getElementById("filter")
    var valueSelectFilter = selectFilter.value
    var select = document.getElementById("filterTableBy")
    var value = select.value
    request(buildTableHours, 'Handlers/filterByController.aspx?filterByValue=' + value + '&action=table&filterBy=' + valueSelectFilter);
}