function cleanFilter() {

    document.getElementById("form1").reset();
    var checkVisible = document.getElementById("selectorVisible");
    var checkSelector = document.getElementById("checkSelector");
    document.getElementById("filter").value="-1"
    checkVisible.checked = false;
    checkSelector.checked = false;
    document.getElementById("lengthPromotionsRecentUpload").innerText = "Promociones recien subidas: (0)";
    requestPromotionsOnload();
}