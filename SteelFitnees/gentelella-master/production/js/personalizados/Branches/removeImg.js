function remremoveImag(i) {    
    var inputImage = document.getElementById("image" + i);
    inputImage.setAttribute('data-image-uploadAut' + i, "");
    document.getElementById("divImage" + i).innerHTML = ""

}