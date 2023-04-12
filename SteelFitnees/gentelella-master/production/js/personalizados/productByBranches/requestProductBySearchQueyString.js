function requestProductBySearchQueyString(id) {
    if (id != -1 && id!=0) {
        document.getElementById("branches").value = id
        buildProductsByBranche()
    }
}