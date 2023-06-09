﻿function buildAllProduct(json, jsonOnkeyp = true) {    
    document.getElementById("containerCardsProducts").innerHTML = ""

    var ban = false;
    var htmlProducts = "";
    if (json != undefined) {
        
        for (var i = 0; i < json.length; i++) {
            ban = true;
            var precioF = parseFloat(json[i].precio).toFixed(2)
            htmlProducts +=
                `              
                    <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 col-xsm-6 cardsBranche" style="margin:5px">
                        <div class="home-blog-single">
                            <div class="blog-img-cap">
                                <div class="blog-img" style="padding:25px">
                                    <img src="${json[i].imagen}" alt="" width="300" height="250">
                                    <!-- Blog date -->
                                    <div class="blog-date text-center" style="padding:10px">
                                        <span>$ ${precioF}</span>
                                    </div>
                                </div>
                                <div style="padding:8px">
                                    <h4><a style="font-size: 15px;" href="showBranchesDetails.aspx?id=${json[i].idSucursal}" >Suc:  ${json[i].nombreSuc}</a></h4>
                                    <h6><a style="font-size: 13px;" >${json[i].nombreProduc}</a></h6>
                                    <p style="font-size: 13px;">${json[i].descriptProduct}</p>
                                </div>
                            </div>
                        </div>
                    </div>`
        }
    }
    if (ban) {
        document.getElementById("containerCardsProducts").innerHTML = htmlProducts

    } else if (!jsonOnkeyp) {
        document.getElementById("containerCardsProducts").innerHTML = "<h4 style='margin-bottom:100px' class='text-center'>Lo siento,el producto buscado no se encuentra en la sucursal en estos momentos,pero dejanoslo saber en los comentarios en la parte de sucursales <a style='color:#0d6efd' href='showBranchesDetails.aspx?id=" + id + "'>Da click aqui para ir a la sucursal y dejar tu comentario (en la parte de abajo de la pagina)</a> y lo tendremos en cuenta. Gracias</h4>"
    } else {
        document.getElementById("containerCardsProducts").innerHTML = `<h2 style="text-align:center">Sin productos por el momento</h2>`
    }
}