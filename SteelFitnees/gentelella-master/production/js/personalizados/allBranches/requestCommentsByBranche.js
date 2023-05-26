
var commentsByBrancheArray=[]
function requestCommentsByBranche(element, event) {    
    var idBranche = event.target.dataset.id
    var idElement = element.id;
    
    //if (commentsByBrancheArray.length == 0) {
    //    console.log("entre")
    //    const request = fetch('Handlers/sucursalesController.aspx?meth=commentsByBranche&id=' + idBranche)       
    //    request
    //        .then(resp => resp.json())
    //        .then(resp => {
    //            resp.data.recoverData.forEach(item => {
    //                commentsByBrancheArray.push(item)
    //            })


    //        })
    //}

    //var comments = " ";
    //commentsByBrancheArray.forEach(item => {
    //    comments += `<span>${item.comment}</span>`
    //})
    $("#cardBranch" + idBranche).tooltip();

    $("#cardBranch" + idBranche).attr('data-html', true);
    $("#cardBranch" + idBranche).attr('title', '<span>Hola</span>');
        

    // Volver a inicializar el tooltip
    $("#cardBranch" + idBranche).tooltip('show');

}