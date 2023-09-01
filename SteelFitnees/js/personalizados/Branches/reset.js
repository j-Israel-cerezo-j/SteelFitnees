function btnReset() {
    document.getElementById("containerImages").innerHTML = ""
    document.getElementById("form1").reset();
    onkeyupInputEmtyy('nombre');
    onkeyupInputEmtyy('description');
    onkeyupInputEmtyy('ubicacion');
    onkeyupInputEmtyy('telephone');
    removeAllFiles();
}