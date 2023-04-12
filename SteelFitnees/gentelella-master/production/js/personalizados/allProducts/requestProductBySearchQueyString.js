function requestProductBySearchQueyString(characters) {
    if (characters != "" && characters != null) {
        document.getElementById("exampleDataList").value = characters;
        onkeyupSearchh();
        document.getElementById("exampleDataList").value = "";
    }
}