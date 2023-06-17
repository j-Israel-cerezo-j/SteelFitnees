function requestPromotionsByFilterBranch() {
    var idBranch = document.getElementById("filter").value;
    request(buildPromotionsOnloadAferPost, 'Handlers/promotionsController.aspx?meth=promotionByBranch&id=' + idBranch, true);
}