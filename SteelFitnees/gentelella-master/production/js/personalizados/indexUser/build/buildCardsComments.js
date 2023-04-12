function buildCardsComments(json, jsonOnkeyp = true) {
    document.getElementById("containerCardsComments").innerHTML = "";
    document.getElementById("carouselExampleDark").innerHTML = "";
    
    var ban = false;
    var html = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;
            html += `<div class="col-lg-4 col-md-4 col-sm-12 col-xsm-4 mt-3">
                        <div class="card mb-3" style="max-width: 540px;height:100%">
                            <div class="row g-0">
                                <div class="row mt-3">
                                    <div class="col-md-12 col-lg-12">
                                        <h6 style="text-align: center" class="text-muted card-text">${json[i].commentDate}</h6>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 col-lg-12">
                                        <div class="card-body">
                                            <h6 class="text-muted card-text">${json[i].comment}</h6>
                                        </div>
                                    </div>
                                </div>                                
                            </div>
                        </div>    
                    </div>  `
        }
    }
    if (ban) {
        document.getElementById("containerCardsComments").innerHTML = html
        document.getElementById("containerSlcWeeks").style.display = "block";
        buildWeeks()
    }
    else if (!jsonOnkeyp) {
        document.getElementById("containerCardsComments").innerHTML = "<h4 class='text-center'>No se encontro ninguna coincidencia</h4>"
    }
    else {
        document.getElementById("containerCardsComments").innerHTML = `<h1 style="text-align: center;margin-top:40px">Sin comentarios por el momento</h1>`
    }
}