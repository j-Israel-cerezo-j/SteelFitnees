function addUrlReturn() {
    var url = document.getElementById("urlPrev").value;
    var btnReturn = document.querySelector("#return");
    btnReturn.href = url;
}