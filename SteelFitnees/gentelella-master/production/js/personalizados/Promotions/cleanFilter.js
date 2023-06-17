function cleanFilter() {
    var checkVisible = document.getElementById("selectorVisible");
    var checkSelector = document.getElementById("checkSelector");

    checkVisible.checked = false;
    checkSelector.checked = false;

    requestPromotionsOnload();
}