var formDataSeach = new FormData();
function searchPromotions() {
    formDataSeach.delete("valueSearch");
    var value = document.getElementById("inputSearch").value    
    formDataSeach.append("valueSearch", value);
    post('Handlers/OnkeyupSearchController.aspx?action=byCharacteres', formDataSeach, json => {
        buildPromotionsOnloadAferPost(json.data.recoverDara);
    })
}