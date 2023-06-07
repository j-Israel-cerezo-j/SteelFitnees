function addPromotion(formData) {
    post('Handlers/promotionsController.aspx?meth=add', formData, (json) => {
        console.log(json)
    });
}