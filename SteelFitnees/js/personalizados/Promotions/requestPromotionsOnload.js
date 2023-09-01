function requestPromotionsOnload() { 
    loadingBlock('.loader');
    request(buildPromotionsOnloadAferPost, 'Handlers/promotionsController.aspx?meth=get', false);
}