 async function buildCardsBranches(json) {
    document.getElementById("team").innerHTML = "";
     var ban = false;    

    var html = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;
            const commentsSize = await requestCountCommentsByBranche(json[i].idSucursal);
            html += `                                            
                        <div class="col-lg-4 col-md-6 col-sm-6 col-xsm-6 cardsBranche">
                            <div class="tooltip-container">
                                <div class="scrollable-div" id="msjToolTipId${json[i].idSucursal}"></div>
                                <div class="tooltip-trigger">
                                    <div class="mb-3 mt-4">
                                        <div class="row g-0">
                                            <div class="col-md-4">
                                                <img src="${json[i].path}" class="reflejo img-fluid rounded-start" alt="...">
                                            </div>
                                            <div class="col-md-8">
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-10">
                                                            <h5 class="card-title">${json[i].nombre}</h5>
                                                        </div>
                                                        <div class="col-2" data-toggle="tooltip" data-placement="top" title="Da click para ver los comentarios de la sucursal">
                                                            <div style="text-align: right;" id="iconCommentShow${json[i].idSucursal}">
                                                                <svg style="cursor: pointer;" xmlns="http://www.w3.org/2000/svg" onclick="requestCommentsByBranche(${json[i].idSucursal})" width="25" height="25" fill="currentColor" class="bi bi-chat-dots" viewBox="0 0 16 16">
                                                                    <path d="m2.165 15.803.02-.004c1.83-.363 2.948-.842 3.468-1.105A9.06 9.06 0 0 0 8 15c4.418 0 8-3.134 8-7s-3.582-7-8-7-8 3.134-8 7c0 1.76.743 3.37 1.97 4.6a10.437 10.437 0 0 1-.524 2.318l-.003.011a10.722 10.722 0 0 1-.244.637c-.079.186.074.394.273.362a21.673 21.673 0 0 0 .693-.125zm.8-3.108a1 1 0 0 0-.287-.801C1.618 10.83 1 9.468 1 8c0-3.192 3.004-6 7-6s7 2.808 7 6c0 3.193-3.004 6-7 6a8.06 8.06 0 0 1-2.088-.272 1 1 0 0 0-.711.074c-.387.196-1.24.57-2.634.893a10.97 10.97 0 0 0 .398-2z"/>
                                                                    <text style="color:black" x="8" y="12" font-size="11" fill="black" text-anchor="middle">${commentsSize}</text>
                                                                </svg>
                                                            </div>
                                                            <div style="text-align: right;display:none" id="iconCommentHide${json[i].idSucursal}">
                                                                <svg style="cursor: pointer;" xmlns="http://www.w3.org/2000/svg" onclick="hideTooltip(${json[i].idSucursal})" width="25" height="25" fill="currentColor" class="bi bi-chat-dots" viewBox="0 0 16 16">
                                                                    <path d="m2.165 15.803.02-.004c1.83-.363 2.948-.842 3.468-1.105A9.06 9.06 0 0 0 8 15c4.418 0 8-3.134 8-7s-3.582-7-8-7-8 3.134-8 7c0 1.76.743 3.37 1.97 4.6a10.437 10.437 0 0 1-.524 2.318l-.003.011a10.722 10.722 0 0 1-.244.637c-.079.186.074.394.273.362a21.673 21.673 0 0 0 .693-.125zm.8-3.108a1 1 0 0 0-.287-.801C1.618 10.83 1 9.468 1 8c0-3.192 3.004-6 7-6s7 2.808 7 6c0 3.193-3.004 6-7 6a8.06 8.06 0 0 1-2.088-.272 1 1 0 0 0-.711.074c-.387.196-1.24.57-2.634.893a10.97 10.97 0 0 0 .398-2z"/>
                                                                    <text style="color:black" x="8" y="12" font-size="11" fill="black" text-anchor="middle">${commentsSize}</text>
                                                                </svg>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <b data-id=${ json[i].idSucursal} style="color:red" id="msjOpening${json[i].idSucursal}">Cerrado</b>
                                                    <small class="ml-5" id="msjSheduleCards${json[i].idSucursal}">Hoy no abre</small>
                                                    <p class="card-text"><small class="text-muted">${json[i].ubicacion}</small></p>
                                                    <a href="showBranchesDetails.aspx?id=${json[i].idSucursal}" class="btn btn-primary reflejo" id="btnIrSucursal">Visitar sucursal</a>                                        
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>`  
        }
    }
    if (ban) {
        document.getElementById("team").innerHTML = html
        buildOpeningBranches();
    }

}