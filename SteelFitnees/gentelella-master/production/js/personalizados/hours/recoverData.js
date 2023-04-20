function recoverDataa(event) {
    document.getElementById("labelMsjAction").innerText = "Modificar registro";
    var id = event.target.attributes.id.value;
    $("#ctrl-principal").css('display', 'none');
    $("#ctrl-update").css('display', 'block');
    recoverData("recoverData", id);
    onkeyupNoSelectInSlc("days")
    onkeyupNoSelectInSlc("branches")


}
function cancelUpdate() {
    document.getElementById("labelMsjAction").innerText = "Agregar hora";

    $("#ctrl-principal").css('display', 'block');
    $("#ctrl-update").css('display', 'none');
    document.getElementById("save").value = "";
    document.getElementById("form1").reset();
    onkeyupNoSelectInSlc("days")
    onkeyupNoSelectInSlc("branches")
    
}

function toggleSelectAll() {
    let isChecked = $("#check-all").prop('checked')
    $("#tbl-roles tbody input[type=checkbox]").prop('checked', !isChecked);
    $("#tbl-roles tbody ins").click();
}


