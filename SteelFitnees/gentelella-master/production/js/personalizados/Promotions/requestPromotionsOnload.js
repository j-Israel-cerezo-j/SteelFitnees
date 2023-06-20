function requestPromotionsOnload() { 
    request(buildPromotionsOnloadAferPost, 'Handlers/promotionsController.aspx?meth=get', true);
}