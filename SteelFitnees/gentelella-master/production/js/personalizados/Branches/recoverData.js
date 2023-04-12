function recoverDataa(event) {
    document.getElementById("labelMsjAction").innerText = "Modificar registro";
    var id = event.target.attributes.id.value;
    $("#ctrl-principal").css('display', 'none');
    $("#ctrl-update").css('display', 'block');
    recoverData("recoverData", id);
    var idsInputs = ["nombre", "description", "ubicacion"];
    styleBoxShadowGreen(idsInputs);

}
function cancelUpdate() {
    $("#ctrl-principal").css('display', 'block');
    $("#ctrl-update").css('display', 'none');
    $("#radiosTW input[type=radio]").iCheck('uncheck');
    document.getElementById("save").value = "";

    document.getElementById("labelMsjAction").innerText = "Agregar sucursal";
    document.getElementById("form1").reset();
    document.getElementById("formFile").setAttribute("required", "required");
    document.getElementById("containerImages").innerHTML = ""
    onkeyupInputEmtyy('nombre')
    onkeyupInputEmtyy('description')
    onkeyupInputEmtyy('ubicacion')

}

function toggleSelectAll() {
    let isChecked = $("#check-all").prop('checked')
    $("#tbl-roles tbody input[type=checkbox]").prop('checked', !isChecked);
    $("#tbl-roles tbody ins").click();
}


