function requestProductBySearchQueyString(id, characters) {
    console.log(characters)
    if (id != -1 && id!=0) {
        document.getElementById("branches").value = id
        document.getElementById("exampleDataList").value = characters;
        onkeyupSearchh();
        document.getElementById("exampleDataList").value = "";
    }
}