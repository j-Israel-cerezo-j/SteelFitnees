function buildCardsBranches(json) {
    document.getElementById("team").innerHTML = "";
    var ban = false;    
    var html = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;
            html += `<div class="col-lg-4 col-md-4 col-sm-12 col-xsm-4 cardsBranche">
                        <div class="mb-3 mt-4" style="max-width: 540px;height:100%">
                            <div class="row g-0">
                                <div class="col-md-4">
                                    <img src="${json[i].path}" style="height: 50%;width: 100%;" class="reflejo img-fluid rounded-start" alt="...">
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h5 class="card-title">${json[i].nombre}</h5>
                                        <p class="card-text"><small class="text-muted">${json[i].ubicacion}</small></p>
                                        <a href="showBranchesDetails.aspx?id=${json[i].idSucursal}" class="btn btn-primary reflejo" id="btnIrSucursal">Visitar sucursal</a>                                        
                                    </div>
                                </div>
                            </div>
                        </div>    
                    </div>  `  
        }
    }
    if (ban) {
        document.getElementById("team").innerHTML = html
    }

}