
 async function buildCardsBranches(json) {
    document.getElementById("team").innerHTML = "";
     var ban = false;    

    var html = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;
            const commentsSize = await requestCountCommentsByBranche(json[i].idSucursal);
            const textComments = commentsSize > 1 ||commentsSize ==0? " Comentarios" :" Comentario"
            html += `
                    <div class="col-lg-4 col-md-6 col-sm-8 col-xsm-12">
                        <div style="display: block;border-top-left-radius: 20px;border-top-right-radius: 20px;" class="scrollable-div" id="msjToolTipId${json[i].idSucursal}"></div>
                        <div class="blog-item">
                            <img src="${json[i].path}" alt="" height="230" width="500">
                            <div class="bi-text">
                                <h5><a href="showBranchesDetails.aspx?id=${json[i].idSucursal}">${json[i].nombre}.</a></h5>
                                <ul>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <li>
                                                <h4 data-id=${ json[i].idSucursal} style="color:red" id="msjOpening${json[i].idSucursal}">Cerrado</h4>
                                            </li>
                                        </div>
                                        <div class="col-lg-8">
                                            <li><h5 style="color: white;margin-top:5px" id="msjSheduleCards${json[i].idSucursal}">Hoy no abre</h5></li>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6" style="text-align: start;" id="iconCommentShow${json[i].idSucursal}">
                                            <li style="font-size:0.8rem" onclick="requestCommentsByBranche(${json[i].idSucursal})">${commentsSize}${textComments} </li>
                                        </div>
                                        <div class="col-lg-6" style="text-align: start;display:none;" id="iconCommentHide${json[i].idSucursal}">
                                            <li style="font-size:0.9rem" onclick="hideTooltip(${json[i].idSucursal})">${commentsSize}${textComments} </li>
                                        </div>
                                    </div>
                                </ul>
                                <p>${json[i].ubicacion}</p>
                            </div>
                        </div>                   
                    </div>
                       `  
        }
    }
    if (ban) {
        document.getElementById("team").innerHTML = html
        buildOpeningBranches();
    }

}
