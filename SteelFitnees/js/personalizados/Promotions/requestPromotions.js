function requestPromotionsByFilterBranchAndVisibilityOrNone() {
    var slcFilterBranch = document.getElementById("filter")
    var idBranch = slcFilterBranch.value;
    var visibiliti = document.getElementById("filterVisivility").value;
    var nameBranch = slcFilterBranch.options[slcFilterBranch.selectedIndex].innerText;

    if (idBranch != "-1" && visibiliti == "-1") {
        if (idBranch == "-2") {
            document.getElementById("stateFilter").innerText="Estado del filtro: Promociones sin asignación de sucursal"
            request(buildPromotionsOnloadAferPost, 'Handlers/promotionsController.aspx?meth=promotionNoBranch', true);
        } else {
            document.getElementById("stateFilter").innerText = "Estado del filtro: Promociones de las sucursal " + nameBranch
            request(buildPromotionsOnloadAferPost, 'Handlers/promotionsController.aspx?meth=promotionByBranchOrVisibility&id=' + idBranch, true);
        }
    } else if (visibiliti != "-1" && idBranch == "-1") {
        document.getElementById("stateFilter").innerText = visibiliti == "1" ? "Estado del filtro: Todas las promociones visibles" : "Estado del filtro: Todas las promociones no visibles"
        request(buildPromotionsOnloadAferPost, 'Handlers/promotionsController.aspx?meth=promotionByBranchOrVisibility&visivility=' + visibiliti, true);
    } else if (visibiliti != "-1" && idBranch != "-1") {
        document.getElementById("stateFilter").innerText = visibiliti == "1" ? "Estado del filtro: Todas las promociones visibles de la sucursal " + nameBranch : "Estado del filtro: Todas las promociones no visibles de la sucursal " + nameBranch
        request(buildPromotionsOnloadAferPost, 'Handlers/promotionsController.aspx?meth=promotionByBranchOrVisibility&id=' + idBranch +'&visivility=' + visibiliti, true);
    }
}