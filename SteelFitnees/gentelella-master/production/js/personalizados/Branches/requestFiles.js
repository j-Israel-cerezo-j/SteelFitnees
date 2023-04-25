function saveTemporaly() {
    var formData = new FormData(document.getElementById("form1"));
    filesAjax(formData,"Handlers/filesController.aspx?action=saveTemporaly");    
}

function removeAllFiles() {
    var formData = new FormData(document.getElementById("form1"));
    filesAjax(formData, "Handlers/filesController.aspx?action=removeAll");
}

function removeFile(fileName) {
    var formData = new FormData(document.getElementById("form1"));
    filesAjax(formData, "Handlers/filesController.aspx?action=removeFile&fileName=" + fileName);
}