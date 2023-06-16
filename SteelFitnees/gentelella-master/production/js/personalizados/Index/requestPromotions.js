function requestPromotions() {
    request(json => {
        var html = "";
        json.forEach(item => {
            html += `
            <div class="slide">
	    		<img src="${item.img}" height="100" width="250" alt="" />
	    	</div>`
        });
        document.getElementById("containerPromotions").innerHTML = html;
    }, 'Handlers/promotionsController.aspx?meth=getPromotionsVisible', true);
}
