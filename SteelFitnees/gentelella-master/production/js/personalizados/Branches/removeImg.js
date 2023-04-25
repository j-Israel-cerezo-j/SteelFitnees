function remremoveImag(i, fileName) {
    document.getElementById("divImage" + i).innerHTML = ""
    removeFile(fileName)
}