function cleanFilter() {
    requestPromotionsOnload();    
}

function cleanFull() {
    document.getElementById("form1").reset();
    var checkVisible = document.getElementById("selectorVisible");
    var checkVisibleUpload = document.getElementById("selectorVisibleUpload");
    var checkSelector = document.getElementById("checkSelector");
    document.getElementById("filter").value = "-1"
    checkVisible.checked = false;
    checkVisibleUpload.checked = false;
    checkSelector.checked = false;
    document.getElementById("containerImagesUpload").innerHTML = ""

    resetArrayFiles();
    buildMsjPromotionsUpload();
}