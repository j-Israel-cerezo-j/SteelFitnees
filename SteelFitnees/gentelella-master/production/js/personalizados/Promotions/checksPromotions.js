function fullSelecteds() {
    
    if (document.getElementById("checkSelector") != undefined) {
        var checkSelector = document.getElementById("checkSelector")
        var checkboxes = document.getElementsByClassName("checkBoxP");
        var arrayCheck = Array.from(checkboxes)
        arrayCheck.map((check) => {
            check.checked = checkSelector.checked;
            if (checkSelector.checked) {
                check.classList.add("checkRedBGRRed")
                checkSelector.classList.add("checkRedBGRRed")
            } else {
                check.classList.remove("checkRedBGRRed")
                checkSelector.classList.remove("checkRedBGRRed")
            }
        });

        if (checkSelector.checked) {
            checkSelector.classList.add("checkRedBGRRed")
        } else {
            checkSelector.classList.remove("checkRedBGRRed")
        }
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
            if (checkAllBranch.checked) {
                checkItem.classList.add("checkRedBGRGreen")
                checkAllBranch.classList.add("checkRedBGRGreen")
            } else {
                checkItem.classList.remove("checkRedBGRGreen")
                checkAllBranch.classList.remove("checkRedBGRGreen")
            }
        })         
    }
}

function addClassColorCheckBox(check,classs) {
    if (check.checked) {
        check.classList.add(classs)
    } else {
        check.classList.remove(classs)
    }
}