﻿function fullSelecteds() {
    
    if (document.getElementById("checkSelector") != undefined) {
        var checkSelector = document.getElementById("checkSelector")
        var checkboxes = document.getElementsByClassName("checkBoxP");
        var arrayCheck = Array.from(checkboxes)
        arrayCheck.map((check) => {

            check.checked = checkSelector.checked ? true : false
        });
    }    
}

function fullVisiblesOnload() {
    if (document.getElementById("selectorVisible") != undefined) {
        var checkVisible = document.getElementById("selectorVisible");

        var checkboxesVisibles = document.getElementsByClassName("checkBoxVB");
        var arrayCheckVisibles = Array.from(checkboxesVisibles)
        arrayCheckVisibles.map((check) => {
            check.checked = checkVisible.checked ? true : false
        });
    }
}

function fullVisiblesUpload() {
    if (document.getElementById("selectorVisibleUpload") != undefined) {
        var checkVisible = document.getElementById("selectorVisibleUpload");

        var checkboxesVisibles = document.getElementsByClassName("checkBoxVUP");
        var arrayCheckVisibles = Array.from(checkboxesVisibles)
        arrayCheckVisibles.map((check) => {
            check.checked = checkVisible.checked ? true : false
        });
    }
}