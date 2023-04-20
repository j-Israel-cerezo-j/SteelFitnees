function recoverDataa(event) {
    document.getElementById("labelMsjAction").innerText = "Modificar registro";
    var id = event.target.attributes.id.value;
    $("#ctrl-principal").css('display', 'none');
    $("#ctrl-update").css('display', 'block');
    recoverData("recoverData", id);
    onkeyupNoSelectInSlc("products")
    onkeyupNoSelectInSlc("branches")
    onkeyupInputEmtyy("cantidad")
    onkeyupInputEmtyy("precio")


}
function cancelUpdate() {
    document.getElementById("labelMsjAction").innerText = "Agrega productos a sucursales";

    $("#ctrl-principal").css('display', 'block');
    $("#ctrl-update").css('display', 'none');
    document.getElementById("save").value = "";
    document.getElementById("form1").reset();
    onkeyupNoSelectInSlc("products")
    onkeyupNoSelectInSlc("branches")
    onkeyupInputEmtyy("cantidad")
    onkeyupInputEmtyy("precio")

}

function toggleSelectAll() {
    let isChecked = $("#check-all").prop('checked')
    $("#tbl-roles tbody input[type=checkbox]").prop('checked', !isChecked);
    $("#tbl-roles tbody ins").click();
}


