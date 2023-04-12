function buildValores(json) {
    console.log(json)
    document.getElementById("containerValores").innerHTML = ""

    var ban = false;
    var htmlValores = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;          
            htmlValores +=
                        `
                           <li style="font-size:25px;"><strong>-${json[i]}</strong></li>
                        `;          
        }
    }
    if (ban) {
        document.getElementById("containerValores").innerHTML = htmlValores

    } else {
        document.getElementById("containerCardsProducts").innerHTML = `<h2 style="text-align:center">Sin productos por el momento</h2>`
    }
}