function recoverDataa(event) {
    document.getElementById("labelMsjAction").innerText = "Modificar registro";
    var id = event.target.attributes.id.value;
    $("#ctrl-principal").css('display', 'none');
    $("#ctrl-update").css('display', 'block');
    recoverData("recoverData", id);
    document.getElementById("formFile").removeAttribute("required");
    var idsInputs = ["product", "description","formFile"];
    styleBoxShadowGreen(idsInputs);
   
}
function cancelUpdate() {
    $("#ctrl-principal").css('display', 'block');
    $("#ctrl-update").css('display', 'none');
    $("#radiosTW input[type=radio]").iCheck('uncheck');
    document.getElementById("save").value = "";

    document.getElementById("labelMsjAction").innerText = "Agregar un producto";
    document.getElementById("form1").reset();

    document.getElementById("formFile").setAttribute("required", "required");
    document.getElementById("image").setAttribute("src", "");
    document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
    onkeyupInputEmtyy('product')
    onkeyupInputEmtyy('description')
    onkeyupInputEmtyy('formFile')
    
}

function toggleSelectAll() {
    let isChecked = $("#check-all").prop('checked')
    $("#tbl-roles tbody input[type=checkbox]").prop('checked', !isChecked);
    $("#tbl-roles tbody ins").click();
}



