function requestComments() {
    var form = document.getElementById("formComments");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('comments');
    } else {
        var idBranche = document.getElementById("idBranche").value
        var formData = new FormData(document.getElementById("formComments"));
        branchesAjax(formData, idBranche);
    }
    form.classList.add('was-validated')        
}