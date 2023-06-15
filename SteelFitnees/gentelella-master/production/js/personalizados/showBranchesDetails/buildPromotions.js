function buildPromotions(json) {
    var html = "";
    json.forEach(item => {
        html += `<div class="slide2">
                <img src="${item.img}" height="300" width="250" alt="" />
            </div>`
    });
    document.getElementById("containerPromotions").innerHTML = html;
}