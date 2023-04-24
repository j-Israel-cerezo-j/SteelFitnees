function buildProductById(json, jsonOnkeyp = true) {
    document.getElementById("containerCardsProducts").innerHTML = ""

    var ban = false;
    var htmlProducts = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;
            var precioF = parseFloat(json[i].precio).toFixed(2)
            htmlProducts +=
                `              
                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-xsm-6">
                        <div class="home-blog-single mb-30">
                            <div class="blog-img-cap">
                                <div class="blog-img">
                                    <img src="${json[i].imagen}" alt="" width="10" height="300">
                                    <!-- Blog date -->
                                    <div class="blog-date text-center">
                                        <span>$ ${precioF}</span>
                                    </div>
                                </div>
                                <div class="blog-cap">
                                    <h5><a >${json[i].producto}</a></h5>
                                    <p>${json[i].Descripcion}</p>
                                </div>
                            </div>
                        </div>
                    </div>`
           
        }
    }
    if (ban) {
        document.getElementById("containerCardsProducts").innerHTML = htmlProducts

    } else if (!jsonOnkeyp) {
        var id = document.getElementById("branches").value
        document.getElementById("containerCardsProducts").innerHTML = "<h4 style='margin-bottom:100px' class='text-center'>Lo siento,el producto buscado no se encuentra en la sucursal en estos momentos,pero dejanoslo saber en los comentarios en la parte de sucursales <a style='color:#0d6efd' href='showBranchesDetails.aspx?id="+id+"'>Da click aqui para ir a la sucursal y dejar tu comentario (en la parte de abajo de la pagina)</a> y lo tendremos en cuenta. Gracias</h4>"
    } else {
        document.getElementById("containerCardsProducts").innerHTML = `<h2 style="text-align:center">Sin productos por el momento</h2>`
    }
}