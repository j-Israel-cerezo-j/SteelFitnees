function addPromotion(formData) {
	post('Handlers/promotionsController.aspx?meth=add', formData, (json) => {
		document.getElementById("containerImages").innerHTML = "";
        if (!json.success) {
            Swal.fire({
                icon: 'error',
                confirmButtonColor: '#572364',
                text: json.error,
                footer: json.data.footeer
            })
        }
        var idBranch = document.getElementById("filter").value;
        if (idBranch != "-1") {
            requestPromotionsByFilterBranch();
        } else {
            buildPromotionsOnloadAferPost(json.data.recoverData);
        }        
    });
}

