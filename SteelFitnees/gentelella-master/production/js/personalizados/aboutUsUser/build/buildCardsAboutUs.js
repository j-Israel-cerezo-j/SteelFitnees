function buildCardsAboutUs(json) {    
    document.getElementById("containerVision").innerHTML = ""
    document.getElementById("containerMision").innerHTML = ""

    var ban = false;
    var htmlMision = "";
    var htmlVision = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;
            htmlMision +=
                `
                    <div class="col-md-4">
							<img src="images/perzonalizadas/aboutUs/misongym.png" alt="" width="150" height="150" class="img-fluid">
						</div>
						<div class="col-md-8 mt-sm-20">
							<p style="font-size: 20px;">${json[i].mision}</p>
						</div>
                 `
            htmlVision += `
                        <div class="col-md-8">
							<p style="font-size: 20px;">${json[i].vision} </p>
						</div>
						<div class="col-md-4">
							<img src="images/perzonalizadas/aboutUs/misongym.png" alt="" width="150" height="150" class="img-fluid">
						</div>`;           
            if (i == 1) {
                break;
            }
        }
    }
    if (ban) {
        document.getElementById("containerVision").innerHTML = htmlVision
        document.getElementById("containerMision").innerHTML = htmlMision

    } else {
        document.getElementById("containerCardsProducts").innerHTML = `<h2 style="text-align:center">Sin productos por el momento</h2>`
    }
}