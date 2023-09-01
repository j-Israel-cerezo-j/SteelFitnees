function requestPromotions() {
    request(json => {
        var html = "";
        json.forEach(item => {
            html += `
            <div class="col-lg-4">
                <div class="ts-item set-bg" data-setbg="${item.img}">
                    <div class="ts_text">
                        <h4>Athart Rachel</h4>
                        <span>Gym Trainer</span>
                    </div>
                </div>
            </div>
          `
        });
        document.getElementById("containerPromotions").innerHTML = html;
    }, 'Handlers/promotionsController.aspx?meth=promotionByBranchOrVisibility&visivility=1', true);
}

