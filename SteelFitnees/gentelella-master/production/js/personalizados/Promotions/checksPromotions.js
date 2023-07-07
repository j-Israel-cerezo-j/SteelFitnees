function fullSelecteds() {
    
    if (document.getElementById("checkSelector") != undefined) {
        var checkSelector = document.getElementById("checkSelector")
        var checkboxes = document.getElementsByClassName("checkBoxP");
        var arrayCheck = Array.from(checkboxes)
        arrayCheck.map((check) => {

            check.checked = checkSelector.checked;
        });
    }    
}

function fullVisiblesOnload() {
    if (document.getElementById("selectorVisible") != undefined) {
        var checkVisible = document.getElementById("selectorVisible");

        var checkboxesVisibles = document.getElementsByClassName("checkBoxVB");
        var arrayCheckVisibles = Array.from(checkboxesVisibles)
        arrayCheckVisibles.map((check) => {
            check.checked = checkVisible.checked;
        });
    }
}

function fullVisiblesUpload() {
    if (document.getElementById("selectorVisibleUpload") != undefined) {
        var checkVisible = document.getElementById("selectorVisibleUpload");

        var checkboxesVisibles = document.getElementsByClassName("checkBoxVUP");
        var arrayCheckVisibles = Array.from(checkboxesVisibles)
        arrayCheckVisibles.map((check) => {
            check.checked = checkVisible.checked;
        });
    }
}

function allBranchesCheks(idDivBranches) {
    if (document.getElementById("checkAllBranch" + idDivBranches.id) != undefined) {
        var checkAllBranch = document.getElementById("checkAllBranch" + idDivBranches.id)
        var divCheckBoxesBranches = document.getElementById(idDivBranches.id).querySelectorAll('input[type="checkbox"]')
        var checkBoxBranchArray = Array.from(divCheckBoxesBranches)
        checkBoxBranchArray.forEach(checkItem => {
            checkItem.checked = checkAllBranch.checked;
        })         
    }
}
