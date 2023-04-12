function requestBranches() {
    request(buildCardsBranches, 'Handlers/sucursalesController.aspx?meth=si',false);
}