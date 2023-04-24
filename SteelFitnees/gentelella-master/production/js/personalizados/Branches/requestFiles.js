function saveTemporaly() {
    var formData = new FormData(document.getElementById("form1"));
    filesAjax(formData,"Handlers/filesController.aspx?action=saveTemporaly");    
}