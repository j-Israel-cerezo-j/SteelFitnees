function iniRange(json) {
    var precioMax = parseInt(json[0].precio);
    var precioMin = parseInt(json[0].precio);
    for (var i = 0; i < json.length; i++) {
        if (precioMax < parseInt(json[i].precio)) {
            precioMax = parseInt(json[i].precio)
        }
        if (precioMin >= parseInt(json[i].precio)) {
            precioMin = parseInt(json[i].precio)
        }
    }
    const rangeInput = document.querySelectorAll(".range-input input"),
        range = document.querySelector(".slider .progress");
   
    rangeInput[0].max = precioMax;
    rangeInput[0].min = precioMin;

    rangeInput[1].max = precioMax;
    rangeInput[1].min = precioMin;

    rangeInput[0].value = precioMin;
    rangeInput[1].value = precioMax;

    document.getElementById("max").value = precioMax
    document.getElementById("min").value = precioMin

    range.style.left = ((precioMin / rangeInput[0].max) * 100) + "%";
    range.style.right = 100 - (precioMax / rangeInput[1].max) * 100 + "%";
}
