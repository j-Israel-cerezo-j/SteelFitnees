function filesAjax(formData,url) {
    var f = $(this);
    $.ajax({
        url: url,
        type: "post",
        dataType: "json",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (resultado) {
            if (resultado.success) {
               
            }
        }
    });
}