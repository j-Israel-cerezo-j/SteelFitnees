function requestPromotionsByFilterBranch() {
    var idBranch = document.getElementById("filter").value;
    if (idBranch!="-1") {
        if (idBranch == "-2") {
            request(buildPromotionsOnloadAferPost, 'Handlers/promotionsController.aspx?meth=promotionNoBranch', true);
        } else {
            request(buildPromotionsOnloadAferPost, 'Handlers/promotionsController.aspx?meth=promotionByBranch&id=' + idBranch, true);
        }    
    }    
}