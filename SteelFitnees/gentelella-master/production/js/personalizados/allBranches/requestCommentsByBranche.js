
function requestCommentsByBranche(id) {
    var iconCommentShow = document.getElementById("iconCommentShow" + id);
    iconCommentShow.style.display = "none";

    var iconCommentHide = document.getElementById("iconCommentHide" + id);
    iconCommentHide.style.display = "block";

    request(resp => {
        var htmlComments = `<div style="padding: 15px"> <b style="color:black;">Comentarios de nuestros clientes: </b>`;
        var ban = false;
        resp.forEach(item => {
            ban = true;
            htmlComments += `
                <p style="margin-bottom: 0px;">
                        <small class="text-muted">${item.commentDate}</small>
                </p>
                <p style="color:black;" class="card-text" style="margin-bottom: 0px;">                        
                    "${item.comment}"
                </p>
                <div class="linea"></div>`
        });

        if (ban) {

            var idBranch = resp[0].fkBranche;
            htmlComments += `</div>`
            document.getElementById("msjToolTipId" + idBranch).innerHTML = htmlComments;
        } else {
            document.getElementById("msjToolTipId" + id).innerHTML = `<p style="color:black;" class="card-text" style="margin-bottom: 0px;">Sin comentarios aún</p>`;
        }
    }, 'Handlers/sucursalesController.aspx?meth=commentsByBranche&id=' + id, false); 

    var tooltip = document.getElementById("msjToolTipId" + id);
    tooltip.style.display = "block";
}

function hideTooltip(id) {
    var iconCommentShow = document.getElementById("iconCommentShow" + id);
    iconCommentShow.style.display = "block";

    var iconCommentHide = document.getElementById("iconCommentHide" + id);
    iconCommentHide.style.display = "none";


    var tooltip = document.getElementById("msjToolTipId"+id);
    tooltip.style.display = "none";
}




function requestCountCommentsByBranche(id) {
    return new Promise((resolve, reject) => {
        request(resp => {
            resolve(resp.length);
        }, 'Handlers/sucursalesController.aspx?meth=commentsByBranche&id=' + id, false);
    });
}

