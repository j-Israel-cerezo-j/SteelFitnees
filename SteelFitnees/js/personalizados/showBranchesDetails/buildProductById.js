function buildProductById(json) {        
    document.getElementById("containerProducts").innerHTML = ""    

    var ban = false;    
    var htmlProducts = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;                            
            htmlProducts +=
                `<div class="col-lg-3 col-md-3 col-sm-3 col-xsm-3" style="text-align: center;">
                    <div class="single-team mb-30">
                        <div class="team-img">
                            <img src="${json[i].imagen}" alt="" width="1" height="300" style="width:90%">
                            <div class="team-caption">
                                <h3><a >${json[i].producto}</a></h3>
                                <!-- Blog Social -->
                            </div>
                        </div>
                    </div>
                </div>`
            if (i == 2) {
                break;
            }
        }        
    }
    if (ban) {
        document.getElementById("containerProducts").innerHTML = htmlProducts

    } else {
        document.getElementById("containerProducts").innerHTML = `<h1>Sin productos por el momento</h1>`
    }
}